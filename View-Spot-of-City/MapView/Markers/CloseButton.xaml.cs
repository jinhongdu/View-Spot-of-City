﻿using System.Windows;
using System.Windows.Input;
using GMapView.MyGmapControl;
using System;

namespace GMapView.Markers
{
    /// <summary>
    /// Interaction logic for MyIcon.xaml
    /// </summary>
    public partial class CloseButton
    {
        MyGMap _MapControl;
        GMapView _GMapView;
        Guid _Id;

        public CloseButton(GMapView GMapView, MyGMap mapControl, Guid id, double width, double height)
        {
            this.InitializeComponent();

            this.Width = width;
            this.Height = height;

            this._MapControl = mapControl;
            this._GMapView = GMapView;
            this._Id = id;

            this.Loaded += new RoutedEventHandler(CloseButton_Loaded);
            this.MouseDown += CloseButton_MouseDown;
            this.MouseWheel += CloseButton_MouseWheel;
        }

        private void CloseButton_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            _MapControl._OnMouseWheel(e);
        }

        void CloseButton_Loaded(object sender, RoutedEventArgs e)
        {
            if (icon.Source.CanFreeze)
            {
                icon.Source.Freeze();
            }
        }

        private void CloseButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int count = this._MapControl.Markers.Count;
            for(int i=0;i<count;i++)
            {
                if (_MapControl.Markers[i].Tag != null && ((Guid)_MapControl.Markers[i].Tag) == this._Id)
                {
                    _MapControl.Markers.RemoveAt(i);
                    i--;count--;
                }
            }
            e.Handled = true;
        }
    }
}