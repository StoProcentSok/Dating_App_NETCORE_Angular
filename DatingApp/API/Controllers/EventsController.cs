using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using API.Interfaces;
using System.Linq;

namespace API.Controllers
{
    public class EventsController : BaseApiController
    {
        private readonly IEventRepository _eventsRepository;
        private readonly DataContext _context;
        public EventsController(IEventRepository eventsRepository, DataContext context)
        {
            this._eventsRepository = eventsRepository;
            this._context = context;
        }

        [HttpGet("get")]
        public async Task<IEnumerable<Event>> GetEvents()
        {
            var events = await _eventsRepository.GetEvents();
            return events;
        }

        [HttpGet("{id}", Name = "GetById")]
        public async Task<ActionResult<Event>> GetEvent(int eventId)
        {
            var @event = await _context.Events.FirstOrDefaultAsync(e => e.Id == eventId);
            return @event;
        }

        [HttpPost("Add")]
        public async Task<ActionResult<Event>> AddEvent(string eventName)
        {
            var newEvent = new Event
            {
                EventName = eventName
            };

            _context.Events.Add(newEvent);
            await _context.SaveChangesAsync();

            return newEvent;
        }

        [HttpDelete("delete-event/{eventId}")]
        public async Task<ActionResult> DeleteEvent(int eventId)
        {
            var @event = _context.Events.FirstOrDefault(x => x.Id == eventId);
            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();

            return Ok();

        }
    }
}
