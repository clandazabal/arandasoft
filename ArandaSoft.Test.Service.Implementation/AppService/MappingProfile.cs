namespace ArandaSoft.Test.Service.Implementation.AppService
{
    using ArandaSoft.Test.Model.Entity;
    using ArandaSoft.Test.Shared.DTO;
    using AutoMapper;

    public class MappingProfile : Profile
    {
        #region Constructor

        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<ProductCategory, ProductCategoryDTO>().ReverseMap();
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Método de inicio.
        /// </summary>
        public void Start()
        {
            Mapper.Initialize(c =>
            {
                c.AddProfile<MappingProfile>();
            });
        }

        #endregion
    }
}
