namespace ArandaSoft.Test.Shared.Parameter
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ProductUpdateParameter
    {
        #region Propiedades

        [Required(ErrorMessage = "El ID del producto es requerido.")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Valor no permitido.")]
        public int ID { get; set; }

        /// <summary>
        /// ID de la categoría del producto.
        /// </summary>
        [Range(1, Int32.MaxValue, ErrorMessage = "Valor no permitido.")]
        public int? CategoryId { get; set; }

        /// <summary>
        /// Nombre del producto.
        /// </summary>
        [MaxLength(50, ErrorMessage ="El nombre del producto no puede superar los 50 caracteres.")]
        public string Name { get; set; }

        /// <summary>
        /// Nombre del producto.
        /// </summary>
        [MaxLength(200, ErrorMessage = "La descripción del producto no puede superar los 200 caracteres.")]
        public string Description { get; set; }


        /// <summary>
        /// String Base64 de la imagen.
        /// </summary>
        [DataType(DataType.ImageUrl, ErrorMessage = "Imagen no valida, debe ser un String Base64.")]
        public byte[] Image { get; set; }

        #endregion
    }
}
