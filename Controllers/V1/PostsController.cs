using Microsoft.AspNetCore.Mvc;
using RestAPI.Contracts.V1;
using RestAPI.Contracts.V1.Request;
using RestAPI.Contracts.V1.Response;
using RestAPI.Domain;
using RestAPI.Helpers;
using RestAPI.Services;
using System;
using System.Threading.Tasks;

namespace RestAPI.Controllers.V1
{
    public class PostsController : Controller
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet(ApiRoutes.Posts.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid postId)
        {

            return Ok(await _postService.GetByIdAsync(postId));
        }

        [HttpGet(ApiRoutes.Posts.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _postService.GetAllAsync());
        }

        [HttpPost(ApiRoutes.Posts.Create)]
        public async Task<IActionResult> Create(
            [FromBody] CreatePostRequest createPostRequest)
        {
            if (createPostRequest == null || createPostRequest.Name == null)
            {
                return BadRequest();
            }

            var post = new Post { Name = createPostRequest.Name };
            var added = await _postService.AddAsync(post);

            if (!added)
            {
                return NoContent();
            }

            var uriPath = ApiRoutes.Posts.Get.Replace("{postId}", post.Id.ToString());
            var locationUri = HttpHelper.GetFullUriPath(HttpContext.Request, uriPath);

            var response = new CreatePostResponse
            {
                CreatedPostId = post.Id,
                CustomMessage = "yay!"
            };

            return Created(locationUri, response);
        }

        [HttpPut(ApiRoutes.Posts.Update)]
        public async Task<IActionResult> Update(
            [FromRoute] Guid postId,
            [FromBody] UpdatePostRequest updatePostRequest)
        {
            var post = new Post
            {
                Id = postId,
                Name = updatePostRequest.Name
            };

            if (await _postService.UpdateAsync(post))
                return Ok(post);

            return NotFound();
        }

        [HttpDelete(ApiRoutes.Posts.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid postId)
        {
            var deleted = await _postService.DeleteByIdAsync(postId);

            if (deleted)
                return NoContent();

            return NotFound();
        }
    }
}
