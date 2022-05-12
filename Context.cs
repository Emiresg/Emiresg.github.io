using Microsoft.EntityFrameworkCore;
using SistemYonetimi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemYonetimi
{
    public class Context:DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }



        public DbSet<Log> Logs { get; set; }
    }
}
