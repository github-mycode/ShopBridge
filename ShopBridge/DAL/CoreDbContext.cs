using Microsoft.EntityFrameworkCore;
using ShopBridge.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.DAL
{
    public class CoreDbContext:DbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options)
         : base(options)
        {
        }
        public DbSet<Item> item { get; set; }

        
    }
}
