using EventHub.Application.Repositories;
using EventHub.Communication.Responses;
using EventHub.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Application.UseCases
{
    public class GetEventByIdUseCase
    {
        private readonly IEventRepository _repository;
        public GetEventByIdUseCase(IEventRepository eventRepository)
        {
            _repository = eventRepository;
        }

        public async Task<EventResponseJson> Execute(Guid id)
        {
            var evnt = await _repository.GetByIdAsync(id);
            return new EventResponseJson
            {
                ID_Event = evnt.ID_Event,
                Name = evnt.Name,
                Description = evnt.Description,
                Location = evnt.Location,
                StartDateTime = evnt.StartDateTime,
                EndDateTime = evnt.EndDateTime,
                Type = evnt.Type,
                Price = evnt.Price,
                Capacity = evnt.Capacity,
                Status = evnt.Status,
                CheckinAmount = evnt.checkIns.Where(check => check.State == "Active").ToList().Count,
                RegistedAmount = evnt.checkIns.Where(check => check.State == "Pendent").ToList().Count,
                CreatorID = evnt.CreatorID,
            };
        }
    }
}
