using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Merchandising.Application.Products.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Merchandising.WebUI.Controllers
{
    public class SearchController : ApiController
    {
        [HttpGet("{keyword}")]
        public async Task<ActionResult<ProductsVm>> Search(string keyword)
        {
            return await Mediator.Send(new SearchProductQuery { Keyword = keyword });
        }


    }
}
