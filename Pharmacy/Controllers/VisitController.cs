using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI;
using Pharmacy.DAL;
using Pharmacy.Models;

namespace Pharmacy.Controllers
{
    public class VisitController : PharmacyController
    {
        // GET: Visit
        public ActionResult Delete(VisitData model)
        {
            if (model != null)
            {
                var visit = entities.VisitDatas.First(x => x.Id == model.Id);
                visit.Removed = true;
                entities.SaveChanges();
                return RedirectToAction("VisitList", "Client", new { id = model.ClientId } );
            }
            return HttpNotFound("Sorry but this page is not exists");            
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                var data = entities.VisitDatas.First(x => x.Id == id);
                var model = new ChangeVisitModel(data);                                
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Edit(ChangeVisitModel model)
        {
            if (ModelState.IsValid)
            {
                if ((model.VisitData.OrderAmount > 10000) || (model.VisitData.OrderAmount < 0))
                {
                    ModelState.AddModelError("VisitData.OrderAmount", "Amount should be more than 0 and not more than 10000");
                    return View(model);
                }
                var modelToChange = entities.VisitDatas.First(x => x.Id == model.VisitData.Id);
                modelToChange.VisitDate = model.VisitData.VisitDate;
                modelToChange.OrderAmount = model.VisitData.OrderAmount;
                modelToChange.OrderStatus = model.VisitData.OrderStatus;                
                entities.SaveChanges();
                return RedirectToAction("VisitList", "Client", new { id = model.VisitData.ClientId });
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Create(int? clientId)
        {
            ChangeVisitModel model = new ChangeVisitModel();
            if (clientId == null)
                return HttpNotFound("The page with this client is not exists");
            model.VisitData.ClientId = clientId;
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(ChangeVisitModel model)
        {
            if (ModelState.IsValid)
            {
                if ((model.VisitData.OrderAmount > 10000) || (model.VisitData.OrderAmount < 0))
                {
                    ModelState.AddModelError("VisitData.OrderAmount", "Amount should be more than 0 and not more than 10000");
                    return View(model);
                }
                VisitData newVisitData = new VisitData();
                newVisitData.VisitDate = model.VisitData.VisitDate;
                newVisitData.OrderAmount = model.VisitData.OrderAmount;
                newVisitData.OrderStatus = model.VisitData.OrderStatus;
                newVisitData.Removed = false;
                newVisitData.ClientId = model.VisitData.ClientId;
                entities.VisitDatas.Add(newVisitData);
                entities.SaveChanges();
                return RedirectToAction("VisitList", "Client", new {id = model.VisitData.ClientId});
            }
            else
            {
                return View(model);
            }
        }
    }
}