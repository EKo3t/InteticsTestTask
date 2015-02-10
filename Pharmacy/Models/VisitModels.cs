using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pharmacy.DAL;

namespace Pharmacy.Models
{
    public class ChangeVisitModel
    {
        public ChangeVisitModel()
        {
            VisitData = new VisitData();
            StatusList = new List<SelectListItem>(){
                    new SelectListItem() {Text="Completed", Value="Completed"},
                    new SelectListItem() {Text="In progress", Value="In progress"},
                    new SelectListItem() {Text="Canceled", Value="Canceled"},
            };
        }

        public ChangeVisitModel(VisitData data)
        {
            VisitData = data;
            StatusList = new List<SelectListItem>(){
                    new SelectListItem() {Text="Completed", Value="Completed"},
                    new SelectListItem() {Text="In progress", Value="In progress"},
                    new SelectListItem() {Text="Canceled", Value="Canceled"},
            };
        }
        public VisitData VisitData { get; set; }

        public List<SelectListItem> StatusList { get; set; }
    
    }
}