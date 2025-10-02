using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class JsonRepository<T> where T : class
    {
        private readonly string _filePath;
        private readonly JsonSerializerOptions _options = new JsonSerializerOptions { WriteIndented = true };

        public JsonRepository(string filePath)
        {
            _filePath = filePath;
        }
        
        public async Task<List<T>> GetAllAsync()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    return new List<T>();
                }
                var json = await File.ReadAllTextAsync(_filePath);

                if (string.IsNullOrEmpty(json.Trim()) || json.Trim() == "{}")
                {
                    return new List<T>();
                }

                var result = JsonSerializer.Deserialize<List<T>>(json, _options);
                return result;
            }
            catch(JsonException)
            {
                return null;
            }
            catch
            {
                throw;
            }

        }

        public async Task<T> GetOne(T entity)
        {
            var itemsList = await GetAllAsync() ?? new List<T>();
            var item = itemsList.FirstOrDefault(x => x == entity);

            if (item == null)
                return null;

            return item;
        }

        public async Task CreateAsync(T entity)
        {
            var itemsList = await GetAllAsync() ?? new List<T>();
            itemsList.Add(entity);
            var json = JsonSerializer.Serialize(itemsList, _options);
            await File.WriteAllTextAsync(_filePath, json);
        }

        public async Task SaveAllAsync(List<T> entity)
        {
            var json = JsonSerializer.Serialize(entity, _options);
            await File.WriteAllTextAsync(_filePath, json);
        }

        public async Task EditAsync(T entity)
        {
            var itemsList = await GetAllAsync() ?? new List<T>();
            var item = itemsList.FindIndex(x => x == entity);
            if (item != -1)
            {
                itemsList[item] = entity;
                var json = JsonSerializer.Serialize(itemsList, _options);
                await File.WriteAllTextAsync(_filePath, json);
            }
        }

        public async Task RemoveAsync(T items)
        {
            var item = await GetAllAsync() ?? new List<T>();
            var itemToRemove = item.FirstOrDefault(x => x == items);

            if (itemToRemove == null)
                return;

            item.Remove(itemToRemove);

            var json = JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(_filePath, json);
        }
    }
}
