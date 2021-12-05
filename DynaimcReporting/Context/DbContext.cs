using DynaimcReporting.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynaimcReporting.Context
{
    public class ReportContext : DbContext
    {
        public ReportContext()
        {
        }

        public ReportContext(DbContextOptions<ReportContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DefaultConnection");
            }
        }

        public DbSet<ReportMaster> ReportMasters { get; set; }
        public DbSet<ReportParameter> ReportParameters { get; set; }
        public DbSet<ReportType> ReportType { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
