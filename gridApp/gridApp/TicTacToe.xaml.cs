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
        public bool First = false;
        Label WhoFirst;
        BoxView box;
        public TicTacToe()
        {
            FirstPlayer();
            NewGame();
            WHO();
        }

        void NewGame()
        {
            Grid grid = new Grid();
            //string [] boxes = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            for (int i = 0; i < 3; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(150, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(150, GridUnitType.Star) });
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    box = new BoxView { Color = Color.FromRgb(150, 150, 150) };
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
            newGame.Clicked += new EventHandler(NewGame_Clicked);
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

            WhoFirst = new Label
            {
                TextColor = Color.Black,
                Text = "..."
            };
            AbsoluteLayout.SetLayoutBounds(WhoFirst, new Rectangle(0.7, 1.3, 150, 50));
            AbsoluteLayout.SetLayoutFlags(WhoFirst, AbsoluteLayoutFlags.PositionProportional);
            absolute.Children.Add(WhoFirst);

            StackLayout stack = new StackLayout()
            {
                Children = { grid, absolute }
            };
            Content = stack;
        }
        public async void FirstPlayer()
        {
            string FirstPlayer = await DisplayPromptAsync("Who is first?", "Zero - 1, cross - 2", 
                initialValue:"1", 
                maxLength:1, 
                keyboard:Keyboard.Numeric);
            if(FirstPlayer == "1")
            {
                First = true;
            }
            else if (FirstPlayer == "2")
            {
                First = true;
            }
        }
        Random rnd = new Random();
        private bool First_playerRND()
        {
            int player = rnd.Next(0, 2);
            if(player == 1)
            {
                First = true;
            }
            else if (player == 2)
            {
                First = false;
            }
            return First;
        }
        private void XO_Clicked(object sender, EventArgs e)
        {
            First_playerRND();
            NewGame();
            WHO();
        }
        private void NewGame_Clicked(object sender, EventArgs e)
        {
            NewGame();
            WHO();
        }
        private void Tap_Tapped(object sender, EventArgs e)
        {
            BoxView box = sender as BoxView;
            
            if(box.Color == Color.FromRgb(150, 150, 150) && First)
            {
                box.Color = Color.FromRgb(128, 57, 30);
                First = false;
            }
            else if (box.Color == Color.FromRgb(150, 150, 150) && !First)
            {
                box.Color = Color.FromRgb(224, 123, 57);
                First = true;
            }
            else
            {
                DisplayAlert("Warning!", "The enemy has already cut this field.", "OK");
            }
            WHO();
        }
        private void WHO()
        {
            if(First == true)
            {
                WhoFirst.Text = "Zero move";
            }
            else if (First == false)
            {
                WhoFirst.Text = "Cross move";
            }
        }

        private void Winner()
        {

        }
    }
}