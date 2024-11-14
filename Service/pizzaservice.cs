using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace PROJECTPIZZA;
using Microsoft.AspNetCore.Mvc;
using porjectPizza.Interfaces;
using webapi;


public class pizzaService:Ipizza{
     List<Pizza>type=new List<Pizza>(){
      new Pizza(10,true,"pizza binica",50),
      new Pizza(13,true,"pizza orginal",45),
      new Pizza(16,false,"pizza special",100),
      new Pizza(12,true,"pizza xl",70),
      new Pizza(11,true,"pizza bolgarit",68.5),
    };
public  string  GetPizzaName(int id){
   foreach(var i in type){
      if(i.id==id){
        return i.pizzaName;
    }
  }
    return null;

 }


public double GetPizzaprice(string name){
foreach(var i in type){
   if(i.pizzaName.Equals(name)){
      return i.price;
    }
      
}
return 0;
}


public bool UpdateId(int id,int newid){
  foreach(var i in type){
    if(i.id==id){
     i.id=newid;
      return true;
    }
   
   }
    return false;

}


public bool DeleletItem(string name){
foreach(var i in type){
    if(i.pizzaName==name){
       type.Remove(i);
      return true;
    }
   
   }
    return false;

}

 public void AddItem(int id,bool ifgloten,string pizzaName,double price){
  
 type.Add(new Pizza(id,ifgloten,pizzaName,price));
  
}

   
}