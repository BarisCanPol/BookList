using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.AuthorList
{
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Author Author { get; set; }
        public async Task<IActionResult> OnGet(int? id)
        {
            Author = new Author();

            //Create
            if (id == null)
                return Page();

            //Update
            Author = await _db.Author.FirstOrDefaultAsync(x => x.Id == id);
            if (Author == null)
                return NotFound();

            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Author.Id == 0)
                    _db.Author.Add(Author);
                else
                    _db.Author.Update(Author);

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
