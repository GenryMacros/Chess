using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Audio;
using SFML.System;
using SFML.Window;


namespace Chess.GameMechanics
{
    class MainMenu
    {
        public static bool GameInProgress = false;
        public static bool Versus_AI = false;
       public static Font font = new Font("Fonts/MenuFont.ttf");
       static Color[,] Skins = new Color[,] { {new Color(231, 208, 167), new Color(166, 126, 91)}, {new Color(208, 208, 208), new Color(128, 128, 128) } };
        static Text THECHESS = new Text("The Chess", font, 120);
       static Text play = new Text("Играть", font, 60);
       static Text changeSkin = new Text("Skins", font, 60);
       static Text exit = new Text("Выход", font, 60);
        static Text VersusHuman = new Text("Против человека", font, 60);
        static Text VersusAI = new Text("Против ИИ", font, 60);
        static Text Back = new Text("Назад", font, 60);
        static Text SkinSet1 = new Text("Мягкий свет",font,60);
        static Text SkinSet2 = new Text("Темнолесье", font, 60);
       public static Text GamePaused = new Text("Game Paused", font, 120);
      public  static Text Continue = new Text("Продолжить", font, 60);
      public  static Text Restart = new Text("Заново", font, 60);
        public static Text ToMainMenu = new Text("В главное меню", font, 60);


       public static int menuPage = 0;

        public static void DrawMainMenu(RenderWindow win)
        {
           win.Clear();
         //   Image n = new Image(100, 120, Color.Blue);
          //      Texture t=new Texture(n);
         //   Sprite sp = new Sprite(t);
          
            GameInProgress = false;
            play.Position = new Vector2f(370, 300);
            changeSkin.Position= new Vector2f(390, 380);
            exit.Position = new Vector2f(375, 460);
          //  sp.Position = play.Position;
            THECHESS.Position = new Vector2f(210, 90);
          //  win.Draw(sp);
            
            win.Draw(THECHESS);
            win.Draw(play);
            win.Draw(changeSkin);
            win.Draw(exit);
         
            win.Display();

        }
        public static void TravelInMenu(Vector2i mouse,RenderWindow win,Table table, uint winHeight, uint winWidth)
        {
            if (menuPage == 0 && play.GetGlobalBounds().Contains(mouse.X, mouse.Y))
            {
               
                win.Clear();
                VersusHuman.Position = new Vector2f(play.Position.X-140,play.Position.Y);
                VersusAI.Position = new Vector2f(changeSkin.Position.X - 65, changeSkin.Position.Y);
                Back.Position = exit.Position;
                menuPage++;
                win.Draw(VersusHuman);
                win.Draw(VersusAI);
                win.Draw(Back);
                win.Display();
            }
            else if(menuPage==0 && changeSkin.GetGlobalBounds().Contains(mouse.X, mouse.Y))
            {
                win.Clear();
                menuPage = 2;
                SkinSet1.Position = new Vector2f(play.Position.X-120,play.Position.Y);
                SkinSet2.Position = new Vector2f(play.Position.X - 120, changeSkin.Position.Y);
                Back.Position = exit.Position;
                Image imw= new Image(50, 50, Skins[0,0]);
                Image imb = new Image(50, 50, Skins[0,1]);
                Image imw1 = new Image(50, 50, Skins[1, 0]);
                Image imb2 = new Image(50, 50, Skins[1, 1]);
                Sprite spw = new Sprite(new Texture(imw));
                Sprite spb = new Sprite(new Texture(imb));
                Sprite spw1 = new Sprite(new Texture(imw1));
                Sprite spb2 = new Sprite(new Texture(imb2));
                spw.Position = new Vector2f(SkinSet1.Position.X + 350, SkinSet1.Position.Y+16);
                spb.Position = new Vector2f(SkinSet1.Position.X + 400, SkinSet1.Position.Y+16);
                spw1.Position = new Vector2f(SkinSet2.Position.X + 350, SkinSet2.Position.Y + 16);
                spb2.Position = new Vector2f(SkinSet2.Position.X + 400, SkinSet2.Position.Y + 16);
                win.Draw(SkinSet1);
                win.Draw(SkinSet2);
                win.Draw(Back);
                win.Draw(spw);
                win.Draw(spb);
                win.Draw(spw1);
                win.Draw(spb2);
                win.Display();

            }
            else if (menuPage == 0 && exit.GetGlobalBounds().Contains(mouse.X, mouse.Y) )
            {
                win.Close();
            }
            else if ((menuPage == 1 || menuPage == 2) && Back.GetGlobalBounds().Contains(mouse.X, mouse.Y) )
            {
                win.Clear();
                menuPage=0;
                DrawMainMenu(win);
            }
            else if (menuPage == 1 && VersusHuman.GetGlobalBounds().Contains(mouse.X, mouse.Y))
            {
                menuPage=-1;
                GameInProgress = true;
                win.Clear();
                table.Draw(win);
                win.Display();

            }
            else if (menuPage == 1 && VersusAI.GetGlobalBounds().Contains(mouse.X, mouse.Y))
            {
                menuPage = -1;
                Versus_AI = true;
                GameInProgress = true;
                AICalculations_2.AIStart();
                win.Clear();
                table.Draw(win);
                win.Display();
            }
            else if(menuPage==2 && SkinSet1.GetGlobalBounds().Contains(mouse.X, mouse.Y))
            {
                win.Clear();
                Table.white = Skins[0, 0];
                Table.black = Skins[0, 1];
                table = new Table(winWidth, winHeight);
                menuPage = 0;
                DrawMainMenu(win);
          
            }
            else if (menuPage == 2 && SkinSet2.GetGlobalBounds().Contains(mouse.X, mouse.Y))
            {
                win.Clear();

                Table.white = Skins[1, 0];
                Table.black = Skins[1, 1];
                table = new Table(winWidth, winHeight);
                menuPage = 0;
                DrawMainMenu(win);
               
            }
            else if(menuPage==4 && Continue.GetGlobalBounds().Contains(mouse.X, mouse.Y))
            {

                menuPage = -1;
                GameInProgress = true;
                win.Clear();
                table.Draw(win);
                win.Display();
            }
            else if(menuPage == 4 && ToMainMenu.GetGlobalBounds().Contains(mouse.X, mouse.Y))
            {
                win.Clear();
                menuPage = 0;
                Table.RestartParams();
                Table.turnOfPlayer = "white";
                table = new Table(winWidth, winHeight);
                Versus_AI = false;
                DrawMainMenu(win);
               
            }
            else if(menuPage==4 && Restart.GetGlobalBounds().Contains(mouse.X, mouse.Y))
            {
                win.Clear();
                menuPage = -1;
                GameInProgress = true;
                Table.RestartParams();
               
                Table.turnOfPlayer = "white";
                table = new Table(winWidth, winHeight);
                table.Draw(win);
                win.Display();


            }




            else if (menuPage == -1)
            {
                DrawMainMenu(win);
                menuPage++;
            }
        }
       public static void Pause()
        {

            if (menuPage == 4)
            {
                menuPage = -1;
                GameInProgress = true;
            }
            else if (menuPage == -1)
            {
                GameInProgress = false;
                menuPage = 4;
                ToMainMenu.Position = new Vector2f(exit.Position.X - 130, exit.Position.Y);
                GamePaused.Position = new Vector2f(THECHESS.Position.X - 120, THECHESS.Position.Y);
                Continue.Position = new Vector2f(play.Position.X - 80, play.Position.Y);
                Restart.Position = new Vector2f(changeSkin.Position.X - 30, changeSkin.Position.Y);

            }
        }
        public static void GG(string color,RenderWindow win)
        {
            Versus_AI = false;
            GameInProgress = false;
            uint alignLeft = 13;
        Image im = new Image(920, 100,Color.White);
            Sprite sp = new Sprite(new Texture(im));
            string winner = " ";
            if (color == "white") winner = "Поздавляем с победой" + "," + "белые" + "!";
           else if (color == "black") winner = "Поздавляем с победой" + "," + "черные" + "!";
            else
            {
                winner = "Поражение!";
                alignLeft = 300;
            }
             Text GG = new Text(winner, font, 62);
            GG.Position = new Vector2f(alignLeft, 350);
            GG.Color = Color.Black;
            sp.Position = new Vector2f(0, 350);
            win.Draw(sp);
            win.Draw(GG);
            win.Display();
        }
    }
}
