﻿using System;
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
using System.Windows.Shapes;

namespace TsvetoshaApplication
{
    /// <summary>
    /// Логика взаимодействия для FloristWindow.xaml
    /// </summary>
    public partial class FloristWindow : Window
    {
        public FloristWindow(string name, string surname, string patronymic)
        {
            InitializeComponent();
        }
    }
}
