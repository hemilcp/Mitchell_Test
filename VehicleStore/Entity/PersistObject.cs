using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace VehicleStore.Entity
{
    public class PersistObject
    {
        public HttpResponseMessage returnHTTP(Object obj)
        {
            try
            {
                var javaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                string json = javaScriptSerializer.Serialize(obj);
                return new HttpResponseMessage()
                {
                    Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json")
                };
            }
            catch
            {
                var javaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                string json = javaScriptSerializer.Serialize("in catch");
                return new HttpResponseMessage()
                {
                    Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json")
                };
            }
        }

    }
}