using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace MegaDeskRazor.Models
{
    public class Desk
    {
    
        public Desk(int width, int depth, int drawerNum, string surfaceMaterial)
        {
            this.Width = width;
            this.Depth = depth;
            this.DrawerNum = drawerNum;
            this.SurfaceMaterial = surfaceMaterial;
            this.SurfaceArea = width * depth;
          
        }
        public Desk()
        {
            this.Width = 0;
            this.Depth = 0;
            this.DrawerNum = 0;
            this.SurfaceMaterial = "Oak";
            SurfaceArea = Width * Depth;

        }
        [Key]
        public int DeskId { get; set; }

        public int Width { get; set; }
        public int Depth { get; set; }
        public int DrawerNum { get; set; }
        public string SurfaceMaterial { get; set; }
        public int SurfaceArea { get; set; }

    }

    public enum DesktopMaterial
    {
        Oak,
        Laminate,
        Pine,
        Rosewood,
        Veneer
    }
}
