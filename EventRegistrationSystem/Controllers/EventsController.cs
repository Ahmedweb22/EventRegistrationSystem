using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventRegistrationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;
        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var events = await _eventService.GetAllEventsAsync();
            return Ok(events);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
  var e = await _eventService.GetEventByIdAsync(id);
            if (e == null) return NotFound();
            return Ok(e);
        }
        [HttpPost]
        public async Task<IActionResult> Create( EventCreateRequest request)
        {
            var createdEvent = await _eventService.CreateEventAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = createdEvent.Id }, createdEvent);
        }
    }
}
