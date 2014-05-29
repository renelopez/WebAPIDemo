using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Breeze.ContextProvider;
using Newtonsoft.Json.Linq;
using Breeze.WebApi2;
using WebApiDemo.Data;

namespace WebApiDemo.Services
{
    [BreezeController]
    public class BreezeController : ApiController
    {
        private IRepository _repo;

        public BreezeController(IRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public string Metadata()
        {
            return _repo.MetaData;
        }

        [HttpPost]
        public SaveResult SaveChanges(JObject saveBundle)
        {
            return _repo.SaveChanges(saveBundle);
        }

        [HttpGet]
        public IQueryable<Book> Books()
        {
            return _repo.Books();
        }

        [HttpGet]
        public IQueryable<Order> Orders()
        {
            return _repo.Orders();
        }
    }
}
