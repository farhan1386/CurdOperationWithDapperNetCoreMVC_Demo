using CurdOperationWithDapperNetCoreMVC_Demo.Data;
using CurdOperationWithDapperNetCoreMVC_Demo.Models;
using Dapper;

namespace CurdOperationWithDapperNetCoreMVC_Demo.Repositories
{
    public class ProductRepository : IProduct
    {
        private readonly DapperDbContext context;

        public ProductRepository(DapperDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<ProductModel>> Get()
        {
            var sql = $@"SELECT [ProductId],
                               [ProductName],
                               [Price],
                               [ProdcutDescription],
                               [CreatedOn],
                               [UpdateOn]
                            FROM 
                               [Products]";

            using var connection = context.CreateConnection();
            return await connection.QueryAsync<ProductModel>(sql);
        }
        public async Task<ProductModel> Find(Guid uid)
        {
            var sql = $@"SELECT [ProductId],
                               [ProductName],
                               [Price],
                               [ProdcutDescription],
                               [CreatedOn],
                               [UpdateOn]
                            FROM 
                               [Products]
                            WHERE
                              [ProductId]=@uid";

            using var connection = context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<ProductModel>(sql, new { uid });
        }
        public async Task<ProductModel> Add(ProductModel model)
        {
            model.ProductId = Guid.NewGuid();
            model.CreatedOn = DateTime.Now;
            var sql = $@"INSERT INTO [dbo].[Products]
                                ([ProductId],
                                 [ProductName],
                                 [Price],
                                 [ProdcutDescription],
                                 [CreatedOn])
                                VALUES
                                (@ProductId,
                                 @ProductName,
                                 @Price,
                                 @ProdcutDescription,
                                 @CreatedOn)";

            using var connection = context.CreateConnection();
            await connection.ExecuteAsync(sql, model);
            return model;
        }
        public async Task<ProductModel> Update(ProductModel model)
        {
            model.UpdateOn = DateTime.Now;
            var sql = $@"UPDATE[dbo].[Products]
                           SET [ProductId] = @ProductId,
                               [ProductName] = @ProductName,
                               [Price] = @Price,
                               [ProdcutDescription] = @ProdcutDescription,
                               [UpdateOn] = @UpdateOn
                          WHERE
                              ProductId=@ProductId";

            using var connection = context.CreateConnection();
            await connection.ExecuteAsync(sql, model);
            return model;
        }
        public async Task<ProductModel> Remove(ProductModel model)
        {
            var sql = $@"
                        DELETE FROM
                            [dbo].[Products]
                        WHERE
                            [ProductId]=@ProductId";
            using var connection = context.CreateConnection();
            await connection.ExecuteAsync(sql, model);
            return model;
        }
    }
}
