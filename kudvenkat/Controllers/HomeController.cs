using kudvenkat.Models;
using kudvenkat.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace kudvenkat.Controllers
{
  public class HomeController : Controller
  {
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IHostingEnvironment _hostingEnvironment;

    public HomeController(IEmployeeRepository employeeRepository, 
        IHostingEnvironment hostingEnvironment)
    {
      _employeeRepository = employeeRepository;
      _hostingEnvironment = hostingEnvironment;
    }

    public ViewResult Index()
    {
      var model = _employeeRepository.GetAllEmployees();
      return View(model);
    }

    public ViewResult Details(int? id)
    {
      HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
      {
        Employee = _employeeRepository.GetEmployee(id ?? 1),
        PageTitle = "Employee Details"
      };

      return View(homeDetailsViewModel);
    }

    [HttpGet]
    public ViewResult Edit(int id)
    {
      Employee employee = _employeeRepository.GetEmployee(id);
      EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel
      {
        Id = employee.Id,
        Name = employee.Name,
        Email = employee.Email,
        Department = employee.Department,
        ExistingPhotoPath = employee.PhotoPath
      };
      return View(employeeEditViewModel);
    }

    // Through model binding, the action method parameter
    // EmployeeEditViewModel receives the posted edit form data
    [HttpPost]
    public IActionResult Edit(EmployeeEditViewModel model)
    {
      // Check if the provided data is valid, if not rerender the edit view
      // so the user can correct and resubmit the edit form
      if (ModelState.IsValid)
      {
        // Retrieve the employee being edited from the database
        Employee employee = _employeeRepository.GetEmployee(model.Id);
        // Update the employee object with the data in the model object
        employee.Name = model.Name;
        employee.Email = model.Email;
        employee.Department = (Dept)model.Department;

        // If the user wants to change the photo, a new photo will be
        // uploaded and the Photo property on the model object receives
        // the uploaded photo. If the Photo property is null, user did
        // not upload a new photo and keeps his existing photo
        if (model.Photos != null)
        {
          // If a new photo is uploaded, the existing photo must be
          // deleted. So check if there is an existing photo and delete
          if (model.ExistingPhotoPath != null)
          {
            string filePath = Path.Combine(_hostingEnvironment.WebRootPath,
                "images", model.ExistingPhotoPath);
            System.IO.File.Delete(filePath);
          }
          // Save the new photo in wwwroot/images folder and update
          // PhotoPath property of the employee object which will be
          // eventually saved in the database
          employee.PhotoPath = ProcessUploadedFile(model);
        }

        // Call update method on the repository service passing it the
        // employee object to update the data in the database table
        Employee updatedEmployee = _employeeRepository.Update(employee);

        return RedirectToAction("index");
      }

      return View(model);
    }

    [HttpGet]
    public ViewResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(EmployeeCreateViewModel model)
    {
      if (ModelState.IsValid)
      {
        // Employee newEmployee = _employeeRepository.Add(employee);
        // return RedirectToAction("Details", new { id = newEmployee.Id });
        string uniqueFileName = null;

        if (model.Photos != null && model.Photos.Count > 0)
        {
          // Loop thru each selected file
          foreach (IFormFile photo in model.Photos)
          {
            // The file must be uploaded to the images folder in wwwroot
            // To get the path of the wwwroot folder we are using the injected
            // IHostingEnvironment service provided by ASP.NET Core
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
            // To make sure the file name is unique we are appending a new
            // GUID value and and an underscore to the file name
            uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(photo.FileName);
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            // Use CopyTo() method provided by IFormFile interface to
            // copy the file to wwwroot/images folder
            photo.CopyTo(new FileStream(filePath, FileMode.Create));
          }
        }


        Employee newEmployee = new Employee
        {
          Name = model.Name,
          Email = model.Email,
          Department = (Dept)model.Department,
          PhotoPath = uniqueFileName
        };

        _employeeRepository.Add(newEmployee);
        return RedirectToAction("details", "home", new { id = newEmployee.Id });
      }

      return View();
    }

    private string ProcessUploadedFile(EmployeeCreateViewModel model)
    {
      string uniqueFileName = null;

      if (model.Photos != null)
      {
        string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
        uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.Photos[0].FileName);
        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
          model.Photos[0].CopyTo(fileStream);
        }
      }

      return uniqueFileName;
    }
  }
}
