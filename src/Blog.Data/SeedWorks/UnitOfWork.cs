using AutoMapper;
using Blog.Core.Repository;
using Blog.Core.SeedWorks;
using Blog.Data.Repositories;

namespace Blog.Data.SeedWorks
{
    public class UnitOfWork : IUnitOfWorks
    {
        private readonly BlogContext context;

        public UnitOfWork(BlogContext context, IMapper mapper)
        {
            this.context = context;
            Posts = new PostRepository(context, mapper);

        }

        public IPostRepository Posts { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await context.SaveChangesAsync();
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
