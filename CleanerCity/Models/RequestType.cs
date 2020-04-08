
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanerCity.Models
{
    [Table("dbo.REQUEST_TYPES")]
    public class RequestType
    {
        public RequestType()
        {
        }
        public RequestType(int id, string description)
        {
            this.Id = id;
            this.Description = description;
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("description")]
        public string Description { get; set; }
    }
}
