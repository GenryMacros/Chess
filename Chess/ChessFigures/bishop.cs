using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.GameMechanics;

namespace Chess.ChessFigures
{
    class bishop : figure
    {

        public static string WhiteImagePath = "White_Figures/bishop.png";
        public static string BlackImagePath = "Black_Figures/bishop.png";
        public static List<int> whiteWTargets = new List<int>();
        public static List<int> whiteBTargets = new List<int>();
        public static List<int> blackWTargets = new List<int>();
        public static List<int> blackBTargets = new List<int>();

        public static int[] CanMove(title[] arr, int i, string color)
        {
            List<int> indexArr = new List<int>();

            if (i % 8 != 0)
            {
                indexArr.AddRange(FindTilesLeft(arr, i, indexArr, color));
            }
            if ((i+1) % 8 != 0)
            {
                indexArr.AddRange(FindTilesRight(arr, i, indexArr, color));
            }

            return indexArr.ToArray();
        }
       
      private  static List<int> FindTilesRight(title[] arr, int i, List<int> indexArr, string color)
        {
            if ((i + 1) % 8 == 0) return indexArr;
                try
                {
                for (int k = 0; k > -1; k++)
                {
                    int index = i + 9 + k + 8 * k;
                    if (Iffs(index, arr, indexArr, color) == false) break;
                }
            }
            catch { }
            try
            {
                for (int k = 0; k > -1; k++)
                {
                    int index = i - 7 + k - 8 * k;
                    if (Iffs(index, arr, indexArr, color) == false) break;
                }

            }
            catch { }
            return indexArr;
        }
        private static List<int> FindTilesLeft(title[] arr, int i, List<int> indexArr, string color)
        {
            if (i % 8 == 0) return indexArr;
            try
            {
                for (int k = 0; k > -1; k++)
                {
                    int index = i + 7 - k + 8 * k;
                    if (Iffs(index, arr, indexArr, color) == false) break;

                }
            }
            catch { }
            try
            {
                for (int k = 0; k > -1; k++)
                {
                    int index = i - 9 - k - 8 * k;
                   if( Iffs(index, arr, indexArr, color) ==false) break;

                }
            }
            catch { }
            return indexArr;
        }
        private static bool Iffs(int index, title[] arr, List<int> indexArr, string color)
        {

                if (arr[index].colorOfFigure == color) return false;
                if ((arr[index].colorOfFigure != color && arr[index].Id_Of_Figure != " "))
                {
                indexArr.Add(index);
                return false;
            }
                else if ((index) % 8 == 0 && (arr[index].Id_Of_Figure == " " || arr[index].Id_Of_Figure != color))
                {
                indexArr.Add(index);
                return false;
            }
                else if ((index) % 8 == 0) return false;
            else if ((index + 1) % 8 == 0)
                {
                indexArr.Add(index);
                return false;
            }
                indexArr.Add(index);
            return true;

            
        }
        public static bool CanMoveAI(title[] arr, int i, string color,int King)
        {
            List<int> indexArr = new List<int>();
            

            if (i % 8 != 0)
            {
                if (FindKingInTheLeft(arr, i, indexArr, color, King)) return true;
            }
            if ((i + 1) % 8 != 0)
            {
                if (FindKingInTheRight(arr, i, indexArr, color, King)) return true;
            }

            return false;
        }
       private static bool FindKingInTheRight(title[] arr, int i, List<int> indexArr, string color, int King)
        {
            if ((i + 1) % 8 == 0) return false;
            float lastY = arr[i].sp.Position.Y;
            try
            {
                for (int k = 0; k > -1; k++)
                {
                    int index = i + 9 + k + 8 * k;
                    if (lastY - title.titleHeight != arr[index].sp.Position.Y) break;
                    if (index == King) return true;
                    lastY = arr[index].sp.Position.Y;
                }
            }
            catch { }
            try
            {
                for (int k = 0; k > -1; k++)
                {
                    int index = i - 7 + k - 8 * k;
                    if (lastY + title.titleHeight != arr[index].sp.Position.Y) break;
                    if (index == King) return true;
                    lastY = arr[index].sp.Position.Y;
                }

            }
            catch { }
            return false;
        }
        private static bool FindKingInTheLeft(title[] arr, int i, List<int> indexArr, string color, int King)
        {
            if (i % 8 == 0) return false;
            float lastY = arr[i].sp.Position.Y;
            try
            {
                for (int k = 0; k > -1; k++)
                {
                   
                    int index = i + 7 - k + 8 * k;
                    if (lastY - title.titleHeight != arr[index].sp.Position.Y) break;
                    if (index == King) return true;
                    lastY = arr[index].sp.Position.Y;

                }
            }
            catch { }
            lastY = arr[i].sp.Position.Y;
            try
            {
                for (int k = 0; k > -1; k++)
                {
                    int index = i - 9 - k - 8 * k;
                    if (lastY + title.titleHeight != arr[index].sp.Position.Y) break;
                    if (index == King) return true;
                    lastY = arr[index].sp.Position.Y;

                }
            }
            catch { }
            return false;
        }
  




    }
      
    }

