using Microsoft.EntityFrameworkCore;
using RandomWord.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomWord.Data
{
    public class CommandLogContext:DbContext
    {
        public DbSet<CommandLog> commandLogs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=DB;Integrated Security=SSPI;");
        }
    }
   
}
