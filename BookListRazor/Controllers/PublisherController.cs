using BookListRazor.Data;
using BookListRazor.Model.Common;
using BookListRazor.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PublisherController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly PublisherService _publisherService;

        public PublisherController(ApplicationDbContext db, PublisherService publisherService)
        {
            _db = db;
            _publisherService = publisherService;
        }

        //[HttpGet]
        //public JsonResult GetAll()
        //{
        //    return Json(new { data =  _db.Publisher.ToList() });
        //}

        [HttpGet]
        public async Task<JsonResult> GetAll()
        {
            return Json(new { data = await _db.Publisher.ToListAsync()});
        }

        [HttpGet]
        public JsonResult GetPublisherCombo()
        {
            var list = _db.Publisher.Select(x => new IdTextPair { id = x.Id, text = x.Name }).ToList();

            return Json(list);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var record = await _db.Publisher.FindAsync(id);
            if (record is null)
                return Json(new { success = false, message = "Error while deleting" });

            var result = _publisherService.ValidateDeletion(record);

            if (!result.Result)
                return Json(new { success = false, message = result.Message });

            _db.Publisher.Remove(record);

            await _db.SaveChangesAsync();

            return Json(new { success = true, message = "Delete successful" });
        }
    }
}
