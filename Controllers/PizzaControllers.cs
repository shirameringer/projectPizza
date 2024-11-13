using Microsoft.AspNetCore.Mvc;
using webapi;

namespace h_w2.Controllers;


public class PizzaController : Basecontrollers
{
    
    List<Pizza>type=new List<Pizza>(){
      new Pizza(10,true,"pizza binica"),
      new Pizza(13,true,"pizza orginal"),
      new Pizza(16,false,"pizza special"),
      new Pizza(12,true,"pizza xl"),
      new Pizza(11,true,"pizza bolgarit"),
    };

[Route("[action]/{id}")]
[HttpGet] 
 public  IActionResult GetPizzaName(int id){
   foreach(var i in type){
    if(i.id==id){
        return Ok(i.pizzaName);
    }
   
   }
    return NotFound();

 }
[Route("[action]/{name}")]
[HttpGet] 
public IActionResult GetPizzaDetailse(string name){
foreach(var i in type){
   if(i.pizzaName==name){
      return Ok("name: "+i.pizzaName+",ifGloten: "+i.ifGloten+",id: "+i.id);
    }
      
}
return NotFound();
}
[Route("[action]/{id}/{newid}")]
[HttpPut] 
public IActionResult UpdateId(int id,int newid){
  foreach(var i in type){
    if(i.id==id){
     i.id=newid;
      return Ok("data update");
    }
   
   }
    return NotFound();

}

[Route("[action]/{name}")]
[HttpDelete] 
public IActionResult DeleletItem(string name){
foreach(var i in type){
    if(i.pizzaName==name){
       type.Remove(i);
      return Ok("this item is delete");
    }
   
   }
    return NotFound();

}
[Route("[action]/{id}/{ifgloten}/{pizzaName}")]
[HttpPost] 
public IActionResult AddItem(int id,bool ifgloten,string pizzaName){
type.Add(new Pizza(id,ifgloten,pizzaName));
return Ok("add item");
}

}