namespace PizzaStore.DB;

public record Pizza
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}

public class PizzaDB
{
    private static Dictionary<int, Pizza> _pizzas = new Dictionary<int, Pizza>
   {
     { 1, new Pizza {Name = "Montemagno", Description = "A really tasty pizza"} },
     { 2, new Pizza {Name = "The Galloway", Description = "Pizza shaped like a submarine, silent but deadly"} },
     { 3, new Pizza {Name = "The Noring", Description = "Pizza shaped like a Viking helmet, where's the mead"} },
   };

    public static Dictionary<int, Pizza> GetPizzas()
    {
        return _pizzas;
    }

    public static Pizza? GetPizza(int key)
    {
        return _pizzas.ContainsKey(key) ? _pizzas.Where(k => k.Key == key).First().Value : null;
    }

    public static Pizza CreatePizza(Pizza pizza)
    {
        _pizzas.Add(4, pizza);
        return pizza;
    }

    public static Pizza UpdatePizza(Pizza update)
    {
        _pizzas.Where(_pizza => _pizza.Value.Name == update.Name).First().Value.Name = update.Name;
        _pizzas.Where(_pizza => _pizza.Value.Name == update.Name).First().Value.Description = update.Description;

        return update;
    }

    public static void RemovePizza(int key)
    {
        _pizzas.Remove(key);
    }
}