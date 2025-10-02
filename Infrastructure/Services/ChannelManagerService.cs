using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Repository.Interface;

namespace Infrastructure.Services
{
    public class ChannelManagerService : IChannelManagerService
    {
        private readonly IChannelManagerRepository _channelManagerRepository;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IMapper _mapper;
        public ChannelManagerService(IChannelManagerRepository channelManagerRepository, 
            IScheduleRepository scheduleRepository,
            IMapper mapper)
        {
            _channelManagerRepository = channelManagerRepository;
            _mapper = mapper;
        }

        public async Task CreateChannelManager(ChannelManagerDto channelManagerDto)
        {
            channelManagerDto.ChannelId = Guid.NewGuid(); //always new guid
            var channelData = _mapper.Map<ChannelManager>(channelManagerDto);


            await _channelManagerRepository.SaveAsync(channelData);
            
            var scheduleDto = new ScheduleDto
            {
                ScheduleId = Guid.NewGuid(),
                ChannelId = channelManagerDto.ChannelId,
                IsRecurring = false,
                CreatedAt = DateTime.Now
            };

            var schedData = _mapper.Map<Schedule>(scheduleDto);
            await _scheduleRepository.SaveAsync(schedData);

        }


        /// <summary>
        /// use pagination to optimize the page load
        /// </summary>
        /// <param name="startPage"></param>
        /// <param name="lastPage"></param>
        /// <returns></returns>
        public async Task<List<ChannelManagerDto>> GetAllTvChannels(int startPage, int lastPage)
        {
            var channelList = _mapper.Map<List<ChannelManagerDto>>(await _channelManagerRepository.LoadAll());

            return channelList
                .Skip(startPage)
                .Take(lastPage)
                .ToList();
        }
    }
}
