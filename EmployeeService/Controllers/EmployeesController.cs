﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeDataAccess;

namespace EmployeeService.Controllers
{
    public class EmployeesController : ApiController
    {
        public IEnumerable<Employee> Get()
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                return entities.Employees.ToList();
            }
        }
        //public Employee Get(int id)
        //{
        //    using (EmployeeDBEntities entities = new EmployeeDBEntities())
        //    {
        //        return entities.Employees.FirstOrDefault(e=>e.ID==id);
        //    }
        //}
        public HttpResponseMessage Get(int id)
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                var entity = entities.Employees.FirstOrDefault(e => e.ID == id);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id =" + id.ToString() + " not found");
                }
            }
        }
        public HttpResponseMessage Post([FromBody]Employee employee)
        //public void Post([FromBody]Employee employee)
        {
            try
            {
                using (EmployeeDBEntities entities = new EmployeeDBEntities())
                {
                    entities.Employees.Add(employee);
                    entities.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, employee);
                    message.Headers.Location = new Uri(Request.RequestUri + employee.ID.ToString());
                    return message;
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }
        //public void Delete(int id)
        //{
        //    using (EmployeeDBEntities entities = new EmployeeDBEntities())
        //    {
        //        entities.Employees.Remove(entities.Employees.FirstOrDefault(e => e.ID == id));
        //    }
        //}
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (EmployeeDBEntities entities = new EmployeeDBEntities())
                {
                    var entity = entities.Employees.FirstOrDefault(e => e.ID == id);
                    if (entity != null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id =" + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        entities.Employees.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }
        //public void Put(int id, [FromBody] Employee employee)
        //{
        //    using (EmployeeDBEntities entities = new EmployeeDBEntities())
        //    {
        //        var entity = entities.Employees.FirstOrDefault(e => e.ID == id);
        //        entity.FirstName = employee.FirstName;
        //        entity.LastName = employee.LastName;
        //        entity.Gender = employee.Gender;
        //        entity.Salary = employee.Salary;
        //        entities.SaveChanges();
        //    }
        //}
        public HttpResponseMessage Put(int id, [FromBody] Employee employee)
        {
            try
            {
                using (EmployeeDBEntities entities = new EmployeeDBEntities())
                {
                    var entity = entities.Employees.FirstOrDefault(e => e.ID == id);    
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id =" + id.ToString() + " not found to update");
                    }
                    else
                    {
                        entity.FirstName = employee.FirstName;
                        entity.LastName = employee.LastName;
                        entity.Gender = employee.Gender;
                        entity.Salary = employee.Salary;
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }
    }
}
