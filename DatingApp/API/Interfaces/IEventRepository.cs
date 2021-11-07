using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Interfaces
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetEvents();
        Task<Event> GetEvent(int eventId);

    }
}