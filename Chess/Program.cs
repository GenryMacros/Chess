using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SFML.Graphics;
using SFML.Audio;
using SFML.System;
using SFML.Window;
using Chess.GameMechanics;
using Chess.ChessFigures;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            uint winHeight = 920;
            uint winWidth = 920;
           RenderWindow win = new RenderWindow(new SFML.Window.VideoMode(winWidth, winHeight), "Chess");
            Table table = new Table(winWidth, winHeight);
            int selected = -1;

          //  table.Draw(win);
            win.Display();
            win.Closed += OnClose;
            win.MouseButtonPressed += OnClick;
            win.KeyPressed += OnKeyPress;

            MainMenu.DrawMainMenu(win);
            while (win.IsOpen)
            {
              
                win.DispatchEvents();
                if (Table.turnOfPlayer == "black" && MainMenu.Versus_AI == true )
                {
            
                    AI.MakeAEasyMove(win);
                    win.Clear();
                    table.Draw(win);
                    win.Display();
                  
                    if (Table.isCheckmateWhite == true && Table.GG("white"))
                    {
                        win.Clear();
                        Table.RestartParams();
                        table = new Table(winWidth, winHeight);
                        win.Clear();
                        win.Display();
                        MainMenu.GG("AI", win);
                        
                    }
                    Table.turnOfPlayer = "white";

                }

            }

            void OnClose(object sender, EventArgs e)
            {
                RenderWindow win1 = (RenderWindow)sender;
                win1.Close();
            }
            void OnClick(object sender, EventArgs e)
            {
                Vector2i mousePosition = SFML.Window.Mouse.GetPosition(win);
                if (MainMenu.GameInProgress==false)MainMenu.TravelInMenu(mousePosition, win,table,winHeight,winWidth);
                if (MainMenu.Versus_AI == true && Table.turnOfPlayer == "black") return;
                else if (pawn.inTransformation)
                {
                    for (int k = 0; k < pawn.titles.Count(); k++)
                    {
                        if (pawn.titles[k].GetGlobalBounds().Contains(mousePosition.X, mousePosition.Y))
                        {
                            pawn.transform(k);


                            table.Draw(win);
                            win.Display();
                        }
                    }
                }
                else if (selected == -1)
                {
                    for (int i = 0; i < Table.actualDeck.Length; i++)
                    {
                        if (Table.actualDeck[i].sp.GetGlobalBounds().Contains(mousePosition.X, mousePosition.Y) && Table.actualDeck[i].Id_Of_Figure != " " && Table.actualDeck[i].colorOfFigure == Table.turnOfPlayer)
                        {
                            selected = i;
                            table.Select(i);
                            table.Draw(win);
                            win.Display();
                        }
                    }
                }
                else
                {
                    table.MoveFigure(mousePosition, win);
                    table.Draw(win);
                    win.Display();
                    if (Table.actualDeck[selected].Id_Of_Figure == " ")
                    {
                        Table.turnOfPlayer = TransferTurn(Table.turnOfPlayer);
                    }
                    selected = -1;
                }                           
                    }
            void OnKeyPress(object sender, EventArgs e)
            {
                if (MainMenu.menuPage == 4)
                {
                    win.Clear();
                    MainMenu.Pause();
                    table.Draw(win);
                    win.Display();
                }
               else if (SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.Escape) == true)
                {
                    win.Clear();
                    MainMenu.Pause();
                    win.Draw(MainMenu.GamePaused);
                    win.Draw(MainMenu.Restart);
                    win.Draw(MainMenu.Continue);
                    win.Draw(MainMenu.ToMainMenu);
                    win.Display();
                }
            }

        string  TransferTurn(string c)
            {
              
                    if (c == "black")
                    {
                    if (Table.isCheckmateWhite == true && Table.GG("white"))
                    {
                        win.Clear();
                        Table.RestartParams();
                        table = new Table(winWidth, winHeight);
                        win.Clear();
                        win.Display();
                        MainMenu.GG("black", win);
                    }
                return "white";
                    }
                    if (Table.isCheckmateBlack == true && Table.GG("black"))
                    {
                        win.Clear();
                        Table.RestartParams();
                        table = new Table(winWidth, winHeight);
                        win.Clear();
                        win.Display();
                    
                    MainMenu.GG("white", win);
                    return "white";

                    }
               
                return "black";
                
            }

        }

    }
}
