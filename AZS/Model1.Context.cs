﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AZS
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class АЗСEntities : DbContext
    {
        public АЗСEntities()
            : base("name=АЗСEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DetailsOrdersSupply> DetailsOrdersSupplies { get; set; }
        public virtual DbSet<GasStation> GasStations { get; set; }
        public virtual DbSet<OrdersFromClient> OrdersFromClients { get; set; }
        public virtual DbSet<OrdersFromSupplier> OrdersFromSuppliers { get; set; }
        public virtual DbSet<Petrol> Petrols { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
