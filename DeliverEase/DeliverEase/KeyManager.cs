using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace DeliverEase
{
    public class KeyManager
    {
        public string StripeKey { get; set; }
        public string SendGridKey { get; set; }
        public KeyManager()
        {
            SetKeys();
        }
        public void SetKeys()
        {
            JObject keyObject = JObject.Parse(File.ReadAllText(@"C:\Users\DalekMyBalls\Desktop\DevCodeCamp\aspdotnet\deliverease\DeliverEase\DeliverEase\Keys\Keys.json"));
            SendGridKey = keyObject.GetValue("SendGridKey").ToString();
            StripeKey = keyObject.GetValue("StripeSecretKey").ToString();
        }
    }

}