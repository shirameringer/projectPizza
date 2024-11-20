using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using myModels.Interfaces;
namespace porjectPizza.Controllers;


    public class workerController : Basecontrollers
    {
        Iworker _worker;
        public workerController(Iworker worker)
        {
            _worker = worker;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public IActionResult getWorkerById(int id)
        {
           string w1;
            w1 = _worker.getWorkerById(id);
            if (w1!= null)
            {
                return Ok(w1);

            }

            return NotFound();
        }
        [Route("[action]/{id}/{ifgloten}/{pizzaName}")]
        [HttpPost]

        public IActionResult postworker(int id, string fname, string lNmae)
        {

            _worker.postworker(id, fname, lNmae);
            return Ok("add item");
        }
    }
