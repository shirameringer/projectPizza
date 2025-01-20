using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using myModels;
using myModels.Interfaces;
namespace porjectPizza.Controllers;



public class Ordercontroller : Basecontrollers
{
   Iorder _order;

   public Ordercontroller(Iorder order)
   {
      _order = order;
   }
   [Route("[action]/{pizzaName}/{count}/{customerName}/{price}/{creditNum}/{validity}/{threeDigit}/{email}")]
   [HttpPost]
   public async Task<IActionResult> postOrder(string pizzaName, int count, string customerName, double price, long creditNum, string validity, int threeDigit, string email)
   {
      var result= await _order.postOrder(pizzaName, count, customerName, price, creditNum, validity, threeDigit, email);
      return Ok(result);
   }
   [Route("[action]")]
   [HttpPost]
   public async Task<IActionResult> toPayAsync()
   {
      var result = await _order.toPayAsync();
      return Ok(result);
   }


   [Route("[action]/{order}")]
   [HttpPost]
   public async Task<IActionResult> makeingPizzaAsync(Order order)
   {
      var result = await _order.makeingPizzaAsync(order);
      return Ok(result);
   }
   [Route("[action]")]
   [HttpPost]

   public IActionResult printBill(Order o)
   {
      printBill(o);
      return Ok("goood");

   }
}