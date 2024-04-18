using EventHub.Application.UseCases;
using EventHub.Communication.Responses;
using EventHub.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace EventHub.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CheckInController : ControllerBase
    {
        private readonly GetCheckInByIdUseCase _getCheckInByIdUseCase;
        private readonly RemoveCheckInUseCase _removeCheckInUseCase;
        public CheckInController(GetCheckInByIdUseCase getCheckInByIdUseCase, RemoveCheckInUseCase removeCheckInUseCase) 
        {
            _getCheckInByIdUseCase = getCheckInByIdUseCase;
            _removeCheckInUseCase = removeCheckInUseCase;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(CheckInResponseJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundException), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _getCheckInByIdUseCase.Execute(id);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(CheckInResponseJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundException), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveCheckIn([FromRoute] Guid id)
        {
            var response = await _removeCheckInUseCase.Execute(id);
            return Ok(response);
        }
    }
}
