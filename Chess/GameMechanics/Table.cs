using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Audio;
using SFML.System;
using SFML.Window;
using Chess.ChessFigures;

namespace Chess.GameMechanics
{


    class Table
    {
      public static  title[] actualDeck = new title[64];
      public static  List<int> selectedTiles = new List<int>();
        public static string turnOfPlayer = "white";
        public static bool WhiteGG = false;
        public static bool BlackGG = false;
        public static bool  isCheckmateWhite = false;
        public static bool  isCheckmateBlack = false;
        public static int   whiteKingIndex = 60;
        public static int   blackKingIndex = 4;
      public static List<int> whiteTargets = new List<int>();
      public static List<int> blackTargets = new List<int>();
        string[] idS = new string[] { "castle", "horse", "bishop", "queen", "king", "bishop", "horse", "castle","pawn" };
      public static  Color selectColor = new Color(217, 194, 73);
      public static Color white = new Color(231, 208, 167);
      public static Color black = new Color(166, 126, 91);
        public Table(uint width, uint height)
        {
            float currentY = 0;
            string currentId="castle";
            string colorOfFigure = "black";
            actualDeck[0] = new title(width, height, white,idS[0],0,0, colorOfFigure);
            for(int i = 1; i < actualDeck.Length; i++)
            {
                if(i!=0 && i % 8 == 0)
                {
                    currentY += height / 8;
                    if (currentY == (height / 8) * 6) colorOfFigure = "white";
                    if (currentY > height / 8 && currentY < (height / 8) * 6)
                    {
                        currentId = " ";
                        colorOfFigure = " ";
                    }
                    else if (currentY == height / 8 || currentY == (height / 8) * 6) currentId = idS[idS.Length - 1];
                    else currentId = idS[0];

                    actualDeck[i] = new title(width, height, actualDeck[i - 1].c, currentId, 0, currentY,colorOfFigure);
                }
                else 
                {
                    if (currentY == (height / 8) * 7)  currentId = idS[i - 56];
     
                    else if (currentId != "pawn" && currentId != " ") currentId = idS[i];

                 actualDeck[i] = new title(width, height,ReverseColor(actualDeck[i-1].c), currentId, actualDeck[i - 1].sp.Position.X + title.titleWidth, actualDeck[i - 1].sp.Position.Y, colorOfFigure);
        
                }  
            }
        }
        public void Draw(RenderWindow win)
        {
            Image ki=new Image(1,1,Color.White);
            for (int i = 0; i < actualDeck.Length; i++)
            {
                win.Draw(actualDeck[i].sp);
                win.Draw(actualDeck[i].SelectedSp);
                if (actualDeck[i].Id_Of_Figure != " ")
                {
                    switch (actualDeck[i].Id_Of_Figure)
                    {
                        case "pawn":
                            if (actualDeck[i].colorOfFigure == "white")  ki = new Image(pawn.WhiteImagePath);
                            else ki = new Image(pawn.BlackImagePath);
                            break;
                        case "queen":
                            if (actualDeck[i].colorOfFigure == "white")  ki = new Image(queen.WhiteImagePath);
                            else ki = new Image(queen.BlackImagePath);
                            break;
                        case "king":
                            if (actualDeck[i].colorOfFigure=="white") ki = new Image(king.WhiteImagePath);
                            else ki = new Image(king.BlackImagePath);
                            break;
                        case "castle":
                            if (actualDeck[i].colorOfFigure == "white") ki = new Image(castle.WhiteImagePath);
                            else ki = new Image(castle.BlackImagePath);
                            break;
                        case "horse":
                            if (actualDeck[i].colorOfFigure == "white")  ki = new Image(horse.WhiteImagePath);
                            else ki = new Image(horse.BlackImagePath);
                            break;
                        case "bishop":
                            if (actualDeck[i].colorOfFigure == "white")  ki = new Image(bishop.WhiteImagePath);
                            else ki = new Image(bishop.BlackImagePath);
                            break;
                    }
                    Texture t = new Texture(ki);
                    Sprite sp = new Sprite(t);
                    sp.Position = actualDeck[i].sp.Position;
                    win.Draw(sp);
                    if (pawn.inTransformation) pawn.DrawP(win);
                }
            }
            
           
        }
        public void Select(int i)
        {
            int[] displaySelectable;
            actualDeck[i].ChangeTitle(selectColor);
            selectedTiles.Add(i);
            switch (actualDeck[i].Id_Of_Figure)
            {
                case "pawn":
                  displaySelectable= pawn.CanMove(actualDeck, i,actualDeck[i].colorOfFigure);
                    Selector(displaySelectable);
                    break;
                case "queen":
                    displaySelectable = queen.CanMove(actualDeck, i, actualDeck[i].colorOfFigure);
                    Selector(displaySelectable);
                    break;
                case "king":
                   if(actualDeck[i].colorOfFigure=="black") displaySelectable = king.CanMove(actualDeck, i, actualDeck[i].colorOfFigure);
                   else displaySelectable = king.CanMove(actualDeck, i, actualDeck[i].colorOfFigure);
                    Selector(displaySelectable);
                    break;
                case "castle":
                    displaySelectable = castle.CanMove(actualDeck, i, actualDeck[i].colorOfFigure);
                    Selector(displaySelectable);
                    break;
                case "horse":
                    displaySelectable = horse.CanMove(actualDeck, i, actualDeck[i].colorOfFigure);
                    Selector(displaySelectable);
                    break;
                case "bishop":
                    displaySelectable = bishop.CanMove(actualDeck, i, actualDeck[i].colorOfFigure);
                    Selector(displaySelectable);
                    break;
            }
        }

        public void MoveFigure(Vector2i mouse,RenderWindow win)
        {
           for(int i = 1; i < selectedTiles.Count;i++)
             {
                 int index = selectedTiles[i];
                 if (actualDeck[index].sp.GetGlobalBounds().Contains(mouse.X, mouse.Y))
                 {
                    if (TableSelectors.FigureMover(index, selectedTiles[0],win) == false) break;
                    for (int k = 0; k < selectedTiles.Count; k++)
                     {                      
                        int indexK = selectedTiles[k];
                        actualDeck[indexK].ChangeTitle();
                     }
                    selectedTiles.Clear();
                    Select(index);
                    selectedTiles.RemoveAt(0);
                    actualDeck[index].ChangeTitle();
                    TableSelectors.ChangeFigureTargets(actualDeck[index],index);
  
                    return;
                 }

             }
             for (int k = 0; k < selectedTiles.Count; k++)
             {
                int indexK = selectedTiles[k];
                actualDeck[indexK].ChangeTitle();
             }
            selectedTiles.Clear();
             
        }
        private Color ReverseColor(Color c)
        {
            if (c == white) return black;
            return white;
        }
        private void Selector(int[] arr)
        {
            for (int k = 0; k < arr.Length; k++)
            {
                int index = arr[k];

                actualDeck[index].ChangeTitle(selectColor);

                selectedTiles.Add(index);

            }
        }
        public static bool GG (string color)
        {
            if (color == "white")
            {
                for(int j = 0; j < actualDeck.Length; j++)
                {
                    if (actualDeck[j].colorOfFigure==color && PhantomTable.CanThisBlock(j, actualDeck[j].Id_Of_Figure, actualDeck)) return false;

                }
              
            }
            else if (color == "black")
            {
                for (int j = 0; j < actualDeck.Length; j++)
                {
                    if (actualDeck[j].colorOfFigure == color && PhantomTable.CanThisBlock(j, actualDeck[j].Id_Of_Figure,actualDeck)) return false;

                }
            }
            return true;
        }
        public static void RestartParams()
        {
        actualDeck = new title[64];
        List<int> selectedTiles = new List<int>();
        WhiteGG = false;
        BlackGG = false;
        isCheckmateWhite = false;
        isCheckmateBlack = false;
        whiteKingIndex = 60;
        blackKingIndex = 4;
        List<int> whiteTargets = new List<int>();
        List<int> blackTargets = new List<int>();
            king.blackTargets = new List<int>();
            king.whiteTargets = new List<int>();
            queen.whiteTargets = new List<int>();
            queen.blackTargets = new List<int>();
            pawn.blackTargets = new List<int>();
            pawn.whiteTargets = new List<int>();
            castle.whiteBTargets = new List<int>();
            castle.whiteWTargets = new List<int>();
            castle.blackBTargets = new List<int>();
            castle.blackWTargets = new List<int>();
            bishop.whiteBTargets = new List<int>();
            bishop.whiteWTargets = new List<int>();
            bishop.blackBTargets = new List<int>();
            bishop.blackWTargets = new List<int>();
            horse.whiteBTargets = new List<int>();
            horse.whiteWTargets = new List<int>();
            horse.blackBTargets = new List<int>();
            horse.blackWTargets = new List<int>();

        }

    }
}
