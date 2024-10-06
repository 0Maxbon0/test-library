using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace LibraryManagement.DAL.Repositories
{
    public class PenaltyRepository
    {
        private readonly LibraryContext _context;

        public PenaltyRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<List<Penalty>> GetAllPenaltiesAsync()
        {
            return await _context.Penalties.ToListAsync();
        }

        public async Task<Penalty> GetPenaltyByIdAsync(int id)
        {
            return await _context.Penalties.FindAsync(id);
        }

        public async Task AddPenaltyAsync(Penalty penalty)
        {
            await _context.Penalties.AddAsync(penalty);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePenaltyAsync(Penalty penalty)
        {
            _context.Penalties.Update(penalty);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePenaltyAsync(int id)
        {
            var penalty = await GetPenaltyByIdAsync(id);
            if (penalty != null)
            {
                _context.Penalties.Remove(penalty);
                await _context.SaveChangesAsync();
            }
        }
    }
}
