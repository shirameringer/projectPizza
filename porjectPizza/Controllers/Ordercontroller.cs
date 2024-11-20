using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using myModels.Interfaces;
namespace porjectPizza.Controllers;

    
    public class Ordercontroller : Basecontrollers
    {
       Iorder _order;

        public Ordercontroller(Iorder order)
        {
           _order=order;
        }
    [Route("[action]/{pizzaName}/{count}/{customerName}")]
    [HttpPost]     
    public  IActionResult postOrder(string pizzaName, int count, string customerName){
     _order.postOrder(pizzaName,count,customerName);
        return Ok("the added succesfuly");
    }
       
    }
