using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.ChessFigures;
using SFML.Graphics;
using SFML.Audio;
using SFML.System;
using SFML.Window;

namespace Chess.GameMechanics
{
    class TableSelectors
    {
        internal static void ChangeTargets(string color)
        {
            if (color == "black")
            {
                Table.blackTargets.Clear();
                Table.blackTargets.AddRange(bishop.blackBTargets);
                Table.blackTargets.AddRange(horse.blackBTargets);
                Table.blackTargets.AddRange(castle.blackBTargets);
                Table.blackTargets.AddRange(bishop.blackWTargets);
                Table.blackTargets.AddRange(horse.blackWTargets);
                Table.blackTargets.AddRange(castle.blackWTargets);
                Table.blackTargets.AddRange(king.blackTargets);
                Table.blackTargets.AddRange(queen.blackTargets);
                Table.blackTargets.AddRange(pawn.blackTargets);
                if (Table.blackTargets.Contains(Table.whiteKingIndex)) Table.isCheckmateWhite = true;
            }
            else if (color == "white")
            {
                Table.whiteTargets.Clear();
                Table.whiteTargets.AddRange(bishop.whiteWTargets);
                Table.whiteTargets.AddRange(horse.whiteWTargets);
                Table.whiteTargets.AddRange(castle.whiteWTargets);
                Table.whiteTargets.AddRange(bishop.whiteBTargets);
                Table.whiteTargets.AddRange(horse.whiteBTargets);
                Table.whiteTargets.AddRange(castle.whiteBTargets);
                Table.whiteTargets.AddRange(king.whiteTargets);
                Table.whiteTargets.AddRange(queen.whiteTargets);
                Table.whiteTargets.AddRange(pawn.whiteTargets);
                if (Table.whiteTargets.Contains(Table.blackKingIndex)) Table.isCheckmateBlack = true;
            }
        }
        internal static void ChangeFigureTargets(title title, int index)
        {
            switch (title.Id_Of_Figure)
            {
                case "pawn":
                    if (title.colorOfFigure == "black")
                    {
                        pawn.blackTargets.Clear();
                        pawn.blackTargets.AddRange(PawnTargets(Table.actualDeck, "black"));
                        ChangeTargets("black");
                    }
                    else
                    {
                        pawn.whiteTargets.Clear();
                        pawn.whiteTargets.AddRange(PawnTargets(Table.actualDeck, "white"));
                        ChangeTargets("white");
                    }
                    break;
                case "queen":
                    if (title.colorOfFigure == "black")
                    {
                        queen.blackTargets.Clear();

                        queen.blackTargets.AddRange(queen.CanMove(Table.actualDeck, index, Table.actualDeck[index].colorOfFigure));
                        ChangeTargets("black");
                    }
                    else
                    {
                        queen.whiteTargets.Clear();
                        queen.whiteTargets.AddRange(queen.CanMove(Table.actualDeck, index, Table.actualDeck[index].colorOfFigure));
                        ChangeTargets("white");
                    }
                    break;
                case "king":
                    if (title.colorOfFigure == "black")
                    {
                        title[] arr = Table.actualDeck;
                        int i = index;
                        king.blackTargets.Clear();
                        try
                        {
                            if ((arr[i + 8].Id_Of_Figure == " ") && arr[i].sp.Position.Y + title.titleHeight == arr[i + 8].sp.Position.Y) king.blackTargets.Add(i + 8);
                            if ((arr[i + 9].Id_Of_Figure == " " )  && arr[i].sp.Position.Y + title.titleHeight == arr[i + 9].sp.Position.Y) king.blackTargets.Add(i + 9);
                            if ((arr[i + 7].Id_Of_Figure == " ")  && arr[i].sp.Position.Y + title.titleHeight == arr[i + 7].sp.Position.Y) king.blackTargets.Add(i + 7);
                        }
                        catch { }

                        try
                        {
                            if ((arr[i - 8].Id_Of_Figure == " ")  && arr[i].sp.Position.Y - title.titleHeight == arr[i - 8].sp.Position.Y) king.blackTargets.Add(i - 8);
                            if ((arr[i - 9].Id_Of_Figure == " ") && arr[i].sp.Position.Y - title.titleHeight == arr[i - 9].sp.Position.Y) king.blackTargets.Add(i - 9);
                            if ((arr[i - 7].Id_Of_Figure == " ") && arr[i].sp.Position.Y - title.titleHeight == arr[i - 7].sp.Position.Y) king.blackTargets.Add(i - 7);
                        }
                        catch { }

                        try
                        {
                            if ((arr[i + 1].Id_Of_Figure == " ")  && arr[i].sp.Position.Y == arr[i + 1].sp.Position.Y) king.blackTargets.Add(i + 1);
                            if ((arr[i - 1].Id_Of_Figure == " ")  && arr[i].sp.Position.Y == arr[i - 1].sp.Position.Y) king.blackTargets.Add(i - 1);
                        }
                        catch { }
                      
                        ChangeTargets("black");
                    }
                    else
                    {
                        title[] arr = Table.actualDeck;
                        int i = index;
                        king.whiteTargets.Clear();
                        try
                        {
                            if ((arr[i + 8].Id_Of_Figure == " ") && arr[i].sp.Position.Y + title.titleHeight == arr[i + 8].sp.Position.Y) king.whiteTargets.Add(i + 8);
                            if ((arr[i + 9].Id_Of_Figure == " ") && arr[i].sp.Position.Y + title.titleHeight == arr[i + 9].sp.Position.Y) king.whiteTargets.Add(i + 9);
                            if ((arr[i + 7].Id_Of_Figure == " ") && arr[i].sp.Position.Y + title.titleHeight == arr[i + 7].sp.Position.Y) king.whiteTargets.Add(i + 7);
                        }
                        catch { }

                        try
                        {
                            if ((arr[i - 8].Id_Of_Figure == " ") && arr[i].sp.Position.Y - title.titleHeight == arr[i - 8].sp.Position.Y) king.whiteTargets.Add(i - 8);
                            if ((arr[i - 9].Id_Of_Figure == " ") && arr[i].sp.Position.Y - title.titleHeight == arr[i - 9].sp.Position.Y) king.whiteTargets.Add(i - 9);
                            if ((arr[i - 7].Id_Of_Figure == " ") && arr[i].sp.Position.Y - title.titleHeight == arr[i - 7].sp.Position.Y) king.whiteTargets.Add(i - 7);
                        }
                        catch { }

                        try
                        {
                            if ((arr[i + 1].Id_Of_Figure == " ") && arr[i].sp.Position.Y == arr[i + 1].sp.Position.Y) king.whiteTargets.Add(i + 1);
                            if ((arr[i - 1].Id_Of_Figure == " ") && arr[i].sp.Position.Y == arr[i - 1].sp.Position.Y) king.whiteTargets.Add(i - 1);
                        }
                        catch { }

                        ChangeTargets("white");
                    }
                    break;
                case "castle":
                    if (title.colorOfFigure == "black")
                    {
                        if (title.firstColorOfFigure == "black")
                        {
                            castle.blackBTargets.Clear();
                            castle.blackBTargets.AddRange(castle.CanMove(Table.actualDeck, index, Table.actualDeck[index].colorOfFigure));

                        }
                        else if (title.firstColorOfFigure == "white")
                        {
                            castle.blackWTargets.Clear();
                            castle.blackWTargets.AddRange(castle.CanMove(Table.actualDeck, index, Table.actualDeck[index].colorOfFigure));
                        }
                        ChangeTargets("black");
                    }
                    else
                    {
                        if (title.firstColorOfFigure == "black")
                        {
                            castle.whiteBTargets.Clear();
                            castle.whiteBTargets.AddRange(castle.CanMove(Table.actualDeck, index, Table.actualDeck[index].colorOfFigure));
                        }
                        else if (title.firstColorOfFigure == "white")
                        {
                            castle.whiteWTargets.Clear();
                            castle.whiteWTargets.AddRange(castle.CanMove(Table.actualDeck, index, Table.actualDeck[index].colorOfFigure));
                        }
                        ChangeTargets("white");
                    }
                    break;
                case "horse":
                    if (title.colorOfFigure == "black")
                    {
                        if (title.firstColorOfFigure == "black")
                        {
                            horse.blackBTargets.Clear();
                            horse.blackBTargets.AddRange(horse.CanMove(Table.actualDeck, index, Table.actualDeck[index].colorOfFigure));

                        }
                        else if (title.firstColorOfFigure == "white")
                        {
                            horse.blackWTargets.Clear();
                            horse.blackWTargets.AddRange(horse.CanMove(Table.actualDeck, index, Table.actualDeck[index].colorOfFigure));
                        }
                        ChangeTargets("black");
                    }
                    else
                    {
                        if (title.firstColorOfFigure == "black")
                        {
                            horse.whiteBTargets.Clear();
                            horse.whiteBTargets.AddRange(horse.CanMove(Table.actualDeck, index, Table.actualDeck[index].colorOfFigure));
                        }
                        else if (title.firstColorOfFigure == "white")
                        {
                            horse.whiteWTargets.Clear();
                            horse.whiteWTargets.AddRange(horse.CanMove(Table.actualDeck, index, Table.actualDeck[index].colorOfFigure));
                        }
                        ChangeTargets("white");
                    }
                    break;
                case "bishop":
                    if (title.colorOfFigure == "black")
                    {
                        if (title.firstColorOfFigure == "black")
                        {
                            bishop.blackBTargets.Clear();
                            bishop.blackBTargets.AddRange(bishop.CanMove(Table.actualDeck, index, Table.actualDeck[index].colorOfFigure));
                        }
                        else if (title.firstColorOfFigure == "white")
                        {
                            bishop.blackWTargets.Clear();
                            bishop.blackWTargets.AddRange(bishop.CanMove(Table.actualDeck, index, Table.actualDeck[index].colorOfFigure));
                        }
                        ChangeTargets("black");
                    }
                    else
                    {
                        if (title.firstColorOfFigure == "black")
                        {
                            bishop.whiteBTargets.Clear();
                            bishop.whiteBTargets.AddRange(bishop.CanMove(Table.actualDeck, index, Table.actualDeck[index].colorOfFigure));
                        }
                        else if (title.firstColorOfFigure == "white")
                        {
                            bishop.whiteWTargets.Clear();
                            bishop.whiteWTargets.AddRange(bishop.CanMove(Table.actualDeck, index, Table.actualDeck[index].colorOfFigure));
                        }
                        ChangeTargets("white");
                    }
                    break;
            }
            for (int k = 0; k < Table.selectedTiles.Count; k++)
            {
                Table.actualDeck[Table.selectedTiles[k]].ChangeTitle();

                if (Table.actualDeck[index].colorOfFigure == "black" && Table.selectedTiles.Contains(Table.whiteKingIndex)) Table.isCheckmateWhite = true;
                else if (Table.actualDeck[index].colorOfFigure == "white" && Table.selectedTiles.Contains(Table.blackKingIndex)) Table.isCheckmateBlack = true;
            }
            Table.selectedTiles.Clear();

        }
        public static void TwoFigureChanger(int newPos,int prevPos)
        {
            if (Table.actualDeck[prevPos].Id_Of_Figure == "king" && ((newPos == prevPos-2) || (newPos == prevPos + 2)))
            {
                king.Castling(Table.actualDeck, Table.actualDeck[prevPos].colorOfFigure, prevPos, newPos);
                return;

            }
            Table.actualDeck[newPos].Id_Of_Figure = Table.actualDeck[prevPos].Id_Of_Figure;
            Table.actualDeck[newPos].colorOfFigure = Table.actualDeck[prevPos].colorOfFigure;
            Table.actualDeck[newPos].firstColorOfFigure = Table.actualDeck[prevPos].firstColorOfFigure;
            Table.actualDeck[prevPos].Id_Of_Figure = " ";
            Table.actualDeck[prevPos].colorOfFigure = " ";
            Table.actualDeck[prevPos].firstColorOfFigure = " ";
            if (Table.actualDeck[newPos].Id_Of_Figure == "king")
            {
                if (Table.actualDeck[newPos].colorOfFigure == "white") Table.whiteKingIndex = newPos;
                if (Table.actualDeck[newPos].colorOfFigure == "black") Table.blackKingIndex = newPos;
                
            }
        }
 
        public static bool FigureMover(int newPos,int prevPos, RenderWindow win)
        {
            string colorF = Table.actualDeck[newPos].colorOfFigure;
            string ID = Table.actualDeck[newPos].Id_Of_Figure;
            string FC = Table.actualDeck[newPos].firstColorOfFigure;
            int WhiteKing = Table.whiteKingIndex;
            int BlackKing = Table.blackKingIndex;

            TwoFigureChanger(newPos, prevPos);
            if (calculateCheckmate(Table.actualDeck[newPos].colorOfFigure))
            {
                Table.actualDeck[prevPos].Id_Of_Figure = Table.actualDeck[newPos].Id_Of_Figure;
                Table.actualDeck[prevPos].colorOfFigure = Table.actualDeck[newPos].colorOfFigure;
                Table.actualDeck[prevPos].firstColorOfFigure = Table.actualDeck[newPos].firstColorOfFigure;
                Table.actualDeck[newPos].Id_Of_Figure = ID;
                Table.actualDeck[newPos].colorOfFigure = colorF;
                Table.actualDeck[newPos].firstColorOfFigure = FC;
                Table.blackKingIndex = BlackKing;
                Table.whiteKingIndex = WhiteKing;

                return false;
            }
            if (ID != " ")
            {
                CleanTargets(ID, colorF, FC);
                ChangeTargets(colorF);
               
            }
            if (Table.actualDeck[newPos].Id_Of_Figure == "pawn" && (Table.actualDeck[newPos].sp.Position.Y == 0 || Table.actualDeck[newPos].sp.Position.Y == title.titleHeight * 7)) pawn.transformation(Table.actualDeck[newPos], win, newPos);
            return true;

        }

        public static bool calculateCheckmate(string color)
        {
     
            if (color == "white")
            {
                  if (Table.isCheckmateWhite == false && 47<Table.whiteKingIndex && Table.whiteKingIndex <= 63) return false;
                return Plunk("black",Table.actualDeck,Table.whiteKingIndex);
               
            }
            else
            {
                  if (Table.isCheckmateBlack == false && 0 < Table.blackKingIndex && Table.blackKingIndex <= 15) return false;
                return  Plunk("white", Table.actualDeck, Table.blackKingIndex);
               
            }
          
        }
  
        private static void CleanTargets(string id,string color,string first)
        {
            switch (id)
            {
                case "pawn":
                    if (color == "black") pawn.blackTargets.Clear();
                    if (color == "white") pawn.whiteTargets.Clear();
                    PawnTargets(Table.actualDeck, color);
                    break;
                case "queen":
                    if (color == "white") queen.whiteTargets.Clear();
                    else queen.blackTargets.Clear();
                    break;
                case "king":
                  
                    break;
                case "castle":
                    if (color == "white" && first == "white") castle.whiteWTargets.Clear();
                    else if(color == "white" && first == "black") castle.whiteBTargets.Clear();
                    else if(color == "black" && first == "white") castle.blackWTargets.Clear();
                    else if (color == "black" && first == "black") castle.blackBTargets.Clear();

                    break;
                case "horse":
                    if (color == "white" && first == "white") horse.whiteWTargets.Clear();
                    else if (color == "white" && first == "black") horse.whiteBTargets.Clear();
                    else if (color == "black" && first == "white") horse.blackWTargets.Clear();
                    else if (color == "black" && first == "black") horse.blackBTargets.Clear();
                    break;
                case "bishop":
                    if (color == "white" && first == "white") bishop.whiteWTargets.Clear();
                    else if (color == "white" && first == "black") bishop.whiteBTargets.Clear();
                    else if (color == "black" && first == "white") bishop.blackWTargets.Clear();
                    else if (color == "black" && first == "black") bishop.blackBTargets.Clear();
                    break;
            }
        }
        internal static bool Plunk(string color,title[] arr,int kingIndex)
        {
            //List<int> targets = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].colorOfFigure != color ) continue;
                if (arr[i].Id_Of_Figure == "queen")
                {
                    if (queen.CanMove(arr, i, color).Contains(kingIndex)) return true;
                }
                if (arr[i].Id_Of_Figure == "bishop") 
                {
                    if (bishop.CanMove(arr, i, color).Contains(kingIndex)) return true;
                }
                if (arr[i].Id_Of_Figure == "castle")
                {
                    if (castle.CanMove(arr, i, color).Contains(kingIndex)) return true;
                }
                if (arr[i].Id_Of_Figure == "horse") 
                {
                    if (horse.CanMove(arr, i, color).Contains(kingIndex)) return true;
                }
                if (arr[i].Id_Of_Figure == "pawn") 
                {
                    if (pawn.CanMove(arr, i, color).Contains(kingIndex)) return true;
                }
                if (arr[i].Id_Of_Figure == "king") 
                {
                    if (king.CanMove(arr, i, color).Contains(kingIndex)) return true;
                }
            }
            return false;
        }
       internal static List<int> PawnTargets(title[] arr,string color)
        {
            List<int> targets = new List<int>();
            int endNumber = 0;
            int modifier = 1;
            if (color == "black")
            {
                endNumber = 56;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (i < endNumber && arr[i].colorOfFigure == color && arr[i].Id_Of_Figure == "pawn")
                    {
                        targets.Add(i + 9 * modifier);
                        targets.Add(i + 7 * modifier);

                    }
                }
            }
            else
            {
                endNumber = 7;
                modifier = -1;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (i < endNumber && arr[i].colorOfFigure == color && arr[i].Id_Of_Figure == "pawn")
                    {
                        targets.Add(i + 9 * modifier);
                        targets.Add(i + 7 * modifier);

                    }
                }
            }


            return targets;
        }
    }
}
