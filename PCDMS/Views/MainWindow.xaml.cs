﻿using System.Windows;
using System.Windows.Controls;

namespace PCDMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            dgDocuments.ItemsSource = App.Settings.DocumentsList;
            Title = "PCDMS Mockup";

            miWord.Tag = new DocInfo() { Type = "Word Document", Extension = "docx" };
            miExcel.Tag = new DocInfo() { Type = "Excel Workbook", Extension = "xlsx" };
            miPowerPoint.Tag = new DocInfo() { Type = "PowerPoint Presentation", Extension = "pptx" };
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            NewFileDialog dialog = new NewFileDialog(mi.Tag as DocInfo);
            dialog.ShowDialog();
        }
    }
}
