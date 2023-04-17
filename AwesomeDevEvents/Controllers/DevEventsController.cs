using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeGameApi.Controllers
{
    [Route("api/dev-events")]
    [ApiController]
    public class DevEventsController : ControllerBase
    {
        private readonly DevEventsContext _options;

        public DevEventsController(DevEventsContext options)
        {
            _options = options;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var devEvents = _context.DevEvent.Where(d => !d.IsDeleted).ToList();
            return Ok(devEvents);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var devEvent = _options.DevEvent.SingleOrDefault(d => d.Id == id);
            if(devEvent == null){
                return NotFound();
            }
            return Ok(devEvent);
        }

        [HttpPost]
        public IActionResult CreateEvent(DevEvent devEvent)
        {
            _options.DevEvent.Add(devEvent);
            return CreatedAtAction(nameof(GetById), new {id = devEvent.Id}, devEvent);
        }

          [HttpPut("{id}")]
        public IActionResult UpdateEvent(Guid id, DevEvent input)
        {
            var devEvent = _options.DevEvent.SingleOrDefault(d => d.Id == id);
            if(devEvent == null){
                return NotFound();
            }
            devEvent.Update(input.Title, input.Description, input.StartDate, input.EndDate);

            return NoContent();
        }

          [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid id)
        {
             var devEvent = _options.DevEvent.SingleOrDefault(d => d.Id == id);
            if(devEvent == null){
                return NotFound();
            }
            devEvent.Delete();
            
            return NoContent();
        }
    }
}