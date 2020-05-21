using kudvenkat.Models;
using kudvenkat.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kudvenkat.Controllers
{
  public class HomeController : Controller
  {
    private readonly IEmployeeRepository _employeeRepository;

    public HomeController(IEmployeeRepository employeeRepository)
    {
      _employeeRepository = employeeRepository;
    }

    public ViewResult Index()
    {
      var model = _employeeRepository.GetAllEmployees();
      return View(model);
    }

    public ViewResult Details()
    {
      HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
      {
        Employee = _employeeRepository.GetEmployee(1),
        PageTitle = "Employee Details"
      };
      Employee model = _employeeRepository.GetEmployee(1);
      ViewBag.Employee = model;
      ViewBag.PageTitle = "Employee Details";

      return View(homeDetailsViewModel);
    }
  }
}
