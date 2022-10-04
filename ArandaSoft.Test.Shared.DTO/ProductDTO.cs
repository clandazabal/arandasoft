namespace ArandaSoft.Test.Shared.DTO
{
    public class ProductDTO
    {
        #region Propiedades

        /// <summary>
        /// ID del producto.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del producto.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Descripción del producto.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Categoría del producto.
        /// </summary>
        public ProductCategoryDTO ProductCategory { get; set; }

        /// <summary>
        /// Imagen del producto.
        /// </summary>
        public byte[] Image { get; set; }

        #endregion
    }
}
