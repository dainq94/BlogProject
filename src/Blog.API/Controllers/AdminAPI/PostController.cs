using AutoMapper;
using Blog.Core.Models;
using Blog.Core.Models.Content;
using Blog.Core.SeedWorks;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers.AdminAPI
{
    [Route("api/admin/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IUnitOfWorks _unitOfWork;
        private readonly IMapper _mapper;
        public PostController(IUnitOfWorks unitOfWorks, IMapper mapper)
        {
            _unitOfWork = unitOfWorks;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("paging")]
        public async Task<ActionResult<PagedResult<PostInListDto>>> GetPostsPaging(string? keyword, Guid? categoryId, int pageIndex, int pageSize = 10)
        {
            var result = await _unitOfWork.Posts.GetPostsPagingAsync(keyword, categoryId, pageIndex, pageSize);
            return Ok(result);
        }
    }
}

