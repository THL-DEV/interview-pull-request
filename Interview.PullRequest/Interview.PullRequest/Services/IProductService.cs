using Interview.PullRequest.Entities;

namespace Interview.PullRequest.Services
{
    public interface IProductService
    {
        public Product BuildProduct();
        public decimal CalculatePrice(Product product);
    }
}
