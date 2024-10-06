using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;


namespace LibraryManagement.DAL.Repositories
{
    public class MemberRepository
    {
        private readonly LibraryContext _context;

        public MemberRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<List<Member>> GetAllMembersAsync()
        {
            return await _context.Members.ToListAsync();
        }

        public async Task<Member> GetMemberByIdAsync(int id)
        {
            return await _context.Members.FindAsync(id);
        }

        public async Task AddMemberAsync(Member member)
        {
            await _context.Members.AddAsync(member);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMemberAsync(Member member)
        {
            _context.Members.Update(member);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMemberAsync(int id)
        {
            var member = await GetMemberByIdAsync(id);
            if (member != null)
            {
                _context.Members.Remove(member);
                await _context.SaveChangesAsync();
            }
        }
    }
}
