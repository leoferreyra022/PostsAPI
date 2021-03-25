using Microsoft.EntityFrameworkCore;
using RestAPI.Data;
using RestAPI.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestAPI.Services
{
    public class PostService : IPostService
    {
        private readonly DataContext _dataContext;
        public PostService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> AddAsync(Post post)
        {
            await _dataContext.Posts.AddAsync(post);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<Post> GetByIdAsync(Guid id)
        {
            return await _dataContext.Posts.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Post>> GetAllAsync()
        {
            return await _dataContext.Posts.ToListAsync();
        }

        public async Task<bool> UpdateAsync(Post post)
        {
            _dataContext.Update(post);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var post = await GetByIdAsync(id);

            if (post == null)
                return false;

            _dataContext.Posts.Remove(post);
            var removed = await _dataContext.SaveChangesAsync();
            return removed > 0;
        }
    }
}
