using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FirstApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        int currentState = 1;
        double firstnumber, secondnumber;
        string myoperator;
        public MainPage()
        {
            InitializeComponent();
        }

        private void ButtonNumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;

            if (this.Output.Text == "0" || currentState < 0)
            {
                this.Output.Text = "";

                if (currentState < 0)
                    currentState *= -1;
            }

            this.Output.Text += pressed;

            double number;
            if (double.TryParse(this.Output.Text, out number))
            {
                this.Output.Text = number.ToString();
                if (currentState == 1)
                {
                    firstnumber = number;
                }
                else
                {
                    secondnumber = number;
                }
            }
        }
        private void ButtonPoint(object sender, EventArgs e)
        {
            if ((Output.Text.IndexOf(",") == -1) && (Output.Text.IndexOf("∞") == -1))
                Output.Text += ",";
        }
        private void ButtonOperator(object sender, EventArgs e)
        {
            currentState = -2;
            Button button = (Button)sender;
            string pressed = button.Text;
            myoperator = pressed;
        }
        private void ButtonPercent(object sender, EventArgs e)
        {
            if (currentState == -1 || currentState == 1)
            {
                var result = firstnumber / 100;
                this.Output.Text = result.ToString();
                firstnumber = result;
                currentState = -1;
            }
        }
        private void ButtonClearAll(object sender, EventArgs e)
        {
            firstnumber = 0;
            secondnumber = 0;
            currentState = 1;
            this.Output.Text = "0";
        }
        private void ButtonClear(object sender, EventArgs e)
        {
            if (currentState == 1)
            {
                int lenght = Output.Text.Length - 1;
                string text = Output.Text;
                Output.Text = "";
                for (int i = 0; i < lenght; i++)
                {
                    Output.Text = Output.Text + text[i];
                }
                double number;
                if (double.TryParse(this.Output.Text, out number))
                {
                    this.Output.Text = number.ToString();
                    if (currentState == 1)
                    {
                        firstnumber = number;
                    }
                    else
                    {
                        secondnumber = number;
                    }
                }
            }
        }
        private void ButtonSolution(object sender, EventArgs e)
        {
            if (currentState == 2) 
            {
                var result = Operator.Solution(firstnumber, secondnumber, myoperator);
                this.Output.Text = result.ToString();
                firstnumber = result;
                currentState = -1;
            }
        }
    }
}
