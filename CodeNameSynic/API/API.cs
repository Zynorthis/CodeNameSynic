using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeNameSynic
{
    public static class API
    {
        private static string key = "AIzaSyDhWS_6PLn7hvXPuLPvjd2pwpL2xL0cYMc";
        public static string Key { get { return key; } set { key = value; } }


        private static string apiLinkGMap = "https://maps.googleapis.com/maps/api/js?key=" + key + "&callback=initMap";
        public static string APILinkGMap { get { return apiLinkGMap; } }

        private static string apiLinkGeocoder = "https://maps.googleapis.com/maps/api/geocode/json?key=" + key + "&address";
        public static string APILinkGeocoder { get { return apiLinkGeocoder; } }
    }
}