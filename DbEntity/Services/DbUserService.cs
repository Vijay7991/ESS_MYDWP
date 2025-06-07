// Services/DbUserService.cs
using System.ComponentModel;
using System.Diagnostics;
using DBEnity.Data;
using DbEntity.Models;
using Globals.Models;
using Microsoft.EntityFrameworkCore;

namespace DBEnity.Services
{
    public class DbUserService
    {
        private readonly AppDbContext _context;

        public DbUserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync(); 
        }

        public async Task<bool> GetUser(string userName, string password)
        {
            return await _context.Users.AnyAsync(u => u.UserName == userName && u.Password == password);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
