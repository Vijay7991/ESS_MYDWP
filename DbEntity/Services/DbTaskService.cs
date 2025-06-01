using DBEnity.Data;
using DbEntity.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DBEnity.Services
{
    public class DbTaskService
    {
        private readonly AppDbContext _context;

        public DbTaskService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(DbTask task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task<List<DbTask>> GetAllAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<DbTask?> GetByIdAsync(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task UpdateAsync(DbTask task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }
}