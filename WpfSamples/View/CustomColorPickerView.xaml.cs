﻿using System.Windows;
using System.Windows.Media;

namespace WpfSamples.View
{
    public partial class CustomColorPickerView : Window
    {
        public CustomColorPickerView()
        {
            InitializeComponent();
        }

        private void ColorPicker_OnColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {
        }
    }
}