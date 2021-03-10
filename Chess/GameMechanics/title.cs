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
    class title
    {
        internal Color c;
        internal Image im;
        internal Texture text;
        internal Sprite sp;
        internal  Sprite SelectedSp;
        internal string Id_Of_Figure;
        internal string colorOfFigure;
        internal string firstColorOfFigure = "";
        static internal uint titleWidth;
        static internal uint titleHeight;
        
       


        internal title(uint width, uint height, Color color, string id, float x, float y,string CF)
        {
            titleWidth = width / 8;
            titleHeight = height / 8;
            c = color;
            im = new Image(titleWidth, titleHeight, color);
            text = new Texture(im);
            sp = new Sprite(text);
            sp.Position = new Vector2f(x, y);
            Id_Of_Figure = id;
            colorOfFigure = CF;
            if (id != " " && color == Table.white) firstColorOfFigure = "white";
            else if (id != " " && color == Table.black) firstColorOfFigure = "black";
            Color c1 = new Color(Table.selectColor.R, Table.selectColor.G, Table.selectColor.B, 0);
            Image im1 = new Image(titleWidth, titleHeight, c1);
            Texture text1 = new Texture(im1);
            SelectedSp = new Sprite(text1);
        }
        internal void ChangeTitle(Color newColor)
        {
       
            Color c = new Color(Table.selectColor.R, Table.selectColor.G, Table.selectColor.B, 120);
            Image im = new Image(titleWidth, titleHeight, c);
            Texture text = new Texture(im);
            SelectedSp = new Sprite(text);
            SelectedSp.Position = sp.Position;
        }
        internal void ChangeTitle()
        {
            Color c = new Color(Table.selectColor.R, Table.selectColor.G, Table.selectColor.B,0);
            Image im = new Image(titleWidth, titleHeight, c);
            Texture text = new Texture(im);
            this.SelectedSp = new Sprite(text);
        }




    }
}
