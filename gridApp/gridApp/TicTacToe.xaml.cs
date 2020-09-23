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
        public TicTacToe()
        {
            BoxView box;
            Grid grid = new Grid();

            for (int i = 0; i < 3; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
            }

            AbsoluteLayout absolute = new AbsoluteLayout();

            Button newGame = new Button { BackgroundColor = Color.Black, 
                TextColor = Color.White, 
                Text = "New game" };
            AbsoluteLayout.SetLayoutBounds(newGame, new Rectangle(0.5, 0.02, 175, 50));
            AbsoluteLayout.SetLayoutFlags(newGame, AbsoluteLayoutFlags.PositionProportional);
            absolute.Children.Add(newGame);

            Button XO = new Button
            {
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                Text = "X or O"
            };
            AbsoluteLayout.SetLayoutBounds(XO, new Rectangle(0.1, 0.5, 100, 50));
            AbsoluteLayout.SetLayoutFlags(XO, AbsoluteLayoutFlags.PositionProportional);
            absolute.Children.Add(XO);

            StackLayout stack = new StackLayout()
            {
                Children = {grid, absolute}
            };
            Content = stack;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    box = new BoxView { Color = Color.FromRgb(200, 100, 50) };
                    grid.Children.Add(box, i, j);
                    var tap = new TapGestureRecognizer();
                    tap.Tapped += Tap_Tapped; ;
                    box.GestureRecognizers.Add(tap);
                }
            }
        }

        private void Tap_Tapped(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}