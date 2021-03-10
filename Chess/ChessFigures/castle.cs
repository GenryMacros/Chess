using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.GameMechanics;

namespace Chess.ChessFigures
{
    class castle : figure
    {
        public static string WhiteImagePath = "White_Figures/castle.png";
        public static string BlackImagePath = "Black_Figures/castle.png";
        public static List<int> whiteBTargets = new List<int>();
        public static List<int> whiteWTargets = new List<int>();
        public static List<int> blackBTargets = new List<int>();
        public static List<int> blackWTargets = new List<int>();
      
        public static int[] CanMove(title[] arr, int i, string color)
        {
            List<int> indexarr = new List<int>();

            for (int j = i + 1; j < arr.Length; j++)
            {
                if ((j + 1) % 8 == 0 && arr[j].colorOfFigure != color)
                {
                    indexarr.Add(j);
                    break;
                }
                else if (j % 8 == 0) break;
                else if (arr[j].colorOfFigure == color) break;
                else if (arr[j].Id_Of_Figure == " ") indexarr.Add(j);
                else if (arr[j].colorOfFigure != color)
                {
                    indexarr.Add(j);
                    break;
                }
                indexarr.Add(j);
            }
            for (int j = i - 1; j >= 0; j--)
            {
                if (i % 8 == 0) break;
                else if (j % 8 == 0 && arr[j].colorOfFigure != color)
                {
                    indexarr.Add(j);
                    break;
                }
                else if (arr[j].colorOfFigure == color) break;
                else if (arr[j].Id_Of_Figure == " ") indexarr.Add(j);
                else if (arr[j].colorOfFigure != color)
                {
                    indexarr.Add(j);
                    break;
                }

            }

            for (int j = 1; j > 0; j++)
            {
                try
                {
                    int index = i + 8 * j;
                    if (arr[index].colorOfFigure == color) break;
                    else if (arr[index].Id_Of_Figure == " ") indexarr.Add(index);
                    else if (arr[index].colorOfFigure != color)
                    {
                        indexarr.Add(index);
                        break;
                    }
                }
                catch { break; }


            }
            for (int j = -1; j < 0; j--)
            {
                try
                {
                    int index = i + 8 * j;
                    if (arr[index].colorOfFigure == color) break;
                    else if (arr[index].Id_Of_Figure == " ") indexarr.Add(index);
                    else if (arr[index].colorOfFigure != color)
                    {
                        indexarr.Add(index);
                        break;
                    }

                }
                catch { break; }
            }
            return indexarr.ToArray();
        }
        public static bool CanMoveAI(title[] arr, int i, string color,int King)
        {
        

            for (int j = i + 1; j < arr.Length; j++)
            {
              
                 if (j % 8 == 0) break;
                else if (arr[j].colorOfFigure == color) break;
                else if (j == King) return true;
              
             
            }
            for (int j = i - 1; j >= 0; j--)
            {
                if (i % 8 == 0) break;
                else if (arr[j].colorOfFigure == color) break;
                else if ( j == King) return true;
              

            }

            for (int j = 1; j > 0; j++)
            {
                try
                {
                    int index = i + 8 * j;
                    if (arr[index].colorOfFigure == color) break;
                    else if (arr[index].colorOfFigure != color && index == King) return true;
                   
                }
                catch { break; }


            }
            for (int j = -1; j < 0; j--)
            {
                try
                {
                    int index = i + 8 * j;
                    if (arr[index].colorOfFigure == color) break;
                    else if (arr[index].colorOfFigure != color && index==King) return true;
                  

                }
                catch { break; }
            }
            return false;
        }
    }
       
}
