using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk
{
    public class Desk
    {
        private int width;
        private int depth;
        private int drawerNum;
        public const int MIN_WIDTH = 24;
        public const int MAX_WIDTH = 96;
        public const int MIN_DEPTH = 12;
        public const int MAX_DEPTH = 48;
        public const int DRAWER_MIN = 0;
        public const int DRAWER_MAX = 7;

        public int Width { get => width; set => width = value; }
        public int Depth { get => depth; set => depth = value; }
        public int DrawerNum { get => drawerNum; set => drawerNum = value; }
        public DesktopMaterial MaterialType { get; set; }
        public enum DesktopMaterial
        {
            Pine = 50,
            Laminate = 100,
            Oak = 200,
            Rosewood = 300,
            Veneer = 150
        };

        public Desk()
        {

        }

        public Desk(int width, int depth, int drawerNum, DesktopMaterial materialType)
        {
            Width = width;
            Depth = depth;
            DrawerNum = drawerNum;
            MaterialType = materialType;
        }

        public int getArea()
        {
            return width * depth;
        }

        
    }
}
