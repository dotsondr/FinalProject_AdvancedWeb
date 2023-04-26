using Microsoft.EntityFrameworkCore;
using DRDLab7RelatedData1.Models.Entities;
using System;

namespace RelatedDataCreateRead.Services
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Book => Set<Book>();

        public DbSet<Author> Author => Set<Author>();

        public ApplicationDbContext(DbContextOptions options) : base(options) { }


    }
}