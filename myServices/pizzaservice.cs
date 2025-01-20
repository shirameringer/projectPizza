using myModels;
using myModels.Interfaces;
using fileScdervices.Interface;

namespace myServices;
public class pizzaService : Ipizza
{
  private readonly IfileServices<Pizza> _IFileService;
  public pizzaService(IfileServices<Pizza> fileService)
  {

    _IFileService = fileService;
  }
  List<Pizza> type = new List<Pizza>(){
      new Pizza(10,true,"pizza binica",50),
      new Pizza(13,true,"pizza orginal",45),
      new Pizza(16,false,"pizza special",100),
      new Pizza(12,true,"pizza xl",70),
      new Pizza(11,true,"pizza bolgarit",68.5),
    };
  public string GetPizzaNameById(int id)
  {
    var pizzasList = _IFileService.Read();
    foreach (var i in pizzasList)
    {
      if (i.id == id)
      {
        return i.pizzaName;
      }
    }
    return null;

  }


  public double GetPizzaPriceById(string name)
  {
    var pizzasList = _IFileService.Read();
    foreach (var i in pizzasList)
    {
      if (i.pizzaName.Equals(name))
      {
        return i.price;
      }

    }
    return 0;
  }


  public bool UpdateId(int id, int newid)
  {
    var pizzasList = _IFileService.Read();
    foreach (var i in pizzasList)
    {
      if (i.id == id)
      {
        i.id = newid;
        return true;
      }

    }
    return false;

  }


  public bool DeleletPizza(string name)
  {
    var pizzasList = _IFileService.Read();
    foreach (var i in pizzasList)
    {
      if (i.pizzaName == name)
      {
        type.Remove(i);
        return true;
      }

    }
    return false;

  }

  public void AddPizza(int id, bool ifgloten, string pizzaName, double price)
  {
    Pizza pizza=new Pizza(id, ifgloten, pizzaName, price);
   _IFileService.Write(pizza);

  }



}

