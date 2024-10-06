using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LibraryManagement.DAL.Repositories; 
using Models; 

namespace LibraryManagement.UI.Controllers
{
    public class MembersController : Controller
    {
        private readonly MemberRepository _memberRepository;

        public MembersController(MemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        // عرض قائمة الأعضاء
        public async Task<IActionResult> Index()
        {
            var members = await _memberRepository.GetAllMembersAsync();
            return View(members);
        }

        // عرض نموذج إضافة عضو
        public IActionResult Create()
        {
            return View();
        }

        // إضافة عضو جديد
        [HttpPost]
        public async Task<IActionResult> Create(Member model)
        {
            if (ModelState.IsValid)
            {
                await _memberRepository.AddMemberAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // عرض نموذج تعديل عضو
        public async Task<IActionResult> Edit(int id)
        {
            var member = await _memberRepository.GetMemberByIdAsync(id);
            if (member == null) return NotFound();

            return View(member);
        }

        // تعديل عضو موجود
        [HttpPost]
        public async Task<IActionResult> Edit(Member model)
        {
            if (ModelState.IsValid)
            {
                await _memberRepository.UpdateMemberAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // حذف عضو
        public async Task<IActionResult> Delete(int id)
        {
            var member = await _memberRepository.GetMemberByIdAsync(id);
            if (member == null) return NotFound();

            return View(member);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _memberRepository.DeleteMemberAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
