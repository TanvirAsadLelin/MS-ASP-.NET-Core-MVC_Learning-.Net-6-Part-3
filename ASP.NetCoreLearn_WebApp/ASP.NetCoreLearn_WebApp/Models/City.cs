using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace ASP.NetCoreLearn_WebApp.Models
{
    public class City
    {   
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Population { get; set; }
        [DisplayName("Size of Area")]
        public int AreaSize { get; set; }
        [DisplayName("Date of Build")]
        public DateTime BuildDate { get; set; } = DateTime.Now;

    }
}
