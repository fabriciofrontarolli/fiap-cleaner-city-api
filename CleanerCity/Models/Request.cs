using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanerCity.Models
{
    [Table("REQUESTS")]
    public class Request
    {
        public Request()
        {
        }
        public Request(int id, string description, string latitude, string longitude, RequestType requestType, User user)
        {
            Id = id;
            Description = description;
            Latitude = latitude;
            Longitude = longitude;
            RequestType = requestType;
            User = user;
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("latitude")]
        public string Latitude { get; set; }

        [Column("longitude")]
        public string Longitude { get; set; }

        [Column("request_type_id")]
        public int RequestTypeId { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        public RequestType RequestType { get; set; }
        public User User{ get; set; }
    }
}