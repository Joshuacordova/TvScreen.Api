using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository.Interface
{
    public interface IContentCatalogRepository
    {
        Task<List<ContentCatalog>> LoadAll();
        Task SaveAsync(ContentCatalog contentCatalog);
        Task UpdateAsync(ContentCatalog contentCatalog);
        Task DeleteAsync(ContentCatalog contentCatalog);
        Task<ContentCatalog> FindContentCatalogByGUID(Guid uid);
    }
}
