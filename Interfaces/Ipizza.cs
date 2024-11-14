using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace porjectPizza.Interfaces
{
public interface Ipizza{
string  GetPizzaName(int id);
double GetPizzaprice(string name);
bool UpdateId(int id,int newid);
bool DeleletItem(string name);
void AddItem(int id,bool ifgloten,string pizzaName,double price);
}
}