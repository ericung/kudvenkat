using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kudvenkat.Controllers
{
  public class AccountController : Controller
  {
    [HttpGet]
    public IActionResult Register()
    {
      return View();
    }
  }
}
