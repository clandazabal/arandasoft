namespace ArandaSoft.Test.Model.Context
{    
    using System.Data.Entity;
    using ArandaSoft.Test.Model.Context.Migrations;
    using ArandaSoft.Test.Model.Entity;

    public partial class ArandaSoftTestContext : DbContext
    {
        #region Constructor

        /// <summary>
        /// Constructor Inicializador del contexto.
        /// </summary>
        public ArandaSoftTestContext() : base(nameOrConnectionString:"ArandaSoftTestConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ArandaSoftTestContext, Configuration>());
        }

        #endregion

        #region Propiedades

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }

        #endregion

        #region Métodos

        /// <summary>
        /// Método sobreescrito reconstrucción del modelo.
        /// </summary>
        /// <param name="modelBuilder">DbModelBuilder</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ProductCategory>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ProductCategory>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.ProductCategory)
                .HasForeignKey(e => e.CategoryId)
                .WillCascadeOnDelete(false);
        }

        #endregion
    }
}
