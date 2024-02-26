using CurdOperationWithDapperNetCoreMVC_Demo.Models;

namespace CurdOperationWithDapperNetCoreMVC_Demo.Repositories
{
    public interface IProduct
    {
        Task<IEnumerable<ProductModel>> Get();
        Task<ProductModel> Find(Guid uid);
        Task<ProductModel> Add(ProductModel model);
        Task<ProductModel> Update(ProductModel model);
        Task<ProductModel> Remove(ProductModel model);
    }
}
