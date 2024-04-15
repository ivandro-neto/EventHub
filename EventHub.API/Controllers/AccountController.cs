using EventHub.Application.UseCases.Accounts;
using EventHub.Application.UseCases.Accounts.Register;
using EventHub.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace EventHub.API.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<IActionResult> GetAllEvents()
        {
            var responseList = await _getAllAccountsUseCase.Execute();
            return Ok(responseList);
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> CreateEvent([FromBody] AccountCreateRequestJson account)
        {
            await _accountRegisterUseCase.Execute(account);
            return Created();
        }

    }
}
