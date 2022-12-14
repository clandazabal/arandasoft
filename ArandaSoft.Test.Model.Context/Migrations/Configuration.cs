namespace ArandaSoft.Test.Model.Context.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ArandaSoft.Test.Model.Entity;

    internal sealed class Configuration : DbMigrationsConfiguration<ArandaSoftTestContext>
    {
        #region Constructor

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "ArandaSoft.Test.Model.Context.ArandaSoftTestContext";
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Metodo sobreescrito de inicio.
        /// Carga de datos inicial.
        /// </summary>
        /// <param name="context">ArandaSoftTestContext</param>
        protected override void Seed(ArandaSoftTestContext context)
        {
            if (context.ProductCategory.Count() == 0)
            {
                IList<ProductCategory> defaultCategory = new List<ProductCategory>();
                defaultCategory.Add(new ProductCategory { Id = 1, Name = "Tecnología" });
                defaultCategory.Add(new ProductCategory { Id = 2, Name = "Electrodomésticos" });
                defaultCategory.Add(new ProductCategory { Id = 3, Name = "Vestuario" });
                defaultCategory.Add(new ProductCategory { Id = 4, Name = "Hogar" });
                defaultCategory.Add(new ProductCategory { Id = 5, Name = "Ferretería" });
                context.ProductCategory.AddRange(defaultCategory);
            }

            string strImage = @"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";
            byte[] bytes = Convert.FromBase64String(strImage);

            if (context.Product.Count() == 0)
            {
                IList<Product> defaultCategory = new List<Product>();
                defaultCategory.Add(new Product { Id = 1, CategoryId = 3, Name = "Camisa", Description = "Camisa manga larga talla M", Image = bytes });
                defaultCategory.Add(new Product { Id = 2, CategoryId = 2, Name = "Televisor", Description = "Televisor LCD 48 pulgadas", Image = null });
                defaultCategory.Add(new Product { Id = 3, CategoryId = 5, Name = "Pintura", Description = "Pintura viniltex color blanco tipo 1", Image = null });
                defaultCategory.Add(new Product { Id = 4, CategoryId = 5, Name = "Bombillo", Description = "Bombillo 75W Elexctrolux", Image = null });
                defaultCategory.Add(new Product { Id = 5, CategoryId = 4, Name = "Sofá"});
                defaultCategory.Add(new Product { Id = 6, CategoryId = 1, Name = "Celular", Description = "Celular Samsung Galaxy 20", Image = bytes });
                defaultCategory.Add(new Product { Id = 7, CategoryId = 1, Name = "Celular", Description = "Celular iPhone 13 pro", Image = null });
                defaultCategory.Add(new Product { Id = 8, CategoryId = 4, Name = "Comedor", Description = "Comedor de 6 puestos color blanco", Image = null });
                defaultCategory.Add(new Product { Id = 9, CategoryId = 2, Name = "Nevera", Description = "", Image = bytes });
                context.Product.AddRange(defaultCategory);
            }

            base.Seed(context);
        }

        #endregion
    }
}
