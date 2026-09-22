namespace Tally_App
{
    public partial class MainPage : ContentPage
    {
        public int runningTally = 0;
        public MainPage()
        {
            InitializeComponent();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int totalTally = 0;


            //Clears the tally
            if (button.Text == "C")
            {
                TallyDisplay.Text = "";
                runningTally = 0;
                TotalDisplay.Text = string.Empty;
            }
            //Adds number to tally
            else if (button.Text == "+")
            {
                if(TallyDisplay.Text.EndsWith("+") == false && 
                    String.IsNullOrWhiteSpace(TallyDisplay.Text) == false)
                {
                    TallyDisplay.Text += "\r";
                    TallyDisplay.Text += button.Text;
                }
            }
            //Input from keypad
            else
            {
                TallyDisplay.Text += button.Text;
            }

            //Creates an array of numbers between the + and newline
            string[] tallyList = TallyDisplay.Text.Split(new char[] { '+', '\r' });

            //Iterates through the array and adds to the total
            foreach (string number in tallyList)
            {
                string trimmed_number = number.Trim('+');

                if (String.IsNullOrWhiteSpace(trimmed_number) == false)
                {
                    totalTally += int.Parse(trimmed_number);
                }
            }

            //Display total
            TotalDisplay.Text = $"Total: {totalTally}";
        }
    }
}
