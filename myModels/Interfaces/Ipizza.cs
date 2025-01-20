using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace myModels.Interfaces;

public interface Ipizza{
string  GetPizzaNameById(int id);
double GetPizzaPriceById(string name);
bool UpdateId(int id,int newid);
bool DeleletPizza(string name);
void AddPizza(int id,bool ifgloten,string pizzaName,double price);
}
