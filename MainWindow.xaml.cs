using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

using static System.Net.Mime.MediaTypeNames;
using Image = System.Windows.Controls.Image;

namespace letsTodo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {


            Ellipse ellipse = new Ellipse();
            ellipse.Width = 8;
            ellipse.Height = 8;
            ellipse.Fill = new SolidColorBrush(Color.FromArgb(0xFF, 0x6E, 0x9C, 0xEF));
            Grid container = new Grid();
            container.Children.Add(ellipse);
            ellipse.HorizontalAlignment = HorizontalAlignment.Center;
            ellipse.VerticalAlignment = VerticalAlignment.Center;

            TextBox textBox = new TextBox() { Width = 370, Margin = new Thickness(2), BorderBrush = Brushes.White, FontSize = 10, AcceptsReturn = true, TextWrapping = TextWrapping.Wrap };
            textBox.TextChanged += TextBox_TextChanged;
            PreviewKeyDown += MainWindow_PreviewKeyDown;
            StackPanel inlineStackPanel = new StackPanel();
            inlineStackPanel.Orientation = Orientation.Horizontal;
            inlineStackPanel.Children.Add(container);
            inlineStackPanel.Children.Add(textBox);

            ListBox.Items.Add(inlineStackPanel);

        }

        private void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                FocusManager.SetFocusedElement(this, null);
                Keyboard.ClearFocus();
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {

            ListBoxCompleted.Items.Clear();


        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {

            ListBox listBox = ListBox;

            List<TextBox> textBoxes = new List<TextBox>();

            foreach (var selectedItem in listBox.SelectedItems.Cast<StackPanel>().ToList())
            {
                StackPanel selectedStackPanel = selectedItem as StackPanel;
                if (selectedStackPanel != null)
                {
                    TextBox textBox = null;
                    foreach (var child in selectedStackPanel.Children)
                    {
                        if (child is TextBox)
                        {
                            textBox = child as TextBox;
                            textBoxes.Add(textBox);
                        }

                    }

                    if (textBox != null)
                    {
                        string textValue = textBox.Text;

                        TextBlock textBlock = new TextBlock
                        {
                            Width = 370,
                            Margin = new Thickness(3),
                            Text = textValue,
                            FontSize = 10,
                            TextWrapping = TextWrapping.Wrap,
                            TextDecorations = new TextDecorationCollection()
                    {
                        new TextDecoration() { Location = TextDecorationLocation.Strikethrough }
                    }
                        };

                        Image checkImage = new Image
                        {
                            Source = new BitmapImage(new Uri("blueTick.png", UriKind.Relative)),
                            Width = 10,
                            Height = 10

                        };

                        StackPanel inlineStackPanel = new StackPanel
                        {
                            Orientation = Orientation.Horizontal
                        };

                        inlineStackPanel.Children.Add(checkImage);
                        inlineStackPanel.Children.Add(textBlock);

                        ListBoxCompleted.Items.Add(inlineStackPanel);
                    }

                    listBox.Items.Remove(selectedItem);
                }
            }
            if (Keyboard.FocusedElement is TextBox focusedTextBox)
            {
                try
                {
                    TextBlock textBlock = new TextBlock
                    {
                        Width = 370,
                        Margin = new Thickness(3),
                        Text = focusedTextBox.Text,
                        FontSize = 10,
                        TextWrapping = TextWrapping.Wrap,
                        TextDecorations = new TextDecorationCollection()
            {
                new TextDecoration() { Location = TextDecorationLocation.Strikethrough }
            }
                    };

                    Image checkImage = new Image
                    {
                        Source = new BitmapImage(new Uri("blueTick.png", UriKind.Relative)),
                        Width = 10,
                        Height = 10
                    };

                    StackPanel inlineStackPanel = new StackPanel
                    {
                        Orientation = Orientation.Horizontal
                    };

                    inlineStackPanel.Children.Add(checkImage);
                    inlineStackPanel.Children.Add(textBlock);

                    ListBoxCompleted.Items.Add(inlineStackPanel);

                    // Log success message or use breakpoints for debugging
                    Console.WriteLine("Item added successfully to ListBoxCompleted.");
                }
                catch (Exception ex)
                {
                    // Log any exceptions that occur during execution
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }

        }

        private void ListBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListBoxItem listBoxItem)
            {

                listBoxItem.IsSelected = !listBoxItem.IsSelected;


                e.Handled = true;
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {

                textBox.Height = CalculateTextBoxHeight(textBox);
            }

        }

        private double CalculateTextBoxHeight(TextBox textBox)
        {

            double lineHeight = textBox.FontSize * 1.2;
            double contentHeight = textBox.LineCount * lineHeight;
            double padding = textBox.Padding.Top + textBox.Padding.Bottom;
            double border = textBox.BorderThickness.Top + textBox.BorderThickness.Bottom;

            return contentHeight + padding + border;
        }


    }








}
