﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BancoCore
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class bancodbEntities : DbContext
    {
        public bancodbEntities()
            : base("name=bancodbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Conta> Conta { get; set; }
        public virtual DbSet<Correntista> Correntista { get; set; }
        public virtual DbSet<Lancamentos> Lancamentos { get; set; }
    }
}
