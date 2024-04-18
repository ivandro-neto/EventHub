using EventHub.Application.Repositories;
using EventHub.Infrastructure.Entities;

namespace EventHub.Application.UseCases
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
