using EventHub.Application.Repositories;
using EventHub.Communication.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Application.UseCases
{
    public class RemoveCheckInUseCase
    {
        private readonly ICheckInRepository _repository;
        public RemoveCheckInUseCase(ICheckInRepository checkinRepository)
        {
            _repository = checkinRepository;
        }

        public async Task<CheckInResponseJson> Execute(Guid id)
        {
            var checkin = await _repository.GetByIdAsync(id);
            
            await _repository.DeleteCheckInAsync(id);

            return new CheckInResponseJson
            {
                ID_CheckIn = id,
                ID_Event = checkin.ID_Event,
                ID_Attendee = checkin.ID_Account,
                CheckInDateTime = checkin.CheckInDateTime,
                State = checkin.State,
            };
        }
    }
}
