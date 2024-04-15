using EventHub.Application.Repositories.Accounts;
using EventHub.Application.Repositories.Events;
using EventHub.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Application.UseCases.Accounts
{
    public class GetAllAccountsUseCase
    {
        private readonly IAccountRepository _repository;
        public GetAllAccountsUseCase(IAccountRepository eventRepository)
        {
            _repository = eventRepository;
        }

        public async Task<List<Account>> Execute()
        {
            return await _repository.GetAllAsync();
        }
    }
}
