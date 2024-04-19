using EventHub.Infrastructure;
using EventHub.Infrastructure.Entities;
using EventHub.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace EventHub.Application.Repositories
{
    public interface ICategoryRepository
    {
        Task<ICollection<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(Guid id);
        Task<Category> GetByNameAsync(string name);
        Task AddCategoryAsync(Category category);
        Task<EventCategory>AddEventCategoryAsync(EventCategory eventCategory);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(Guid id);
        Task DeleteByNameAsync(string name);
    }
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EventHubDBContext _context;
        public CategoryRepository(EventHubDBContext eventHubDBContext)
        {
            _context = eventHubDBContext;
        }
        public async Task AddCategoryAsync(Category category)
        {
            var categoryExits = await _context.Category.FirstOrDefaultAsync(attributes => attributes.Name == category.Name);
            if(categoryExits is not null)
            {
                throw new ConflictErrorException("There is a category with this name.");
            }

            await _context.Category.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task<EventCategory> AddEventCategoryAsync(EventCategory eventCategory)
        {
            var EventcategoryExits = await _context.Category.FindAsync(eventCategory.ID_EventCategory);
            if (EventcategoryExits is not null)
            {
                throw new ConflictErrorException("There is an event category with this Id.");
            }

            await _context.EventCategory.AddAsync(eventCategory);
            await _context.SaveChangesAsync();

            return eventCategory;
        }

        public async Task DeleteByNameAsync(string name)
        {
            var category = await _context.Category.FindAsync(name);
            if(category is null) 
            {
                throw new NotFoundException("There is no any category with this name.");
            }
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(Guid id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category is null)
            {
                throw new NotFoundException("There is no any category with this id.");
            }
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Category>> GetAllAsync()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(Guid id)
        {
            var category = await _context.Category.FirstOrDefaultAsync(attribute => attribute.ID_Category == id);
            if (category is null)
            {
                throw new NotFoundException("There is no any category with this id.");
            }
            return category;
        }

        public async Task<Category> GetByNameAsync(string name)
        {
            var category = await _context.Category.FirstOrDefaultAsync(attribute => attribute.Name == name);
            if (category is null)
            {
                throw new NotFoundException("There is no any category with this name.");
            }
            return category;
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            _context.Category.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}
