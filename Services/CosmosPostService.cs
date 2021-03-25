using Cosmonaut;
using Cosmonaut.Extensions;
using RestAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Services
{
    public class CosmosPostService : IPostService
    {
        private readonly ICosmosStore<CosmosPostDto> _cosmosStore;

        public CosmosPostService(ICosmosStore<CosmosPostDto> cosmosStore)
        {
            _cosmosStore = cosmosStore;
        }

        public async Task<bool> AddAsync(Post post)
        {
            var cosmosPostDto = new CosmosPostDto
            {
                Id = Guid.NewGuid().ToString(),
                Name = post.Name
            };

            var added = await _cosmosStore.AddAsync(cosmosPostDto);

            return added.IsSuccess;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var deleted = await _cosmosStore.RemoveByIdAsync(id.ToString());

            return deleted.IsSuccess;
        }

        public async Task<List<Post>> GetAllAsync()
        {
            var posts = await _cosmosStore.Query().ToListAsync();

            return posts.Select(x => new Post
            {
                Id = Guid.Parse(x.Id),
                Name = x.Name
            }).ToList();
        }

        public async Task<Post> GetByIdAsync(Guid id)
        {
            var cosmosPost = await _cosmosStore.FindAsync(id.ToString());

            if (cosmosPost == null)
                return null;

            return new Post
            {
                Id = Guid.Parse(cosmosPost.Id.ToString()),
                Name = cosmosPost.Name
            };
        }

        public async Task<bool> UpdateAsync(Post post)
        {
            var cosmosPostDto = new CosmosPostDto
            {
                Id = post.Id.ToString(),
                Name = post.Name
            };

            var updated = await _cosmosStore.UpdateAsync(cosmosPostDto);

            return updated.IsSuccess;
        }
    }
}
