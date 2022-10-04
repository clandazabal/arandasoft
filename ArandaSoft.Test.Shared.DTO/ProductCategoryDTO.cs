namespace ArandaSoft.Test.Shared.DTO
{
    using System.ComponentModel.DataAnnotations;

    public  class ProductCategoryDTO
    {
        #region Propiedades

        /// <summary>
        /// ID de la categoría.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre de la categoría.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        #endregion
    }
}
