using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CountdownTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

        string userInputTime;
        string[] splittedUserTime;

        public MainWindow()
        {
            InitializeComponent();

            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            DateTime dateDate = DateTime.Now;
            currentTime.Text = dateDate.ToString();

            try
            {
                int endTimeHour, endTimeMinute, endTimeSecond, userTimeHour, userTimeMinute, counterHour, counterMinute, counterSecond;
        
                if (splittedUserTime == null)
                {
                    endTimeHour = 1 + dateDate.Hour;
                    endTimeMinute = 1 + dateDate.Minute;
                    endTimeSecond = dateDate.Second;
                }
                else
                {                    
                    userTimeHour = Convert.ToInt16(splittedUserTime[0]);
                    userTimeMinute = Convert.ToInt16(splittedUserTime[1]);

                    if (userTimeHour < dateDate.Hour && userTimeMinute < dateDate.Hour)
                    {                        
                        endTimeSecond = 60;
                        endTimeMinute = 60 + userTimeMinute;
                        endTimeHour = 23 + userTimeHour;
                    }
                    else 
                    {
                        if (userTimeHour < dateDate.Hour)
                        {
                            endTimeHour = (24 - dateDate.Hour) + userTimeHour;
                        }
                        else
                        {
                            endTimeHour = userTimeHour;
                        }

                        if (userTimeMinute == 0)
                        {
                            endTimeMinute = 60;
                        }
                        else if (userTimeMinute <= dateDate.Minute)
                        {
                            endTimeHour = endTimeHour - 1;
                            endTimeMinute = 60 + userTimeMinute;
                        }
                        else
                        {
                            endTimeMinute = userTimeMinute;
                        }
                        endTimeSecond = 60;
                    }
                }
                
                counterHour = endTimeHour - (dateDate.Hour + 1);
                counterMinute = endTimeMinute - (dateDate.Minute + 1);
                counterSecond = endTimeSecond - dateDate.Second;

                string counterStringHour;
                string counterStringMinute;
                string counterStringSecond;

                if (counterHour == 1)
                {
                    counterStringHour = " Hour, ";
                }
                else
                {
                    counterStringHour = " Hours, ";
                }
                if (counterMinute == 1)
                {
                    counterStringMinute = " Minute, ";
                }
                else
                {
                    counterStringMinute = " Minutes, ";
                }
                if (counterSecond == 1)
                {
                    counterStringSecond = " Second Left!";
                }
                else
                {
                    counterStringSecond = " Seconds Left!";
                }

                counterTime.Text = "Only " + counterHour + counterStringHour + counterMinute + counterStringMinute + counterSecond + counterStringSecond;
            }
            catch (Exception)
            {
                MessageBox.Show("Error" + e);
            }
        }

        private void btn_startTimer_Click(object sender, RoutedEventArgs e)
        {
            input_endTime.Text = userInputTime;
            char splitSeperator = ':';

            if (userInputTime == null)
            {
                MessageBox.Show("Please enter a valid format.");
            }
            else
            {
                splittedUserTime = userInputTime.Split(splitSeperator);
            }

        }

        private void input_endTime_TextChanged(object sender, TextChangedEventArgs e)
        {
            string userTime = input_endTime.Text;
            userInputTime = userTime;
        }

    }
}
