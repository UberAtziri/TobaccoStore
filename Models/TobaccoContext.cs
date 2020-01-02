using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TobaccoStore.Models
{
    public class TobaccoContext : DbContext
    {
        public TobaccoContext(DbContextOptions<TobaccoContext> options)
            : base(options)
        { }
        public DbSet<TobaccoModel> Tobacco { get; set; }
    }
}
