namespace ArandaSoft.Test.Service.Implementation.Repository.Persistence
{
    using ArandaSoft.Test.Model.Context;
    using ArandaSoft.Test.Model.Entity;

    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ArandaSoftTestContext context) : base(context)
        {
        }
    }
}
