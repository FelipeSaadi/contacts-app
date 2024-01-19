using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using contacts_app.Models;
using Microsoft.EntityFrameworkCore;

namespace contacts_app.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ContactModel> Contacts {get; set;}
    }
}