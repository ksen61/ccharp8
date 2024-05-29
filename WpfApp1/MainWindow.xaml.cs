using ClassLibrary;
using System;
using System.IO;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using static ClassLibrary.Serial;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private const string filePath = "Failik.xml";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Serialize_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var data = new TextBoxx
                {
                    Text1 = Txt1.Text,
                    Text2 = Txt2.Text,
                    Text3 = Txt3.Text

                };
                Serial.Serialize(data, filePath);
                MessageBox.Show((string)Application.Current.Resources["SerialMessage"]);
                Txt1.Clear();
                Txt2.Clear();
                Txt3.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format((string)Application.Current.Resources["SerialFail"], ex.Message));
            }
        }

        private void Deserialize_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    var data = Serial.Deserialize<TextBoxx>(filePath);
                    Txt1.Text = data.Text1;
                    Txt2.Text = data.Text2;
                    Txt3.Text = data.Text3;
                    MessageBox.Show((string)Application.Current.Resources["DeserialMessage"]);
                }
                else
                {
                    MessageBox.Show((string)Application.Current.Resources["SerialNoFile"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format((string)Application.Current.Resources["DeserialFail"], ex.Message));
            }
        }

        private void English_Click(object sender, RoutedEventArgs e)
        {

            App.Theme = "En.xaml";
        }

        private void Russian_Click(object sender, RoutedEventArgs e)
        {
            App.Theme = "Ru.xaml";
        }

        private void Language(string languageUri)
        {
            var uri = new Uri(languageUri);
            var resourceDict = (ResourceDictionary)Application.LoadComponent(uri);

            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
    }
}
