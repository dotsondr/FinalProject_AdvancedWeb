using Microsoft.EntityFrameworkCore;
using FinalProject_AdvancedWeb.Models.Entities;
using System;
using FinalProject_AdvancedWeb.Models.ViewModels;

namespace FinalProject_AdvancedWeb.Services
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Shelf> Shelf => Set<Shelf>();

        public DbSet<Product> Product => Set<Product>();

        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<FinalProject_AdvancedWeb.Models.ViewModels.ShelfDetailsVM>? ShelfDetailsVM { get; set; }


    }
}