using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StateHandling.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;


namespace StateHandling.Models
{
    public class StateManager
    {

        Controller control;
        IMemoryCache cache;

        const string emailKey = "Email";

        public string Email
        {
            get { return cache.Get<string>(emailKey); }
            set { cache.Set(emailKey, value); }
        }

        private string companyKey = "CompanyName";

        public string CompanyName
        {
            get { return control.HttpContext.Session.GetString(companyKey); }
            set { control.HttpContext.Session.SetString(companyKey, value); }
        }

        const string greetingKey = "Greeting";

        public string Greeting
        {
            get { return (string)control.TempData[greetingKey]; }
            set { control.TempData[greetingKey] = value; }
        }

        public StateManager(Controller control, IMemoryCache cache)
        {
            this.control = control;
            this.cache = cache;
        } 
    }
}
