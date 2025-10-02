using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IContentCatalogService
    {
        Task<List<ContentCatalogDto>> GetAllContentCatalog(int startPage, int lastPage);
        Task<ContentCatalogDto> GetContentCatalogByGuid(Guid guid);
        Task CreateContentCatalog(ContentCatalogDto contentCatalogDto);
        Task UpdateContentCatalog(ContentCatalogDto contentCatalogDto);
        Task DeleteContetnCatalog(ContentCatalogDto contentCatalogDto);
    }
}
