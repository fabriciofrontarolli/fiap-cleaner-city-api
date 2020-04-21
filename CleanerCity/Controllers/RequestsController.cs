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
            Requests = getAllRequests();
            IEnumerable<MapMarker> markers = getAllRequestsMarkers();

            /* View Model */
            ViewAllRequestsViewModel vm = new ViewAllRequestsViewModel(Requests, markers);

            return View(vm);
        }

        /* API */
        [HttpGet]
        public JsonResult GetAllRequests()
        {
            var requests = getAllRequests();
            return Json(requests, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetAllRequestsMarkers()
        {
            var markers = getAllRequestsMarkers();
            return Json(markers, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetAllRequestsTypes()
        {
            RequestTypes = ctx.RequestTypes.ToList();
            return Json(RequestTypes, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CreateRequest(Request request)
        {
            ctx.Requests.Add(request);

            ctx.SaveChanges();

            return Json(request);
        }

        private List<Request> getAllRequests()
        {
            var requests = ctx.Requests.ToList();
            return requests;
        }

        private IEnumerable<MapMarker> getAllRequestsMarkers()
        {
            Requests = getAllRequests();

            /* Markers */
            IEnumerable<MapMarker> markers = (
                                                from r in Requests
                                                select new MapMarker(r.Description, r.Latitude, r.Longitude)
                                             ).ToList();
            return markers;
        }
    }
}
