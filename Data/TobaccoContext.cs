using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TobaccoStore.Entities;

namespace TobaccoStore.Data
{
    public class TobaccoContext : DbContext
    {
        public TobaccoContext(DbContextOptions<TobaccoContext> options)
            : base(options)
        { }
        public DbSet<TobaccoEntity> Tobacco { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<RoleEntity> Roles {get; set;}

        
       

        public async Task<ActionResult<List<OrderEntity>>> getOrders()
        {
            return await Orders.Include(i=>i.Customer).Include(i=>i.Purchases).ToListAsync();
        }
        
       
    }

    

}
