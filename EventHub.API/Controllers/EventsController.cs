using EventHub.Application.UseCases.Events;
using EventHub.Communication.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EventHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly RegisterEventUseCase _registerEventUseCase;
        private readonly GetAllEventsUseCase _getAllEventsUseCase;
        private readonly GetEventByIdUseCase _getEventByIdUseCase;
        public EventsController(RegisterEventUseCase registerEventUseCase, GetAllEventsUseCase getAllEventsUseCase, GetEventByIdUseCase eventByIdUseCase ) 
        {
            _registerEventUseCase = registerEventUseCase;
            _getAllEventsUseCase = getAllEventsUseCase;
            _getEventByIdUseCase = eventByIdUseCase;
        }

        [HttpGet]
        public async Task<IActionResult>GetAllEvents()
        {
            var responseList = await _getAllEventsUseCase.Execute();
            return Ok(responseList);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetEventById([FromRoute] Guid id) 
        {
            var response = await _getEventByIdUseCase.Execute(id);
            return Ok(response);
        }

        [HttpPost]
        [Route("{userID}/register")]
        public async Task <IActionResult >CreateEvent([FromRoute] Guid userID, [FromBody] CreateEventRequestJson Event)
        {
            var response = await _registerEventUseCase.Execute(userID, Event);
            return Created(string.Empty, response);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateEvent([FromRoute] Guid id, [FromBody] CreateEventRequestJson Event)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteEvent([FromRoute] Guid id)
        {
            return Ok();
        }
    }
}
