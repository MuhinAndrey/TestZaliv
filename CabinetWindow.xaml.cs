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

namespace FinalyDem
{
    public partial class CabinetWindow : Window
    {
        public CabinetWindow()
        {
            InitializeComponent();
            CabinetGrid.ItemsSource = DemEntities.GetContext().Registration.ToList();
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить?","Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var _delete = CabinetGrid.SelectedItem as Registration;

                DemEntities.GetContext().Registration.Remove(_delete);
                DemEntities.GetContext().SaveChanges();

                MessageBox.Show("Удалено!","Уведомление");

                CabinetGrid.ItemsSource = DemEntities.GetContext().Registration.ToList();
            }
        }
    }
}
