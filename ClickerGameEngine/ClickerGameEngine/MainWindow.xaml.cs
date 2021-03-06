﻿using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace ClickerGameEngine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private long _playerWallet;
        private int _moneyPerSecond;
        private int _moneyPerClick = 1;
        private readonly GameObject[] _gameObjectAggregator = GameSetUp.BuildGameObjects();

        public MainWindow()
        {
            InitializeComponent();

            var timer = new DispatcherTimer(DispatcherPriority.SystemIdle);
            timer.Tick += OnUpdateTimerTick;
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Start();

            GameSetUp.SetUpUI(_gameObjectAggregator);
        }

        private void OnUpdateTimerTick(object sender, EventArgs e)
        {
            _playerWallet += _moneyPerSecond;
            moneyTextBox.Text = _playerWallet.ToString();
            moneyPerClickTextBlock.Text = _moneyPerClick.ToString();
        }

        private void MoneyPerSecondUpdate()
        {
            _moneyPerSecond = 0;

            foreach (var x in _gameObjectAggregator)
            {
                _moneyPerSecond += x.GetProduction();
            }

            moneyPerSecondTextBox.Text = _moneyPerSecond.ToString();
        }

        private void ImageOneClicked(object sender, MouseEventArgs e)
        {
            BuyNewObject(_gameObjectAggregator[0]);
        }

        private void ImageTwoClicked(object sender, MouseEventArgs e)
        {
            BuyNewObject(_gameObjectAggregator[1]);
        }

        private void ImageThreeClicked(object sender, MouseEventArgs e)
        {
            BuyNewObject(_gameObjectAggregator[2]);
        }

        private void ImageFourClicked(object sender, MouseEventArgs e)
        {
            BuyNewObject(_gameObjectAggregator[3]);
        }

        private void ImageFiveClicked(object sender, MouseEventArgs e)
        {
            BuyNewObject(_gameObjectAggregator[4]);
        }

        private void ImageSixClicked(object sender, MouseEventArgs e)
        {
            BuyNewObject(_gameObjectAggregator[5]);
        }

        private void ImageSevenClicked(object sender, MouseEventArgs e)
        {
            BuyNewObject(_gameObjectAggregator[6]);
        }

        private void ImageEightClicked(object sender, MouseEventArgs e)
        {
            BuyNewObject(_gameObjectAggregator[7]);
        }

        private void BuyNewObject(GameObject gameObject)
        {
            if (_playerWallet >= gameObject.GetPrice())
            {
                _playerWallet -= gameObject.GetPrice();
                gameObject.IncreaseLevel();
                MoneyPerSecondUpdate();
                _moneyPerClick += gameObject.GetProductionPerClick();
            }
            else
            {
                MessageBox.Show("You do not have enough money!");
     
            }

            GameSetUp.SetUpUI(_gameObjectAggregator);
        }

        private void ClickAreaHandler(object sender, MouseEventArgs e)
        {
            _playerWallet += _moneyPerClick;
            moneyTextBox.Text = _playerWallet.ToString();
        }
    }
}
