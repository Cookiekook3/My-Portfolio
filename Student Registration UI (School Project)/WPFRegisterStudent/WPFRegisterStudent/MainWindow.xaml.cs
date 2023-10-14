
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

namespace WPFRegisterStudent
{
    
    public partial class MainWindow : Window
    {
        Course choice;
        private int creditHours = 0;  

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Course course1 = new Course("IT 145");
            Course course2 = new Course("IT 200");
            Course course3 = new Course("IT 201");
            Course course4 = new Course("IT 270");
            Course course5 = new Course("IT 315");
            Course course6 = new Course("IT 328");
            Course course7 = new Course("IT 330");

            this.comboBox.Items.Add(course1);
            this.comboBox.Items.Add(course2);
            this.comboBox.Items.Add(course3);
            this.comboBox.Items.Add(course4);
            this.comboBox.Items.Add(course5);
            this.comboBox.Items.Add(course6);
            this.comboBox.Items.Add(course7); 
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            choice = (Course)(this.comboBox.SelectedItem);

         

            if (this.listBox.Items.Contains(choice) && choice.IsRegisteredAlready())
            {
                this.textBlock1.Text = "You have already registered for this " + choice.ToString() + " course";  
            }
            else if (creditHours < 9)  
            {
                this.listBox.Items.Add(choice);  
                choice.SetToRegistered();
                creditHours += 3;  
                this.textBox.Text = Convert.ToString(creditHours);  
                this.textBlock1.Text = "Registration confirmed for course " + choice.ToString();  
            }
            else
                this.textBlock1.Text = "You can't register for more than 9 credit hours.";
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        
        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }
    }
}
