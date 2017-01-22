using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace math_quiz
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();

        int addend1, addend2, TimeLeft, minuend, subtrahend, multiplicand, multiplier,
            dividend, divisor;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (checkTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers right",
                    "Congratulations");
                startButton.Enabled = true;
            }
            if (TimeLeft > 0)
            {
                TimeLeft = TimeLeft - 1;
                timeLabel.Text = TimeLeft + " seconds";
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time", "sorry");
                sum.Value = addend1 + addend2;
                startButton.Enabled = true;
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void answer_enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        public void StartTheQuiz()
        {
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            minuend = randomizer.Next(1, 100);
            subtrahend = randomizer.Next(1, minuend);

            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();

            multiplicand = randomizer.Next(1, 11);
            multiplier = randomizer.Next(1, 11);

            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();

            divisor = randomizer.Next(1, 11);
            int temporaryQuotient = randomizer.Next(1, 11);
            dividend = temporaryQuotient * divisor;

            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();

            sum.Value = 0;
            difference.Value = 0;
            product.Value = 0;
            quotient.Value = 0;

            TimeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }
        private bool checkTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value) && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value) && quotient.Value == dividend / divisor)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
