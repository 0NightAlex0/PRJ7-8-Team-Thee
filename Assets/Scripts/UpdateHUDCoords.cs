
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//using Windows.Devices.Geolocation;

//using System;

//public class UpdateHUDCoords : MonoBehaviour
//{
//    public GameObject GuiText;
//    public GameObject PlayerGameObject;
//    Text x;
//    Location loc;
//    // Use this for initialization
//    void Start()
//    {
//        loc = new Location();
//        x = GuiText.GetComponent<Text>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        loc.setlonglat();
//        if (loc.lati != null && loc.longi != null)
//        {
//            x.text = loc.longi.ToString() + loc.lati.ToString();
//        }
//        else
//        {
//            x.text = "no connection werkt helemaal niet";
//        }

//    }
//    public class Location
//    {
//        public double lati;
//        public double longi;
//        public async void setlonglat()
//        {
//            Geolocator geolocator = new Geolocator();
//            geolocator.DesiredAccuracyInMeters = 5;

//            Geoposition position =
//                await geolocator.GetGeopositionAsync(
//                TimeSpan.FromMinutes(0),
//                TimeSpan.FromSeconds(3));
//            lati = position.Coordinate.Latitude;
//            longi = position.Coordinate.Longitude;

//        }

//    }

//}

