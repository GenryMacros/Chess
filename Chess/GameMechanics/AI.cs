using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Audio;
using SFML.System;
using SFML.Window;
using Chess.GameMechanics;
using Chess.ChessFigures;
namespace Chess.GameMechanics
{
    class AI
    {
       static title[] table;
        public  static void MakeAEasyMove(RenderWindow win)
        {
            
            table = Table.actualDeck;
           
            int[] move = AICalculations_2.CalculateBestMove(table);
            if (move[1] == move[0])
            {
                MakeARandoMmove(win);
                return;
            }
            if (!TableSelectors.FigureMover(move[1], move[0], win) ||( move[0]==7 && move[1]==6))
            {
                MakeARandoMmove(win);
                return;
            }
            TableSelectors.ChangeFigureTargets(Table.actualDeck[move[1]], move[1]);
        }
       public static void MakeARandoMmove(RenderWindow win)
        {
            
            bool selectedIndex = false;
            table = Table.actualDeck;
            
            
                Random rand = new Random();
                int[] arr = new int[64];
                int j = 1;
            for(int i = 0; i < arr.Length; i++)
                {
                    arr[i] = i;
                }
            int ControlledRandom = 64;
                for (int i = 0; ; i++)
                {
                    int index = rand.Next(0, ControlledRandom);
                    if (table[index].colorOfFigure != "black") continue;
                    int[] indexes = CanMove(index);
                    if (indexes.Length == 0 || indexes[0] == -1) continue;
                    int newTitle = ChooseRandomly(indexes);
                    if (TableSelectors.FigureMover(newTitle, index, win)) break;
                int a = index;
                arr[index] = arr[arr.Length - j];
                arr[arr.Length - j] = index;
                j++;
                ControlledRandom--;
                }
            

        }
       static int[] CanMove(int i)
        {
            int[] arr = new int[] { -1 };
            switch (table[i].Id_Of_Figure)
            {
                case "pawn":
                   arr= pawn.CanMove(table, i, table[i].colorOfFigure);
                    break;
                case "queen":
                    arr = queen.CanMove(table, i, table[i].colorOfFigure);
                    break;
                case "king":
                    arr = king.CanMove(table, i, table[i].colorOfFigure);
                    break;
                case "horse":
                    arr = horse.CanMove(table, i, table[i].colorOfFigure);
                    break;
                case "bishop":
                    arr = bishop.CanMove(table, i, table[i].colorOfFigure);
                    break;
                case "castle":
                    arr = castle.CanMove(table, i, table[i].colorOfFigure);
                    break;
             
            }
            return arr;
        }
        static int ChooseRandomly(int[] arr)
        {
            int MaxValue = arr.Max();


            while (true)
            {
                Random rand = new Random();
                int stopP = rand.Next(0, 64);
                for (int i = 0; i < arr.Length; i++)
                {
                    if (stopP == arr[i]) return arr[i];
                }
            }
        }
        

    }
}
