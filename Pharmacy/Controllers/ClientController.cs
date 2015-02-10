using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pharmacy.DAL;
using Pharmacy.Models;

namespace Pharmacy.Controllers
{
    public class ClientController : PharmacyController
    {
        // GET: Client
        public ActionResult Details(MainClientData model)
        {
            PharmacyEntities entities = new PharmacyEntities();
            ClientDetailsModel viewModel = new ClientDetailsModel();
            if ((model != null)&&(model.id != 0))
            {
                viewModel.MainData = model;
                viewModel.EyeData = entities.EyeClientDatas.First(x => x.ClientId == model.id);
                viewModel.OtherData = entities.OtherClientDatas.First(x => x.ClientId == model.id);
                return View(viewModel);
            }
            else
            {
                return HttpNotFound("Sorry but this page is not exists.");
            }
        }

        public ActionResult VisitList(int? id)
        {
            ClientVisitsmodel model = new ClientVisitsmodel();
            if (id != null)
            {
                model.VisitDataList = entities.VisitDatas.Where(x => ((x.ClientId == id) && (x.Removed == false))).ToList();
                model.ClientId = id;
                return View(model);
            }
            else
            {
               return HttpNotFound("Sorry but this page is not exists");
            }            
        }
    }
}