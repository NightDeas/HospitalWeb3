using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
	internal static class DataBaseService
	{
		/// <summary>
		/// Возвращает строку подключения из appsettings.json
		/// </summary>
		internal static string GetConnectionString()
		{
			return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				//.AddJsonFile("appsettings.json", false, true)
				.AddJsonFile("appsettings.Development.json", true, true);
			var config = builder.Build();
			string connection = config.GetConnectionString("home");
			return connection;
		}
	}
}
