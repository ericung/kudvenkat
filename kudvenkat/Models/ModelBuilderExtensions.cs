using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace kudvenkat.Models
{
  public static class ModelBuilderExtensions
  {
    public static void Seed(this ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Employee>().HasData(
          new Employee
          {
            Id = 1,
            Name = "Mary",
            Department = Dept.IT,
            Email = "mary@pragimtech.com"
          },
          new Employee
          {
            Id = 2,
            Name = "John",
            Department = Dept.HR,
            Email = "john@pragimtech.com"
          }
      );

    }
  }
}
