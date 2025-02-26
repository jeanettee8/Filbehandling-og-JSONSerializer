namespace Filbehandling_og_JSONSerializer;

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string filePath = "laptop.json";

            List<Laptop> laptops = new List<Laptop>();
            if (File.Exists(filePath))
            {
                string existingJson = File.ReadAllText(filePath);
                Console.WriteLine($"Data already exists within the file laptop.json{File.ReadAllText(filePath)}");
                if(!string.IsNullOrWhiteSpace(existingJson))
                {
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
            laptops.Add(newLaptop);
            string json = JsonSerializer.Serialize(laptops, new JsonSerializerOptions {WriteIndented = true});
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
