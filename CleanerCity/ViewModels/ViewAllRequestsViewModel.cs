using CleanerCity.Models;
using System.Collections.Generic;

namespace CleanerCity.ViewModels
{
    public class ViewAllRequestsViewModel
    {
        public ViewAllRequestsViewModel() { }

        public ViewAllRequestsViewModel(IEnumerable<Request> requests, IEnumerable<MapMarker> mapMarkers)
        {
            Requests = requests;
            MapMarkers = mapMarkers;
            RequestTypes = new List<RequestType>();
        }

        public ViewAllRequestsViewModel(IEnumerable<Request> requests, IEnumerable<MapMarker> mapMarkers, IEnumerable<RequestType> requestTypes)
        {
            Requests = requests;
            MapMarkers = mapMarkers;
            RequestTypes = requestTypes;
        }

        public IEnumerable<Request> Requests { get; set; }
        public IEnumerable<MapMarker> MapMarkers { get; set; }
        public IEnumerable<RequestType> RequestTypes { get; set; }
    }
}
