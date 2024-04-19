using EventHub.Application.Repositories;
using EventHub.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Application.UseCases
{
    public class RemoveCategoryFromEventUseCase
    {
        private readonly IEventRepository _eventRepository;
        public RemoveCategoryFromEventUseCase(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task Execute(Guid eventId, Guid categoryId)
        {
            var eventEntity = await _eventRepository.GetByIdAsync(eventId);

            // Remover a categoria do evento
            var eventCategory = eventEntity.EventCategories.FirstOrDefault(ec => ec.ID_Category == categoryId);
            if(eventCategory is null)
            {
                throw new NotFoundException("Category not found.");
            }
            eventEntity.EventCategories.Remove(eventCategory);
            await _eventRepository.UpdateEventAsync(eventId, eventEntity); // Certifique-se de implementar o método Update no seu repositório de eventos
        }
    }
}
