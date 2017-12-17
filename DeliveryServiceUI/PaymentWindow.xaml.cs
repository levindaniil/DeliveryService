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

namespace DeliveryServiceUI
{
    /// <summary>
    /// Логика взаимодействия для PaymentWindow.xaml
    /// </summary>
    public partial class PaymentWindow : Window
    {
        public event Action CloseParent;

        public PaymentWindow()
        {
            InitializeComponent();
        }

        private void cashPaymentButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ваш заказ оформлен (оплата при получении)", "Заказ оформлен", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
            CloseParent?.Invoke();
        }

        private void confirmPaymentButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckData())
            {
                MessageBox.Show("Оплата проведена успешно", "Заказ оформлен", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
                CloseParent?.Invoke();
            }
            else
                MessageBox.Show("Введите корректные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private bool CheckData()
        {
            return (IsNumber(firstFourTextBox.Text, 4) && IsNumber(secondFourTextBox.Text, 4)
                && IsNumber(thirdFourTextBox.Text, 4) && IsNumber(fourthFourTextBox.Text, 4) && IsNumber(cvvTextBox.Text, 3));
        }

        private bool IsNumber(string txt,int len)
        {
            int n;
            if (int.TryParse(txt, out n) && n.ToString().Count() == len)
                return true;
            else
                return false;
        }
    }
}
