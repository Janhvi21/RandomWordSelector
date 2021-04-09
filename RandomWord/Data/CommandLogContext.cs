using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RandomWord.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomWord.Data
{
    public class CommandLogContext : DbContext
    {
        public DbSet<CommandLog> commandLogs { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connString = Startup.Configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connString);
        }
    }

}
