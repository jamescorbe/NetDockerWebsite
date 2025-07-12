using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDatabaseCore
{
    public class UserDatabaseContext : DbContext
    {
        public UserDatabaseContext(DbContextOptions<UserDatabaseContext> dbContextOptions): base(dbContextOptions) 
        {
            try
            {
                 var dbCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;

                if (dbCreator != null)
                {
                    if (!dbCreator.CanConnect()) dbCreator.Create();

                    if (!dbCreator.HasTables()) dbCreator.CreateTables();
                }

            }
            catch (Exception ex)
            {
            }
        }

        public virtual DbSet<DBUser> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
