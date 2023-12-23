using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Fruit_Ninja
{
    public class Element
    {
        private static readonly Random R = new Random();
        
        public Image Image { get; private set;}
        
        public Point UpLeftPoint { get; private set; }
        public Point UpRightPoint { get; private set;}
        public Point LeftLowPoint { get; private set; }
        
        private int _directionX;
        private int _directionY;

        public bool enabled = true;
        public string type;

        public Element()
        {
            Initialization();
        }

        public void Draw(PaintEventArgs e)
        {
            var newImage = Image;

            Point[] destPara =
            {
                UpLeftPoint,
                UpRightPoint,
                LeftLowPoint
            };
            e.Graphics.DrawImage(newImage, destPara);
        }

        public void Move()
        {
            if (enabled)
            {
                if (UpLeftPoint.Y <= 0 || UpRightPoint.Y <= 0)
                {
                    _directionY = 10;
                    _directionX = 0;
                    enabled = false;
                }
                else if (UpLeftPoint.X <= 0 || UpRightPoint.X >= SettingsForm.Settings.Width)
                {
                    _directionY = -10;
                    _directionX = -_directionX;
                }
            }

            UpLeftPoint = new Point(UpLeftPoint.X + _directionX, UpLeftPoint.Y + _directionY);
            UpRightPoint = new Point(UpRightPoint.X + _directionX, UpRightPoint.Y + _directionY);
            LeftLowPoint = new Point(LeftLowPoint.X + _directionX, LeftLowPoint.Y + _directionY);
        }

        public bool IntersectsCurve(List<Point> points)
        {
            return points.Any(IsPointInsideElement);
        }

        private bool IsPointInsideElement(Point point)
        {
            return point.X >= UpLeftPoint.X
                   && point.X <= UpRightPoint.X
                   && point.Y >= UpLeftPoint.Y
                   && point.Y <= LeftLowPoint.Y;
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
            var elementIndex = R.Next(availableElements);

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
            Image = elementImage;
            type = elementType;
        }

        private void SetElementPosition()
        {
            var positions = (SettingsForm.Settings.Width - 20) / Image.Width;
            var currentPosition = R.Next(positions);

            UpLeftPoint = new Point(currentPosition * Image.Width + 10, SettingsForm.Settings.Height - Image.Height / 2);
            UpRightPoint = new Point((currentPosition + 1) * Image.Width, SettingsForm.Settings.Height - Image.Height / 2);
            LeftLowPoint = new Point(currentPosition * Image.Width + 10, SettingsForm.Settings.Height + Image.Height / 2);

            _directionX = GetElementDirectionX(currentPosition, positions);
            _directionY = -10;
        }

        private static int GetElementDirectionX(int currentPosition, int positions)
        {
            if (currentPosition == 0 || currentPosition == positions - 1)
            {
                return currentPosition == 0 ? 10 : -10;
            }

            var d = R.Next(2);

            return d == 0 ? 10 : -10;
        }
    }
}