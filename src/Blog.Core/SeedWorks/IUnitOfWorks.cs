using Blog.Core.Repository;

namespace Blog.Core.SeedWorks
{
    public interface IUnitOfWorks
    {
        IPostRepository Posts { get; }
        Task<int> CompleteAsync();

    }
}
