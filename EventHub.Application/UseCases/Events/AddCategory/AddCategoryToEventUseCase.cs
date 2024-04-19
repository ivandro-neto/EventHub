using EventHub.Application.Repositories;
using EventHub.Communication.Responses;
using EventHub.Exceptions;
using EventHub.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Application.UseCases
{
    public class AddCategoryToEventUseCase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IEventRepository _eventRepository;
        public AddCategoryToEventUseCase(IEventRepository eventRepository, ICategoryRepository categoryRepository)
        {
            _eventRepository = eventRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryAddedResponseJson> Execute(Guid eventId, string categoryName)
        {
            var eventEntity = await _eventRepository.GetByIdAsync(eventId);

            var categoryEntity = await _categoryRepository.GetByNameAsync(categoryName);

            // Adicionar a categoria ao evento
            eventEntity.EventCategories.Add(new EventCategory 
            {
                ID_Event = eventId,
                ID_Category = categoryEntity.ID_Category,
                Category = categoryEntity,
            });

            await _eventRepository.UpdateEventAsync(eventId, eventEntity); // Certifique-se de implementar o método Update no seu repositório de eventos

            return new CategoryAddedResponseJson
            { 
               EventId = eventId,
               CategoryId = categoryEntity.ID_Category,
               CategoryName = categoryEntity.Name,
            };
        }
    }
}
