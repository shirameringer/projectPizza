using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using myModels.Interfaces;
namespace porjectPizza.Controllers;
public class PizzaController : Basecontrollers
{
     Ipizza _pizza;
       public PizzaController(Ipizza pizza)
        {
            _pizza = pizza;
        }
    
   

[Route("[action]/{id}")]
[HttpGet] 
 public IActionResult GetPizzaName(int id){
   string s1;
   s1=_pizza.GetPizzaName(id);
   if(s1!=null){
     return Ok(s1);
     
   }
   
    return NotFound(s1);
 }

   
[Route("[action]/{name}")]
[HttpGet] 
public IActionResult GetPizzaprice(string name){
   double price;
   price=_pizza.GetPizzaprice(name);
   if(price>0)
   return Ok(price);
return NotFound();
}


[Route("[action]/{id}/{newid}")]
[HttpPut] 
public IActionResult UpdateId(int id,int newid){
  bool flag;
   flag=_pizza.UpdateId(id,newid);
   if(flag==true)
   return Ok("update");
    return NotFound();

}

[Route("[action]/{name}")]
[HttpDelete] 
public IActionResult DeleletItem(string name){
  bool flag;
   flag=_pizza.DeleletItem(name);
   if(flag==true)
   return Ok("delete");
    return NotFound();

}

[Route("[action]/{id}/{ifgloten}/{pizzaName}")]
[HttpPost] 
public IActionResult AddItem(int id,bool ifgloten,string pizzaName,double price){

_pizza.AddItem(id,ifgloten,pizzaName,price);
return Ok("add item");
}

}

