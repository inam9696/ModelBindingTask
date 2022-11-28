using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ModelBindingTask.Models;
using System.Collections.Generic;

namespace ModelBindingTask.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
