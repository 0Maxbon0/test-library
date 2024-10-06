using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace LibraryManagement.DAL.Repositories

{
    public class CheckoutRepository
    {
        private readonly LibraryContext _context;

        public CheckoutRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<List<Checkout>> GetAllCheckoutsAsync()
        {
            return await _context.Checkouts.ToListAsync();
        }

        public async Task<Checkout> GetCheckoutByIdAsync(int id)
        {
            return await _context.Checkouts.FindAsync(id);
        }

        public async Task AddCheckoutAsync(Checkout checkout)
        {
            await _context.Checkouts.AddAsync(checkout);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCheckoutAsync(Checkout checkout)
        {
            _context.Checkouts.Update(checkout);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCheckoutAsync(int id)
        {
            var checkout = await GetCheckoutByIdAsync(id);
            if (checkout != null)
            {
                _context.Checkouts.Remove(checkout);
                await _context.SaveChangesAsync();
            }
        }
    }
}
