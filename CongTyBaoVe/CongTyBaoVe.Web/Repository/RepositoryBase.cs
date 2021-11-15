using CongTyBaoVe.Web.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CongTyBaoVe.Web.Repository
{
	public class RepositoryBase
	{
		public CongTyBaoVeDbContext db;
		public RepositoryBase()
		{
			db = new CongTyBaoVeDbContext();
		}
		public RepositoryBase(CongTyBaoVeDbContext _db)
		{
			db = _db;
		}
		public async Task Save()
		{
			await db.SaveChangesAsync();
		}
		public void Copy<TModel>(TModel from, TModel to, string skipProperties = "")
		{
			var type = from.GetType();
			var arrSkipProperties = skipProperties.Split(',').Select(x => x.Trim()).ToList();
			foreach (var prop in type.GetProperties())
			{
				if (arrSkipProperties.IndexOf(prop.Name) < 0)
				{
					prop.SetValue(to, prop.GetValue(from));
				}
			}
		}
	}
}
