using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.GameMechanics;

namespace Chess.ChessFigures
{
    class king: figure
    {
        private static int BlackKingStartPosition = 4;
        private static int WhiteKingStartPosition = 60;
        public static string WhiteImagePath = "White_Figures/king.png";
        public static string BlackImagePath = "Black_Figures/king.png";
        public static List<int> whiteTargets = new List<int>();
        public static List<int> blackTargets = new List<int>();

      
        public static int[] CanMove(title[] arr, int i,string color)
        {
            List<int> blocked;
            if (color == "black") blocked = Table.whiteTargets;
            else blocked = Table.blackTargets;
            List<int> indexArr = new List<int>();
            try
            {
                if ((arr[i + 8].Id_Of_Figure == " " || arr[i + 8].colorOfFigure != color) && blocked.Contains(i + 8) == false && arr[i].sp.Position.Y + title.titleHeight == arr[i + 8].sp.Position.Y) indexArr.Add(i + 8);
                if ((arr[i + 9].Id_Of_Figure == " " || arr[i + 9].colorOfFigure != color) && blocked.Contains(i + 9) == false && arr[i].sp.Position.Y + title.titleHeight == arr[i + 9].sp.Position.Y) indexArr.Add(i + 9);
                if ((arr[i + 7].Id_Of_Figure == " " || arr[i + 7].colorOfFigure != color) && blocked.Contains(i + 7) == false && arr[i].sp.Position.Y + title.titleHeight == arr[i + 7].sp.Position.Y) indexArr.Add(i + 7);
            }
            catch { }

            try
            {
                if ((arr[i - 8].Id_Of_Figure == " " || arr[i - 8].colorOfFigure != color) && blocked.Contains(i - 8) == false && arr[i].sp.Position.Y - title.titleHeight == arr[i - 8].sp.Position.Y) indexArr.Add(i - 8);
                if ((arr[i - 9].Id_Of_Figure == " " || arr[i - 9].colorOfFigure != color) && blocked.Contains(i - 9) == false && arr[i].sp.Position.Y-  title.titleHeight == arr[i - 9].sp.Position.Y) indexArr.Add(i - 9);
                if ((arr[i - 7].Id_Of_Figure == " " || arr[i - 7].colorOfFigure != color) && blocked.Contains(i - 7) == false && arr[i].sp.Position.Y - title.titleHeight == arr[i - 7].sp.Position.Y) indexArr.Add(i - 7);
            }
            catch { }

            try
            {
                if ((arr[i + 1].Id_Of_Figure == " " || arr[i + 1].colorOfFigure != color) && blocked.Contains(i + 1) == false && arr[i].sp.Position.Y == arr[i + 1].sp.Position.Y) indexArr.Add(i + 1);
                if ((arr[i - 1].Id_Of_Figure == " " || arr[i - 1].colorOfFigure != color) && blocked.Contains(i - 1) == false && arr[i].sp.Position.Y == arr[i - 1].sp.Position.Y) indexArr.Add(i - 1);
            }
            catch { }
            if (i == WhiteKingStartPosition && color == "white" && Table.isCheckmateWhite == false && arr[WhiteKingStartPosition + 1].Id_Of_Figure == " " && arr[WhiteKingStartPosition + 2].Id_Of_Figure == " " && arr[WhiteKingStartPosition + 3].Id_Of_Figure == "castle" && arr[WhiteKingStartPosition + 3].colorOfFigure == "white") indexArr.Add(i + 2);
            if (i == WhiteKingStartPosition && color == "white" && Table.isCheckmateWhite == false && arr[WhiteKingStartPosition - 1].Id_Of_Figure == " " && arr[WhiteKingStartPosition - 2].Id_Of_Figure == " " && arr[WhiteKingStartPosition - 3].Id_Of_Figure == " " && arr[WhiteKingStartPosition - 4].Id_Of_Figure=="castle" && arr[WhiteKingStartPosition - 4].colorOfFigure == "white") indexArr.Add(i - 2);
            if (i == BlackKingStartPosition && color == "black" && Table.isCheckmateBlack == false && arr[BlackKingStartPosition + 1].Id_Of_Figure == " " && arr[BlackKingStartPosition + 2].Id_Of_Figure == " " && arr[BlackKingStartPosition + 3].Id_Of_Figure == "castle" && arr[BlackKingStartPosition + 3].colorOfFigure == "black") indexArr.Add(i + 2);
            if (i == BlackKingStartPosition && color == "black" && Table.isCheckmateBlack == false && arr[BlackKingStartPosition - 1].Id_Of_Figure == " " && arr[BlackKingStartPosition - 2].Id_Of_Figure == " " && arr[BlackKingStartPosition - 3].Id_Of_Figure == " " && arr[BlackKingStartPosition - 4].Id_Of_Figure == "castle" && arr[BlackKingStartPosition - 4].colorOfFigure == "black") indexArr.Add(i - 2);

            return indexArr.ToArray();
        }
       
        public static void Castling(title[] arr,string color,int prevPos,int newPos)
        {
            int cof = newPos - prevPos;
            if(cof==2)
            {
                int number=0;
                if (color == "black") number = 7;
                else number = 63;
                arr[prevPos].Id_Of_Figure = " ";
                arr[prevPos].colorOfFigure = " ";
                arr[newPos].Id_Of_Figure = "king";
                arr[newPos].colorOfFigure = color;
                arr[number].Id_Of_Figure = " ";
                arr[number].colorOfFigure = " ";
                arr[prevPos + 1].firstColorOfFigure = arr[number].firstColorOfFigure;
                arr[number].firstColorOfFigure = " ";
                arr[prevPos + 1].Id_Of_Figure = "castle";
                arr[prevPos + 1].colorOfFigure = color;
            }
            else if (cof == -2)
            {
                int number = 0;
                if (color == "black") number = 0;
                else number = 56;
                arr[prevPos].Id_Of_Figure = " ";
                arr[prevPos].colorOfFigure = " ";
                arr[newPos].Id_Of_Figure = "king";
                arr[newPos].colorOfFigure = color;
                arr[number].Id_Of_Figure = " ";
                arr[number].colorOfFigure = " ";
                arr[prevPos - 1].firstColorOfFigure = arr[number].firstColorOfFigure;
                arr[number].firstColorOfFigure = " ";
                arr[prevPos - 1].Id_Of_Figure = "castle";
                arr[prevPos - 1].colorOfFigure = color;
            }
            if (arr[newPos].colorOfFigure == "black") Table.blackKingIndex = newPos;
            else Table.whiteKingIndex = newPos;
        }
      
    }
}
