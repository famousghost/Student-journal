using System;
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
            InitializeComboBoxes();
            InitializeComponent();
        }

        private void InitializeComboBoxes()
        {
            for (int i = 1; i <= 31; i++)
            {
                //Day.Items.Add(i.ToString());
            }

            for(int i=1;i<=12;i++)
            {
               // Month.Items.Add(i.ToString());
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
            bool checkDate = DateTime.TryParseExact("09 01 1995", format, CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate);

            Student student = new Student(PeselTextBox.Text, NameTextBox.Text, SurnameTextBox.Text, birthDate, CityTextBox.Text);
            if(studentRepository.AddStudent(student) == AddStudentResult.FailedToAddStudent)
            {
                MessageBox.Show("nie udalo sie dodac studenta");
            }
            else if(studentRepository.AddStudent(student) == AddStudentResult.StudentIsExist)
            {
                MessageBox.Show("Taki student juz istnieje");
            }
            else
            {
                studentRepository.AddStudent(student);
                MessageBox.Show("Dodales studenta");
                ClearTextBoxes();

            }
        }
    }
}
