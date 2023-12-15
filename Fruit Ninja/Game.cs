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

        public static Random R = new Random();

        public Image Background;

        public List<Element> Elements = new List<Element>();

        public Score CurrentScore = new Score(0, new DateTime(), "");
        public int Time = 25;
        public int BombsClicked = 0;

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
            var randomIndex = R.Next(BackgroundResources.Length);
            Background = BackgroundResources[randomIndex];
        }

        public void Draw(PaintEventArgs e)
        {
            foreach (var el in Elements)
            {
                el.Draw(e);
            }
        }

        public void Move()
        {
            foreach (var el in Elements)
            {
                el.Move();
            }

            for (var i = Elements.Count - 1; i >= 0; i--)
            {
                if (Elements[i].type.Equals("-10Bomb")
                    || Elements[i].type.Equals("GameOverBomb")
                    || Elements[i].ulCorner.Y < SettingsForm.settings.Height)
                {
                    continue;
                }

                CurrentScore.points -= 2;
                Elements.Remove(Elements[i]);
            }
        }

        public void DrawCurve(List<Point> points)
        {
            MainForm.panelGame.Invoke((MethodInvoker)delegate
            {
                using (var g = MainForm.panelGame.CreateGraphics())
                {
                    if (points.Count >= 2)
                    {
                        g.DrawCurve(Pens.GreenYellow, points.ToArray());
                    }
                }
            });
        }

        public bool IsCut(List<Point> points)
        { 
            var elementHandlers = new Dictionary<string, Action>
            {
                { "-10Bomb", () => ProcessBombClick(-10) },
                { "Banana", () => ProcessFruitClick(2) },
                { "Apple", () => ProcessFruitClick(3) },
                { "Pineapple", () => ProcessFruitClick(4) },
                { "Watermelon", () => ProcessFruitClick(5) }
            };

            foreach (var el in Elements.Where(el => el.IntersectsCurve(points)))
            {
                if (elementHandlers.TryGetValue(el.type, out var handler))
                {
                    handler.Invoke();
                    Elements.Remove(el);
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
            if (BombsClicked >= 3) return;

            CurrentScore.SettleScore(penalty);
            BombsClicked++;
        }

        private void ProcessFruitClick(int score)
        {
            CurrentScore.SettleScore(score);
        }
    }
}