using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Pharmacy.DAL;
using Pharmacy.Models;

namespace Pharmacy.Controllers
{
    public class HomeController : PharmacyController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Clients()
        {
            PharmacyEntities entities = new PharmacyEntities();
            ClientListModel model = new ClientListModel();
            model.ClientList = entities.MainClientDatas.ToList();
            
            return View(model);
        }

        [HttpGet]
        public ActionResult FindClient()
        {
            ClientSearchModel model = new ClientSearchModel();
            model.ClientResultList = new ClientListModel();
            model.SearchingClientData = new MainClientData();
            model.SearchStatus = false;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FindClient(ClientSearchModel model)
        {
            PharmacyEntities entities = new PharmacyEntities();
            model.ClientResultList = new ClientListModel();
            if (model.SearchingClientData.FirstName != null)
                model.ClientResultList.ClientList = entities.MainClientDatas.Where(
                    x => (x.FirstName.Contains(model.SearchingClientData.FirstName))).ToList();
            if (model.SearchingClientData.LastName != null)
                model.ClientResultList.ClientList = entities.MainClientDatas.Where(
                    x => (x.LastName.Contains(model.SearchingClientData.LastName))).ToList();
            if (model.SearchingClientData.Email != null)
                model.ClientResultList.ClientList = entities.MainClientDatas.Where(
                    x => (x.Email.Contains(model.SearchingClientData.Email))).ToList();

            model.SearchingClientData = new MainClientData();
            model.SearchStatus = true;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateClientModel model)
        {
            if (ModelState.IsValid)
            {
                PharmacyEntities entities = new PharmacyEntities();
                entities.MainClientDatas.Add(model.MainData);
                entities.SaveChanges();
                int mainDataId = entities.MainClientDatas.First(x => x.Email == model.MainData.Email).id;
                model.OtherData.ClientId = mainDataId;
                model.EyeData.ClientId = mainDataId;
                entities.OtherClientDatas.Add(model.OtherData);
                entities.EyeClientDatas.Add(model.EyeData);
                entities.SaveChanges();
                return RedirectToAction("FindClient");
            }
            else
            {
                return View(model);
            }
            
        }
    }
}