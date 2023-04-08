using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XF_Calculator
{
        public partial class MainPage : ContentPage
        {
            int currentState = 1;
            string myoperator;
            double firstNumber, secondNumber;

            public MainPage()
            {
                InitializeComponent();
                OnClear(this, null);
            }

            void OnSelectNumber(object sender, EventArgs e)
            {
                Button button = (Button)sender;


                string pressed = button.Text;
                //validation before button is pressed

                //if the current result is 0 in text box then we will direct the calculator to exclude 0 when pressing buttons
                if (this.resultText.Text == "0" || currentState < 0)//at first current state is 1
                {
                    this.resultText.Text = "";//here the text value will be cleared when pressing button

                    if (currentState < 0) //at first current value is 1 so this condition is excluded
                        currentState *= -1;
                }

                this.resultText.Text += pressed;// this condition is called when current state is greater and text box will aquire the pressed 

                double number;//if  we are going  to assign two dynamic number for a given variable using try parse method 
                if (double.TryParse(this.resultText.Text, out number))
                {
                    this.resultText.Text = number.ToString("N0");
                    if (currentState == 1)
                    {
                        firstNumber = number;//at first current state will be 1 and it will assign first number with the pressed number variable
                    }
                    else
                    {
                        secondNumber = number;//it will be implemented as the number of current state changes i.e. 2
                    }
                }
            }

            void OnSelectOperator(object sender, EventArgs e)//event is called when the select operator is called 
            {
                currentState = -2;
                Button button = (Button)sender;
                string pressed = button.Text;
                myoperator = pressed;
            }

            void OnClear(object sender, EventArgs e)// this method is called when we press the AC button
            {
                firstNumber = 0;
                secondNumber = 0;
                currentState = 1;
                this.resultText.Text = "0";
            }

            void OnPercentage(object sender, EventArgs e) //This method is useful when we are going to find out percentage of last rsulting variable or the initial variable
            {

                if ((currentState == -1) || (currentState == 1))//please use some break point to check when we are going to get current state value as -1 or 1
                {

                    //var result = OperatorHelper.MyPercentage(firstNumber, myoperator);
                    var result = firstNumber / 100;
                    this.resultText.Text = result.ToString();
                    firstNumber = result;
                    currentState = -1;

                }


            }
            void OnCalculate(object sender, EventArgs e) //This method is called when we have both first number and second number and we are going to evaluate those number
            {
                if (currentState == 2)
                {
                    var result = SimpleCalculator.Calculate(firstNumber, secondNumber, myoperator);

                    this.resultText.Text = result.ToString();
                    firstNumber = result;
                    currentState = -1;
                }
            }
            void OnSquareRoot(object sender, EventArgs e) //We call this event when we have one resulting number or initial number ,we are going to find out the square root of that number
            {
                if ((currentState == -1) || (currentState == 1))
                {
                    //var result = OperatorHelper.MySquareRoot(firstNumber, myoperator);
                    var result = Math.Sqrt(firstNumber);

                    this.resultText.Text = result.ToString();
                    firstNumber = result;
                    currentState = -1;
                }
            }


            private void squareclicked(object sender, EventArgs e)//We call this method when we have one resulting number or initial number ,we are going to find out the square root of that number
            {

                if ((currentState == -1) || (currentState == 1))
                {
                    //var result = OperatorHelper.MySquare(firstNumber, myoperator);
                    var result = firstNumber * firstNumber;
                    this.resultText.Text = result.ToString();
                    firstNumber = result;
                    currentState = -1;
                }
            }

        }
    }