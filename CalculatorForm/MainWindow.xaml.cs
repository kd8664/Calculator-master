﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
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

using CalculatorNS;
using Newtonsoft.Json;

namespace CalculatorForm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ObservableCollection<HElement> history = new ObservableCollection<HElement>();
            IHistoryStorage historyStorage = new DatabaseHistoryStorage();
            historyStorage.Read(history);

            DataContext = new MainViewModel(historyStorage)
            {
                History = history
            };
        }
    }
}
