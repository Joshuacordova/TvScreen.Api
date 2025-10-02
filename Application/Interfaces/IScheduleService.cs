using Application.DTOs;

namespace Application.Interfaces
{
    public interface IScheduleService
    {
        Task<List<ScheduleContentDto>> GetAllSchedule(string filter, int startPage, int lastPage);
    }
}
