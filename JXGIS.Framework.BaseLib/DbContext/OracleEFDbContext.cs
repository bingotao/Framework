using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXGIS.Framework.BaseLib
{
    public class OracleEFDbContext : DbContext
    {
        static readonly string _conStr = (string)SystemUtils.Config.OracleDbConStr;
        public OracleEFDbContext() : base(_conStr)
        {
            this.Database.Initialize(false);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            string connectionString = _conStr;
            int indexOf = connectionString.IndexOf("USER ID", StringComparison.OrdinalIgnoreCase);
            string str = connectionString.Substring(indexOf);
            int startIndexOf = str.IndexOf("=", StringComparison.OrdinalIgnoreCase);
            int lastIndexOf = str.IndexOf(";", StringComparison.OrdinalIgnoreCase);
            string uid = str.Substring(startIndexOf + 1, lastIndexOf - startIndexOf - 1).Trim().ToUpper();
            modelBuilder.HasDefaultSchema(uid);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
