using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.BookList
{
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Book Book { get; set; }
        public async Task<IActionResult> OnGet(int? id)
        {
            Book = new Book();

            //Create
            if (id == null)
                return Page();

            //Update
            Book = await _db.Book.FirstOrDefaultAsync(x => x.Id == id);
            if (Book == null)
                return NotFound();

            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Book.Id == 0)
                    _db.Book.Add(Book);
                else
                    _db.Book.Update(Book);


                var record = await _db.Book.FindAsync(Book.Id);
                record.Name = Book.Name;
                record.ISBN = Book.ISBN;
                record.Author = Book.Author;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}