using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using vega.Models;
using vega.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Vega.Controllers
{
    public class MakesController: Controller
    {
        private readonly VegaDbContext context;
        public MakesController(VegaDbContext context)
        {
            this.context = context;
        }
        [HttpGet("/api/makes")]
        public IEnumerable<MakesController> GetMakes()
        {
            return context.Makes.Include(m=> m.Models) ;
        }
    }
}