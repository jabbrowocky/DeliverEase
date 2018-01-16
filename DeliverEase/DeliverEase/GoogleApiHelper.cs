using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using DeliverEase.Models;


namespace DeliverEase
{
    public class GoogleApiHelper
    {


        public GoogleApi ApiCall(string formattedAddress)
        {
            var client = new RestClient("https://maps.google.com/maps/api/geocode/json?address=" + formattedAddress + "&key=AIzaSyCxzznBe8ybNXYxz0ZOyhRJQbbVGvam75s");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Postman-Token", "f5a42c39-01b9-5338-2583-94fa37ffd884");
            request.AddHeader("Cache-Control", "no-cache");
            IRestResponse response = client.Execute(request);
            GoogleApi data = GoogleApi.FromJson(response.Content);
            
            return data;
           
        }
        
       
    }
}