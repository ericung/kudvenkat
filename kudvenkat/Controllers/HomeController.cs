﻿using kudvenkat.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kudvenkat.Controllers
{
  public class HomeController : Controller
  {
    private IEmployeeRepository _employeeRepository;

    public HomeController(IEmployeeRepository employeeRepository)
    {
      _employeeRepository = employeeRepository;
    }

    public string Index()
    {
      return _employeeRepository.GetEmployee(1).Name;
    }
  }
}