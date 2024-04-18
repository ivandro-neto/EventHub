using EventHub.Application.Repositories;
using EventHub.Communication.Requests;
using EventHub.Communication.Responses;
using EventHub.Exceptions;
using EventHub.Infrastructure.Entities;


namespace EventHub.Application.UseCases
{
    public class RegisterEventUseCase
    {
        private readonly IEventRepository _repository;
        public RegisterEventUseCase(IEventRepository eventRepository)
        {
            _repository = eventRepository;
        }

        public async Task<EventCreatedResponseJson> Execute(Guid userID, CreateEventRequestJson eventRequest)
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
                Capacity = eventRequest.Capacity
            };
            await _repository.CreateEventAsync(userID, evnt);
            return new EventCreatedResponseJson
            {
                Id = evnt.ID_Event,
                Name = evnt.Name,
                CreatorID = evnt.CreatorID,
            };
        }

        private static void Validate(CreateEventRequestJson eventRequest)
        {
            if (eventRequest == null)
            {
                throw new NotFoundException("Must provide an event.");
            }
            if (string.IsNullOrWhiteSpace(eventRequest.Name)) 
            {
                throw new ErrorOnValidationException("Must provide an event name.");
            }
            if(string.IsNullOrWhiteSpace(eventRequest.Description)) 
            {
                throw new ArgumentException("Must provide a description.");
            }
          
        }
    }
}
