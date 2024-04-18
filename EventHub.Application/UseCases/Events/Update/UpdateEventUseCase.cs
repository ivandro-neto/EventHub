using EventHub.Application.Repositories;
using EventHub.Communication.Requests;
using EventHub.Communication.Responses;
using EventHub.Exceptions;
using EventHub.Infrastructure.Entities;

namespace EventHub.Application.UseCases
{
    public class UpdateEventUseCase
    {
        private readonly IEventRepository _repository;
        public UpdateEventUseCase(IEventRepository eventRepository)
        {
            _repository = eventRepository;
        }

        public async Task<EventCreatedResponseJson> Execute(Guid id, CreateEventRequestJson eventRequest)
        {
            Validate(eventRequest);
            Event evnt = new()
            {
                Name = eventRequest.Name,
                Description = eventRequest.Description,
                StartDateTime = eventRequest.StartDateTime,
                EndDateTime = eventRequest.EndDateTime,
                Location = eventRequest.Location,
                Price = eventRequest.Price,
                Type = eventRequest.Type,
                Capacity = eventRequest.Capacity,
                Status = eventRequest.Status,
            };
            await _repository.UpdateEventAsync(id, evnt);
            return new EventCreatedResponseJson
            {
                Id = id,
                Name = evnt.Name,
                CreatorID = evnt.CreatorID,
            };
        }

        private static void Validate(CreateEventRequestJson eventRequest)
        {
            if (eventRequest == null)
            {
                throw new NotFoundException("Must provide a valid event.");
            }
            if (string.IsNullOrWhiteSpace(eventRequest.Name))
            {
                throw new ErrorOnValidationException("Must provide a valid event name.");
            }
            if (string.IsNullOrWhiteSpace(eventRequest.Description))
            {
                throw new ArgumentException("Must provide a valid description.");
            }

        }
    }
}
