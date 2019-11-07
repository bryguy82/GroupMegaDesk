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

        [Range(24, 96), Required]
        public int width { get; set; }

        [Range(12, 48), Required]
        public int depth { get; set; }

        [Range(0, 7), Required]
        public int drawerNum { get; set; }

        [Required]
        public DesktopMaterial? materialType { get; set; }

        public ICollection<DeskQuote> deskQuotes { get; set; }


        public Desk()
        {

        }

        public int getArea()
        {
            return width * depth;
        }
    }
}
