using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ContentCatalogService : IContentCatalogService
    {
        private readonly IContentCatalogRepository _contentCatalogRepository;
        private readonly IScheduleRepository _scheduleRepository;   
        private readonly IMapper _mapper;

        public ContentCatalogService(IContentCatalogRepository contentCatalogRepository, 
            IScheduleRepository scheduleRepository,
            IMapper mapper)
        {
            _contentCatalogRepository = contentCatalogRepository;
            _mapper = mapper;
        }
        public async Task CreateContentCatalog(ContentCatalogDto contentCatalogDto)
        {

            var data = await _contentCatalogRepository.LoadAll();

            var isExists = data.Any(x => x.Title == contentCatalogDto.Title);

            if (isExists)
                throw new Exception("Cannot add — title already exists in the catalog.");

            contentCatalogDto.ContentId = Guid.NewGuid();
            var contentCatalogData = _mapper.Map<ContentCatalog>(contentCatalogDto);
            await _contentCatalogRepository.SaveAsync(contentCatalogData);


            var scheduleDto = new ScheduleDto
            {
                ScheduleId = Guid.NewGuid(),
                ContentId = contentCatalogDto.ContentId,
                IsRecurring = false,
                CreatedAt = DateTime.Now
            };

            var schedData = _mapper.Map<Schedule>(scheduleDto);
            await _scheduleRepository.SaveAsync(schedData);
        }

        public async Task DeleteContetnCatalog(ContentCatalogDto contentCatalogDto)
        {
            var contentCatalogData = _mapper.Map<ContentCatalog>(contentCatalogDto);
            await _contentCatalogRepository.DeleteAsync(contentCatalogData  );
        }

        public async Task<List<ContentCatalogDto>> GetAllContentCatalog(int startPage, int lastPage)
        {
            var contentCatalogList = _mapper.Map<List<ContentCatalogDto>>(await _contentCatalogRepository.LoadAll());

            return contentCatalogList
                .Skip(startPage)
                .Take(lastPage)
                .ToList();
        }

        public async Task<ContentCatalogDto> GetContentCatalogByGuid(Guid guid)
        {
            
            return _mapper.Map<ContentCatalogDto>(await _contentCatalogRepository.FindContentCatalogByGUID(guid));
        }

        public async Task UpdateContentCatalog(ContentCatalogDto contentCatalogDto)
        {
            var contentCatalogData = _mapper.Map<ContentCatalog>(contentCatalogDto);
            await _contentCatalogRepository.UpdateAsync(contentCatalogData);
        }
    }
}
