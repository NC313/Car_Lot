namespace Car_Lot;

using System;
using System.Collections.Generic;

class Car
{
    // Data members for car details
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }

    // No-arguments constructor with default values
    public Car()
    {
        Make = "";
        Model = "";
        Year = 0;
        Price = 0.0m;
    }

    // Constructor with four arguments
    public Car(string make, string model, int year, decimal price)
    {
        Make = make;
        Model = model;
        Year = year;
        Price = price;
    }

    // ToString method
    public override string ToString()
    {
        return $"{Year} {Make} {Model}, Price: {Price:C}";
    }

    // Public static member for the list of cars
    public static List<Car> CarInventory = new List<Car>();

    // ListCars method
    public static void ListCars()
    {
        for (int i = 0; i < CarInventory.Count; i++)
        {
            Console.WriteLine($"{i}. {CarInventory[i]}");
        }
    }

    // Remove method
    public static void Remove(int index)
    {
        if (index >= 0 && index < CarInventory.Count)
        {
            CarInventory.RemoveAt(index);
        }
    }
}

class UsedCar : Car
{
    // Data member for used car details
    public double Mileage { get; set; }

    // Constructor
    public UsedCar(string make, string model, int year, decimal price, double mileage)
        : base(make, model, year, price)
    {
        Mileage = mileage;
    }

    // ToString method
    public override string ToString()
    {
        return $"{base.ToString()}, Mileage: {Mileage} miles (Used)";
    }
}

class Program
{
    static void Main()
    {
        // Create instances of Car and UsedCar and add them to the list
        Car.CarInventory.Add(new Car("Toyota", "Camry", 2022, 25000.00m));
        Car.CarInventory.Add(new Car("Honda", "Accord", 2023, 27000.00m));
        Car.CarInventory.Add(new Car("Ford", "Mustang", 2023, 35000.00m));

        Car.CarInventory.Add(new UsedCar("Chevrolet", "Malibu", 2019, 18000.00m, 30000.5));
        Car.CarInventory.Add(new UsedCar("Nissan", "Altima", 2018, 15000.00m, 40000.2));
        Car.CarInventory.Add(new UsedCar("Hyundai", "Elantra", 2020, 16000.00m, 35000.8));

        // Print the initial list of cars
        Console.WriteLine("Initial List of Cars:");
        Car.ListCars();

        // Ask the user which car they would like to buy
        int selectedIndex;
        while (true)
        {
            Console.Write("\nEnter the number of the car you would like to buy: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out selectedIndex) && selectedIndex >= 0 && selectedIndex < Car.CarInventory.Count)
            {
                break;
            }

            Console.WriteLine("Invalid input. Please enter a valid number.");
        }

        // Print out the details for the chosen car
        Console.WriteLine($"\nDetails for the chosen car:\n{Car.CarInventory[selectedIndex]}");

        // Remove the chosen car from the list
        Car.Remove(selectedIndex);

        // List all the cars again
        Console.WriteLine("\nUpdated List of Cars:");
        Car.ListCars();
    }
}
