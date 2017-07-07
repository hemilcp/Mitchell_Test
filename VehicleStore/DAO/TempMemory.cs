using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleStore.Models;

namespace VehicleStore.DAO
{
    public class TempMemory
    {
        static List<Vehicle> VehicleDB = new List<Vehicle>();


         public TempMemory()
        {
      //      VehicleDB = new List<Vehicle>();
     //       Vehicle v1 = new Vehicle { Id = 1, Year = 2013, Make = "Honda", Model = "City" };
     //       Vehicle v2 = new Vehicle { Id = 2, Year = 2016, Make = "Honda", Model = "Accent" };

         //   VehicleDB.Add(v1);
          //  VehicleDB.Add(v2);
        }

        //get all vehicle records 
        public List<Vehicle> getAllVehicleList()
        {
            return TempMemory.VehicleDB;
        }

        //get the details of the records of vehicle by id
        public Vehicle getVehicleDetails(int id)
        {
            var vehicle = VehicleDB.SingleOrDefault(item => item.Id == id);
            return vehicle;
        }

        //Add new vehicle record
        public bool addNewVehicleDetails(Vehicle input)
        {
            bool flag = false;
            //before adding vehicle record, check if there is any existing record
            if (!checkIfVehicleExists(input.Id) && checkvalidation(input))
            {
                TempMemory.VehicleDB.Add(input);
                return true;
            }
            return flag;
        }

        //Check if the Make and Model are not-null. Also year must be between 1950 - 2050
        private bool checkvalidation(Vehicle input)
        {
            if (input.Make != null && input.Model != null && checkYear(input.Year))
            {
                return true;
            }
            else return false;
        }

        //Check if year in the range of 1950-2050
        private bool checkYear(int year)
        {
            if (year >= 1950 && year <= 2050) return true;
            else return false;
        }

        //Delete a vehicle record
        public bool deleteVehicleDetails(Vehicle input)
        {
            //Get the vehicle record to delete
            var vehicle = VehicleDB.Single(item => item.Id == input.Id);
            if (vehicle != null) { VehicleDB.Remove(vehicle); return true; }
            else return false;
            
        }

        //Update the vehicle details 
        public bool updateVehicleDetails(Vehicle input)
        {
            var vehicle = VehicleDB.Single(item => item.Id == input.Id);
            if (vehicle != null)
            {
                vehicle.Year = input.Year;
                vehicle.Make = input.Make;
                vehicle.Model = input.Model;
                return true;
            }
            else return false;
        }

        //Check if any vehicle record exists with the same ID. Return true if exists.
        public bool checkIfVehicleExists(int id)
        {
            var vehicle = VehicleDB.Exists(item => item.Id == id);
            if (vehicle) return true;
            else return false;
        }

    }
}