using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class JsonStorageOptions
    {
        public string? ContentCatalogPath { get; set; }
        public string? ChannelManagerPath { get; set; }
        public string? SchedulePath { get; set; }
    }
}
