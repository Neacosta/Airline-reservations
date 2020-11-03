using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline_Reservations_System_
{
    class Program
    {
        public static bool[] seats;
        public static int totalAssignedFirstClass;
        public static int totalAssignedEconomyClass;
        static void Main(string[] args)
        {
            
            seats = new bool[11];
            int choice = 0;

            for (int i = 1; i < seats.Length; i++)
            {
                try
                {
                    Console.WriteLine("Please enter 1 for First Class and Please type 2 for Economy.");
                    choice = Convert.ToInt32(Console.ReadLine());
                    while (choice < 1 || choice > 2)
                    {
                        Console.WriteLine("Wrong choice! Please enter 1 or 2");
                        choice = Convert.ToInt32(Console.ReadLine());
                        i--;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Incorrect input. Please enter a number.");
                    i--;
                }


                if (choice == 1)
                {
                    try
                    {

                        bool availableSeats = IsFirstClassAvailable();
                        if (availableSeats == true)
                        {
                            assignFirstClass();

                        }
                        else
                        {
                            Console.WriteLine("FIRST class is full. ECONOMY class is still available. Press 2 for reservation, or " +
                                               "press a number bigger than 2 to exit");
                            choice = Convert.ToInt32(Console.ReadLine());
                            if (choice > 2)
                            {
                                Console.WriteLine("Next plane leaves in 3 hours");
                                break;

                            }

                            i--;
                        }

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Incorrect input. Please enter a number.");
                        i--;

                    }


                }
                if (choice == 2)
                {
                    try
                    {



                        bool availableESeats = IsEconomyClassAvailable();
                        if (availableESeats == true)
                        {
                            assignEconomyClass();

                        }
                        else
                        {
                            Console.WriteLine("Economy class is full. First class is still available. Press 1 for reservation, or " +
                                                 "press a number bigger than 2 to exit");

                            choice = Convert.ToInt32(Console.ReadLine());
                            if (choice > 2)
                            {
                                Console.WriteLine("Next plane leaves in 3 hours");
                                break;
                            }
                            else if (choice == 1)
                            {
                                assignFirstClass();
                            }
                            i--;
                        }

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Incorrect input. Please enter a number.");
                        i--;

                    }

                }
                if (totalAssignedEconomyClass == 5 && totalAssignedFirstClass == 5)
                {
                    Console.WriteLine("The plane is full.");

                }
            }
        }

      
        public static int assignFirstClass()
        {

            for (int i = 1; i < 6; i++)
            {
                if (seats[i] == false)
                {
                    seats[i] = true;
                    totalAssignedFirstClass++;
                    DisplayAllSeats(i);
                    return i; 
                }
            }
            return -1;
           
        }

        public static int assignEconomyClass()
        {


            for (int i = 6; i <seats.Length; i++)
            {
                if (seats[i] == false)
                {
                    seats[i] = true;
                    totalAssignedEconomyClass++;
                    DisplayAllSeats(i);
                    return i; 
                }
            }
            return -1;

           
        }

        public static void DisplayAllSeats(int i)
        {
            Console.WriteLine("You reserved economy class seat {0}", i);
        }
        public static bool IsEconomyClassAvailable()
        {
            for (int i = 6; i < seats.Length; i++) //using for loop
            {
                if (seats[i] == false)
                {
                    return true; //available
                }
            }
            return false; //otherwise unavailable
        }

        public static bool IsFirstClassAvailable()
        {
            for (int i = 1; i < 6; i++) //using for loop
            {
                if (seats[i] == false)
                {
                    return true; //available
                }
            }
            return false;

        }
    }


}

