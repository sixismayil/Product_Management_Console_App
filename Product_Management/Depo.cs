using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Management
{
    internal class Depo
    {

        private List<DepoItem> items = new List<DepoItem>();

        public void AddItem(DepoItem item)
        {
            if (items.Contains(item))
            {
                Console.WriteLine($"{item.Title} by {item.Model} is already in the depo.");
            }
            else
            {
                items.Add(item);
                Console.WriteLine($"{item.Title} by {item.Model} added to the depo.");
            }
        }
        public void ListItem()
        {
            Console.WriteLine("Depo Items:");
            foreach (var item in items)
            {
                item.DisplayInfo();
                Console.WriteLine();
            }
        }

        public void CheckOutItem()
        {
            Console.Write("Enter name: ");
            string title = Console.ReadLine();
            List<string> names = new List<string>();
            foreach (var item in items)
            {
                names.Add(item.Title);
                if (item.Title == title)
                {
                    if (item.Status == ItemStatus.Available)
                    {
                        item.Status = ItemStatus.CheckedOut;
                        Console.WriteLine($"{item.Title} has been checked out.");
                    }
                    else
                    {
                        Console.WriteLine($"{item.Title} is already checked out.");
                    }
                    break;
                }

            }
            if (!names.Contains(title))
            {
                Console.WriteLine($"{title} is not in the depo.");
            }
        }


        public void ReturnItem()
        {
            Console.Write("Enter name: ");
            string title = Console.ReadLine();
            List<string> names = new List<string>();
            foreach (var item in items)
            {
                names.Add(item.Title);
                if (item.Title == title)
                {
                    Console.WriteLine($"{item.Title} has been returned.");
                    item.Status = ItemStatus.Available;
                    break;
                }
            }
            if (!names.Contains(title))
            {
                Console.WriteLine($"{title} is not in the depo.");
            }
        }


        public void SaveItemsToFile()
        {
            string directoryPath = @"D:\Fayllar\Projects";
            string fileName = "depoData.txt";
            string filePath = Path.Combine(directoryPath, fileName);
            Directory.CreateDirectory(directoryPath);
            using (StreamWriter writer = new StreamWriter(filePath))
                foreach (var item in items)
                {

                    try
                    {

                        {
                            writer.WriteLine($"Category: {item.Model},\n" +
                            $"Title: {item.Title},\n" +
                            $"Size: {item.Size},\n" +
                            $"Status: {item.Status}\n");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occured: {0}", ex.Message);
                    }
                }

        }
    }
}
