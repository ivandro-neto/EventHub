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
    public class GetAllEventsUseCase
    {
        private readonly IEventRepository _repository;
        public GetAllEventsUseCase(IEventRepository eventRepository)
        {
            _repository = eventRepository;
        }

        public async Task<List<EventResponseJson>> Execute(Guid? category)
        {
            var events = await _repository.GetAllAsync();

            if(category.HasValue)
            {
                events = events.Where(e => e.EventCategories.Any(ec => ec.ID_Category == category.Value)).ToList();
            }

            return events.Select(evnt => new EventResponseJson()
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
                EventCategories = evnt.EventCategories,
                Status = evnt.Status,
                CreatorID = evnt.CreatorID,
            }).ToList();
        }
    }
}
