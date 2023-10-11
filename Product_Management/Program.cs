using Product_Management;
using System;
using System.Text.RegularExpressions;


namespace ProductManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {

            string pattern = @"^[a-zA-Z0-9\s]*$";
            Regex regex = new Regex(pattern);
            Depo depo = new Depo();
            while (true)
            {
                Console.WriteLine("Depo Management System");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. List Items");
                Console.WriteLine("3. Check Out Item");
                Console.WriteLine("4. Return Item");
                Console.WriteLine("5. Save Depo Data");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter item type (Clothe/Shoe): ");
                        string itemType = Console.ReadLine();

                        if (itemType == "Clothe")
                        {
                            Console.Write("Enter clothe title: ");
                            string clotheTitle = Console.ReadLine();
                            bool isValid = regex.IsMatch(clotheTitle);
                            if (!isValid)
                            {
                                Console.WriteLine("Invalid Pattern! \n" +
                                    "Try again with correct clothe title!");

                                break;
                            }
                            Console.Write("Enter size: ");
                            string size = Console.ReadLine();

                            Clothes clothe = new Clothes(itemType, clotheTitle, ItemStatus.Available, size);
                            depo.AddItem(clothe);
                        }
                        else if (itemType == "Shoe")
                        {
                            Console.Write("Enter Shoe type: ");
                            string shoeTitle = Console.ReadLine();
                            bool isValid = regex.IsMatch(shoeTitle);
                            if (!isValid)
                            {
                                Console.WriteLine("Invalid Pattern! \n" +
                                    "Try again with correct shoe type!");
                                break;
                            }
                            Console.Write("Enter size (numbers): ");
                            string Size = Console.ReadLine();

                            Shoes Shoes = new Shoes(itemType, shoeTitle, ItemStatus.Available, Size);
                            depo.AddItem(Shoes);
                        }
                        else
                        {
                            Console.WriteLine("Invalid item type. Please enter 'Clothe' or 'Shoe'.");
                        }
                        break;
                    case 2:
                        depo.ListItem();
                        break;
                    case 3:
                        depo.CheckOutItem();
                        break;
                    case 4:
                        depo.ReturnItem();
                        break;
                    case 5:
                        depo.SaveItemsToFile();
                        Console.WriteLine("All items saved in text file.");
                        break;
                    case 6:
                        Console.WriteLine("Exiting the program.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.WriteLine("-----------------------");
            }
            Console.ReadKey();
        }
    }
}
