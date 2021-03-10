using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.GameMechanics;

namespace Chess.ChessFigures
{
    class queen:figure
    {
 
     public static  string WhiteImagePath = "White_Figures/queen.png";
     public static  string BlackImagePath = "Black_Figures/queen.png";
        public static List<int> whiteTargets = new List<int>();
        public static List<int> blackTargets = new List<int>();
     
      

        public static int[] CanMove(title[] arr, int i,string color)
        {
            List<int> indexArr = new List<int>();
           indexArr.AddRange(bishop.CanMove(arr, i, color));
           indexArr.AddRange(castle.CanMove(arr, i, color));
            return indexArr.ToArray();
        }
        public static bool CanMoveAI(title[] arr, int i, string color,int King)
        {
            List<int> indexArr = new List<int>();
            if (bishop.CanMoveAI(arr, i, color, King)) return true;
            if(castle.CanMoveAI(arr, i, color, King)) return true;

            return false;
        }
    }
}
