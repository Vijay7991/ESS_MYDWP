using DBEnity.Data;
using DbEntity.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DBEnity.Services
{
    public class DbLeaveService
    {
        private readonly AppDbContext _context;

        public DbLeaveService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(DbLeave leave)
        {
            _context.Leaves.Add(leave);
            await _context.SaveChangesAsync();
        }

        public async Task<List<DbLeave>> GetAllAsync()
        {
            return await _context.Leaves.ToListAsync();
        }

        public async Task<DbLeave?> GetByIdAsync(int id)
        {
            return await _context.Leaves.FindAsync(id);
        }

        public async Task UpdateAsync(DbLeave leave)
        {
            _context.Leaves.Update(leave);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var leave = await _context.Leaves.FindAsync(id);
            if (leave != null)
            {
                _context.Leaves.Remove(leave);
                await _context.SaveChangesAsync();
            }
        }
    }
}