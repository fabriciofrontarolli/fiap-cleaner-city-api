using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CleanerCity.DAL.Context;
using CleanerCity.Models;
using CleanerCity.ViewModels;

namespace CleanerCity.Controllers
{
    public class RequestsController : Controller
    {
        CleanerCityContext ctx = new CleanerCityContext();
        public RequestsController()
        {
        }
        public IEnumerable<Request> Requests { get; set; }
        public IEnumerable<RequestType> RequestTypes = new List<RequestType>();

        public ActionResult Index()
        {
            RequestTypes = ctx.RequestTypes.ToList<RequestType>();
            var newRequest = new Request();
            var vm = new NewRequestViewModel(newRequest, RequestTypes);
            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(NewRequestViewModel vm)
        {
            vm.Request.Latitude = "-22.910153";
            vm.Request.Longitude = "-47.062502";
            vm.Request.UserId = 1;

            /*
            var selectedRequestType = (
                                        from c in RequestTypes
                                        select c.Id == vm.Request.RequestTypeId
                                      );
            */

            /* Cadastra no banco */
            var newRequest = vm.Request;
            ctx.Requests.Add(vm.Request);

            ctx.SaveChanges();

            return RedirectToAction("All");
        }

        public ActionResult All()
        {
            Requests = ctx.Requests.ToList<Request>();
            /* Markers */
            IEnumerable<MapMarker> markers = (
                                                from r in Requests
                                                select new MapMarker(r.Description, r.Latitude, r.Longitude)
                                             ).ToList();

            /* View Model */
            ViewAllRequestsViewModel vm = new ViewAllRequestsViewModel(Requests, markers);

            return View(vm);
        }
    }
}