﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kudvenkat.Models
{
  public interface IEmployeeRepository
  {
    IEnumerable<Employee> GetAllEmployees();

    Employee GetEmployee(int Id);

    Employee Add(Employee employee);

    Employee Update(Employee employeeChanges);

    Employee Delete(int id);
  }
}
