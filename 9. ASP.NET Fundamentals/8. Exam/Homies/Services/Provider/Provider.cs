using Homies.Data;
using Homies.Data.Models;
using Homies.Services.Contracts;
using Homies.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace Homies.Services.Provider
{
    public class Provider : IService
    {
        private HomiesDbContext context;

        public Provider(HomiesDbContext _db)
        {
            context = _db;
        }
        public async Task AddEvent(EventFormModel model, string userId)
        {
            var newEvent = new Event()
            {
                Name = model.Name,
                Description = model.Description,
                OrganiserId = userId,
                Start = model.Start,
                CreatedOn = DateTime.Now,
                End = model.End,
                TypeId = model.TypeId,
            };

            await context.Events.AddAsync(newEvent);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TypeViewModel>> GetAllTypes()
        {
            return await context
                .Types
                .Select(t => new TypeViewModel
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToListAsync();
        }

        public async Task<EventEditModel> GetEventById(int id)
        {
            var currentEvent = await context
                .Events
                .FindAsync(id);

            return new EventEditModel
            {
                Name = currentEvent.Name,
                Description = currentEvent.Description,
                Start = currentEvent.Start.ToString("yyyy-MM-dd H:mm"),
                End = currentEvent.End.ToString("yyyy-MM-dd H:mm"),
                TypeId = currentEvent.TypeId,
            };
        }
        public async Task EditEvent(EventEditModel model, int id)
        {
            var currentEvent = await context
                .Events
            .FindAsync(id);

            currentEvent.Name = model.Name;
            currentEvent.Description = model.Description;
            currentEvent.Start = DateTime.Parse(model.Start);
            currentEvent.End = DateTime.Parse(model.End);
            currentEvent.TypeId = model.TypeId;

            await context.SaveChangesAsync();
        }

        public async Task<EventDetailsModel> GetDetails(int id)
        {
            var current = await context
                .Events
                .Where(e => e.Id == id)
                .Select(x => new EventDetailsModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Start = x.Start.ToString("yyyy-MM-dd H:mm"),
                    End = x.End.ToString("yyyy-MM-dd H:mm"),
                    Organiser = x.Organiser.UserName,
                    CreatedOn = x.CreatedOn.ToString("yyyy-MM-dd H:mm"),
                    Type = x.Type.Name
                }).FirstAsync();

            return current;
        }

        public async Task<IEnumerable<EventViewModel>> GetAllEvents()
        {
            return await context
                .Events
                .Select(x => new EventViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Start = x.Start.ToString("yyyy-MM-dd H:mm"),
                    Type = x.Type.Name,
                    Organiser = x.Organiser.UserName,
                }).ToListAsync();
        }

        public async Task JoinEvent(int id, string userId)
        {
            var currentEvent = await context
                .EventsParticipants
                .FirstOrDefaultAsync(x => x.EventId == id && x.HelperId == userId);

            if (currentEvent != null)
            {
                return;
            }

            var joined = new EventParticipant
            {
                HelperId = userId,
                EventId = id
            };

            await context.EventsParticipants.AddAsync(joined);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<EventViewModel>> GetJoinedEvents(string userId)
        {
            return await context
                .EventsParticipants
                .Where(x => x.HelperId == userId)
                .Select(x => new EventViewModel
                {
                    Id = x.EventId,
                    Name = x.Event.Name,
                    Start = x.Event.Start.ToString("yyyy-MM-dd H:mm"),
                    Type = x.Event.Type.Name,
                    Organiser = x.Event.Organiser.UserName,
                })
                .ToListAsync();
        }

        public async Task LeaveEvent(int id, string userId)
        {
            var currentEvent = await context
                .EventsParticipants
                .FirstOrDefaultAsync(x => x.EventId == id && x.HelperId == userId);

            context.EventsParticipants.Remove(currentEvent);
            await context.SaveChangesAsync();
        }
    }
}
