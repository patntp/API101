using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Revise.Models
{
    public class ReviseContext : DbContext
    {
        public ReviseContext(DbContextOptions<ReviseContext> options)
            : base(options)
        {
        }
        public DbSet<ReviseItem> ReviseItems { get; set; }
    }
}
