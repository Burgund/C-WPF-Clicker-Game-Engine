﻿using System.Windows.Media.Imaging;

namespace ClickerGameEngine
{
    internal class GameObject
    {
        private readonly string _name;
        private int _level;
        private int _production;
        private int _price;

        //100x100 pixels bitmap
        private readonly BitmapImage _bitmapUri;

        public GameObject(string name, int level, int production, int price, BitmapImage bitmapUri)
        {
            _name = name;
            _level = level;
            _production = production;
            _price = price;
            _bitmapUri = bitmapUri;
        }

        public string GetName()
        {
            return _name;
        }

        public int GetLevel()
        {
            return _level;
        }

        public int GetProduction()
        {
            return _level == 0 ? 0 : _production;
        }

        public int GetPrice()
        {
            return _price;
        }

        public BitmapImage GetBitmap()
        {
            return _bitmapUri;
        }

        public void IncreaseLevel()
        {
            _level++;
            _price += _price / 2;

            var productionIncrease = _production / 3;
            if (productionIncrease == 0) productionIncrease = 1;
            _production += productionIncrease;
        }

        public int GetProductionPerClick()
        {
            int amount = _production / 8;
            return amount != 0 ? amount : 1;
        }
    }
}
