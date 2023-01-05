using jQueryDataTable.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace jQueryDataTable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationContext db;

        public CustomersController(ApplicationContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public IActionResult GetCustomers()
        {

            var pageSize = int.Parse(Request.Form["length"]);
            var skip = int.Parse(Request.Form["start"]);

            var SearchValue = Request.Form["search[value]"];

            var sortColumn = Request.Form[string.Concat("columns[", Request.Form["order[0][column]"], "][name]")];

            var sortColumnDirection = Request.Form["order[0][dir]"];

            IQueryable<Customer> customers = db.Customers.Where(m=> 
            string.IsNullOrEmpty(SearchValue)?true
            :(m.FirstName.Contains(SearchValue))
            ||m.LastName.Contains(SearchValue)
            ||m.Contact.Contains(SearchValue)
            ||m.Email.Contains(SearchValue));

            if (!(string.IsNullOrEmpty(sortColumn)&&string.IsNullOrEmpty(sortColumnDirection)))
            {
               customers= customers.OrderBy(string.Concat(sortColumn, " ", sortColumnDirection));
            }
            var data = customers.Skip(skip).Take(pageSize).ToList();
            var recoredsTotal=customers.Count();
             
            //reservid Names in dataTables==>
            /*
             recoredsTotal,
            recoredsFiltered,
            data
             
             */
            var JsonData = new
            {
                recoredsFiltered = recoredsTotal,
                recoredsTotal,
                data
            };
            return Ok(JsonData);
        }
    }
}
