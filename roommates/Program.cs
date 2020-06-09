using System;
using System.Collections.Generic;
using System.Data;
using Roommates.Models;
using Roommates.Repositories;

namespace Roommates
{
    class Program
    {
        /// <summary>
        ///  This is the address of the database.
        ///  We define it here as a constant since it will never change.
        /// </summary>
        private const string CONNECTION_STRING = @"server=localhost\SQLExpress;database=Roommates;integrated security=true";

        static void Main(string[] args)
        {
            //RoomRepository roomRepo = new RoomRepository(CONNECTION_STRING);

            //Console.WriteLine("Getting All Rooms:");
            //Console.WriteLine();

            //List<Room> allRooms = roomRepo.GetAll();


            RoommateRepository roommateRepo = new RoommateRepository(CONNECTION_STRING);

            Console.WriteLine("Getting All Roommates:");
            Console.WriteLine();

            List<Roommate> allRoommates = roommateRepo.GetAllWithRoom();

            foreach (Roommate roommate in allRoommates)
            {
                Console.WriteLine($"Roommate {roommate.Id} Information");
                Console.WriteLine($"Full Name: {roommate.FirstName} {roommate.LastName}");
                Console.WriteLine($"Rent Portion: {roommate.RentPortion}");
                Console.WriteLine($"Date Moved In: {roommate.MoveInDate}");
                Console.WriteLine($"");
                Console.WriteLine($"Roommates Room:");
                Console.WriteLine($"Room Name: {roommate.Room.Name}");
                Console.WriteLine($"Maximum Occupancy: {roommate.Room.MaxOccupancy}");
                Console.WriteLine("---------------");
                Console.WriteLine($"");
            }

            Roommate newRoommate = new Roommate
            {
                FirstName = "John",
                LastName = "Dough",
                RentPortion = 50,
                MoveInDate = DateTime.Now,
                Room = null
            };
            roommateRepo.Insert(newRoommate);



            //RoomRepository roomRepo = new RoomRepository(CONNECTION_STRING);

            //Console.WriteLine("Getting All Rooms:");
            //Console.WriteLine();

            //List<Room> allRooms = roomRepo.GetAll();

            //foreach (Room room in allRooms)
            //{
            //    Console.WriteLine($"{room.Id} {room.Name} {room.MaxOccupancy}");
            //}

            //Room frontBedroom = roomRepo.GetById(1);
            //Console.WriteLine("Enter a new name for the front room.");
            //frontBedroom.Name = Console.ReadLine();
            //roomRepo.Update(frontBedroom);

            //roomRepo.Delete(2);

            //allRooms = roomRepo.GetAll();

            //foreach (Room room in allRooms)
            //{
            //    Console.WriteLine($"{room.Id} {room.Name} {room.MaxOccupancy}");
            //}


        }
    }
}