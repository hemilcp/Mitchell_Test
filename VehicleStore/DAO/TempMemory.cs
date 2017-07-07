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
            if (!checkIfVehicleExists(input.Id))
            {
                TempMemory.VehicleDB.Add(input);
                return true;
            }
            return flag;
        }

        //Delete a vehicle record
        public bool deleteVehicleDetails(Vehicle input)
        {
            //Get the vehicle record to delete
            var vehicle = VehicleDB.Single(item => item.Id == input.Id);
            if (vehicle != null) { VehicleDB.Remove(vehicle); return true; }
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