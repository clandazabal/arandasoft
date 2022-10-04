namespace ArandaSoft.Test.Model.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Product")]
    public partial class Product
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public byte[] Image { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
    }
}
