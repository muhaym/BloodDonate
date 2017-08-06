using System;
using System.Threading.Tasks;
using BloodDonate.Models;
using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Linq;
using GeoCoordinatePortable;

namespace BloodDonate.Services
{
    public static class BasicServices
    {
        public static MobileServiceClient MobileService =
            new MobileServiceClient("https://eblooddonate.azurewebsites.net");
        public static async Task<Result<bool>> AddBloodAsync(Donors donor)
        {
            var result = new Result<bool>();
            try
            {
                await MobileService.GetTable<Donors>().InsertAsync(donor);
                result.Status = 100;
                result.data = true;
                result.Message = "Successfully Added to List";
                return result;
            }
            catch (Exception e)
            {
                result.Status = 101;
                result.data = false;
                result.Message = e.ToString();
                return result;
            }
        }
        public static async Task<Result<List<Donors>>> RetrieveDonors(double latitude, double longitude, string bloodgroup, int range)
        {
            var result = new Result<List<Donors>>();
            try
            {
                var donors = await MobileService.GetTable<Donors>().Where(x => x.Group == bloodgroup).ToListAsync();
                //Do Not Use the following practice in Real Life Apps.
                var coord = new GeoCoordinate(latitude, longitude);
                var nearest = donors.Select(x => new GeoCoordinate(latitude, longitude))
                                        .OrderBy(x => x.GetDistanceTo(coord));
                var query = from l in donors
                            let dist = new GeoCoordinate(l.Latitude, l.Longitude).GetDistanceTo(coord)
                            where dist < range
                            select l;
                var y = query.ToList();

                result.data = y;
                result.Status = 100;
                result.Message = "Successfully Retrieved Donors";
            }
            catch (Exception e)
            {
                result.data = null;
                result.Status = 101;
                result.Message = e.ToString();
            }
            return result;
        }
    }
}
