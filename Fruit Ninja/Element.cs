using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Fruit_Ninja
{
    public class Element
    {
        public static Random r = new Random();

        public Image image;

        public Point ulCorner;
        public Point urCorner;
        public Point llCorner;

        public int directionX;
        public int directionY;

        public bool enabled = true;
        public string type;

        public Element()
        {
            Generate();
        }

        public void Draw(PaintEventArgs e)
        {
            var newImage = image;

            Point[] destPara =
            {
                ulCorner,
                urCorner,
                llCorner
            };
            e.Graphics.DrawImage(newImage, destPara);
        }

        public void Move()
        {
            if (enabled)
            {
                if (ulCorner.Y <= 0 || urCorner.Y <= 0)
                {
                    directionY = 10;
                    directionX = 0;
                    enabled = false;
                }
                else if (ulCorner.X <= 0 || urCorner.X >= SettingsForm.settings.Width)
                {
                    directionY = -10;
                    directionX = -directionX;
                }
            }

            ulCorner = new Point(ulCorner.X + directionX, ulCorner.Y + directionY);
            urCorner = new Point(urCorner.X + directionX, urCorner.Y + directionY);
            llCorner = new Point(llCorner.X + directionX, llCorner.Y + directionY);
        }

        public bool IntersectsCurve(List<Point> points)
        {
            foreach (var point in points)
            {
                if (IsPointInsideElement(point))
                    return false;
            }

            return true;

            return points.Any(IsPointInsideElement);
        }

        private bool IsPointInsideElement(Point point)
        {

            return true;
            return IsClicked(point);
        }
        
        public bool IsClicked(Point p)
        {
            return p.X >= ulCorner.X 
                   && p.X <= urCorner.X
                   && p.Y >= ulCorner.Y
                   && p.Y <= llCorner.Y;
        }

        public void Generate()
        {
            var difficulty = SettingsForm.settings.Difficulty;
            var availableElements = 0;

            switch (difficulty.ToUpper())
            {
                case "EASY":
                    availableElements = 4;
                    break;
                case "MEDIUM":
                    availableElements = 5;
                    break;
                case "HARD":
                    availableElements = 6;
                    break;
            }

            switch (r.Next(availableElements))
            {
                case 0:
                    {
                        image = Properties.Resources.Banana;
                        type = "Banana";
                        break;
                    }
                case 1:
                    {
                        image = Properties.Resources.Green_Apple;
                        type = "Apple";
                        break;
                    }
                case 2:
                    {
                        image = Properties.Resources.Pineapple;
                        type = "Pineapple";
                        break;
                    }
                case 3:
                    {
                        image = Properties.Resources.Watermelon;
                        type = "Watermelon";
                        break;
                    }
                case 4:
                    {
                        image = Properties.Resources._10_Bomb;
                        type = "-10Bomb";
                        break;
                    }
                case 5:
                    {
                        image = Properties.Resources.bombGameOver;
                        type = "GameOverBomb";
                        break;
                    }
                default:
                    {
                        type = "";
                        break;
                    }
            }

            var positions = (SettingsForm.settings.Width - 20) / image.Width;
            var currentPosition = r.Next(positions);

            ulCorner = new Point(currentPosition * image.Width + 10, SettingsForm.settings.Height - image.Height / 2);
            urCorner = new Point((currentPosition + 1) * image.Width, SettingsForm.settings.Height - image.Height / 2);
            llCorner = new Point(currentPosition * image.Width + 10, SettingsForm.settings.Height + image.Height / 2);

            directionX = 0;
            directionY = -10;

            if (currentPosition == 0)
            {
                directionX = 10;
            }
            else if (currentPosition < positions / 2)
            {
                var d = r.Next(2);

                directionX = d == 0 ? 10 : -10;
            }
            else if (currentPosition == positions - 1)
            {
                directionX = -10;
            }
            else
            {
                var d = r.Next(2);

                directionX = d == 0 ? 10 : -10;
            }
        }
    }
}