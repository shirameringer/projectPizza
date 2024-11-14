using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace PROJECTPIZZA;
using Microsoft.AspNetCore.Mvc;
using webapi;


public class pizzaService:Ipizza{
     List<Pizza>type=new List<Pizza>(){
      new Pizza(10,true,"pizza binica"),
      new Pizza(13,true,"pizza orginal"),
      new Pizza(16,false,"pizza special"),
      new Pizza(12,true,"pizza xl"),
      new Pizza(11,true,"pizza bolgarit"),
    };
    public  string  GetPizzaName(int id){
   foreach(var i in type){
    if(i.id==id){
         return i.pizzaName;
    }
   
   }
    return null;

 }


public string GetPizzaDetailse(string name){
foreach(var i in type){
   if(i.pizzaName==name){
      return "name: "+i.pizzaName+",ifGloten: "+i.ifGloten+",id: "+i.id;
    }
      
}
return null;
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

public string AddItem(int id,bool ifgloten,string pizzaName){
type.Add(new Pizza(id,ifgloten,pizzaName));
return "add item";
}

    public bool GetPizzaDetailse(int id, int newid)
    {
        throw new NotImplementedException();
    }
}