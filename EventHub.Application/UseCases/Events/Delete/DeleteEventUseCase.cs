using EventHub.Application.Repositories.Events;
using EventHub.Communication.Requests;
using EventHub.Communication.Responses;
using EventHub.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Application.UseCases.Events
{
    public class DeleteEventUseCase
    {

        private readonly IEventRepository _repository;
        public DeleteEventUseCase(IEventRepository eventRepository)
        {
            _repository = eventRepository;
        }

        public async Task<EventCreatedResponseJson> Execute(Guid id)
        {
            var existEvent = await _repository.GetByIdAsync(id);
            await _repository.DeleteEventAsync(id);
            return new EventCreatedResponseJson
            {
                Id = id,
                Name = existEvent.Name,
                CreatorID = existEvent.CreatorID,
            };
        }
    }
}
