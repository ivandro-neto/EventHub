using EventHub.Application.Repositories.Events;
using EventHub.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Application.UseCases.Events
{
    public class GetAllEventsUseCase
    {
        private readonly IEventRepository _repository;
        public GetAllEventsUseCase(IEventRepository eventRepository)
        {
            _repository = eventRepository;
        }
        
        public async Task<List<Event>> Execute()
        {
            return await _repository.GetAllAsync();
        }
    }
}
