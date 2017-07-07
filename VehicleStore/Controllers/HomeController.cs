using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using VehicleStore.DAO;
using VehicleStore.Entity;
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
        public HttpResponseMessage AddVehicleDetails(Vehicle input)
        {
            var check = db.addNewVehicleDetails(input);
            if (check) return new PersistObject().returnHTTP("Vehicle Details saved successfully!");
            else return new PersistObject().returnHTTP("A record with same Id exists!"); 
        }


        [HttpGet]
        public HttpResponseMessage GetAllVehiclesDetails()
        {
            return new PersistObject().returnHTTP(db.getAllVehicleList());

        }


        // Alternatively we can also return IHttpActionResult instead of HttpResonseMessage
        public IHttpActionResult GetVehicleDetails(int id)
        {
            var vehicle = db.getVehicleDetails(id);
            if (vehicle == null)
                return NotFound();
            return Ok(vehicle);
        }

        [HttpDelete]
        public HttpResponseMessage DeleteVehicleDetails(Vehicle input)
        {
            var check = db.deleteVehicleDetails(input);
            if (check) return new PersistObject().returnHTTP("Vehicle details deleted successfully!");
            else return new PersistObject().returnHTTP("No record exists with such details!");   
        }

        [HttpPut]
        public HttpResponseMessage UpdateVehicleDetails(Vehicle input)
        {
            var check = db.updateVehicleDetails(input);
            if (check) return new PersistObject().returnHTTP("Vehicle details Updated with Id " + input.Id);
            else return new PersistObject().returnHTTP("Cannot update the record. maybe no record exist with such Id!");
        }

    }
}
