using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace TobaccoStore.Models
{
    public class TobaccoContext : DbContext
    {
        public TobaccoContext(DbContextOptions<TobaccoContext> options)
            : base(options)
        { }
        public DbSet<TobaccoModel> Tobacco { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OrderModel> Orders { get; set; }

        //HTTP GET
        public async Task<ActionResult<List<User>>> getUsers()
        {
            return await Users.ToListAsync();
        }

        public async Task<ActionResult<List<TobaccoModel>>> getTobacco()
        {
            return await Tobacco.ToListAsync();
        }
        public async Task<ActionResult<List<OrderModel>>> getOrders()
        {
            return await Orders.Include(i=>i.Customer).Include(i=>i.Purchases).ToListAsync();
        }
        
       
    }

    

}
