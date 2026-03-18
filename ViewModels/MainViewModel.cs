using CommunityToolkit.Mvvm.ComponentModel;
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
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Dobokocka.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly int _diceSize = 60;
        private int _dotSize => _diceSize / 5;

        private readonly List<Die> _dice = new();

        public ObservableCollection<Canvas> DiceDisplay { get; } = new(); 

        public int NumberOfDice
        {
            get => _numberOfDice;
            set
            {
                SetProperty(ref _numberOfDice, value);
                SetupDice();
                UpdateDisplay();
            }
        }
        private int _numberOfDice = 3;

        [ObservableProperty]
        private bool _inputEnabled = true;

        public MainViewModel()
        {
            SetupDice();
            UpdateDisplay();
        }

        [RelayCommand]
        private async Task Roll()
        {
            InputEnabled = false;
            for (int i = 0; i < 20; i++)
            {
                foreach (Die d in _dice)
                {
                    d.Roll();
                }
                UpdateDisplay();
                await Task.Delay(100 + (int)Math.Pow(i,2));
            }
            InputEnabled = true;
        }

        private void SetupDice()
        {
            _dice.Clear();
            for (int i = 0; i < _numberOfDice; i++)
            {
                if (i >= _dice.Count)
                {
                    _dice.Add(new Die());
                }
            }
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
