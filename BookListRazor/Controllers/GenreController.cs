using BookListRazor.Data;
using BookListRazor.Model.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Controllers
{
    [Route("api/[controller]/[action]")]
    public class GenreController : Controller
    {
        private readonly ApplicationDbContext _db;
        public GenreController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<JsonResult> GetAll()
        {
            return Json(new { data = await _db.Genre.ToListAsync() });
        }

        [HttpGet]
        public JsonResult GetGenreCombo()
        {
            var list = _db.Genre.Select(x => new IdTextPair { id = x.Id, text = x.GenreName }).ToList();

            return Json(list);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var record = await _db.Genre.FindAsync(id);
            if (record is null)
                return Json(new { success = false, message = "Error while deleting" });

            _db.Genre.Remove(record);

            await _db.SaveChangesAsync();

            return Json(new { success = true, message = "Delete successful" });
        }
    }
}
