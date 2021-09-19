using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryBD
{
    public class GuichetContext : DbContext
    {
        public GuichetContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Ticket> Tickets
        {
            get;
            set;
        }
        public DbSet<Session> Sessions
        {
            set;
            get;
        }
        public DbSet<Category> Categories
        {
            get;
            set;
        }
        public DbSet<User> Users
        {
            get;
            set;
        }

    }
}
