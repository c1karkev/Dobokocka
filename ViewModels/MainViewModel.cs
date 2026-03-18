using CommunityToolkit.Mvvm.Input;
using Dobokocka.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Dobokocka.ViewModels
{
    public partial class MainViewModel
    {
        private readonly int _diceSize = 60;
        private int _dotSize => _diceSize / 5;

        private readonly List<Die> _dice = new()
        {
            new Die(),
            new Die(),
            new Die()
        };

        public ObservableCollection<Canvas> DiceDisplay { get; } = new();

        public MainViewModel()
        {
            UpdateDisplay();
        }

        [RelayCommand]
        private void Roll()
        {
            foreach(Die d in _dice)
            {
                d.Roll();
            }
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            DiceDisplay.Clear();
            foreach (Die d in _dice)
            {
                Canvas dieCanvas = new Canvas();
                dieCanvas.Width = _diceSize;
                dieCanvas.Height = _diceSize;
                dieCanvas.Background = Brushes.LightSteelBlue;

                Ellipse dot;
                // center dot
                if ((new int[] {1, 3, 5}).Contains(d.Value))
                {
                    dot = GetDiceDot();
                    Canvas.SetLeft(dot, (_diceSize - _dotSize) / 2);
                    Canvas.SetTop(dot, (_diceSize - _dotSize) / 2);
                    dieCanvas.Children.Add(dot);
                }
                // top left, bottom right dots
                if ((new int[] { 2, 3, 4, 5, 6 }).Contains(d.Value))
                {
                    // top left
                    dot = GetDiceDot();
                    Canvas.SetLeft(dot, _diceSize / 6);
                    Canvas.SetTop(dot, _diceSize / 6);
                    dieCanvas.Children.Add(dot);
                    // bottom right
                    dot = GetDiceDot();
                    Canvas.SetRight(dot, _diceSize / 6);
                    Canvas.SetBottom(dot, _diceSize / 6);
                    dieCanvas.Children.Add(dot);
                }
                // top right, bottom left dots
                if ((new int[] { 4, 5, 6 }).Contains(d.Value))
                {
                    // top right
                    dot = GetDiceDot();
                    Canvas.SetRight(dot, _diceSize / 6);
                    Canvas.SetTop(dot, _diceSize / 6);
                    dieCanvas.Children.Add(dot);
                    // bottom left
                    dot = GetDiceDot();
                    Canvas.SetLeft(dot, _diceSize / 6);
                    Canvas.SetBottom(dot, _diceSize / 6);
                    dieCanvas.Children.Add(dot);
                }
                // center left and right dots
                if (d.Value == 6)
                {
                    // left
                    dot = GetDiceDot();
                    Canvas.SetLeft(dot, _diceSize / 6);
                    Canvas.SetTop(dot, (_diceSize - _dotSize) / 2);
                    dieCanvas.Children.Add(dot);
                    // right
                    dot = GetDiceDot();
                    Canvas.SetRight(dot, _diceSize / 6);
                    Canvas.SetTop(dot, (_diceSize - _dotSize) / 2);
                    dieCanvas.Children.Add(dot);
                }
                DiceDisplay.Add(dieCanvas);
            }
        }

        private Ellipse GetDiceDot()
        {
            Ellipse dot = new Ellipse();
            dot.Fill = Brushes.Black;
            dot.Width = _dotSize;
            dot.Height = dot.Width;
            return dot;
        }
    }
}
