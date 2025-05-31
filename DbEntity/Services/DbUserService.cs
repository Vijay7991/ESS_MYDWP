// Services/DbUserService.cs
using System.ComponentModel;
using System.Diagnostics;
using DBEnity.Data;
using DbEntity.Models;
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

        public async Task AddAsync(DbUser user)
        {
            _context.DbUsers.Add(user);
            await _context.SaveChangesAsync(); 
        }

        public async Task<bool> UserHas(string userName, string password)
        {
            return await _context.DbUsers.AnyAsync(u => u.UserName == userName && u.Password == password);
        }

        public async Task<List<DbUser>> GetAllAsync()
        {
            return await _context.DbUsers.ToListAsync();
        }
    }
}
