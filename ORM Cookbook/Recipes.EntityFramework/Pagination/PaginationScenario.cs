﻿using Recipes.EntityFramework.Entities;
using Recipes.Pagination;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Recipes.EntityFramework.Pagination
{
    public class PaginationScenario : IPaginationScenario<Employee>
    {
        private Func<OrmCookbookContext> CreateDbContext;

        public PaginationScenario(Func<OrmCookbookContext> dBContextFactory)
        {
            CreateDbContext = dBContextFactory;
        }

        public void InsertBatch(IList<Employee> employees)
        {
            using (var context = CreateDbContext())
            {
                context.Employee.AddRange(employees);
                context.SaveChanges();
            }
        }

        public IList<Employee> PaginateWithPageSize(string lastName, int page, int pageSize)
        {
            using (var context = CreateDbContext())
                return context.Employee.Where(e => e.LastName == lastName)
                    .OrderBy(e => e.FirstName).ThenBy(e => e.EmployeeKey)
                    .Skip(page * pageSize).Take(pageSize).ToList();
        }

        [SuppressMessage("Globalization", "CA1307")]
        public IList<Employee> PaginateWithSkipPast(string lastName, Employee? skipPast, int take)
        {
            using (var context = CreateDbContext())
            {
                if (skipPast == null)
                {
                    return context.Employee.Where(e => e.LastName == lastName)
                        .OrderBy(e => e.FirstName).ThenBy(e => e.EmployeeKey)
                        .Take(take).ToList();
                }
                else
                {
                    return context.Employee
                        .Where(e => (e.LastName == lastName) && (
                            (string.Compare(e.FirstName, skipPast.FirstName) > 0)
                                || (e.FirstName == skipPast.FirstName && e.EmployeeKey > skipPast.EmployeeKey))
                            )
                        .OrderBy(e => e.FirstName).ThenBy(e => e.EmployeeKey)
                        .Take(take).ToList();
                }
            }
        }

        public IList<Employee> PaginateWithSkipTake(string lastName, int skip, int take)
        {
            using (var context = CreateDbContext())
                return context.Employee.Where(e => e.LastName == lastName)
                    .OrderBy(e => e.FirstName).ThenBy(e => e.EmployeeKey)
                    .Skip(skip).Take(take).ToList();
        }
    }
}
