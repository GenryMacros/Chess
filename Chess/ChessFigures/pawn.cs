using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.GameMechanics;
using SFML.Graphics;
using SFML.Audio;
using SFML.System;
using SFML.Window;

namespace Chess.ChessFigures
{
    class pawn :figure
    {
         
        public static string WhiteImagePath = "White_Figures/pawn.png";
        public static string BlackImagePath = "Black_Figures/pawn.png";
        public static List<int> whiteTargets = new List<int>();
        public static List<int> blackTargets = new List<int>();
        public static bool inTransformation = false;
        public static List<Sprite> titles = new List<Sprite>();
        static int transformIndex;


      
      
        public static int[] CanMove(title[] arr, int i,string color)
        {
            List<int> intarr = new List<int>();
          
                if (((arr[i].sp.Position.Y == title.titleHeight && color == "black") || (arr[i].sp.Position.Y == title.titleHeight * 6 && color=="white")) && ((color=="white" && arr[i - 16].Id_Of_Figure == " " && arr[i - 8].Id_Of_Figure == " ") || (color=="black" && arr[i + 16].Id_Of_Figure == " " && arr[i + 8].Id_Of_Figure == " ")))
                {
                if (color == "white")
                {
                    if (arr[i - 7].colorOfFigure != color && arr[i - 7].Id_Of_Figure != " " && arr[i - 7].sp.Position.Y==arr[i].sp.Position.Y-title.titleHeight) intarr.Add(i - 7);
                    if (arr[i - 9].colorOfFigure != color && arr[i - 9].Id_Of_Figure != " " && arr[i - 9].sp.Position.Y == arr[i].sp.Position.Y - title.titleHeight) intarr.Add(i - 9);
                    intarr.Add(i - 8);
                    intarr.Add(i - 16);
                    return intarr.ToArray();
                }
                else
                {
                    if (arr[i + 7].colorOfFigure != color && arr[i + 7].Id_Of_Figure != " " && arr[i + 7].sp.Position.Y == arr[i].sp.Position.Y + title.titleHeight) intarr.Add(i + 7);
                    if (arr[i + 9].colorOfFigure != color && arr[i + 9].Id_Of_Figure != " " && arr[i + 9].sp.Position.Y == arr[i].sp.Position.Y + title.titleHeight) intarr.Add(i + 9);
                    intarr.Add(i + 8);
                    intarr.Add(i + 16);
                    return intarr.ToArray();
                }

            }
                else if (color == "white")
                {
                try
                {
                    if (arr[i - 7].colorOfFigure != color && arr[i - 7].Id_Of_Figure != " " && arr[i - 7].sp.Position.Y == arr[i].sp.Position.Y - title.titleHeight) intarr.Add(i - 7);
                    if (arr[i - 9].colorOfFigure != color && arr[i - 9].Id_Of_Figure != " " && arr[i - 9].sp.Position.Y == arr[i].sp.Position.Y - title.titleHeight) intarr.Add(i - 9);
                    if (arr[i - 8].Id_Of_Figure == " ") intarr.Add(i - 8);
                }
                catch { }
                    return intarr.ToArray();
                }
                else if(color=="black") {
                try
                {
                    if (arr[i + 7].colorOfFigure != color && arr[i + 7].Id_Of_Figure != " " && arr[i + 7].sp.Position.Y == arr[i].sp.Position.Y + title.titleHeight) intarr.Add(i + 7);
                    if (arr[i + 9].colorOfFigure != color && arr[i + 9].Id_Of_Figure != " " && arr[i + 9].sp.Position.Y == arr[i].sp.Position.Y + title.titleHeight) intarr.Add(i + 9);
                    if (arr[i + 8].Id_Of_Figure == " ") intarr.Add(i + 8);
                }
                catch { }
                return intarr.ToArray();
            }

            return intarr.ToArray();
        }
        public static bool CanMoveAI(title[] arr, int i, string color,int King)
        {
           

            if (((arr[i].sp.Position.Y == title.titleHeight && color == "black") || (arr[i].sp.Position.Y == title.titleHeight * 6 && color == "white")) && ((color == "white" && arr[i - 16].Id_Of_Figure == " " && arr[i - 8].Id_Of_Figure == " ") || (color == "black" && arr[i + 16].Id_Of_Figure == " " && arr[i + 8].Id_Of_Figure == " ")))
            {
                if (color == "white")
                {
                    if (arr[i - 7].colorOfFigure != color && arr[i - 7].Id_Of_Figure != " " && arr[i - 7].sp.Position.Y == arr[i].sp.Position.Y - title.titleHeight && i - 7 == King) return true;
                    if (arr[i - 9].colorOfFigure != color && arr[i - 9].Id_Of_Figure != " " && arr[i - 9].sp.Position.Y == arr[i].sp.Position.Y - title.titleHeight && i - 9 == King) return true;

                    if (i - 8 == King || i - 16 == King) return true;
                    return false;
                }
                else
                {
                    if (arr[i + 7].colorOfFigure != color && arr[i + 7].Id_Of_Figure != " " && arr[i + 7].sp.Position.Y == arr[i].sp.Position.Y + title.titleHeight && i + 7 == King) return true;
                    if (arr[i + 9].colorOfFigure != color && arr[i + 9].Id_Of_Figure != " " && arr[i + 9].sp.Position.Y == arr[i].sp.Position.Y + title.titleHeight && i + 9 == King) return true;
                    if (i + 8 == King || i + 16 == King) return true;
                    return false;
                }

            }
            else if (color == "white")
            {
                try
                {
                    if (arr[i - 7].colorOfFigure != color && arr[i - 7].Id_Of_Figure != " " && arr[i - 7].sp.Position.Y == arr[i].sp.Position.Y - title.titleHeight && i-7==King) return true;
                    if (arr[i - 9].colorOfFigure != color && arr[i - 9].Id_Of_Figure != " " && arr[i - 9].sp.Position.Y == arr[i].sp.Position.Y - title.titleHeight && i-9 == King) return true;
                    if (arr[i - 8].Id_Of_Figure == " " && i-8 == King) return true;
                }
                catch { }
                return false;
            }
            else if (color == "black")
            {
                try
                {
                    if (arr[i + 7].colorOfFigure != color && arr[i + 7].Id_Of_Figure != " " && arr[i + 7].sp.Position.Y == arr[i].sp.Position.Y + title.titleHeight && i + 7 == King) return true;
                    if (arr[i + 9].colorOfFigure != color && arr[i + 9].Id_Of_Figure != " " && arr[i + 9].sp.Position.Y == arr[i].sp.Position.Y + title.titleHeight && i + 9 == King) return true;
                    if (arr[i + 8].Id_Of_Figure == " " && i+8 == King) return true;
                }
                catch { }
                return false;
            }

            return false;
        }
        public static void transformation(title tit,RenderWindow win,int i)
        {
            if (MainMenu.Versus_AI == true && tit.colorOfFigure=="black")
            {
                Table.actualDeck[i].Id_Of_Figure = "queen";
                return;
            }
            transformIndex = i;
            inTransformation = true;
            float Ypos;
            if (tit.colorOfFigure == "white") Ypos = tit.sp.Position.Y + title.titleHeight;
            else Ypos = tit.sp.Position.Y - title.titleHeight;
            float Xpos = tit.sp.Position.X;
            uint width = title.titleWidth;
            uint height = title.titleHeight;
            Image im = new Image(width, height,new Color(255,255,255,200));
            Texture text = new Texture(im);
            Sprite sp1 = new Sprite(text);
            Sprite sp2 = new Sprite(text);
            Image imFQ = new Image(0,0);
            Image imFH = new Image(0,0);
            sp1.Position = new Vector2f(Xpos - title.titleWidth/2, Ypos);
            sp2.Position = new Vector2f(Xpos + title.titleWidth/2, Ypos);
            if (tit.colorOfFigure == "white")
            {
                imFQ = new Image(queen.WhiteImagePath);
                imFH = new Image(horse.WhiteImagePath);
            }
            else if (tit.colorOfFigure == "black")
            {
                 imFQ = new Image(queen.BlackImagePath);
                 imFH = new Image(horse.BlackImagePath);
            }
            Texture tFQ = new Texture(imFQ);
            Texture tFH = new Texture(imFH);
            Sprite sQ = new Sprite(tFQ);
            Sprite sH = new Sprite(tFH);
            sQ.Position = sp1.Position;
            sH.Position = sp2.Position;
            titles.Add(sp1);
            titles.Add(sp2);
            titles.Add(sQ);
            titles.Add(sH);
       
        }
        public static void transform(int i)
        {
            if (i == 0) Table.actualDeck[transformIndex].Id_Of_Figure = "queen";
            else if(i==1) Table.actualDeck[transformIndex].Id_Of_Figure = "horse";
            inTransformation = false;
            titles.Clear();
        }
        public static void DrawP(RenderWindow win)
        {
            for(int i = 0; i < titles.Count(); i++)
            {
                win.Draw(titles[i]);
            }
        }

     
    }
}
