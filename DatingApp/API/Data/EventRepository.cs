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

        public Task<Event> GetEvent(int eventId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Event>> GetEvents()
        {
            var events = _context.Events.ToListAsync();
            return await events;
        }
    }
}