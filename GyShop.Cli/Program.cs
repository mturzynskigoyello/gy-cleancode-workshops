using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyShop.Cli
{
    class Program
    {
        private static Dictionary<string, string> users = new Dictionary<string, string>
        {
            ["mateusz"] = "123456",
            ["maciek"] = "123456"
        };

        private static List<string> items = new List<string>
        {
            "design-patterns",
            "refactoring",
            "SOLID",
            "tdd",
            "linq"
        };

        private static List<int> xpOnStock = new List<int>
        {
            20,
            1,
            0,
            80,
            5
        };

        private static List<string> orders = new List<string>
        {
            "maciek|design-patterns|12|linq|2"
        };

        /// <summary>
        /// this method process an order
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Goyello CleanCode Workshops Shop");
            Console.WriteLine("You can order extraordinary skills which will make your code looks cool!");
            Console.WriteLine("Please enter your username:");
            string username;
            string pwd;
            // read username
            username = Console.ReadLine();
            Console.WriteLine("Please enter your password:");
            pwd = Console.ReadLine();
            bool isPasswordValid;
            bool isUser;
            try
            {
                string p = users[username];
                if (p == pwd)
                {
                    isPasswordValid = true;
                }
                else
                {
                    isPasswordValid = false;
                }
                isUser = true;
            }
            catch (Exception e)
            {
                // username does not exist
                isPasswordValid = false;
                isUser = false;
            }   
            if (isUser && !isPasswordValid)
            {
                // invalid password
                Console.WriteLine("Invalid user password");
                Console.ReadLine();
            }
            else
            {
                bool userCreated = false;
                if (!isUser)
                {
                    // validate password if it's strong enough
                    bool pwdOk1 = false;
                    bool pwdOk2 = false;
                    bool pwdOk3 = false;
                    for (int i = 0; i < pwd.Length; i++)
                    {
                        if (pwd[i] == 'a' || pwd[i] == 'b' || pwd[i] == 'c' || pwd[i] == 'd' || pwd[i] == 'e' || pwd[i] == 'f' || pwd[i] == 'g' || pwd[i] == 'h' || pwd[i] == 'i' || pwd[i] == 'j' || pwd[i] == 'k' || pwd[i] == 'l' || pwd[i] == 'm' || pwd[i] == 'n' || pwd[i] == 'o' || pwd[i] == 'p' || pwd[i] == 'q' || pwd[i] == 'r' || pwd[i] == 's' || pwd[i] == 't' || pwd[i] == 'u' || pwd[i] == 'w' || pwd[i] == 'z' || pwd[i] == 'y' || pwd[i] == 'x')
                        {
                            pwdOk1 = true;
                        }
                        if (pwd[i] == 'A' || pwd[i] == 'B' || pwd[i] == 'C' || pwd[i] == 'D' || pwd[i] == 'E' || pwd[i] == 'F' || pwd[i] == 'G' || pwd[i] == 'H' || pwd[i] == 'I' || pwd[i] == 'J' || pwd[i] == 'K' || pwd[i] == 'L' || pwd[i] == 'M' || pwd[i] == 'N' || pwd[i] == 'O' || pwd[i] == 'P' || pwd[i] == 'Q' || pwd[i] == 'R' || pwd[i] == 'S' || pwd[i] == 'T' || pwd[i] == 'U' || pwd[i] == 'W' || pwd[i] == 'Z' || pwd[i] == 'Y' || pwd[i] == 'X')
                        {
                            pwdOk2 = true;
                        }
                        if (pwd[i] == '1' || pwd[i] == '2' || pwd[i] == '3' || pwd[i] == '4' || pwd[i] == '5' || pwd[i] == '6' || pwd[i] == '7' || pwd[i] == '8' || pwd[i] == '9' || pwd[i] == '0')
                        {
                            pwdOk3 = true;
                        }
                    }
                    if(pwd.Length < 6)
                    {
                        userCreated = false;
                    }
                    else if (pwdOk1 == false)
                    {
                        userCreated = false;
                    }
                    else if (pwdOk2 == false)
                    {
                        userCreated = false;
                    }
                    else if (pwdOk3 == false)
                    {
                        userCreated = false;
                    }
                    else
                    {
                        Console.WriteLine("User created");
                        users[username] = pwd;
                        userCreated = true;
                    }                   
                }
                if (!isUser && !userCreated)
                {
                    Console.WriteLine("Invalid password");
                }
                else
                {
                    Console.WriteLine("You may order following items");
                    int itemsCount = 0;
                    try
                    {
                        while (true)
                        {
                            Console.Write(items[itemsCount] + ", ");
                            itemsCount++;
                        }
                    }
                    catch (Exception e)
                    {
                        // end of items
                        Console.WriteLine();
                    }
                    string[] products = new string[20];
                    int[] xps = new int[20];
                    int i = 0;                    
                    while (true)
                    {
                        Console.WriteLine("Select an item");
                        var name = Console.ReadLine();
                        if (name == "")
                        {
                            break;
                        }
                        Console.WriteLine("Select XP");
                        var xp = int.Parse(Console.ReadLine());
                        // no product yet
                        isUser = false;
                        for (int ii = 0; ii < items.Count; ii++)
                        {
                            if (items[ii] == name)
                            {
                                var availableXp = xpOnStock[ii];
                                if (availableXp < xp)
                                {                                    
                                    Console.WriteLine("No enough xp on stock for item: " + name);
                                }
                                else
                                {
                                    products[i] = name;
                                    xps[i] = xp;
                                    // decrease stock availability
                                    xpOnStock[ii] = xpOnStock[ii] - xp;
                                    i++;
                                    isUser = true;
                                }
                                break;
                            }
                        }
                        if (!isUser)
                        {
                            Console.WriteLine("Product does not exist: " + name);
                        }                        
                    }                    
                    string product = null;
                    int k = 0;
                    int xp2 = 0;
                    string userOrder = username;
                    // print order summary
                    do
                    {
                        if (k == 0)
                        {
                            Console.WriteLine("Congratzz" + username + ", you just ordered:");
                        }
                        product = products[k];
                        if (product != null)
                        {
                            Console.WriteLine(product + " with XP " + xps[k]);
                            xp2 = xp2 + xps[k];
                            userOrder += "|" + product + "|" + xps[k];
                            // k += 10;
                        }
                        k++;
                    } while (product != null);
                    orders.Add(userOrder);
                    Console.WriteLine("Total xp: " + xp2);
                    Console.WriteLine("Orders in queue:");
                    // print all orders;
                    for (int l = 0; l < 10; l++)
                    {
                        try
                        {
                            Console.WriteLine(orders[l]);
                        }
                        catch
                        {
                            // no more orders;
                            break;
                        }
                    }
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadLine();                    
                }
            }
        }
    }
}