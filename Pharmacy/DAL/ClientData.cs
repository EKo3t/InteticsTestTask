using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pharmacy.DAL
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class MetadataClientTypeAttribute : Attribute
    {
        public MetadataClientTypeAttribute(Type modelType, Type dataType)
        {
            TypeDescriptor.AddProviderTransparent(
               new AssociatedMetadataTypeTypeDescriptionProvider(
                   modelType,
                   dataType
               ),
               modelType);
        }
    }

    [MetadataClientType(typeof(MainClientData), typeof(MainClientDataValidation))]
    public partial class MainClientData
    {
    }

    [MetadataClientType(typeof(OtherClientData), typeof(OtherClientDataValidation))]
    public partial class OtherClientData
    {
    }

    [MetadataClientType(typeof(VisitData), typeof(VisitClientDataValidation))]
    public partial class EyeClientData
    {
    }


}