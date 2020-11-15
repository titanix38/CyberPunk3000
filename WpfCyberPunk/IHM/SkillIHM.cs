﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfCyberPunk.IHM
{
    public class SkillIHM
    {
        private int _itemCount;
        private int _column;
        private int _posRow;
        private int _posCol;

        public Grid MainGrid { get; private set; }

        public string Name { get; set; }
        public string Alias { get; set; }

        public SkillIHM()
        {
            _itemCount = 1;
            _column = 1;
            _posRow = 0;
            _posCol = 0;
            InitGrid();
        }

        public SkillIHM(int itemCount, int column)
        {
            _itemCount = itemCount;
            _column = column;
            _posRow = 0;
            _posCol = 0;
            InitGrid();
        }

        private void InitGrid()
        {
            MainGrid = new Grid()
            {
                HorizontalAlignment = HorizontalAlignment.Left,
            };

            for (int i = 1; i <= _itemCount; i++)
            {
                MainGrid.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 1; i <= _column; i++)
            {
                MainGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        public void SetGrid()
        {
            StackPanel subStack = new StackPanel()
            {
                Name = "StkPan_SubItems",
                Orientation = Orientation.Horizontal,
                //Height = 20
                //Width = 200
            };
            Label lblName = new Label()
            {
                Name = string.Concat("lb_", Alias),
                Content = Name,
                FontSize = 10,
                Width = 100
            };
            TextBox txtScore = new TextBox()
            {
                Name = string.Concat("tbScore_", Alias),
                FontSize = 10,
                Height = 14,
                Width = 25,
                Margin = new Thickness(0, 0, 5, 0),
                HorizontalAlignment = HorizontalAlignment.Right,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center
            };
            TextBox txtPoint = new TextBox()
            {
                Name = string.Concat("tbPoint_", Alias),
                FontSize = 10,
                Height = 14,
                Width = 25,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };
            CheckBox chkBox = new CheckBox()
            {
                VerticalAlignment = VerticalAlignment.Center,
                Height = 14,
                //Width = 14,
                Margin = new Thickness(10, 0, 10, 0),
            };

            subStack.Children.Add(lblName);
            subStack.Children.Add(txtScore);
            subStack.Children.Add(txtPoint);
            subStack.Children.Add(chkBox);
            
            if (_posRow == _itemCount/_column)
            {
                _posRow = 0;
                _posCol++;
            }
            
            MainGrid.Children.Add(subStack);

            Grid.SetRow(subStack, _posRow);
            Grid.SetColumn(subStack, _posCol);
            _posRow++;
        }
    }
}