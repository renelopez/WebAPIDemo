using System.Linq;
using Breeze.ContextProvider;
using Breeze.ContextProvider.EF6;
using Newtonsoft.Json.Linq;

namespace WebApiDemo.Data
{
    public class Repository : IRepository
    {
        private readonly EFContextProvider<WebAPIDemoContext>_contextProvider=new EFContextProvider<WebAPIDemoContext>();

        public string MetaData
        {
            get { return _contextProvider.Metadata(); }
        }
        public SaveResult SaveChanges(JObject saveBundle)
        {
            return _contextProvider.SaveChanges(saveBundle);
        }

        public IQueryable<Book> Books()
        {
            return _contextProvider.Context.Books;
        }

        public IQueryable<Order> Orders()
        {
            return _contextProvider.Context.Orders;
        }
    }
}