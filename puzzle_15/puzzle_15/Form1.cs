namespace puzzle_15
{
    public partial class Form1 : Form
    {
        Button [,] dokemeha;
        public Form1()
        {
            InitializeComponent();

            

            dokemeha = new Button [4,4]{ { button1, button2, button3, button4 },
                                         {button5, button6 , button7,  button8},
                                         {button9, button10, button11, button12},
                                         { button13 ,button14, button15, button16}
                                       };

            int number;

            Random r = new Random();

            int[] arr = new int[16];

            bool find;

            for (int i = 0; i < 16; i++)
            {
                while (true)
                {
                    number = r.Next(0, 17);
                    find = false;

                    for (int j = 0; j < i; j++)
                    {
                        if (arr[j] == number)
                        {
                            find = true;
                        }
                    }
                    if (!find)
                    {
                        arr[i] = number;
                        break;
                    }
                }
            }

            int index = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                { 
                    dokemeha[i, j].Text = Convert.ToString(arr[index]);
                    index++; 
                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Button button = (sender as Button);

            if (empty(button))
            {
                move_button(button);
            }
            if(compare())
            {
                MessageBox.Show("Win");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            hide_button();
        }

        private void hide_button()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (dokemeha[i, j].Text == "16")
                    {
                        dokemeha[i, j].Hide();
                    }
                }
            }
        }

        private bool empty(Button button)
        {
            int X, Y, x, y;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (dokemeha[i, j].Text == "16")
                    {
                        x = button.Location.X;
                        y = button.Location.Y;

                        X = dokemeha[i, j].Location.X;
                        Y = dokemeha[i, j].Location.Y;

                        if ( ((X - x == 81 && Y == y) || (x - X == 81 && Y == y)) || ((Y - y == 62 && X == x) || (y - Y == 62 && X == x)) )
                        {
                            return true;
                        }

                    }
                }
            }
            return false;
        }

        private void move_button(Button button)
        {
            int X, Y, x, y;

            X = button.Location.X;
            Y = button.Location.Y;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (dokemeha[i, j].Text == "16")
                    {
                        x = dokemeha[i, j].Location.X;
                        y = dokemeha[i, j].Location.Y;

                        button.Location = new Point(x, y);

                        dokemeha[i, j].Location = new Point(X, Y);
                    }
                }
            }
        }

        private bool compare()
        {
            int number;
            int count = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    number = Convert.ToInt16(dokemeha[i, j].Text);

                    if (number > Convert.ToInt16(dokemeha[i, j + 1].Text) && count < 4)
                    {
                       return false;
                    }
                }
                count = 0;
            }
            return true;
        }

    }
}