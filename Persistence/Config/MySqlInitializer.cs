using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Config
{
    public class MySqlInitializer : IDatabaseInitializer<MySqlHistoryContext>
    {
        public void InitializeDatabase(MySqlHistoryContext context)
        {
            if (!context.Database.Exists())
            {
                context.Database.Create();
            }
            else
            {
                var migrationHistoryTableExists = ((IObjectContextAdapter)context).ObjectContext.ExecuteStoreQuery<int>(
                    string.Format(
                        "SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = '{0}' AND table_name= '__MigrationHistory'",
                        "[Insert your database schema here - such as 'users']"
                    ));

                if (migrationHistoryTableExists.FirstOrDefault() == 0)
                {
                    context.Database.Delete();
                    context.Database.Create();
                }
            }
        }
    }
}
