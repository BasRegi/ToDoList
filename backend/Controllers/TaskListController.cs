using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/lists")]
    [ApiController]
    public class TaskListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
