using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;


namespace LibraryManagement.DAL.Repositories
{
    public class ReturnRepository
    {
        private readonly LibraryContext _context;

        public ReturnRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<List<Return>> GetAllReturnsAsync()
        {
            return await _context.Returns.ToListAsync();
        }

        public async Task<Return> GetReturnByIdAsync(int id)
        {
            return await _context.Returns.FindAsync(id);
        }

        public async Task AddReturnAsync(Return returnItem)
        {
            await _context.Returns.AddAsync(returnItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReturnAsync(Return returnItem)
        {
            _context.Returns.Update(returnItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReturnAsync(int id)
        {
            var returnItem = await GetReturnByIdAsync(id);
            if (returnItem != null)
            {
                _context.Returns.Remove(returnItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}
