using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.JsonPatch;
namespace dating_app.models
{
    // set route attribute to make request as 'api/Product'
    [Route("api/[controller]")]
    public class valuec : Controller
    {
        private readonly StoreAppContext _context;
        // initiate database context
        public valuec(StoreAppContext context)
        {
            _context = context;
        }

     

        [HttpGet("{id}")]
        public value GetValue(long id)
        {   value result =_context.values.Find(id);
            return result;
        }


    [HttpGet]
    public List<value> GetValues()
    {    List<value> res=_context.values.ToList();

        return res;
    }

    }
}
