using EventHub.Application.Repositories.Events;
using EventHub.Communication.Requests;
using EventHub.Communication.Responses;
using EventHub.Infrastructure.Entities;


namespace EventHub.Application.UseCases.Events
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
                throw new ArgumentNullException(nameof(eventRequest));
            }
            if (string.IsNullOrWhiteSpace(eventRequest.Name)) 
            {
                throw new ArgumentException(nameof(eventRequest));
            }
            if(string.IsNullOrWhiteSpace(eventRequest.Description)) 
            {
                throw new ArgumentException(nameof(eventRequest));
            }
          
        }
    }
}
