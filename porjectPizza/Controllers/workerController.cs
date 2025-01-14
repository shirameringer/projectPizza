using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using fileScdervices.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using myModels;
using myModels.Interfaces;
namespace porjectPizza.Controllers;


public class workerController : Basecontrollers
{
    Iworker _worker;
    private readonly IfileServices<Worker> _IFileService;
    public workerController(Iworker worker, IfileServices<Worker> fileService)
    {
        _worker = worker;
        _IFileService = fileService;
    }

    [Route("[action]/{id}")]
    [HttpGet]
    [Authorize(Policy = "Admin")]
    public IActionResult getWorkerById(int id)
    {
        string w1;
        w1 = _worker.getWorkerById(id);
        if (w1 != null)
        {
            return Ok(w1);

        }

        return NotFound();
    }
    [Route("[action]/{id}/{ifgloten}/{pizzaName}")]
    [HttpPost]
    [Authorize(Policy = "Admin")]

    public IActionResult postworker(int id, string fname, string lNmae, string password, string role)
    {

        _worker.postworker(id, fname, lNmae, password, role);
        return Ok("add item");
    }
    [HttpGet]
    [Route("[action]")]
    public List<Worker> GetListOfWorker()
    {
        return _IFileService.Read();
    }
    [HttpPost]
    [Route("[action]")]
    [Authorize(Policy = "superWorker")]
    public void writeWorker([FromBody] Worker w)
    {
        _IFileService.Write(w);
    }

}
