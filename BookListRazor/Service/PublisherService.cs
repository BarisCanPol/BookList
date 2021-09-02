using BookListRazor.Data;
using BookListRazor.Service.Interface;
using BookListRazor.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Service
{
    public class PublisherService : IValidation<Publisher>
    {
        private readonly ApplicationDbContext _db;

        public PublisherService(ApplicationDbContext db)
        {
            _db = db;
        }
        public ResultInfo ValidateDeletion(Publisher entity)
        {
            var books = _db.Book.Where(x => x.PublisherId == entity.Id).ToList();

            if (books != null)
                return new ResultInfo(false, "This record used in a Book");

            return new ResultInfo(true, "");
        }
    }
}
