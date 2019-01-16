using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex28_Databases
{
    class Menu
    {
        Controller _controller = new Controller();
        
        bool Stop = true;
        public void Run()
        {
            try
            {
                while (Stop == true)
                {
                    Console.Clear();
                    Console.WriteLine("Welcome to my awesome menu");
                    Console.WriteLine("1: Insert a pet");
                    Console.WriteLine("2: Show all pets");
                    Console.WriteLine("3: Find owner by last name");
                    Console.WriteLine("4: Find owner by email");
                    Console.WriteLine("5: Show all owned pets by the owner");
                    Console.WriteLine("0: To close");

                    string read = Console.ReadLine();
                    switch (read)
                    {
                        case "1":
                            Console.WriteLine("Name of pet");
                            string PetName = Console.ReadLine();

                            Console.WriteLine("What kind if pet is this");
                            string PetType = Console.ReadLine();

                            Console.WriteLine("What breed is this");
                            string PetBreed = Console.ReadLine();

                            Console.WriteLine("Date of birth");
                            string date = Console.ReadLine();
                            DateTime Birth = Convert.ToDateTime(date);

                            Console.WriteLine("Wight of the pet");
                            double PetWeight = double.Parse(Console.ReadLine());

                            Console.WriteLine("Who owns this pet");
                            int OwnerPK = int.Parse(Console.ReadLine());

                            _controller.InsertPet(PetName, PetType, PetBreed, Birth, PetWeight, OwnerPK);
                            break;
                        case "2":
                            Console.Clear();
                            Console.WriteLine("All pets");
                            foreach (List<string> subList in _controller.ShowPets())
                            {
                                foreach (string item in subList)
                                {
                                    Console.Write(item + " ");
                                }
                                Console.WriteLine();
                            }
                            Console.ReadKey();
                            break;
                        case "3":
                            Console.Clear();
                            Console.WriteLine("Find an owner by last name");
                            string lastname = Console.ReadLine();
                            foreach (var item in _controller.ShowOwnerByLastName(lastname))
                            {
                                Console.WriteLine(item);
                            }
                            Console.ReadKey();
                            break;
                        case "4":
                            Console.Clear();
                            Console.WriteLine("Find owner by Email");
                            string email = Console.ReadLine();
                            foreach (var item in _controller.ShowOwnerByEmail(email))
                            {
                                Console.WriteLine(item);
                            }
                            Console.ReadKey();
                            break;
                        case "5":
                            Console.Clear();
                            Console.WriteLine("Pets of the Owner");
                            int id = int.Parse(Console.ReadLine());
                            foreach (List<string> subList in _controller.ShowPets(id))
                            {
                                foreach (string item in subList)
                                {
                                    Console.Write(item + " ");
                                }
                                Console.WriteLine();
                            }
                            Console.ReadKey();
                            break;
                        case "0":
                            Stop = false;
                            break;

                        default:
                            Stop = false;
                            break;
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
    }
}
