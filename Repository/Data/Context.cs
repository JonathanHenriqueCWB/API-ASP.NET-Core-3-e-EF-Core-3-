using Microsoft.EntityFrameworkCore;
using Models.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
