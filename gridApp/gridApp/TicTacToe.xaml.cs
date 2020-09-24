using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gridApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TicTacToe : ContentPage
    {
        BoxView box;
        Button newGame, XO;
        public TicTacToe()
        {
            NewGame();
        }

        void NewGame()
        {
            Grid grid = new Grid();

            for (int i = 0; i < 3; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(150, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(150, GridUnitType.Star) });
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    box = new BoxView { Color = Color.FromRgb(200, 100, 50) };
                    grid.Children.Add(box, i, j);
                    var tap = new TapGestureRecognizer();
                    tap.Tapped += Tap_Tapped;
                    box.GestureRecognizers.Add(tap);
                }
            }

            AbsoluteLayout absolute = new AbsoluteLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            Button newGame = new Button
            {
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                Text = "New game"
            };
            AbsoluteLayout.SetLayoutBounds(newGame, new Rectangle(0.9, 0.02, 150, 50));
            AbsoluteLayout.SetLayoutFlags(newGame, AbsoluteLayoutFlags.PositionProportional);
            newGame.Clicked += NewGame_Clicked;
            absolute.Children.Add(newGame);

            Button XO = new Button
            {
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                Text = "X or O"
            };
            AbsoluteLayout.SetLayoutBounds(XO, new Rectangle(0.1, 0.02, 150, 50));
            AbsoluteLayout.SetLayoutFlags(XO, AbsoluteLayoutFlags.PositionProportional);
            XO.Clicked += XO_Clicked;
            absolute.Children.Add(XO);

            StackLayout stack = new StackLayout()
            {
                Children = { grid, absolute }
            };
            Content = stack;
        }
        Random rnd = new Random();
        private void XO_Clicked(object sender, EventArgs e, ref int whoFirst)
        {
            if (whoFirst == 1)
            {
                zero();
            }
            else if (whoFirst == 2)
            {
                cross();
            }
        }
        async void zero()
        {
            await DisplayAlert("Who is first?", "Zero goes first.", "ОK");
        }
        async void cross()
        {
            await DisplayAlert("Who is first?", "The cross goes first.", "ОK");
        }
        private void NewGame_Clicked(object sender, EventArgs e)
        {
            NewGame();
        }
        private void Tap_Tapped(object sender, EventArgs e)
        {
            BoxView box = sender as BoxView;
            box.Color = Color.Blue;
            int whoFirst = rnd.Next(1, 3);
            XO_Clicked(ref whoFirst);
        }
    }
}