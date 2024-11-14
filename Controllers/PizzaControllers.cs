using Microsoft.AspNetCore.Mvc;
using webapi;



namespace PROJECTPIZZA.Controllers;


public class PizzaController : Basecontrollers
{
     Ipizza _pizza;
       public PizzaController(Ipizza pizza)
        {
            _pizza = pizza;
        }
    
   

[Route("[action]/{id}")]
[HttpGet] 
 public  IActionResult cGetPizzaName(int id){
   string s1;
   s1=_pizza.GetPizzaName(id);
   if(s1!=null){
    Ok(s1);
   }
    return NotFound();

 }

   
[Route("[action]/{name}")]
[HttpGet] 
public IActionResult GetPizzaDetailse(string name){
   string s1;
   s1=_pizza.GetPizzaDetailse(name);
   if(s1!=null)
   return Ok(s1);
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
    
    return NotFound();

}

[Route("[action]/{id}/{ifgloten}/{pizzaName}")]
[HttpPost] 
public IActionResult AddItem(int id,bool ifgloten,string pizzaName){
// type.Add(new Pizza(id,ifgloten,pizzaName));
return Ok("add item");
}

}