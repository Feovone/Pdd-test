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
using System.Resources;
using Newtonsoft.Json;
using LitJson;
using System.Timers;
using System.Windows.Threading;
namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private void Allq(int i)
        {
            if (i == 20) { Result(); }
            else
            {
                textBoxQuestion.Text = TwentyQuestion[i].Question;
                ShowAnswers(i);
                ShowImage(i);
                currentQuestion = i;
            }
        }
        private void ShowAnswers(int i)
        {
            int len = TwentyQuestion[i].Answers.Length;
            textQuestion1.Text = TwentyQuestion[i].Answers[0];
            textQuestion2.Text = TwentyQuestion[i].Answers[1];
            if (len >= 3)
            {
                textQuestion3.Text = TwentyQuestion[i].Answers[2];
                radioAnswer3.Visibility = Visibility.Visible;
                bAnswer3.Visibility = Visibility.Visible;
            }
            else
            {
                radioAnswer3.Visibility = Visibility.Hidden;
                bAnswer3.Visibility = Visibility.Hidden;
            }
            if (len >= 4)
            {
                textQuestion4.Text = TwentyQuestion[i].Answers[3];
                radioAnswer4.Visibility = Visibility.Visible;
                bAnswer4.Visibility = Visibility.Visible;
            }
            else
            {
                radioAnswer4.Visibility = Visibility.Hidden;
                bAnswer4.Visibility = Visibility.Hidden;
            }
            if (len >= 5)
            {
                textQuestion5.Text = TwentyQuestion[i].Answers[4];
                radioAnswer5.Visibility = Visibility.Visible;
                bAnswer5.Visibility = Visibility.Visible;
            }
            else
            {
                radioAnswer5.Visibility = Visibility.Hidden;
                bAnswer5.Visibility = Visibility.Hidden;
            }
        }
        private void ShowImage(int i)
        {
            if (TwentyQuestion[i].ImgSrc != null)
            {
                image.Source = new BitmapImage(new Uri("Resources/images/" + TwentyQuestion[i].ImgSrc, UriKind.Relative));
            }
            else
            {
                image.Source = null;
            }
        }
    }
}
