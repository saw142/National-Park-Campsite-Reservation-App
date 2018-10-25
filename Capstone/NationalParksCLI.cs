﻿using Capstone.DAL;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class NationalParksCLI
    {

        const string Command_Acadia = "1";
        const string Command_Arches = "2";
        const string Command_Cuyahoga_National_Park = "3";
        const string Command_Quit = "q";
        const string DatabaseConnection = @"Data Source=.\SQLEXPRESS;Initial Catalog=NPCampsite;Integrated Security=True";

        public void RunCLI()
        {
            PrintMenu();
            

            while (true)
            {
                string command = Console.ReadLine();

                if (command.ToLower() != "q")
                {
                    int parkID = int.Parse(command);
                    GetPark(parkID);
                }
            }
        }

        public void GetPark(int parkId)
        {
            Console.WriteLine();
            Console.Clear();

            IParkDAL dal = new ParkSqlDAL(DatabaseConnection);
            Park park = dal.GetParkById(parkId);

            Console.WriteLine($"{park.Name} National Park");
            Console.WriteLine($"Location:           {park.Location}");
            Console.WriteLine($"Established:        {park.EstablishDate}");
            Console.WriteLine($"Area:               {park.Area} sq km");
            Console.WriteLine($"Annual Visitors:    {park.Visitors}");
            Console.WriteLine();
            Console.WriteLine($"{park.Description}");

            Console.WriteLine();
            PrintMenu();
        }

        private void PrintMenu()
        {
            Console.WriteLine("Select a Park for Further Details");
            IParkDAL parkDal = new ParkSqlDAL(DatabaseConnection);
            IList<Park> parks = parkDal.GetParks();

            foreach (Park park in parks)
            {
                Console.WriteLine($"{park.ParkId}) {park.Name}");
            }
            Console.WriteLine("Q) Quit");
        }
    }
}

    

    