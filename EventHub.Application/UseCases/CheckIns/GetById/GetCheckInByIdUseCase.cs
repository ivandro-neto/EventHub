using EventHub.Application.Repositories;
using EventHub.Communication.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Application.UseCases
{
    public class GetCheckInByIdUseCase
    {
        private readonly ICheckInRepository _repository;
        public GetCheckInByIdUseCase(ICheckInRepository eventRepository)
        {
            _repository = eventRepository;
        }

        public async Task<CheckInResponseJson> Execute(Guid id)
        {
            var checkin = await _repository.GetByIdAsync(id);

            return new CheckInResponseJson
            {
                ID_CheckIn = id,
                ID_Event = checkin.ID_Event,
                ID_Attendee = checkin.ID_Account,
                State = checkin.State,
                CheckInDateTime = checkin.CheckInDateTime,
                RegistedDateTime = checkin.RegistedDateTime,
            };
        }
    }
}
