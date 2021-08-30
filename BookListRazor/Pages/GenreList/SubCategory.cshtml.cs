using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.GenreList
{
    public class SubCategoryModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public SubCategoryModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Genre Genre { get; set; }
        public async Task<IActionResult> OnGet(int? id)
        {
            Genre = new Genre();

            //Create
            if (id == null)
                return Page();

            //Update
            Genre = await _db.Genre.FirstOrDefaultAsync(x => x.Id == id);
            if (Genre == null)
                return NotFound();

            return Page();
        }

        //public async Task<IActionResult> OnPost()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (Genre.Id == 0)
        //            _db.Genre.Add(Genre);
        //        else
        //            _db.Genre.Update(Genre);

        //        await _db.SaveChangesAsync();

        //        return RedirectToPage("Index");
        //    }
        //    return Page();
        //}
    }
}
