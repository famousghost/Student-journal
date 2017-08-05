using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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

namespace StudentCartWPF_GIT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StudentRepository studentRepository = new StudentRepository();
        public MainWindow()
        {
            InitializeComponent();
            InitializeComboBoxes();
        }

        private void ShowStudentList()
        {
            StudentList.ItemsSource = null;
            StudentList.Columns.Clear();
            StudentList.ItemsSource = studentRepository.getAllStudents();
        }

        private void InitializeComboBoxes()
        {
            for(int i=1;i<=31;i++)
            {
                if(i<10)
                {
                    Day.Items.Add("0"+i.ToString());
                }
                else
                {
                    Day.Items.Add(i.ToString());
                }
                
            }
            for(int i=1;i<=12;i++)
            {
                if (i < 10)
                {
                    Month.Items.Add("0" + i.ToString());
                }
                else
                {
                    Month.Items.Add(i.ToString());
                }
            }
            for(int i=1950;i<=2010;i++)
            {
                Year.Items.Add(i.ToString());
            }

        }

        private void ClearTextBoxes()
        {
            PeselTextBox.Text = "";
            NameTextBox.Text = "";
            SurnameTextBox.Text = "";
            Day.Text = "";
            Month.Text = "";
            Year.Text = "";
            CityTextBox.Text = "";
        }

        private void StudentAddButton_Click(object sender, RoutedEventArgs e)
        {
            string format = "dd mm yyyy";
            DateTime birthDate;
            string date = Day.Text + " " + Month.Text + " " + Year.Text;
            bool checkDate = DateTime.TryParseExact(date, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate);

            Student student = new Student(PeselTextBox.Text, NameTextBox.Text, SurnameTextBox.Text, birthDate, CityTextBox.Text);
            if(studentRepository.AddStudent(student) == AddStudentResult.SuccessToAddStudent)
            {
                MessageBox.Show(studentRepository.GetStudentAddMessage());
                ClearTextBoxes();
                ShowStudentList();
            }
            else
            {
                MessageBox.Show(studentRepository.GetStudentAddMessage());
            }
        }

        private void DeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            if(studentRepository.DeleteEntity((Student)StudentList.SelectedItem) == DeleteStudentResult.SuccessToDeleteStudent)
            {
                MessageBox.Show(studentRepository.GetStudentDeleteMessage());
                ShowStudentList();
            }
            else
            {
                MessageBox.Show(studentRepository.GetStudentDeleteMessage());
            }
        }
    }
}
