using RestAPI.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestAPI.Services
{
    public interface IPostService
    {
        Task<List<Post>> GetAllAsync();
        Task<Post> GetByIdAsync(Guid id);
        Task<bool> AddAsync(Post post);
        Task<bool> UpdateAsync(Post post);
        Task<bool> DeleteByIdAsync(Guid id);
    }
}
