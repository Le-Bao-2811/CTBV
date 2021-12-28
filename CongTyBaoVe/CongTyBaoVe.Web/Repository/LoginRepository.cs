using CongTyBaoVe.Web.Entites;
using CongTyBaoVe.Web.ViewModels;
using Microsoft.AspNetCore.Authentication;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CongTyBaoVe.Web.Repository
{
	public class LoginRepository: RepositoryBase
	{		
		public LoginRepository(CongTyBaoVeDbContext _db):base(_db)
		{

		}
		public string MD5Hasher(string username, string pwd)
		{
			string input = username + pwd;
			MD5 md5 = new MD5CryptoServiceProvider();
			byte[] fromData = Encoding.UTF8.GetBytes(input);
			byte[] targetData = md5.ComputeHash(fromData);
			string byte2String = null;

			for (int i = 0; i < targetData.Length; i++)
			{
				byte2String += targetData[i].ToString("x2");
			}
			return byte2String;
		}
		//public User Login(string Username = "", string Pasword = "")
		//{
		//	return db.users.Where(x => x.UserName == Username && x.PasswordHash == Pasword).SingleOrDefault();
		//}
		public async Task SignUp(UserVM userVM)
		{
			User user = new User();
			userVM.UserName = userVM.UserName.Replace(" ", "").ToLower();
			userVM.Password = MD5Hasher(userVM.UserName, userVM.Password);
			user.UserName = userVM.UserName;
			user.PasswordHash = userVM.Password;
			user.IsAdmin = userVM.IsAdmin;
			await db.users.AddAsync(user);
			//await db.SaveChangesAsync();
			
		}
		public  User ASno(LoginVM model)
		{
		 	return db.users
						.AsNoTracking()
						.SingleOrDefault(u => u.UserName == model.UserName);
		}
		public async Task<List<User>> ToList(int data)
		{
			return await db.users.Where(x=>x.Id!=data)
				.ToListAsync();
		}
		public void Delete(int id)
		{
			db.users.Remove(db.users.Find(id));
			db.SaveChanges();
		}
		public async Task<bool> CheckUsername(string username)
        {
			var isUser = await db.users.AnyAsync(x => x.UserName == username);
			return isUser;
        }
	}
}
