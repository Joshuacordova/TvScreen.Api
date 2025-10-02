using Application.DTOs;
using Application.Interfaces;
using Domain.Repository.Interface;

namespace Infrastructure.Services
{
    public class ScheduleService : IScheduleService
    {

        private readonly IContentCatalogRepository _contentCatalogRepository;
        private readonly IChannelManagerRepository _channelManagerRepository;
        private readonly IScheduleRepository _scheduleRepository;
        public ScheduleService(IContentCatalogRepository contentCatalogRepository, IChannelManagerRepository channelManagerRepository,
            IScheduleRepository scheduleRepository)
        {
            _contentCatalogRepository = contentCatalogRepository;
            _channelManagerRepository = channelManagerRepository;
            _scheduleRepository = scheduleRepository;
        }

        public async Task<List<ScheduleContentDto>> GetAllSchedule(string filter, int startPage, int lastPage)
        {
            var scheduleTask = await _scheduleRepository.LoadAll();
            var channelManagerTask = await _channelManagerRepository.LoadAll();
            var contentCatalogTask = await _contentCatalogRepository.LoadAll();
            IQueryable<ScheduleContentDto> dataList = null;

            dataList = from sched in scheduleTask.AsQueryable()
                       join channel in channelManagerTask.AsQueryable() on sched.ChannelId equals channel.ChannelId
                       join content in contentCatalogTask.AsQueryable() on sched.ContentId equals content.ContentId
                       select new ScheduleContentDto
                       {
                           ScheduleId = sched.ScheduleId,
                           ChannelName = channel.ChannelName,
                           ChannelCode = channel.ChannelCode,
                           CreatedAt = sched.CreatedAt,
                           UpdatedAt = sched.UpdatedAt
                       };

            if (DateTime.TryParse(filter, out DateTime parsedDate))
            {
                dataList = dataList.Where(x => x.CreatedAt.Value.Date == parsedDate.Date);
            }
            else if (filter.ToLower() == "currently airing")
            {
                dataList = dataList.Where(x => x.CreatedAt.Value.Date == DateTime.Now.Date);
            }
            else
            {
                dataList = dataList.Where(x => x.Title.Equals(filter) ||
                 x.ChannelName.Equals(filter) ||
                 x.ChannelCode.Equals(filter)
                );
            }

            var query = dataList.Skip(startPage).Take(lastPage).ToList();


            return query;
        }
    }
}
