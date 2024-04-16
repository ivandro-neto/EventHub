using EventHub.Communication.Requests;
using EventHub.Infrastructure;
using EventHub.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventHub.Application.Repositories.Events
{
    public interface IEventRepository
    {
        Task<Event> GetByIdAsync(Guid id);
        Task<List<Event>> GetAllAsync();
        Task CreateEventAsync(Guid userId, Event input);
        Task UpdateEventAsync(Guid id, Event input);
        Task DeleteEventAsync(Guid id);
    }

    public class EventRepository : IEventRepository
    {
        private readonly EventHubDBContext _context;

        public EventRepository(EventHubDBContext eventHubDBContext)
        {
            _context = eventHubDBContext;
        }
        public async Task CreateEventAsync(Guid userId, Event input)
        {
            var userExists = await _context.Account.FirstOrDefaultAsync(ac => ac.ID_Account == userId);
            if (userExists is null)
            {
                throw new ArgumentNullException("User not found.");
            }

            // Atribuir o ID do usuário como criador do evento
            input.CreatorID = userId;
            input.Creator = userExists;
            userExists.CreatedEvents.Add(input);
            // Adicionar o evento ao contexto e salvar as mudanças
            await _context.SaveChangesAsync();

        }

        public async Task DeleteEventAsync(Guid id)
        {
            var evnt = _context.Event.FirstOrDefault(evnt => evnt.ID_Event == id);
            if (evnt is null)
            {
                throw new InvalidOperationException("");
            }
                _context.Event.Remove(evnt);
                await _context.SaveChangesAsync();

        }

        public async Task<List<Event>> GetAllAsync()
        {
            return await _context.Event.ToListAsync();
        }

        public async Task<Event> GetByIdAsync(Guid id)
        {
            var evnt = await _context.Event.FirstOrDefaultAsync(evnt => evnt.ID_Event == id);
            return evnt;
        }

        public async Task UpdateEventAsync(Guid id, Event input)
        {
            var evnt = await _context.Event.FirstOrDefaultAsync(e => e.ID_Event == id) ?? throw new InvalidOperationException("");
            evnt.Update(input.Name, input.Description, input.StartDateTime, input.EndDateTime, input.Location, input.Type, input.Price, input.Capacity, input.Status);

             await _context.SaveChangesAsync();
        }
    }
}
