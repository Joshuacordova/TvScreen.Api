using Domain.Entities;
using Domain.Repository.Interface;
using Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ScheduleRepository : JsonRepository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(string filePath) : base(filePath)
        {

        }
        public Task<List<Schedule>> LoadAll()
        {
            return GetAllAsync();
        }

        public async Task SaveAsync(Schedule schedule)
        {
            await CreateAsync(schedule);
        }

        public async Task UpdateAsync(Schedule schedule)
        {
            await EditAsync(schedule);
        }
            
    }
}
