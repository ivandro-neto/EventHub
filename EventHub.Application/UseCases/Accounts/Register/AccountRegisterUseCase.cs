using EventHub.Application.Repositories.Accounts;
using EventHub.Communication.Requests;
using EventHub.Infrastructure.Entities;

namespace EventHub.Application.UseCases.Accounts.Register
{
    public class AccountRegisterUseCase
    {
        private readonly IAccountRepository _repository;
        public AccountRegisterUseCase(IAccountRepository eventRepository)
        {
            _repository = eventRepository;
        }

        public async Task Execute(AccountCreateRequestJson account)
        {
            Account acc = new()
            {
                FirstName = account.FirstName,
                LastName = account.LastName,
                Email = account.Email,
                PasswordHash = account.Password,
                Username = $"@{account.FirstName.ToLower()}{account.LastName.ToLower()}",
            };
            await _repository.CreateAccountAsync(acc);
        }
    }
 
}
