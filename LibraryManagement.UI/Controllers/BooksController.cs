using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Models;
using LibraryManagement.DAL.Repositories;

namespace LibraryManagement.UI.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepository _bookRepository;

        // Constructor accepting the BookRepository via Dependency Injection
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // عرض قائمة الكتب
        public async Task<IActionResult> Index()
        {
            var books = await _bookRepository.GetAllBooksAsync(); // Fetch books via repository
            return View(books);
        }

        // عرض نموذج إضافة كتاب
        public IActionResult Create()
        {
            return View();
        }

        // إضافة كتاب جديد
        [HttpPost]
        public async Task<IActionResult> Create(Book model)
        {
            if (ModelState.IsValid)
            {
                await _bookRepository.AddBookAsync(model); // Add book via repository
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // عرض نموذج تعديل كتاب
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id); // Fetch book by id via repository
            if (book == null) return NotFound();

            return View(book);
        }

        // تعديل كتاب موجود
        [HttpPost]
        public async Task<IActionResult> Edit(Book model)
        {
            if (ModelState.IsValid)
            {
                await _bookRepository.UpdateBookAsync(model); // Update the book via repository
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // حذف كتاب
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id); // Fetch book by id via repository
            if (book == null) return NotFound();

            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _bookRepository.DeleteBookAsync(id); // Delete book via repository
            return RedirectToAction(nameof(Index));
        }

        // عرض نموذج إضافة أو تعديل كتاب
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            Book book;

            if (id == 0)
            {
                book = new Book(); // نموذج جديد
            }
            else
            {
                book = await _bookRepository.GetBookByIdAsync(id); // Fetch book by id via repository
                if (book == null) return NotFound();
            }

            return View(book);
        }

        // إضافة أو تعديل كتاب
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(Book model)
        {
            if (ModelState.IsValid)
            {
                if (model.BookID == 0)
                {
                    await _bookRepository.AddBookAsync(model); // Add book if ID = 0
                }
                else
                {
                    await _bookRepository.UpdateBookAsync(model); // Update book if exists
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
