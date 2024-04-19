using EventHub.Application.UseCases;
using EventHub.Communication.Requests;
using EventHub.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EventHub.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly RegisterEventUseCase _registerEventUseCase;
        private readonly GetAllEventsUseCase _getAllEventsUseCase;
        private readonly GetEventByIdUseCase _getEventByIdUseCase;
        private readonly UpdateEventUseCase _updateEventUseCase;
        private readonly DeleteEventUseCase _deleteEventUseCase;
        private readonly AttendeeRegisterUseCase _attendeeRegisterUseCase;
        private readonly AddCategoryToEventUseCase _addCategoryToEventUseCase;
        private readonly RemoveCategoryFromEventUseCase _removeCategoryFromEventUseCase;
        public EventsController(RegisterEventUseCase registerEventUseCase, GetAllEventsUseCase getAllEventsUseCase, GetEventByIdUseCase eventByIdUseCase, UpdateEventUseCase updateEventUseCase, DeleteEventUseCase deleteEventUseCase, AttendeeRegisterUseCase attendeeRegisterUseCase, AddCategoryToEventUseCase addCategoryToEventUseCase, RemoveCategoryFromEventUseCase removeCategoryFromEventUse) 
        {
            _registerEventUseCase = registerEventUseCase;
            _getAllEventsUseCase = getAllEventsUseCase;
            _getEventByIdUseCase = eventByIdUseCase;
            _updateEventUseCase = updateEventUseCase;
            _deleteEventUseCase = deleteEventUseCase;
            _attendeeRegisterUseCase = attendeeRegisterUseCase;
            _addCategoryToEventUseCase = addCategoryToEventUseCase;
            _removeCategoryFromEventUseCase = removeCategoryFromEventUse;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<EventResponseJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseJson), StatusCodes.Status404NotFound)]
        
        public async Task<IActionResult> GetAllEvents([FromQuery] Guid? category)
        {
            var responseList = await _getAllEventsUseCase.Execute(category);
            return Ok(responseList);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(EventResponseJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEventById([FromRoute] Guid id) 
        {
            var response = await _getEventByIdUseCase.Execute(id);
            return Ok(response);
        }

        [HttpPost]
        [Route("{userID}/register")]
        [ProducesResponseType(typeof(EventCreatedResponseJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponseJson), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponseJson), StatusCodes.Status409Conflict)]

        public async Task <IActionResult>CreateEvent([FromRoute] Guid userID, [FromBody] CreateEventRequestJson Event)
        {
            var response = await _registerEventUseCase.Execute(userID, Event);
            return Created(string.Empty, response);
        }

        [HttpPost]
        [Route("{eventID}/checkin/{userID}")]
        [ProducesResponseType(typeof(EventCreatedResponseJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponseJson), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponseJson), StatusCodes.Status409Conflict)]

        public async Task<IActionResult> AddAttendee([FromRoute] Guid eventID, [FromRoute] Guid userID)
        {
            var response = await _attendeeRegisterUseCase.Execute(eventID, userID);
            return Created(string.Empty, response);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(EventCreatedResponseJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseJson), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponseJson), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateEvent([FromRoute] Guid id, [FromBody] CreateEventRequestJson Event)
        {
            var response = await _updateEventUseCase.Execute(id, Event);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(EventCreatedResponseJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteEvent([FromRoute] Guid id)
        {
            var response = await _deleteEventUseCase.Execute(id);
            return Ok(response);
        }

        [HttpPost]
        [Route("{eventId}/categories/")]
        [ProducesResponseType(typeof(CategoryAddedResponseJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponseJson), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ErrorResponseJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddCategoryToEvent([FromRoute]Guid eventId, [FromQuery]string categoryName)
        {
            var response = await _addCategoryToEventUseCase.Execute(eventId, categoryName);
            return Created(string.Empty, response);
        }

        [HttpDelete]
        [Route("{eventId}/categories/{categoryId}")]
        [ProducesResponseType(typeof(CategoryAddedResponseJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponseJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveCategoryFromEvent(Guid eventId, Guid categoryId)
        {
            await _removeCategoryFromEventUseCase.Execute(eventId, categoryId);
            return Ok();
        }
    }
}
