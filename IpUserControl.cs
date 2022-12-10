using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class IPBox : UserControl
    {
        bool f4 = true, f3 = true, f2 = true;
        int D1 = 0, D2 = 0, D3 = 0, L4 = 0, L3 = -0, L2 = 0;
        public static readonly DependencyProperty BorderHeight =
            DependencyProperty.Register("Borderheight", typeof(string), typeof(IPBox), new PropertyMetadata(string.Empty));
        public string Borderheight
        {
            get { return (string)GetValue(BorderHeight); }
            set { SetValue(BorderHeight, value); }
        }

        public static readonly DependencyProperty BorderWidth =
           DependencyProperty.Register("Borderwidth", typeof(string), typeof(IPBox), new PropertyMetadata(string.Empty));

        public string Borderwidth
        {
            get { return (string)GetValue(BorderWidth); }
            set { SetValue(BorderWidth, value); }

        }

        public static readonly DependencyProperty BorderColor =
            DependencyProperty.Register("Bordercolor", typeof(string), typeof(IPBox), new PropertyMetadata(string.Empty));
        public string Bordercolor
        {
            get { return (string)GetValue(BorderColor); }
            set { SetValue(BorderColor, value); }
        }

        public static readonly DependencyProperty InnerTB =
            DependencyProperty.Register("InnerTBwidth", typeof(string), typeof(IPBox), new PropertyMetadata(string.Empty));
        public string InnerTBwidth
        {
            get { return (string)GetValue(InnerTB); }
            set { SetValue(InnerTB, value); }
        }
        public static readonly DependencyProperty Font =
             DependencyProperty.Register("font", typeof(string), typeof(IPBox), new PropertyMetadata(string.Empty));

        public string font
        {
            get { return (string)GetValue(Font); }
            set { SetValue(Font, value); }
        }


        public IPBox()
        {
            InitializeComponent();
        }

        private void Text1D(object sender, KeyEventArgs e)
        {
            L2 = 0;
            if (e.Key == Key.Right && T1.CaretIndex == T1.Text.Length)
            {
                D1++;
                if (D1 == 2)
                {
                    T2.Focus();
                    T2.CaretIndex = T2.Text.Length;
                    T2.SelectAll();
                    D1 = 0;
                }
            }
            if (T1.Text.Length == 3 && e.Key == Key.Decimal)
            {
                T2.Focus();
                T2.CaretIndex = T2.Text.Length;
                T2.SelectAll();
            }
        }
        private void Text1(object sender, KeyEventArgs e)
        {
            if (T1.CaretIndex == 3 || e.Key == Key.Tab)
            {
                if (T1.CaretIndex == T1.Text.Length)
                {
                    T2.Focus();
                    T2.CaretIndex = T2.Text.Length;
                    T2.SelectAll();
                }
                else if (T1.Text.Length > 0 && T1.CaretIndex == T1.Text.Length && f2)
                {
                    T2.Focus(); T2.CaretIndex = T2.Text.Length;
                    T2.SelectAll();
                }
                f2 = true;
            }
        }
        private void Text2D(object sender, KeyEventArgs e)
        {
            L3 = 0;
            if (e.Key == Key.Right && T2.CaretIndex == T2.Text.Length)
            {
                D2++;
                if (D2 == 2)
                {
                    T3.Focus();
                    T3.CaretIndex = T3.Text.Length;
                    T3.SelectAll();
                    D2 = 0;
                }
            }
            if (T2.Text.Length == 3 && e.Key == Key.Decimal)
            {
                T3.Focus();
                T3.CaretIndex = T3.Text.Length;
                T3.SelectAll();
            }
            if (T2.CaretIndex == 0)
            {
                if ((e.Key == Key.Back || e.Key == Key.Left) && L2 == -1)
                {
                    T1.Focus();
                    T1.CaretIndex = T1.Text.Length;
                }
                else if (L2 == 0)
                {
                    L2--;
                }
            }
        }
        private void Text2(object sender, KeyEventArgs e)
        {
            if (T2.CaretIndex == 3 || e.Key == Key.Tab)
            {
                if (T2.CaretIndex == T2.Text.Length)
                {
                    T3.Focus();
                    T3.CaretIndex = T3.Text.Length;
                    T3.SelectAll();
                }
                else if (T2.Text.Length > 0 && T2.CaretIndex == T2.Text.Length && f3)
                {
                    T3.Focus(); T3.CaretIndex = T3.Text.Length;
                    T3.SelectAll();
                }
                f3 = true;
            }
        }
        private void Text3D(object sender, KeyEventArgs e)
        {
            L4 = 0;
            if (e.Key == Key.Right && T3.CaretIndex == T3.Text.Length)
            {
                D3++;
                if (D3 == 2)
                {
                    T4.Focus();
                    T4.CaretIndex = T3.Text.Length;
                    T4.SelectAll();
                    D3 = 0;
                }
            }
            if (T3.Text.Length == 3 && e.Key == Key.Decimal)
            {
                T4.Focus();
                T4.CaretIndex = T4.Text.Length;
                T4.SelectAll();
            }
            if (T3.CaretIndex == 0)
            {
                if ((e.Key == Key.Back || e.Key == Key.Left) && L3 == -1)
                {
                    T2.Focus();
                    T2.CaretIndex = T2.Text.Length;
                }
                else if (L3 == 0)
                {
                    L3--;
                }
            }
        }
        private void Text3(object sender, KeyEventArgs e)
        {
            if (T3.CaretIndex == 3 || e.Key == Key.Tab)
            {
                if (T3.CaretIndex == T3.Text.Length)
                {
                    T4.Focus();
                    T4.CaretIndex = T4.Text.Length;
                    T4.SelectAll();
                }

                else if (T3.Text.Length > 0 && T3.CaretIndex == T3.Text.Length && f4)
                {
                    T4.Focus(); T4.CaretIndex = T4.Text.Length;
                    T4.SelectAll();
                }
                f4 = true;
            }
        }
        private void Text4(object sender, KeyEventArgs e)
        {
            if (T4.CaretIndex == 0)
            {

                if ((e.Key == Key.Back || e.Key == Key.Left) && L4 == -1)
                {
                    T3.Focus();
                    T3.CaretIndex = T3.Text.Length;
                }
                else if (L4 == 0)
                {
                    L4--;
                }
            }
        }
        public string Value()
        {
            if (T1.Text != "" && T2.Text != "" && T3.Text != "" && T4.Text != "")
            {
                int t1 = int.Parse(T1.Text);
                int t2 = int.Parse(T2.Text);
                int t3 = int.Parse(T3.Text);
                int t4 = int.Parse(T4.Text);
                return t1.ToString() + "." + t2.ToString() + "." + t3.ToString() + "." + t4.ToString();
            }
            return string.Empty;
        }

        private void T4_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (T4.Text.EndsWith(".") && T4.Text.Length != 1)
                {
                    string s = T4.Text;
                    s = s.Substring(0, T4.Text.Length - 1);
                    T4.Text = s;
                    T4.Focus();
                    T4.CaretIndex = T4.Text.Length;
                }
                else if (!(int.Parse(T4.Text) <= 255))
                {
                    T4.Text = String.Empty;
                }

            }
            catch
            {
                T4.Text = string.Empty;
            }
            if (T4.Text.Length == 0)
            {
                T3.Focus();
                T3.CaretIndex = T3.Text.Length;
                f4 = false;
            }

        }
        private void T1_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (T1.Text.EndsWith(".") && T1.Text.Length != 1)
                {
                    string s = T1.Text;
                    s = s.Substring(0, T1.Text.Length - 1);
                    T1.Text = s;
                    T2.Focus();
                    T2.CaretIndex = T2.Text.Length;
                    T2.SelectAll();
                }
                else if (!(int.Parse(T1.Text) <= 255))
                {
                    T1.Text = String.Empty;
                    T1.Focus();
                }
                else if (T1.Text.EndsWith(" "))
                {
                    string s = T1.Text;
                    s = s.Substring(0, T1.Text.Length - 1);
                    T1.Text = s;
                    T1.Focus();
                    T1.CaretIndex = T1.Text.Length;
                }
            }
            catch
            {
                T1.Text = string.Empty;
            }
        }
        private void T3_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (T3.Text.EndsWith(".") && T3.Text.Length != 1)
                {
                    string s = T3.Text;
                    s = s.Substring(0, T3.Text.Length - 1);
                    T3.Text = s;
                    T4.Focus();
                    T4.CaretIndex = T4.Text.Length;
                    T4.SelectAll();
                }
                else if (!(int.Parse(T3.Text) <= 255))
                {
                    T3.Text = String.Empty;
                }

            }
            catch
            {
                T3.Text = string.Empty;
            }

            if (T3.Text.Length == 0)
            {
                T2.Focus(); T2.CaretIndex = T2.Text.Length;
                f3 = false;
            }
        }
        private void T2_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (T2.Text.EndsWith(".") && T2.Text.Length != 1)
                {
                    string s = T2.Text;
                    s = s.Substring(0, T2.Text.Length - 1);
                    T2.Text = s;
                    T3.Focus();
                    T3.CaretIndex = T3.Text.Length;
                    T3.SelectAll();
                }
                else if (!(int.Parse(T2.Text) <= 255))
                {
                    T2.Text = String.Empty;
                }

            }
            catch
            {
                T2.Text = string.Empty;
            }

            if (T2.Text.Length == 0)
            {
                T1.Focus();
                T1.CaretIndex = T1.Text.Length;
                f2 = false;
            }
        }
        public void clear()
        {
            T1.Text = string.Empty;
            T2.Text = string.Empty;
            T3.Text = string.Empty;
            T4.Text = string.Empty;
        }
        public void fill(string ip)
        {
            clear();
            string s = "";
            if (ip != null)
            {
                for (int i = 0; i <= ip.Length; i++)
                {
                    if (T1.Text == "")
                    {
                        if (ip[i] != '.')
                            s += ip[i];
                        else
                        {
                            T1.Text = s;
                            s = "";
                        }
                    }
                    else if (T2.Text == "")
                    {
                        if (ip[i] != '.')
                            s += ip[i];
                        else
                        {
                            T2.Text = s;
                            s = "";
                        }
                    }
                    else if (T3.Text == "")
                    {
                        if (ip[i] != '.')
                            s += ip[i];
                        else
                        {
                            T3.Text = s;
                            s = "";
                        }
                    }
                    else if (T4.Text == "")
                    {
                        if (i <= ip.Length - 1)
                            s += ip[i];
                        else
                        {
                            T4.Text = s;
                            s = "";
                        }
                    }
                }
            }
            if (T1.Text == "" || T2.Text == "" || T3.Text == "" || T4.Text == "")
            {
                T1.Text = "";
                T2.Text = "";
                T3.Text = "";
                T4.Text = "";
            }
            T1.Focus();
        }
        private void Localhostbtnclick(object sender, RoutedEventArgs e)
        {
            this.fill("127.0.0.1");
        }
        public void Hide_LocalHost_btn()
        {
            btn_localhost.Visibility = Visibility.Collapsed;
        }
    }
}

