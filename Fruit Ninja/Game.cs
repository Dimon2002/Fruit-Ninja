using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Fruit_Ninja
{
    public class Game
    {
        public static Random r = new Random();
        
        public Image background;

        public List<Element> elements = new List<Element>();
        
        public Score currentScore = new Score(0,new DateTime(),"");
        public int time = 5;
        public int bombsClicked = 0;

        public Game()
        {
            switch (r.Next(3))
            {
                case 0:
                    {
                       background = Properties.Resources.background1;
                        break;
                    }
                case 1:
                    {
                        background = Properties.Resources.background2;
                        break;
                    }
                case 2:
                    {
                        background = Properties.Resources.background3;
                        break;
                    }
            }
        }

        public void Draw(PaintEventArgs e)
        {
            foreach (var el in elements)
            {
                el.Draw(e);
            }
        }

        public void MoveElements()
        {
            foreach (var el in elements)
            {
                el.Move();
            }

            for(var i = elements.Count - 1; i >= 0; i--)
            {
                if (elements[i].type.Equals("-10Bomb") 
                   || elements[i].type.Equals("GameOverBomb")
                   || elements[i].ulCorner.Y < SettingsForm.settings.Height)
                {
                    continue;
                }

                currentScore.points -= 2;
                elements.Remove(elements[i]);
            }
        }

        public bool CheckClick(Point point)
        {
            foreach (var el in elements.Where(el => el.IsClicked(point)))
            {
                if (bombsClicked == 3) return true;

                switch (el.type)
                {
                    case "-10Bomb":
                        currentScore.SettleScore(-10);
                        bombsClicked++;
                        break;
                    case "GameOverBomb":
                        return true;
                    case "Banana":
                        currentScore.SettleScore(2);
                        break;
                    case "Apple":
                        currentScore.SettleScore(3);
                        break;
                    case "Pineapple":
                        currentScore.SettleScore(4);
                        break;
                    case "Watermelon":
                        currentScore.SettleScore(5);
                        break;
                }

                elements.Remove(el);
                break;
            }

            return false;
        }
    }
}