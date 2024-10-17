namespace TicTacToe
{
    public partial class MainPage : ContentPage
    {
        string sign = "x";

        public MainPage()
        {
            InitializeComponent();
        }

        private void MarkCell(object sender, EventArgs e)
        {
            var button = sender as Button;
            button.Text = sign;
            if (sign == "x")
                sign = "o";
            else if (sign == "o")
                sign = "x";
        }

        private void CheckWin(object sender, EventArgs e) 
        { 
            if(cell1)
        }
    }

}
