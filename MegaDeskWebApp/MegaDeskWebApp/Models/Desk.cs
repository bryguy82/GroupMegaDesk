using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MegaDeskWebApp.Models
{
    public class Desk
    {
        public enum DesktopMaterial
        {
            Pine = 50,
            Laminate = 100,
            Oak = 200,
            Rosewood = 300,
            Veneer = 125
        };

        public int ID { get; set; }

        [Display(Name = "Width"), Range(24, 96), Required]
        public int width { get; set; }

        [Display(Name = "Depth"), Range(12, 48), Required]
        public int depth { get; set; }

        [Display(Name = "Number of Drawers"), Range(0, 7), Required]
        public int drawerNum { get; set; }

        [Display(Name = "Material Type"), Required]
        public string materialType { get; set; }

        [Display(Name = "Rush Days"), Required]
        public int rushDays { get; set; }

        public ICollection<DeskQuote> deskQuotes { get; set; }

        public DesktopMaterial? desktopMaterial {get;set;}

        public Desk()
        {

        }

        public int getArea(int width, int depth)
        {
            return width * depth;
        }
    }
}
