using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AqueDocWebService.Models;

namespace AqueDocWebService.Controllers
{
    public class TaskController : ApiController
    {
        // GET api/<controller>
        public List<TaskModel> Get()
        {
            List<TaskModel> models = new List<TaskModel>()
            {
                new TaskModel() {Id = 1, Description = "Описание задачи 1", Name = "Задача 1"},
                new TaskModel() {Id = 2, Description = "Описание задачи 2", Name = "Задача 2"},
                new TaskModel() {Id = 3, Description = "Описание задачи 3", Name = "Задача 3"},
                new TaskModel() {Id = 4, Description = "Описание задачи 4", Name = "Задача 4"},
                new TaskModel() {Id = 5, Description = "Описание задачи 5", Name = "Задача 5"},
            };
            return models;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}