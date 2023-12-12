using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Fruit_Ninja
{
    public class Game
    {
        public Main MainForm { get; }

        public static Random r = new Random();

        public Image background;

        public List<Element> elements = new List<Element>();

        public Score currentScore = new Score(0, new DateTime(), "");
        public int time = 25;
        public int bombsClicked = 0;

        private static readonly Image[] BackgroundResources =
        {
            Properties.Resources.background1,
            Properties.Resources.background2,
            Properties.Resources.background3
        };

        public Game(Main mainForm)
        {
            InitializeBackground();
            MainForm = mainForm;
        }

        private void InitializeBackground()
        {
            var randomIndex = r.Next(BackgroundResources.Length);
            background = BackgroundResources[randomIndex];
        }

        public void Draw(PaintEventArgs e)
        {
            foreach (var el in elements)
            {
                el.Draw(e);
            }
        }

        public void Move()
        {
            foreach (var el in elements)
            {
                el.Move();
            }

            for (var i = elements.Count - 1; i >= 0; i--)
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

        public void DrawCurve(List<Point> points)
        {
            using (var g = MainForm.panelGame.CreateGraphics())
            {
                if (points.Count >= 2)
                {
                    g.DrawCurve(Pens.Black, points.ToArray());
                }
            }
        }

        public bool CheckSlice(List<Point> points)
        {
            var elementHandlers = new Dictionary<string, Action>
            {
                { "-10Bomb", () => ProcessBombClick(-10) },
                { "Banana", () => ProcessFruitClick(2) },
                { "Apple", () => ProcessFruitClick(3) },
                { "Pineapple", () => ProcessFruitClick(4) },
                { "Watermelon", () => ProcessFruitClick(5) }
            };

            foreach (var el in elements.Where(el => el.IntersectsCurve(points)))
            {
                if (elementHandlers.TryGetValue(el.type, out var handler))
                {
                    handler.Invoke();
                    elements.Remove(el);
                    break;
                }

                if (el.type == "GameOverBomb")
                {
                    return true;
                }
            }

            return false;
        }
        
        public bool CheckClick(Point point)
        {
            var elementHandlers = new Dictionary<string, Action>
            {
                { "-10Bomb", () => ProcessBombClick(-10) },
                { "Banana", () => ProcessFruitClick(2) },
                { "Apple", () => ProcessFruitClick(3) },
                { "Pineapple", () => ProcessFruitClick(4) },
                { "Watermelon", () => ProcessFruitClick(5) }
            };

            foreach (var el in elements.Where(el => el.IsClicked(point)))
            {
                if (elementHandlers.TryGetValue(el.type, out var handler))
                {
                    handler.Invoke();
                    elements.Remove(el);
                    break;
                }

                if (el.type == "GameOverBomb")
                {
                    return true;
                }
            }

            return false;
        }

        private void ProcessBombClick(int penalty)
        {
            if (bombsClicked >= 3) return;

            currentScore.SettleScore(penalty);
            bombsClicked++;
        }

        private void ProcessFruitClick(int score)
        {
            currentScore.SettleScore(score);
        }
    }
}