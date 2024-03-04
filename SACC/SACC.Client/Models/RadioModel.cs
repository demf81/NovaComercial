using System.ComponentModel.DataAnnotations;


namespace SACC.Client.Models
{
    public class RadioModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }


        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}