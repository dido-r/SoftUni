using Homies.Services.Models;

namespace Homies.Services.Contracts
{
    public interface IService
    {
        Task AddEvent(EventFormModel model, string userId);

        Task<IEnumerable<TypeViewModel>> GetAllTypes();

        Task<EventEditModel> GetEventById(int id);

        Task EditEvent(EventEditModel model, int id);

        Task<EventDetailsModel> GetDetails(int id);

        Task<IEnumerable<EventViewModel>> GetAllEvents();

        Task JoinEvent(int id, string userId);

        Task LeaveEvent(int id, string userId);

        Task<IEnumerable<EventViewModel>> GetJoinedEvents(string userId);
    }
}
