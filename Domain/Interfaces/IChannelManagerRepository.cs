using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository.Interface
{
    public interface IChannelManagerRepository
    {
        Task<List<ChannelManager>> LoadAll();
        Task SaveAsync(ChannelManager channelManager);
        Task UpdateAsync(ChannelManager channelManager);
        Task DeleteAsync(ChannelManager channelManager);
    }
}
