using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using VehicleStore.DAO;
using VehicleStore.Models;

namespace VehicleStore.Controllers
{
    [EnableCors(origins: "*", headers:"*", methods:"*")]
    public class HomeController : ApiController
    {

        Models.Vehicle[] vehicles = new Vehicle[]
        {
            new Vehicle { Id = 1, Year = 2014, Make = "Tesla", Model = "Model S"},
            new Vehicle { Id = 2, Year = 2013, Make = "Lambourghini", Model = "Avantador"},
            new Vehicle { Id = 3, Year = 2004, Make = "Suzuki", Model = "Maruti 800"},
            new Vehicle { Id = 4, Year = 2014, Make = "Honda", Model = "Accent"},
            new Vehicle { Id = 5, Year = 2017, Make = "Hundai", Model = "VeganR"},
            new Vehicle { Id = 6, Year = 2012, Make = "Tata", Model = "Nano"},
        };

        DAO.TempMemory db = new TempMemory();

        [HttpPost]
        public string AddVehicleDetails(Vehicle input)
        {
            var check = db.addNewVehicleDetails(input);
            if (check) return "Vehicle Details saved successfully!";
            else return "A record with same Id exists!";
        }
        [HttpGet]
        public IEnumerable<Vehicle> GetAllVehiclesDetails()
        {
            return db.getAllVehicleList();

        }

        public IHttpActionResult GetVehicleDetails(int id)
        {
            var vehicle = db.getVehicleDetails(id);
            if (vehicle == null)
                return NotFound();
            return Ok(vehicle);
        }

        [HttpDelete]
        public string DeleteVehicleDetails(Vehicle input)
        {
            var check = db.deleteVehicleDetails(input);
            if (check) return "Vehicle details deleted successfully!";
            else return "No record exists with such details!";   
        }

        [HttpPut]
        public string UpdateVehicleDetails(string Name, String Id)
        {
            return "Vehicle details Updated with Name " + Name + " and Id " + Id;

        }

    }
}
