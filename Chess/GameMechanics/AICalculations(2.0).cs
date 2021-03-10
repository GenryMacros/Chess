using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Chess.ChessFigures;
namespace Chess.GameMechanics
{
    class AICalculations_2
    {
        static Dictionary<string, int> FigureValue = new Dictionary<string, int> {
            {"pawn",10 },
            {"castle",50},
            {"bishop",30},
            {"horse",30},
            {"queen",90},
            {"king",900} 
        };
        static double[] pawnBlackPositionValue = new double[] {
        0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0,
        5.0, 5.0, 5.0, 5.0, 5.0, 5.0, 5.0, 5.0,
        1.0, 1.0, 2.0, 3.0, 3.0, 2.0, 1.0, 1.0,
        0.5, 0.5, 1.0, 2.5, 2.5, 1.0, 0.5, 0.5,
        0.0, 0.0, 0.0, 2.0, 2.0, 0.0, 0.0, 0.0,
        0.5, -0.5-1.0, 0.0, 0.0, -1.0,-0.5,0.5,
        0.5, 1.0, 1.0, -2.0,-2.0, 1.0, 1.0, 0.5,
        0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0
        };
        static double[] castleBlackPositionValue = new double[] {
        0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0,
        0.5, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 0.5,
       -0.5, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, -0.5,
       -0.5, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, -0.5,
       -0.5, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, -0.5,
       -0.5, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, -0.5,
       -0.5, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, -0.5,
        0.0, 0.0, 0.0, 0.5, 0.5, 0.0, 0.0, 0.0
        };
        static double[] bishopBlackPositionValue = new double[] {
       -2.0, -1.0, -1.0, -1.0, -1.0, -1.0, -1.0, -2.0,
       -1.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, -1.0,
       -1.0, 0.0, 0.5, 1.0, 1.0, 0.5, 0.0, -1.0,
       -1.0, 0.5, 0.5, 1.0, 1.0, 0.5, 0.5, -1.0,
       -1.0, 0.0, 1.0, 1.0, 1.0, 1.0, 0.0, -1.0,
       -1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, -1.0,
       -1.0, 0.5, 0.0, 0.0, 0.0, 0.0, 0.5, -1.0,
       -2.0, -1.0, -1.0, -1.0, -1.0, -1.0, -1.0, -2.0
    };
        static double[] horseBlackPositionValue = new double[] {
       -5.0, -4.0, -3.0, -3.0, -3.0, -3.0, -4.0, -5.0,
       -4.0, -2.0, 0.0, 0.0, 0.0, 0.0, -2.0, -4.0,
       -3.0, 0.0, 1.0, 1.5, 1.5, 1.0, 0.0, -3.0,
       -3.0, 0.5, 1.5, 2.0, 2.0, 1.5, 0.5, -3.0,
       -3.0, 0.0, 1.5, 2.0, 2.0, 1.5, 0.0, -3.0,
       -3.0, 0.5, 1.0, 1.5, 1.5, 1.0, 0.5, -3.0,
       -4.0, -2.0, 0.0, 0.5, 0.5, 0.0, -2.0, -4.0,
       -5.0, -4.0, -3.0, -3.0, -3.0, -3.0, -4.0, -5.0
            };
        static double[] queenBlackPositionValue = new double[] {

       -2.0, -1.0, -1.0, -0.5, -0.5, -1.0, -1.0, -2.0,
       -1.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, -1.0,
       -1.0, 0.0, 0.5, 0.5, 0.5, 0.5, 0.0, -1.0,
       -0.5, 0.0, 0.5, 0.5, 0.5, 0.5, 0.0, -0.5,
        0.0, 0.0, 0.5, 0.5, 0.5, 0.5, 0.0, -0.5,
       -1.0, 0.5, 0.5, 0.5, 0.5, 0.5, 0.0, -1.0,
       -1.0, 0.0, 0.5, 0.0, 0.0, 0.0, 0.0, -1.0,
       -2.0,-1.0,-1.0,-0.5,-0.5,-1.0,-1.0, -2.0
        };
        static double[] kingBlackPositionValue = new double[] {
       -3.0, -4.0, -4.0, -5.0, -5.0, -4.0, -4.0, -3.0,
       -3.0, -4.0, -4.0, -5.0, -5.0, -4.0, -4.0, -3.0,
       -3.0, -4.0, -4.0, -5.0, -5.0, -4.0, -4.0, -3.0,
       -3.0, -4.0, -4.0, -5.0, -5.0, -4.0, -4.0, -3.0,
       -2.0, -3.0, -3.0, -4.0, -4.0, -3.0, -3.0, -2.0,
       -1.0, -2.0, -2.0, -2.0, -2.0, -2.0, -2.0, -1.0,
        2.0,  2.0,  0.0,  0.0,  0.0,  0.0,  2.0,  2.0,
        2.0,  3.0,  1.0,  0.0,  0.0,  1.0,  3.0,  2.0
        };
        static double[] pawnWhitePositionValue = pawnBlackPositionValue;
        static double[] castleWhitePositionValue = castleBlackPositionValue;
        static double[] bishopWhitePositionValue = bishopBlackPositionValue;
        static double[] horseWhitePositionValue = horseBlackPositionValue;
        static double[] queenWhitePositionValue = queenBlackPositionValue;
        static double[] kingWhitePositionValue = kingBlackPositionValue;
        static int depth = 1;
        static double currentBestValue = 0;
        static double currentDeckCost = 0;
        static List<int> TargetedByWhiteTiles = new List<int>();
        public static void AIStart()
        {
            Array.Reverse(pawnBlackPositionValue);
            Array.Reverse(castleBlackPositionValue);
            Array.Reverse(bishopBlackPositionValue);
            Array.Reverse(horseBlackPositionValue);
            Array.Reverse(queenBlackPositionValue);
            Array.Reverse(kingBlackPositionValue);
        }
        public static int[] CalculateBestMove(title[] Board)
        {
            title[] PhantomBoard = Board;
            double BestMove = 99999;
            int BestOldPosition = 0;
            int BestNewBosition = 0;
            int PhantomWhiteKingPosition = Table.whiteKingIndex;
            int PhantomBlackKingPosition = Table.blackKingIndex;
            bool CheckmateBlack = Table.isCheckmateBlack;
            bool CheckMateWhite = Table.isCheckmateWhite;
            Dictionary<int, int[]> PossibleMoves = GetPossibleMoves(Board, "black");
            double alpha = GetDeckValue(Board);

            for (int i = 0; i <= PossibleMoves.Keys.Max(); i++)
            {
                if (!PossibleMoves.ContainsKey(i)) continue;
                int[] CurrentFigurePossibleMoves = PossibleMoves[i];
                for(int j=0;j< CurrentFigurePossibleMoves.Length; j++)
                {
                    double NewCost = CostAfterFigureMove(Board, i, CurrentFigurePossibleMoves[j], depth, BestMove, PhantomBlackKingPosition, PhantomWhiteKingPosition, CheckmateBlack, CheckMateWhite, 99999);
                    if (NewCost <= BestMove)
                    {
                        BestMove = NewCost;
                        BestOldPosition = i;
                        BestNewBosition = CurrentFigurePossibleMoves[j];
                    }
                    Table.isCheckmateBlack = CheckmateBlack;
                    Table.isCheckmateWhite = CheckMateWhite;
                }
            }

            return new int[] { BestOldPosition, BestNewBosition };

        }
        
  
        static double CostAfterFigureMove(title[] deck,int OldPosition,int NewPosition,int depth,double bestValue,int BlackKingIndex,int WhiteKingIndex,bool BlackCheck,bool WhiteCheck,double Best)
        {
           
            int BlackKing = BlackKingIndex;
            int WhiteKing = WhiteKingIndex;
            double value = 0;
            string colorF = deck[NewPosition].colorOfFigure;
            string ID = deck[NewPosition].Id_Of_Figure;
            string FC = deck[NewPosition].firstColorOfFigure;
            deck[NewPosition].Id_Of_Figure = deck[OldPosition].Id_Of_Figure;
            deck[NewPosition].colorOfFigure = deck[OldPosition].colorOfFigure;
            deck[NewPosition].firstColorOfFigure = deck[OldPosition].firstColorOfFigure;
            deck[OldPosition].Id_Of_Figure = " ";
            deck[OldPosition].colorOfFigure = " ";
            deck[OldPosition].firstColorOfFigure = " ";
            if (deck[NewPosition].Id_Of_Figure == "king")
            {
                if (deck[NewPosition].colorOfFigure == "white") WhiteKing = NewPosition;
                else BlackKing = NewPosition;
            }
            double val=GetDeckValue(deck);
         if (deck[NewPosition].colorOfFigure=="white") Table.isCheckmateBlack=IsCheckMate(deck[NewPosition].Id_Of_Figure, deck[NewPosition].colorOfFigure, deck, NewPosition, BlackKingIndex);
           else Table.isCheckmateWhite=IsCheckMate(deck[NewPosition].Id_Of_Figure, deck[NewPosition].colorOfFigure, deck, NewPosition, WhiteKingIndex);

            List<int> targets1 = new List<int>();
            string color = "white";
            if (deck[NewPosition].colorOfFigure == "white") color = "black";
            if ((deck[NewPosition].colorOfFigure == "white" && Table.isCheckmateWhite == true)) value = -99999;
            else if (deck[NewPosition].colorOfFigure == "black" && Table.isCheckmateBlack == true) value = 99999;
           

            if (depth == 0 && Table.isCheckmateBlack==true && GG("black",deck)) value = 99999;
            else if (depth == 0 || ((deck[NewPosition].colorOfFigure == "white" && val < Best) || (deck[NewPosition].colorOfFigure == "black" && val > Best))) value = val;
            else if(Table.isCheckmateWhite==true && GG("white", deck)) value = -99999;
            else if (deck[NewPosition].colorOfFigure == "black") value = CalculateFutureCost(deck, depth, "white", BlackKing, WhiteKing, Table.isCheckmateBlack, Table.isCheckmateWhite);
            else if (deck[NewPosition].colorOfFigure == "white") value = CalculateFutureCost(deck, depth, "black", BlackKing, WhiteKing, Table.isCheckmateBlack, Table.isCheckmateWhite);
          

            deck[OldPosition].Id_Of_Figure = deck[NewPosition].Id_Of_Figure;
            deck[OldPosition].colorOfFigure = deck[NewPosition].colorOfFigure;
            deck[OldPosition].firstColorOfFigure = deck[NewPosition].firstColorOfFigure;
            deck[NewPosition].Id_Of_Figure = ID;
            deck[NewPosition].colorOfFigure = colorF;
            deck[NewPosition].firstColorOfFigure = FC;
            return value;
        }
        public static bool GG(string color,title[] actualDeck)
        {
            if (color == "white")
            {
                for (int j = 0; j < actualDeck.Length; j++)
                {
                    if (actualDeck[j].colorOfFigure == color && PhantomTable.CanThisBlock(j, actualDeck[j].Id_Of_Figure, actualDeck)) return false;

                }

            }
            else if (color == "black")
            {
                for (int j = 0; j < actualDeck.Length; j++)
                {
                    if (actualDeck[j].colorOfFigure == color && PhantomTable.CanThisBlock(j, actualDeck[j].Id_Of_Figure, actualDeck)) return false;

                }
            }
            return true;
        }
        static double CalculateFutureCost(title[] deck,int depth,string color, int BlackKingIndex, int WhiteKingIndex, bool BlackCheck, bool WhiteCheck)
        {
            double value;
            if (color == "white")
            {
                value = -99999;
                Dictionary<int, int[]> PossibleMoves = GetPossibleMoves(deck, "white");
                double alpha = GetDeckValue(deck);
                for (int i = 0; i <= PossibleMoves.Keys.Max(); i++)
                {
                    if (!PossibleMoves.ContainsKey(i)) continue;
                    int[] CurrentFigurePossibleMoves = PossibleMoves[i];
                    for (int j = 0; j < CurrentFigurePossibleMoves.Length; j++)
                    {
                        double NewCost = CostAfterFigureMove(deck, i, CurrentFigurePossibleMoves[j], depth - 1, value, BlackKingIndex, WhiteKingIndex, BlackCheck, WhiteCheck, alpha);
                        if (NewCost >= value)
                        {
                            value = NewCost;
                        }
                        Table.isCheckmateBlack = BlackCheck;
                        Table.isCheckmateWhite = WhiteCheck;
                    }
                }


                return value;
            }
            else
            {
              
                value = 99999;
                Dictionary<int, int[]> PossibleMoves = GetPossibleMoves(deck, "black");
                double alpha = GetDeckValue(deck);
                for (int i = 0; i <= PossibleMoves.Keys.Max(); i++)
                {
                    if (!PossibleMoves.ContainsKey(i)) continue;
                    int[] CurrentFigurePossibleMoves = PossibleMoves[i];
                    for (int j = 0; j < CurrentFigurePossibleMoves.Length; j++)
                    {
                        double NewCost = CostAfterFigureMove(deck, i, CurrentFigurePossibleMoves[j], depth-1, value, BlackKingIndex, WhiteKingIndex, BlackCheck, WhiteCheck, alpha);
                        if (NewCost <= value)
                        {
                            value = NewCost;
                           
                        }
                        Table.isCheckmateBlack = BlackCheck;
                        Table.isCheckmateWhite = WhiteCheck;
                    }
                }
                return value;
            }
        }
      public static double GetDeckValue(title[] deck)
        {
            double value = 0;
            for(int i = 0; i < deck.Length; i++)
            {
                if(deck[i].Id_Of_Figure!=" ")
                {
                    switch (deck[i].Id_Of_Figure)
                    {
                        case "pawn":
                            if (deck[i].colorOfFigure == "white") value += 10 + pawnWhitePositionValue[i];
                            else value += -(FigureValue["pawn"] + pawnBlackPositionValue[i]);
                            break;
                        case "castle":
                            if (deck[i].colorOfFigure == "white") value += 50 + castleWhitePositionValue[i];
                            else value += -(FigureValue["castle"] + castleBlackPositionValue[i]);
                            break;
                        case "bishop":
                            if (deck[i].colorOfFigure == "white") value += 30 + bishopWhitePositionValue[i];
                            else value += -(FigureValue["bishop"] + bishopBlackPositionValue[i]);
                            break;
                        case "horse":
                            if (deck[i].colorOfFigure == "white") value += 30 + horseWhitePositionValue[i];
                            else value += -(FigureValue["horse"] + horseBlackPositionValue[i]);
                            break;
                        case "queen":
                            if (deck[i].colorOfFigure == "white") value += 90 + queenWhitePositionValue[i];
                            else value += -(FigureValue["queen"] + queenBlackPositionValue[i]);
                            break;
                        case "king":
                            if (deck[i].colorOfFigure == "white") value += 900 + kingWhitePositionValue[i];
                            else value += -(FigureValue["king"] + kingBlackPositionValue[i]);
                            break;

                    }
                }
            }
            return value;
        }
       public static Dictionary<int,int[]> GetPossibleMoves(title[] Deck,string color)
        {
            Dictionary<int, int[]> Moves = new Dictionary<int, int[]>();
            for(int i = 0; i < Deck.Length; i++)
            {
                if (Deck[i].colorOfFigure == color)
                {
                    switch (Deck[i].Id_Of_Figure)
                    {
                        case "pawn":
                            Moves.Add(i, pawn.CanMove(Deck, i, Deck[i].colorOfFigure));
                            break;
                        case "castle":
                            Moves.Add(i, castle.CanMove(Deck, i, Deck[i].colorOfFigure) );
                            break;
                        case "bishop":
                            Moves.Add(i, bishop.CanMove(Deck, i, Deck[i].colorOfFigure));
                            break;
                        case "horse":
                            Moves.Add(i, horse.CanMove(Deck, i, Deck[i].colorOfFigure));
                            break;
                        case "queen":
                            Moves.Add(i, queen.CanMove(Deck, i, Deck[i].colorOfFigure));
                            break;
                        case "king":
                            Moves.Add(i, king.CanMove(Deck, i, Deck[i].colorOfFigure));
                            break;
                    }
                }
            }
            return Moves;
        }
        static bool IsCheckMate(string Figure,string color,title[] Deck,int pos,int King)
        {
            
                    switch (Figure)
                    {
                case "queen":
                   return queen.CanMoveAI(Deck, pos, color,King);
                  
                case "pawn":
                         return   pawn.CanMoveAI(Deck, pos, color, King);
                         
                case "bishop":
                   return bishop.CanMoveAI(Deck, pos, color, King);
                    
                case "castle":
                        return  castle.CanMoveAI(Deck, pos, color, King);
                       
                  
                        case "horse":
                         return   horse.CanMoveAI(Deck, pos, color,King);
                            
                  
                        case "king":
                    return false;
                            
                    }
            return false;
          
            
          
        }

    }
}
