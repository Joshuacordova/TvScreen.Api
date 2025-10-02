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
    public class ChannelManagerRepository : JsonRepository<ChannelManager>, IChannelManagerRepository
    {
        public ChannelManagerRepository(string filePath) : base(filePath)
        {
        }

        public async Task DeleteAsync(ChannelManager channelManager)
        {
            await RemoveAsync(channelManager);
        }

        public Task<List<ChannelManager>> LoadAll()
        {
            return GetAllAsync();
        }

        public async Task SaveAsync(ChannelManager channelManager)
        {
            await CreateAsync(channelManager);
        }

        public async Task UpdateAsync(ChannelManager channelManager)
        {
            await EditAsync(channelManager);
        }
    }
}
