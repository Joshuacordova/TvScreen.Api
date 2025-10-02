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
    public class ContentCatalogRepository : JsonRepository<ContentCatalog>, IContentCatalogRepository
    {
        public ContentCatalogRepository(string filePath) : base(filePath)
        {
        }

        public async Task DeleteAsync(ContentCatalog contentCatalog)
        {
            await RemoveAsync(contentCatalog);
        }

        public async Task<List<ContentCatalog>> LoadAll()
        {
            return await GetAllAsync();
        }

        public async Task SaveAsync(ContentCatalog contentCatalog)
        {
            await CreateAsync(contentCatalog);
        }

        public async Task UpdateAsync(ContentCatalog contentCatalog)
        {
            await EditAsync(contentCatalog);
        }

        public async Task<ContentCatalog> FindContentCatalogByGUID(Guid uid)
        {
            var data = await GetAllAsync();
            return data.Where(x => x.ContentId == uid).FirstOrDefault() ?? new ContentCatalog();
        }
    }
}
