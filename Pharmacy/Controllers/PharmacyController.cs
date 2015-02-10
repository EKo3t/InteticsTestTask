using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pharmacy.DAL;

namespace Pharmacy.Controllers
{
    public class PharmacyController : Controller
    {
        protected PharmacyEntities entities = new PharmacyEntities();
    }
}