using EventHub.Application.UseCases;
using EventHub.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace EventHub.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly GetAllAccountsUseCase _getAllAccountsUseCase;
        private readonly AccountRegisterUseCase _accountRegisterUseCase;
        public AccountController( GetAllAccountsUseCase getAllEventsUseCase, AccountRegisterUseCase accountRegisterUseCase)
        {
            _getAllAccountsUseCase = getAllEventsUseCase;
            _accountRegisterUseCase = accountRegisterUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            var responseList = await _getAllAccountsUseCase.Execute();
            return Ok(responseList);
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> CreateAccount([FromBody] AccountCreateRequestJson account)
        {
            await _accountRegisterUseCase.Execute(account);
            return Created();
        }

    }
}
