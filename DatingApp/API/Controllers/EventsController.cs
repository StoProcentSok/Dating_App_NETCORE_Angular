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
using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Helpers;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EventsController : BaseApiController
    {
        private readonly IEventRepository _eventsRepository;
        private readonly IUserRepository _userRepository;
        private readonly DataContext _context;
        public EventsController(IEventRepository eventsRepository, IUserRepository userRepository, DataContext context)
        {
            this._eventsRepository = eventsRepository;
            this._context = context;
            this._userRepository = userRepository;
        }

        [HttpGet("getevents")]
        public async Task<IEnumerable<Event>> GetEvents()
        {
            var events = await _eventsRepository.GetEvents();
            return events;
        }

        [HttpGet("getevent/{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var @event = await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
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

        [HttpPost("register/{eventId}")]
        public async Task<ActionResult> Register(int eventId)
        {
            var sourceUserid = User.GetUserId();
            var sourceUserWithEvents = await _eventsRepository.GetUserWithEvents(sourceUserid);
            var eventToRegisterTo = await _eventsRepository.GetEvent(eventId);

            if (eventToRegisterTo == null) return NotFound();

            var eventParticipation = await _eventsRepository.GetUserEvent(sourceUserid, eventToRegisterTo.Id);
            if (eventParticipation != null) return BadRequest("You Already Joined this event..");

            eventParticipation = new UserEventParticipation()
            {
                SourceUserId = sourceUserid,
                EventToParticipateIniId = eventToRegisterTo.Id
            };

            sourceUserWithEvents.UserEvents.Add(eventParticipation);

            if (await _userRepository.SaveAllAsync()) return Ok();

            return BadRequest("Failed to join event");
        }
    }
}
