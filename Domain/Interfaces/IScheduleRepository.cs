using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository.Interface
{
    public interface IScheduleRepository
    {
        Task<List<Schedule>> LoadAll();
        Task SaveAsync(Schedule schedule);
        Task UpdateAsync(Schedule schedule);
    }
}
