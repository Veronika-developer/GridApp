using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace gridApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            BoxView box;
            Grid grid = new Grid();

            for (int i = 0; i < 5; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition{ Height = new GridLength(1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star) });
            }
                /*{
                    RowDefinitions =
                    {
                        new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                        new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                        new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                        new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                        new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                    },
                    ColumnDefinitions =
                    {
                        new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                        new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                        new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                        new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                        new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                    }
                };*/
            for(int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    box = new BoxView { Color = Color.FromRgb(200, 100, 50) };
                    grid.Children.Add(box, i, j);
                    var tap = new TapGestureRecognizer();
                    tap.Tapped += Tap_Tapped;
                    box.GestureRecognizers.Add(tap);
                }
            }
            Content = grid;
        }

        private void Tap_Tapped(object sender, EventArgs e)
        {
            BoxView box = sender as BoxView;
            if (box.Color == Color.Black)
            {
                box.Color = Color.LightBlue;
            }
            else if (box.Color == Color.FromRgb(200, 100, 50))
            {
                box.Color = Color.Black;
            }
            else if(box.Color == Color.LightBlue)
            {
                box.Color = Color.FromRgb(200, 100, 50);
            }
            
        }
    }
}
