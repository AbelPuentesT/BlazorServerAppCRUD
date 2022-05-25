using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorServerCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerCRUD.Data
{
    public class BookContext: DbContext
    {
        public DbSet<Book>? Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog=BlazorServerCRUD");
        }
    }
}