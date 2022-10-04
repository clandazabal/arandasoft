namespace ArandaSoft.Test.Shared.Parameter
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Parámetros para la creación de un producto.
    /// </summary>
    public class ProductCreateParameter
    {
        #region Propiedades

        /// <summary>
        /// ID de la categoría del producto.
        /// </summary>
        [Range(1, Int32.MaxValue, ErrorMessage = "Valor no permitido.")]
        [Required(ErrorMessage = "El ID de la categoría es requerido.")]
        public int CategoryId { get; set; }

        /// <summary>
        /// Nombre del producto.
        /// </summary>
        [Required(ErrorMessage = "El nombre del producto es requerido."), MaxLength(50, ErrorMessage = "El nombre del producto no puede superar los 50 caracteres.")]
        public string Name { get; set; }

        /// <summary>
        /// Descripción del producto.
        /// </summary>
        [MaxLength(200, ErrorMessage ="La descripción del producto no puede superar los 200 caracteres.")]
        public string Description { get; set; }

        /// <summary>
        /// String Base64 de la imagen.
        /// </summary>
        [DataType(DataType.ImageUrl, ErrorMessage ="Imagen no valida, debe ser un String Base64.")]
        public byte[] Image { get; set; }

        #endregion
    }
}
