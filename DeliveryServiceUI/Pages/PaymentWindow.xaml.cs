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
using DeliveryServiceLogic;

namespace DeliveryServiceUI
{
    /// <summary>
    /// Логика взаимодействия для PaymentWindow.xaml
    /// </summary>
    public partial class PaymentWindow : Window
    {
        public event Action CloseParent;
        Methods _methods = new Methods();
       
        public PaymentWindow()
        {
            InitializeComponent();
        }

        private void cashPaymentButton_Click(object sender, RoutedEventArgs e)
        {
            _methods.UpdateOPsAndOrders();
            MessageBox.Show("Ваш заказ оформлен (оплата при получении)", "Заказ оформлен", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
            CloseParent?.Invoke();
            PageFactory.Instance.PageRepository.OrderPage.RefreshListBox();
        }

        private void confirmPaymentButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckData())
            {
                MessageBox.Show("Оплата проведена успешно", "Заказ оформлен", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
                CloseParent?.Invoke();
                _methods.UpdateOPsAndOrders();
                PageFactory.Instance.PageRepository.OrderPage.RefreshListBox();
            }
            else
                MessageBox.Show("Введите корректные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        

        private bool CheckData()
        {
            return (_methods.IsNumber(firstFourTextBox.Text, 4) && _methods.IsNumber(secondFourTextBox.Text, 4)
                && _methods.IsNumber(thirdFourTextBox.Text, 4) && _methods.IsNumber(fourthFourTextBox.Text, 4) && _methods.IsNumber(cvvTextBox.Text, 3));
        }

        
    }
}
