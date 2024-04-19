using EventHub.Exceptions;
using EventHub.Infrastructure.Entities;
using EventHub.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EventHub.Application.Repositories
{
    public interface ICheckInRepository
    {
        Task<CheckIn> GetByIdAsync(Guid id);
        Task<CheckIn> CreateCheckInAsync(Guid eventId, Guid userId);
        Task DeleteCheckInAsync(Guid id);
    }

    public class CheckInRepository : ICheckInRepository
    {
        private readonly EventHubDBContext _context;

        public CheckInRepository(EventHubDBContext eventHubDBContext)
        {
            _context = eventHubDBContext;
        }
        public async Task<CheckIn> CreateCheckInAsync(Guid eventId, Guid userId)
        {
            var userExists = await _context.Account.FirstOrDefaultAsync(ac => ac.ID_Account == userId);
            var eventExists = await _context.Event.FirstOrDefaultAsync(evnt => evnt.ID_Event == eventId);
            if (userExists is null)
            {
                throw new NotFoundException("User not found.");
            }
            if (eventExists is null)
            {
                throw new ConflictErrorException("Event not found.");
            }
            CheckIn attendee = new()
            {
                ID_Account = userId,
                ID_Event = eventId,
            };
            // Atribuir o ID do usuário como criador do evento
            eventExists.checkIns.Add(attendee);
            // Adicionar o evento ao contexto e salvar as mudanças
            await _context.SaveChangesAsync();
            return attendee;

        }

        public async Task DeleteCheckInAsync(Guid id)
        {
            var checkin = _context.CheckIn.FirstOrDefault(checkin => checkin.ID_CheckIn == id);
            if (checkin is null)
            {
                throw new NotFoundException("there is no any Checkin with the provided id.");
            }
            _context.CheckIn.Remove(checkin);
            await _context.SaveChangesAsync();

        }

     

        public async Task<CheckIn> GetByIdAsync(Guid id)
        {
            var checkin = await _context.CheckIn.FirstOrDefaultAsync(checkin => checkin.ID_CheckIn == id);

            if (checkin is null)
            {
                throw new NotFoundException("there is no any Checkin with the provided id.");
            }
            return checkin;
        }

      
    }
}
