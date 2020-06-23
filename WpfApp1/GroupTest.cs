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
        private DateTime startTime = new DateTime();
        int t = 0;
        private void Timer()
        {
           
            startTime = DateTime.MinValue;
            DispatcherTimer timer = new DispatcherTimer();
            if (t == 0)
            {
                timer.Tick += new EventHandler(dispatcherTimer_Tick);
                timer.Interval = new TimeSpan(0, 0, 1);
                t++;
            }
            timer.Start();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            startTime = startTime.AddSeconds(1);
            labelTime.Content = startTime.ToString("mm:ss");
        }
        private void GroupSelect(string groupName)
        {
            if (groupName == "A,B,C,D,BE,CE,DE")
            {

                for(int j = 0; j < 6; j++) 
                {
                    if (GroupSelected[j] == 1)
                    {
                        GroupSelected[j] = 0;
                    }
                    else
                    {
                        GroupSelected[j] = 1;
                    }
                }
            }
            else
            {
                int i = 0;
                foreach (string name in Group)
                {
                    if (name == groupName)
                    {
                        if (GroupSelected[i] == 1)
                        {
                            GroupSelected[i] = 0;
                        }
                        else
                        {
                            GroupSelected[i] = 1;
                        }
                    }
                    i++;
                }
            }       
        }
        private string StringGroup()
        {
            int j = 0;
            string groupjson="";
            for(int i=0;i<6;i++)
            {
                if(GroupSelected[i] ==1)
                {
                    if (j > 0)
                    {
                        groupjson += ",";
                    }
                    groupjson += Group[i];
                    j++;
                }
               
            }
            return groupjson;
        }
        private string SelectSection(string groupjson)
        {
            int j = 0;
            string[] temp = { };
            string questionsSection = "";
            for (int i = 0; i < groupSection.Length; i++)
            {
                if (groupSection[j].Categories == groupjson)
                {
                    temp = groupSection[j].QuestionSections;
                }
                j++;
            }
            for(int i = 0; i < temp.Length; i++)
            {
                questionsSection += temp[i];
                questionsSection += ";";
            }

            return questionsSection;
        }
        private QuestionsRu[] SelectQuestion(string questionsSection)
        {
            int j = 0;
            for (int i = 0; i < questions.Length; i++) {
                bool h = questionsSection.Contains(Convert.ToString(questions[i].SectionId));

                if (h == true)
                {
                    j++;    
                }
            }
            QuestionsRu[] selectedQuestion = new QuestionsRu[j];
            j = 0;
            for (int i = 0; i < questions.Length; i++)
            {
                bool h = questionsSection.Contains(Convert.ToString(questions[i].SectionId));

                if (h == true)
                {
                    selectedQuestion[j] = questions[i];
                    j++;
                }
            }
           // labelTextQuestion.Content = selectedQuestion.Length;
            return selectedQuestion;
        }
        private void RandomQuestion(QuestionsRu[]selectedQuestion)
        {
            Random rnd = new Random();
            for (int i = 0; i < 20; i++)
            {
                TwentyQuestion[i] = selectedQuestion[rnd.Next(0,selectedQuestion.Length - 1)];
            }  
        }
        private void FirstQuestion()
        {
           Allq(0);
        }
        private void NextQuestion(int currentQuestion)
        {
            Allq(currentQuestion);
        }
        private void butAnswerQuestion_Click(object sender, RoutedEventArgs e)
        {
            int Answer = 0;
            int AnswerQ;
            if (radioAnswer1.IsChecked == true) { Answer = 0; }
            if (radioAnswer2.IsChecked == true) { Answer = 1; }
            if (radioAnswer3.IsChecked == true) { Answer = 2; }
            if (radioAnswer4.IsChecked == true) { Answer = 3; }
            if (radioAnswer5.IsChecked == true) { Answer = 4; }
            radioAnswer1.IsChecked = false;
            radioAnswer2.IsChecked = false;
            radioAnswer3.IsChecked = false;
            radioAnswer4.IsChecked = false;
            radioAnswer5.IsChecked = false;
            if (Answer == TwentyQuestion[currentQuestion].RightAnswerIndex)
            {
                AnswerQ = 1;
                countCorrectAnswer++;
            }
            else
            {
                AnswerQ = 0;
            }
            currentQuestion++;
            ColorCheck(AnswerQ);
            NextQuestion(currentQuestion);
        }
        private void ColorCheck(int AnswerQ)
        {
            SolidColorBrush color;
            if (AnswerQ == 1)
            {
                color = Brushes.Green;
            }else
            if(AnswerQ == -1)
            {
                color = Brushes.LightGray;
            }
            else
            {
                color = Brushes.Red;
            }
            switch (currentQuestion)
            {
                case 1:
                    butQuestion1.Background = color;
                    break;
                case 2:
                    butQuestion2.Background = color;
                    break;
                case 3:
                    butQuestion3.Background = color;
                    break;
                case 4:
                    butQuestion4.Background = color;
                    break;
                case 5:
                    butQuestion5.Background = color;
                    break;
                case 6:
                    butQuestion6.Background = color;
                    break;
                case 7:
                    butQuestion7.Background = color;
                    break;
                case 8:
                    butQuestion8.Background = color;
                    break;
                case 9:
                    butQuestion9.Background = color;
                    break;
                case 10:
                    butQuestion10.Background = color;
                    break;
                case 11:
                    butQuestion11.Background = color;
                    break;
                case 12:
                    butQuestion12.Background = color;
                    break;
                case 13:
                    butQuestion13.Background = color;
                    break;
                case 14:
                    butQuestion14.Background = color;
                    break;
                case 15:
                    butQuestion15.Background = color;
                    break;
                case 16:
                    butQuestion16.Background = color;
                    break;
                case 17:
                    butQuestion17.Background = color;
                    break;
                case 18:
                    butQuestion18.Background = color;
                    break;
                case 19:
                    butQuestion19.Background = color;
                    break;
                case 20:
                    butQuestion20.Background = color;
                    break;

            }
        }
        private void Result()
        {
            TestGrid.Visibility = Visibility.Hidden;
            ResultGrid.Visibility = Visibility.Visible;
            textBoxResult.Text = "Результат " + countCorrectAnswer + " правильных ответов";
        }

    }
}
