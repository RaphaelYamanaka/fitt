﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FittDataBaseEntities : DbContext
    {
        public FittDataBaseEntities()
            : base("name=FittDataBaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<Aluno> Aluno { get; set; }
        public virtual DbSet<Anamnese> Anamnese { get; set; }
        public virtual DbSet<Boleto> Boleto { get; set; }
        public virtual DbSet<Matricula> Matricula { get; set; }
        public virtual DbSet<Professor> Professor { get; set; }
        public virtual DbSet<Turma> Turma { get; set; }
    }
}
