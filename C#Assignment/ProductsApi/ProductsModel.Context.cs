﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProductsApi
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DBProductsEntities : DbContext
    {
        public DBProductsEntities()
            : base("name=DBProductsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<tblCategory> tblCategories { get; set; }
        public virtual DbSet<tblProduct> tblProducts { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }
    
        public virtual int DeleteProductDetails(string id)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteProductDetails", idParameter);
        }
    
        public virtual int InsertProductDetails(string id, string product_name, string categ, Nullable<decimal> price, Nullable<int> qty, string shortdesc, string longdesc, string smallimg, string lrgimg)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            var product_nameParameter = product_name != null ?
                new ObjectParameter("product_name", product_name) :
                new ObjectParameter("product_name", typeof(string));
    
            var categParameter = categ != null ?
                new ObjectParameter("categ", categ) :
                new ObjectParameter("categ", typeof(string));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("price", price) :
                new ObjectParameter("price", typeof(decimal));
    
            var qtyParameter = qty.HasValue ?
                new ObjectParameter("qty", qty) :
                new ObjectParameter("qty", typeof(int));
    
            var shortdescParameter = shortdesc != null ?
                new ObjectParameter("shortdesc", shortdesc) :
                new ObjectParameter("shortdesc", typeof(string));
    
            var longdescParameter = longdesc != null ?
                new ObjectParameter("longdesc", longdesc) :
                new ObjectParameter("longdesc", typeof(string));
    
            var smallimgParameter = smallimg != null ?
                new ObjectParameter("smallimg", smallimg) :
                new ObjectParameter("smallimg", typeof(string));
    
            var lrgimgParameter = lrgimg != null ?
                new ObjectParameter("lrgimg", lrgimg) :
                new ObjectParameter("lrgimg", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertProductDetails", idParameter, product_nameParameter, categParameter, priceParameter, qtyParameter, shortdescParameter, longdescParameter, smallimgParameter, lrgimgParameter);
        }
    
        public virtual int UpdateProductDetails(string id, string product_name, string categ, Nullable<decimal> price, Nullable<int> qty, string shortdesc, string longdesc, string smallimg, string lrgimg)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            var product_nameParameter = product_name != null ?
                new ObjectParameter("product_name", product_name) :
                new ObjectParameter("product_name", typeof(string));
    
            var categParameter = categ != null ?
                new ObjectParameter("categ", categ) :
                new ObjectParameter("categ", typeof(string));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("price", price) :
                new ObjectParameter("price", typeof(decimal));
    
            var qtyParameter = qty.HasValue ?
                new ObjectParameter("qty", qty) :
                new ObjectParameter("qty", typeof(int));
    
            var shortdescParameter = shortdesc != null ?
                new ObjectParameter("shortdesc", shortdesc) :
                new ObjectParameter("shortdesc", typeof(string));
    
            var longdescParameter = longdesc != null ?
                new ObjectParameter("longdesc", longdesc) :
                new ObjectParameter("longdesc", typeof(string));
    
            var smallimgParameter = smallimg != null ?
                new ObjectParameter("smallimg", smallimg) :
                new ObjectParameter("smallimg", typeof(string));
    
            var lrgimgParameter = lrgimg != null ?
                new ObjectParameter("lrgimg", lrgimg) :
                new ObjectParameter("lrgimg", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateProductDetails", idParameter, product_nameParameter, categParameter, priceParameter, qtyParameter, shortdescParameter, longdescParameter, smallimgParameter, lrgimgParameter);
        }
    }
}
