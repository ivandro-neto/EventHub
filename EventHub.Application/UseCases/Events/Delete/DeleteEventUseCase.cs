using EventHub.Application.Repositories;
using EventHub.Communication.Responses;

namespace EventHub.Application.UseCases
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
