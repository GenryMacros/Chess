using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.GameMechanics;

namespace Chess.ChessFigures
{
    class horse: figure
    {
        string id = "horse";
        public static string WhiteImagePath = "White_Figures/horse.png";
        public static string BlackImagePath = "Black_Figures/horse.png";
        public static List<int> whiteWTargets = new List<int>();
        public static List<int> whiteBTargets = new List<int>();
        public static List<int> blackWTargets = new List<int>();
        public static List<int> blackBTargets = new List<int>();
        public static int BlackCost = -30;
        public static int WhiteCost = 30;
        public horse(string Color)
        {
            if (Color == "White") im = new SFML.Graphics.Image(WhiteImagePath);
            else im = new SFML.Graphics.Image(BlackImagePath);
            text = new SFML.Graphics.Texture(im);
            sp = new SFML.Graphics.Sprite(text);
        }

        public static int[] CanMove(title[] arr, int i,string color)
        {
            List<int> indexArr = new List<int>();

            ChecknAdd(i + 17, arr, indexArr, color, i, 2);
            ChecknAdd(i + 15, arr, indexArr, color, i, 2);
            ChecknAdd(i - 17, arr, indexArr, color, i,-2);
            ChecknAdd(i - 15, arr, indexArr, color, i,-2);
            ChecknAdd(i + 10, arr, indexArr, color, i, 1);
            ChecknAdd(i + 6,  arr, indexArr, color, i, 1);
            ChecknAdd(i - 10, arr, indexArr, color, i,-1);
            ChecknAdd(i - 6,  arr, indexArr, color, i,-1);

            return indexArr.ToArray();
        }
        public static bool CanMoveAI(title[] arr, int i, string color,int King)
        {
          

            if (ChecknAddAI(i + 17, arr, color, i, 2, King)) return true;
            if (ChecknAddAI(i + 15, arr, color, i, 2, King)) return true;
            if (ChecknAddAI(i - 17, arr, color, i, -2, King)) return true;
            if (ChecknAddAI(i - 15, arr, color, i, -2, King)) return true;
            if (ChecknAddAI(i + 10, arr, color, i, 1, King)) return true;
            if (ChecknAddAI(i + 6, arr, color, i, 1, King)) return true;
            if (ChecknAddAI(i - 10, arr, color, i, -1, King)) return true;
            if (ChecknAddAI(i - 6, arr, color, i, -1, King)) return true;

            return false;
        }
        private static bool ChecknAddAI(int index, title[] arr, string color, int i, int modifier,int King)
        {
            try
            {
                if ((arr[index].Id_Of_Figure == " " || arr[index].colorOfFigure != color) && (arr[index].sp.Position.Y == arr[i].sp.Position.Y + modifier * title.titleHeight) && King==index) return true;
            }
            catch { }
            return false;
        }
        private static void ChecknAdd(int index,title[] arr,List<int> indexArr,string color,int i,int modifier)
        {
            try
            {
                if ((arr[index].Id_Of_Figure == " " || arr[index].colorOfFigure != color) && (arr[index].sp.Position.Y == arr[i].sp.Position.Y + modifier*title.titleHeight)) indexArr.Add(index);
            }
            catch { }
        }

       

    }
}
