using System.Linq;
using CleanerCity.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CleanerCity.ViewModels
{
    public class NewRequestViewModel
    {
        public NewRequestViewModel() { }
        public NewRequestViewModel(Request request, IEnumerable<RequestType> requestTypes)
        {
            Request = request;
            RequestTypes = requestTypes;
            var requestTypesItems = from r in RequestTypes
                                    select new SelectListItem()
                                    {
                                        Value = r.Id.ToString(),
                                        Text = r.Description
                                    };
            RequestTypesItems = requestTypesItems;
        }

        public Request Request { get; set; }
        public IEnumerable<RequestType> RequestTypes { get; set; }
        public IEnumerable<SelectListItem> RequestTypesItems { get; set; }
    }
}