using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
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

        private const int PenWidth = 5;
        
        private static readonly Image[] BackgroundResources =
        {
            Properties.Resources.background1,
            Properties.Resources.background2,
            Properties.Resources.background3
        };
        
        private static readonly Color[] Colors = 
        {
            (Color.CadetBlue),
            (Color.Aqua),
            (Color.BurlyWood),
            (Color.Crimson),
            (Color.DarkGreen),
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
                    || Elements[i].ulCorner.Y < SettingsForm.Settings.Height)
                {
                    continue;
                }

                CurrentScore.Points -= 2;
                Elements.Remove(Elements[i]);
            }
        }

        public void DrawCurve(List<Point> points, int seed)
        {
            if (points.Count < 2) return;
            
            MainForm.panelGame.Invoke((MethodInvoker)delegate
            {
                using (var g = MainForm.panelGame.CreateGraphics())
                {
                    using (var brush = new LinearGradientBrush(points.First(), points.Last(), GetColor(seed), GetColor(seed/2)))
                    {
                        using (var pen = new Pen(brush, PenWidth))
                        {
                            g.DrawCurve(pen, points.ToArray());
                        }
                    }
                }
            });
        }

        private static Color GetColor(int seed)
        {
            return Colors[new Random(seed).Next(Colors.Length)];
        }

        public bool IsGameActive(List<Point> points)
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
                    return true;
                }

                if (el.type == "GameOverBomb")
                {
                    return false;
                }
            }

            return true;
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