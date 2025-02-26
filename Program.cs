namespace Filbehandling_og_JSONSerializer;

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            //Name of the filepath
            string filePath = "laptop.json";

            //Creates a list to store laptop objects
            List<Laptop> laptops = new List<Laptop>();
            //Checking if filePath exists ("laptop.json")
            if (File.Exists(filePath))
            {
                //If the file exists, read the existing JSON data from the file
                string existingJson = File.ReadAllText(filePath);
                Console.WriteLine($"Data already exists within the file laptop.json{File.ReadAllText(filePath)}");
                //Only deserialize if the file is not empty
                if(!string.IsNullOrWhiteSpace(existingJson))
                {
                    //Convert JSON data to C# objects, in this case List<Laptop> objects
                    laptops = JsonSerializer.Deserialize<List<Laptop>>(existingJson);
                }
            }

            Console.WriteLine("What brand is your laptop?");
            string? brand = Console.ReadLine();
            Console.WriteLine("What color is your laptop?");
            string? color = Console.ReadLine();
            Console.WriteLine("What year is your laptop from?");
            int year;
            while (!int.TryParse(Console.ReadLine(), out year))
            {
                Console.WriteLine("Please input a valid number.");
            }

            var newLaptop = new Laptop
            {
                Brand = brand,
                Color = color,
                Year = year
            };
            //Adds new laptop to the list
            laptops.Add(newLaptop);
            //Converts list to JSON with pretty formatting = readability (Converts C# objects to JSON)
            string json = JsonSerializer.Serialize(laptops, new JsonSerializerOptions {WriteIndented = true});
            //Saves new data to the JSON file
            File.WriteAllText(filePath, json);

            Console.WriteLine("Data was successfully written to the JSON object");
            Console.WriteLine();


        }
        catch (IOException exception)
        {
            Console.WriteLine($"An error occured while writing to the file laptop.json: {exception.Message}");
        }
        catch (Exception exception)
        {
            Console.WriteLine($"{exception.Message}\n");
        }


    }
    }
