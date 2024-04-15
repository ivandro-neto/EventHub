using EventHub.Application.Repositories.Events;
using EventHub.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Application.UseCases.Events
{
    public class GetEventByIdUseCase
    {
        private readonly IEventRepository _repository;
        public GetEventByIdUseCase(IEventRepository eventRepository)
        {
            _repository = eventRepository;
        }

        public async Task<Event> Execute(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}
