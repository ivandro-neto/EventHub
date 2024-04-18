using EventHub.Application.Repositories;
using EventHub.Communication.Requests;
using EventHub.Communication.Responses;
using EventHub.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Application.UseCases
{
    public class AttendeeRegisterUseCase
    {
        private readonly ICheckInRepository _repository;
        public AttendeeRegisterUseCase(ICheckInRepository checkinRepository)
        {
            _repository = checkinRepository;
        }

        public async Task<CheckinCreatedJson> Execute(Guid eventId, Guid userId)
        {
           
            var checkin = await _repository.CreateCheckInAsync(eventId, userId);

            return new CheckinCreatedJson
            {
                id = checkin.ID_CheckIn,
                AccountID = userId,
                EventID = eventId,
            };
        }
    }
}
