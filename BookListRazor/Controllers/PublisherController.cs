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
    [ApiController]
    public class PublisherController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PublisherController(ApplicationDbContext db)
        {
            _db = db;
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
    }
}
