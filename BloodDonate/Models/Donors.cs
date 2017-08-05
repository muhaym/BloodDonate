using System;
namespace BloodDonate.Models
{
    public class Donors
    {
        public string id { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Group { get; set; }
    }
}
