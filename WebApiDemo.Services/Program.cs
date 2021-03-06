﻿using Microsoft.Owin.Hosting;
using System;
using System.Net.Http;
using WebApiDemo.Data;

namespace WebApiDemo.Services
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9000/";

            System.Data.Entity.Database.SetInitializer(new WebAPIDemoContextInitializer());
            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress)) 
            { 
                Console.WriteLine("Running on:"+baseAddress); 
                Console.ReadLine(); 
            } 
        }
    }
}
