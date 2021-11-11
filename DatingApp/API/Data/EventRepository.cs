using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class EventRepository : IEventRepository
    {
        private readonly DataContext _context;
        public EventRepository(DataContext context)
        {
            this._context = context;

        }

        public async Task<Event> GetEvent(int eventId)
        {
            return await _context.Events.FindAsync(eventId);
        }

        public async Task<IEnumerable<Event>> GetEvents()
        {
            var events = _context.Events.ToListAsync();
            return await events;
        }

        public async Task<AppUser> GetUserWithEvents(int userId)
        {
            return await _context.Users
                .Include(x => x.UserEvents)
                .FirstOrDefaultAsync(x => x.Id == userId);
        }

        public async Task<UserEventParticipation> GetUserEvent(int sourceUserId, int eventId)
        {
            return await _context.EventsParticipations.FindAsync(sourceUserId, eventId);
        }
    }
}