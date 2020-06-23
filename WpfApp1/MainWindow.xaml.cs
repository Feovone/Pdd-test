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
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static QuestionsRu[] questions = QuestionsRu.FromJson(Properties.Resources.questionsRu);
        static SectionRu[] sections = SectionRu.FromJson(Properties.Resources.sectionsRu);
        static GroupSection[] groupSection = GroupSection.FromJson(Properties.Resources.groupSection);
        static string[] Group = { "A", "B", "C", "D", "BE,CE", "DE" };
        static int[] GroupSelected = new int[6];
        public QuestionsRu[] TwentyQuestion = new QuestionsRu[20];
        public int currentQuestion = 0;
        int countCorrectAnswer;
        public MainWindow()
        {

            InitializeComponent();
            TestGrid.Visibility = Visibility.Hidden;
            ResultGrid.Visibility = Visibility.Hidden;
           
        }
        class Languages
         {
             static public void ChangeToRus()
             {
                 questions = QuestionsRu.FromJson(Properties.Resources.questionsRu);
                 sections = SectionRu.FromJson(Properties.Resources.sectionsRu);
             }
            static public void ChangeToUa()
             {
                 questions = QuestionsRu.FromJson(Properties.Resources.questionsUa);
                 sections = SectionRu.FromJson(Properties.Resources.sectionsUa);
             }
         }
        private void button_Start(object sender, RoutedEventArgs e)
        {

            StarterGrid.Visibility = Visibility.Hidden;
            TestGrid.Visibility = Visibility.Visible;
            string groupjson = StringGroup();
            groupjson = SelectSection(groupjson);
            QuestionsRu[] selectedqustion = SelectQuestion(groupjson);
            Timer();
            RandomQuestion(selectedqustion);
            FirstQuestion();
            countCorrectAnswer = 0;
        }

        
        private void ColorRevese(Button butGroup)
        {
            string group = butGroup.Name;
            if (butGroup == butGroupAll)
            {
                group = "butGroupA,B,C,D,BE,CE,DE";
                GroupSelect(group.Remove(0, 8));
                if (butGroup.Background == Brushes.LightSteelBlue)
                {
                    butGroup.Background = Brushes.LightGray;
                }
                else
                {
                    butGroup.Background = Brushes.LightSteelBlue;
                }
            }
            else
            {

                if (butGroup == butGroupBE_CE)
                {
                    group = "butGroupBE,CE";
                }

                if (butGroup.Background == Brushes.LightSteelBlue)
                {
                    butGroup.Background = Brushes.LightGray;
                    GroupSelect(group.Remove(0, 8));
                }
                else
                {
                    butGroup.Background = Brushes.LightSteelBlue;
                    GroupSelect(group.Remove(0, 8));
                }
            }
        }
        private void butGroupA_Click(object sender, RoutedEventArgs e)
        {
            ColorRevese(butGroupA);
            if (butGroupDE.IsEnabled == true)
            {                
                butGroupB.IsEnabled = false;
                butGroupC.IsEnabled = false;
                butGroupD.IsEnabled = false;
                butGroupBE_CE.IsEnabled = false;
                butGroupDE.IsEnabled = false;
                butGroupAll.IsEnabled = false;
            }
            else
            {
                butGroupB.IsEnabled = true;
                butGroupC.IsEnabled = true;
                butGroupD.IsEnabled = true;
                butGroupBE_CE.IsEnabled = true;
                butGroupDE.IsEnabled = true;
                butGroupAll.IsEnabled = true;
            }
        }

        private void butGroupC_click(object sender, RoutedEventArgs e)
        {
            ColorRevese(butGroupC);
            if (butGroupDE.IsEnabled == true)
            {
                butGroupA.IsEnabled = false;
                butGroupB.IsEnabled = false;
                butGroupD.IsEnabled = false;
                butGroupBE_CE.IsEnabled = false;
                butGroupDE.IsEnabled = false;
                butGroupAll.IsEnabled = false;
            }
            else
            {
                butGroupA.IsEnabled = true;
                butGroupB.IsEnabled = true;
                butGroupD.IsEnabled = true;
                butGroupBE_CE.IsEnabled = true;
                butGroupDE.IsEnabled = true;
                butGroupAll.IsEnabled = true;
            }
        }

        private void butGroupB_Click(object sender, RoutedEventArgs e)
        {
            ColorRevese(butGroupB);
            if (butGroupDE.IsEnabled == true)
            {
                butGroupA.IsEnabled = false;
                butGroupC.IsEnabled = false;
                butGroupD.IsEnabled = false;
                butGroupBE_CE.IsEnabled = false;
                butGroupDE.IsEnabled = false;
                butGroupAll.IsEnabled = false;
            }
            else
            {
                butGroupA.IsEnabled = true;
                butGroupC.IsEnabled = true;
                butGroupD.IsEnabled = true;
                butGroupBE_CE.IsEnabled = true;
                butGroupDE.IsEnabled = true;
                butGroupAll.IsEnabled = true;
            }
        }

        private void butGroupD_Click(object sender, RoutedEventArgs e)
        {
            ColorRevese(butGroupD);
            if (butGroupDE.IsEnabled == true)
            {
                butGroupA.IsEnabled = false;
                butGroupB.IsEnabled = false;
                butGroupC.IsEnabled = false;
                butGroupBE_CE.IsEnabled = false;
                butGroupDE.IsEnabled = false;
                butGroupAll.IsEnabled = false;
            }
            else
            {
                butGroupA.IsEnabled = true;
                butGroupB.IsEnabled = true;
                butGroupC.IsEnabled = true;
                butGroupBE_CE.IsEnabled = true;
                butGroupDE.IsEnabled = true;
                butGroupAll.IsEnabled = true;
            }
        }
        private void butGroupBE_CE_Click(object sender, RoutedEventArgs e)
        {
            ColorRevese(butGroupBE_CE);
            if (butGroupDE.IsEnabled == true)
            {
                butGroupA.IsEnabled = false;
                butGroupB.IsEnabled = false;
                butGroupC.IsEnabled = false;
                butGroupD.IsEnabled = false;
                butGroupDE.IsEnabled = false;
                butGroupAll.IsEnabled = false;
            }
            else
            {
                butGroupA.IsEnabled = true;
                butGroupB.IsEnabled = true;
                butGroupC.IsEnabled = true;
                butGroupD.IsEnabled = true;
                butGroupDE.IsEnabled = true;
                butGroupAll.IsEnabled = true;
            }
        }
        private void butGroupDE_Click(object sender, RoutedEventArgs e)
        {
            ColorRevese(butGroupDE);
            if (butGroupBE_CE.IsEnabled == true)
            {
                butGroupA.IsEnabled = false;
                butGroupB.IsEnabled = false;
                butGroupC.IsEnabled = false;
                butGroupD.IsEnabled = false;
                butGroupBE_CE.IsEnabled = false;
                butGroupAll.IsEnabled = false;
            }
            else
            {
                butGroupA.IsEnabled = true;
                butGroupB.IsEnabled = true;
                butGroupC.IsEnabled = true;
                butGroupD.IsEnabled = true;
                butGroupBE_CE.IsEnabled = true;
                butGroupAll.IsEnabled = true;
            }
        }


        private void butExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void butReset_Click(object sender, RoutedEventArgs e)
        {
            ResultGrid.Visibility = Visibility.Hidden;

            string groupjson = StringGroup();
            groupjson = SelectSection(groupjson);
            QuestionsRu[] selectedqustion = SelectQuestion(groupjson);
            Timer();
            RandomQuestion(selectedqustion);
            FirstQuestion();
            countCorrectAnswer = 0;
            for (int i = 1; i < 21; i++)
            {
                currentQuestion = i;
                ColorCheck(-1);
            }
            currentQuestion = 0;
            TestGrid.Visibility = Visibility.Visible;
        }

        private void butMenu_Click(object sender, RoutedEventArgs e)
        {
            ResultGrid.Visibility = Visibility.Hidden;
            for (int i = 1; i < 21; i++)
            {
                currentQuestion = i;
                ColorCheck(-1);
            }
            StarterGrid.Visibility = Visibility.Visible;
        }

        private void butChangeRu_Click(object sender, RoutedEventArgs e)
        {
            Languages.ChangeToRus();
        }

        private void butChangeUa_Click(object sender, RoutedEventArgs e)
        {
            Languages.ChangeToUa();
        }

        private void butGroupAll_Click(object sender, RoutedEventArgs e)
        {
            ColorRevese(butGroupAll);
            if (butGroupBE_CE.IsEnabled == true)
            {
                butGroupA.IsEnabled = false;
                butGroupB.IsEnabled = false;
                butGroupC.IsEnabled = false;
                butGroupD.IsEnabled = false;
                butGroupBE_CE.IsEnabled = false;
                butGroupDE.IsEnabled = false;
            }
            else
            {
                butGroupA.IsEnabled = true;
                butGroupB.IsEnabled = true;
                butGroupC.IsEnabled = true;
                butGroupD.IsEnabled = true;
                butGroupBE_CE.IsEnabled = true;
                butGroupDE.IsEnabled = true;
            }
        }
    }  
}
