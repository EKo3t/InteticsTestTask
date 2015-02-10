using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pharmacy.DAL;

namespace Pharmacy.Models
{
    public class ClientListModel
    {
        public List<MainClientData> ClientList { get; set; }
    }

    public class ClientSearchModel
    {

        public MainClientData SearchingClientData { get; set; }

        public ClientListModel ClientResultList { get; set; }

        public bool SearchStatus { get; set; }
    }

    public class CreateClientModel
    {
        public MainClientData MainData { get; set; }
        public EyeClientData EyeData { get; set; }
        public OtherClientData OtherData { get; set; }
    }

    public class ClientDetailsModel
    {
        public MainClientData MainData { get; set; }
        public EyeClientData EyeData { get; set; }
        public OtherClientData OtherData { get; set; }
    }

    public class ClientVisitsmodel
    {
        public List<VisitData> VisitDataList { get; set; }

        public int? ClientId { get; set; }
    }
}