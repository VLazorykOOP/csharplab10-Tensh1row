//Exercise 1
using System; 

using System.Collections.Generic; 

  

// Власний клас винятку для обробки помилок, пов'язаних з продуктами 

public class ProductException : Exception 

{ 

    public ProductException(string message) : base(message) { } 

} 

  

// Власні класи винятків для обробки стандартних винятків 

public class MyArrayTypeMismatchException : Exception 

{ 

    public MyArrayTypeMismatchException(string message) : base(message) { } 

} 

  

public class MyDivideByZeroException : Exception 

{ 

    public MyDivideByZeroException(string message) : base(message) { } 

} 

  

public class MyIndexOutOfRangeException : Exception 

{ 

    public MyIndexOutOfRangeException(string message) : base(message) { } 

} 

  

public class MyInvalidCastException : Exception 

{ 

    public MyInvalidCastException(string message) : base(message) { } 

} 

  

public class MyOutOfMemoryException : Exception 

{ 

    public MyOutOfMemoryException(string message) : base(message) { } 

} 

  

public class MyOverflowException : Exception 

{ 

    public MyOverflowException(string message) : base(message) { } 

} 

  

public class MyStackOverflowException : Exception 

{ 

    public MyStackOverflowException(string message) : base(message) { } 

} 

  

// Інтерфейс Товар 

interface IProduct 

{ 

    void DisplayInfo(); 

    bool IsExpired(); 

} 

  

// Базовий клас Товар 

abstract class ProductBase : IProduct, IDisposable 

{ 

    public string Name { get; set; } 

    public double Price { get; set; } 

    public DateTime ProductionDate { get; set; } 

    public DateTime ExpiryDate { get; set; } 

  

    // Конструктор 

    public ProductBase(string name, double price, DateTime productionDate, DateTime expiryDate) 

    { 

        Name = name; 

        Price = price; 

        ProductionDate = productionDate; 

        ExpiryDate = expiryDate; 

    } 

  

    // Реалізація методу виведення інформації про товар 

    public virtual void DisplayInfo() 

    { 

        Console.WriteLine($"Name: {Name}"); 

        Console.WriteLine($"Price: {Price:C}"); 

        Console.WriteLine($"Production Date: {ProductionDate:d}"); 

        Console.WriteLine($"Expiry Date: {ExpiryDate:d}"); 

    } 

  

    // Реалізація методу перевірки відповідності строку придатності на поточну дату 

    public bool IsExpired() 

    { 

        return DateTime.Now > ExpiryDate; 

    } 

  

    // Реалізація інтерфейсу IDisposable 

    public void Dispose() 

    { 

        // Код для звільнення неуправляемих ресурсів (якщо потрібно) 

    } 

} 

  

// Похідний клас Продукт 

class Product : ProductBase 

{ 

    // Конструктор 

    public Product(string name, double price, DateTime productionDate, DateTime expiryDate) 

        : base(name, price, productionDate, expiryDate) 

    { 

    } 

  

    // Перевизначений метод виведення інформації про товар 

    public override void DisplayInfo() 

    { 

        Console.WriteLine("Product:"); 

        base.DisplayInfo(); 

    } 

} 

  

// Похідний клас Партія 

class Batch : ProductBase 

{ 

    public int Quantity { get; set; } 

  

    // Конструктор 

    public Batch(string name, double price, int quantity, DateTime productionDate, DateTime expiryDate) 

        : base(name, price, productionDate, expiryDate) 

    { 

        Quantity = quantity; 

    } 

  

    // Перевизначений метод виведення інформації про товар 

    public override void DisplayInfo() 

    { 

        Console.WriteLine("Batch:"); 

        base.DisplayInfo(); 

        Console.WriteLine($"Quantity: {Quantity}"); 

    } 

} 

  

// Похідний клас Комплект 

class Kit : ProductBase 

{ 

    public List<string> Products { get; set; } 

  

    // Конструктор 

    public Kit(string name, double price, List<string> products, DateTime productionDate, DateTime expiryDate) 

        : base(name, price, productionDate, expiryDate) 

    { 

        Products = products; 

    } 

  

    // Перевизначений метод виведення інформації про товар 

    public override void DisplayInfo() 

    { 

        Console.WriteLine("Kit:"); 

        base.DisplayInfo(); 

        Console.WriteLine("Products:"); 

        foreach (var product in Products) 

        { 

            Console.WriteLine($"- {product}"); 

        } 

    } 

} 

  

class Program 

{ 

    static void Main(string[] args) 

    { 

        try 

        { 

            // Створення бази товарів 

            List<IProduct> products = new List<IProduct> 

            { 

                new Product("Milk", 2.99, new DateTime(2024, 3, 15), new DateTime(2024, 4, 15)), 

                new Batch("Cookies", 1.49, 10, new DateTime(2024, 3, 10), new DateTime(2024, 4, 10)), 

                new Kit("Gift Basket", 24.99, new List<string>{"Chocolate", "Wine", "Cheese"}, new DateTime(2024, 3, 1), new DateTime(2024, 4, 1)) 

            }; 

  

            // Виведення інформації про товари 

            Console.WriteLine("Products Information:"); 

            foreach (var product in products) 

            { 

                product.DisplayInfo(); 

                Console.WriteLine(); 

            } 

  

            // Пошук прострочених товарів 

            Console.WriteLine("Expired Products:"); 

            foreach (var product in products) 

            { 

                if (product.IsExpired()) 

                { 

                    product.DisplayInfo(); 

                    Console.WriteLine(); 

                } 

            } 

        } 

        catch (MyArrayTypeMismatchException ex) 

        { 

            Console.WriteLine($"Array type mismatch error: {ex.Message}"); 

        } 

        catch (MyDivideByZeroException ex) 

        { 

            Console.WriteLine($"Divide by zero error: {ex.Message}"); 

        } 

        catch (MyIndexOutOfRangeException ex) 

        { 

            Console.WriteLine($"Index out of range error: {ex.Message}"); 

        } 

        catch (MyInvalidCastException ex) 

        { 

            Console.WriteLine($"Invalid cast error: {ex.Message}"); 

        } 

        catch (MyOutOfMemoryException ex) 

        { 

            Console.WriteLine($"Out of memory error: {ex.Message}"); 

        } 

        catch (MyOverflowException ex) 

        { 

            Console.WriteLine($"Overflow error: {ex.Message}"); 

        } 

        catch (MyStackOverflowException ex) 

        { 

            Console.WriteLine($"Stack overflow error: {ex.Message}"); 

        } 

        catch (Exception ex) 

        { 

            Console.WriteLine($"An unexpected error occurred: {ex.Message}"); 

        } 

    } 

} 



//Exercise 2
using System; 

using System.Collections.Generic; 

  

  

class Paroplyav 

{ 

  

    public double Speed { get; private set; } 

    public double Power { get; private set; } 

  

  

    public Paroplyav(double initialSpeed, double initialPower) 

    { 

        Speed = initialSpeed; 

        Power = initialPower; 

    } 

  

    

    public void ChangeSpeed(double newSpeed) 

    { 

        Speed = newSpeed; 

        Console.WriteLine($"Speed changed to {Speed} knots."); 

    } 

  

  

    public void ChangePower(double newPower) 

    { 

        Power = newPower; 

        Console.WriteLine($"Power changed to {Power} kW."); 

    } 

  

} 

  

  

class Event 

{ 

  

    public string Name { get; private set; } 

    public string Description { get; private set; } 

  

  

    public Event(string name, string description) 

    { 

        Name = name; 

        Description = description; 

    } 

} 

  

  

class Simulation 

{ 

   

    public void StartSimulation() 

    { 

         

        Paroplyav paroplyav = new Paroplyav(10, 100); 

  

         

        List<Event> events = new List<Event> 

        { 

            new Event("Increase Speed", "Increase the speed of the steamship."), 

            new Event("Decrease Power", "Decrease the power of the steamship.") 

        }; 

  

        

        foreach (var evt in events) 

        { 

            Console.WriteLine($"Event: {evt.Name}"); 

            Console.WriteLine($"Description: {evt.Description}"); 

             

            HandleEvent(evt, paroplyav); 

            Console.WriteLine(); 

        } 

    } 

  

     

    private void HandleEvent(Event evt, Paroplyav paroplyav) 

    { 

        switch (evt.Name) 

        { 

            case "Increase Speed": 

                paroplyav.ChangeSpeed(paroplyav.Speed + 5); // Збільшення швидкості на 5 вузлів 

                break; 

            case "Decrease Power": 

                paroplyav.ChangePower(paroplyav.Power - 20); // Зменшення потужності на 20 кВт 

                break; 

            default: 

                Console.WriteLine("Unknown event."); 

                break; 

        } 

    } 

} 

  

class Program 

{ 

    static void Main(string[] args) 

    { 

        Simulation simulation = new Simulation(); 

        simulation.StartSimulation(); 

    } 

} 