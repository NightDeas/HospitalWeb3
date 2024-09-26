using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    internal class ContextFactory : IDesignTimeDbContextFactory<Context>
    {
		public Context CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<Context>();
			optionsBuilder.UseSqlServer(DataBase.DataBaseService.GetConnectionString());
			return new Context(optionsBuilder.Options);
		}
    }
}
