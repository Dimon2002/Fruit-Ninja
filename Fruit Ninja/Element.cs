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
        
        // Эти точки определяют, где будет нарисован элемент на игровом поле.
        public Point ulCorner; // up left
        public Point urCorner; // up right
        public Point llCorner; // lower left

        public int directionX;
        public int directionY;

        public bool enabled = true;
        public string type;

        public Element()
        {
            Initialization();
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
                else if (ulCorner.X <= 0 || urCorner.X >= SettingsForm.Settings.Width)
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
            return points.Any(IsPointInsideElement);
        }

        private bool IsPointInsideElement(Point point)
        {
            return point.X >= ulCorner.X
                   && point.X <= urCorner.X
                   && point.Y >= ulCorner.Y
                   && point.Y <= llCorner.Y;
        }

        public void Initialization()
        {
            var difficulty = SettingsForm.Settings.Difficulty;
            var availableElements = GetAvailableElements(difficulty);

            SetElementAttributes(availableElements);
            SetElementPosition();
        }

        private static int GetAvailableElements(string difficulty)
        {
            switch (difficulty.ToUpper())
            {
                case "EASY":
                    return 4;
                case "MEDIUM":
                    return 5;
                case "HARD":
                    return 6;
                default:
                    return 0;
            }
        }

        private void SetElementAttributes(int availableElements)
        {
            var elementIndex = r.Next(availableElements);

            switch (elementIndex)
            {
                case 0:
                    SetElementProperties(Properties.Resources.Banana, "Banana");
                    break;
                case 1:
                    SetElementProperties(Properties.Resources.Green_Apple, "Apple");
                    break;
                case 2:
                    SetElementProperties(Properties.Resources.Pineapple, "Pineapple");
                    break;
                case 3:
                    SetElementProperties(Properties.Resources.Watermelon, "Watermelon");
                    break;
                case 4:
                    SetElementProperties(Properties.Resources._10_Bomb, "-10Bomb");
                    break;
                case 5:
                    SetElementProperties(Properties.Resources.bombGameOver, "GameOverBomb");
                    break;
                default:
                    type = "";
                    break;
            }
        }
        
        private void SetElementProperties(Image elementImage, string elementType)
        {
            image = elementImage;
            type = elementType;
        }

        private void SetElementPosition()
        {
            var positions = (SettingsForm.Settings.Width - 20) / image.Width;
            var currentPosition = r.Next(positions);

            ulCorner = new Point(currentPosition * image.Width + 10, SettingsForm.Settings.Height - image.Height / 2);
            urCorner = new Point((currentPosition + 1) * image.Width, SettingsForm.Settings.Height - image.Height / 2);
            llCorner = new Point(currentPosition * image.Width + 10, SettingsForm.Settings.Height + image.Height / 2);

            directionX = GetElementDirectionX(currentPosition, positions);
            directionY = -10;
        }

        private static int GetElementDirectionX(int currentPosition, int positions)
        {
            if (currentPosition == 0 || currentPosition == positions - 1)
            {
                return currentPosition == 0 ? 10 : -10;
            }

            var d = r.Next(2);

            return d == 0 ? 10 : -10;
        }
    }
}