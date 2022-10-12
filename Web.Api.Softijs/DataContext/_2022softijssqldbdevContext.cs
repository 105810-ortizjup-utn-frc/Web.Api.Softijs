using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Web.Api.Softijs.Models;

namespace Web.Api.Softijs.DataContext
{
    public partial class _2022softijssqldbdevContext : DbContext
    {
        public _2022softijssqldbdevContext()
        {
        }

        public _2022softijssqldbdevContext(DbContextOptions<_2022softijssqldbdevContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Persist Security Info = False;Data Source=2022-softijs-sql-server-dev.database.windows.net;User ID=softijs-web-api;Password=MeGustaElIceCream2022;Initial Catalog=2022-softijs-sql-db-dev");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
