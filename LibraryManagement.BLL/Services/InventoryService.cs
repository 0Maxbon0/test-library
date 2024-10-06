using LibraryManagement.DAL;
using Microsoft.EntityFrameworkCore;
using Models;

namespace LibraryManagement.BLL.Services;

{
    public class InventoryService : IInventoryService
    {
        private readonly LibraryContext _context;

        public InventoryService(LibraryContext context)
        {
            _context = context;
        }

        public async Task<int> GetTotalItemsAsync()
        {
            return await _context.Products.CountAsync();
        }

        public async Task<int> GetLowStockItemsAsync()
        {
            return await _context.Products.CountAsync(p => p.stockQuantity < 5);
        }

        public async Task<int> GetUsersCountAsync()
        {
            return await _context.Users.CountAsync();
        }

        public async Task<List<ActivityModel>> GetRecentActivityAsync()
        {
            return await _context.Activities.OrderByDescending(a => a.Date).Take(5).ToListAsync();
        }
    }
}
