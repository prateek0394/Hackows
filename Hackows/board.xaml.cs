using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using System.Threading;
namespace Hackows
{
    public partial class board : PhoneApplicationPage
    {
        bool ft = true;
        string last;
        bool[] asde = new bool[4]{false,false,false,false};
        static int counter = 1;
        string[,] val = new string[4, 2];
        string asd;
        string[] str;
        int warrior, theif;
        int k;

        //        bool[] b = new bool[4] { false,false,false,false };
        public board()
        {
            InitializeComponent();
            doit1();

        }
        public void doit1()
        {
            if (Convert.ToInt32(s1.Text) >= 1000 || Convert.ToInt32(s2.Text) >= 1000 || Convert.ToInt32(s3.Text) >= 1000 || Convert.ToInt32(s4.Text) >= 1000) {
                string df = Convert.ToString(Math.Max(Convert.ToInt32(s1.Text), Math.Max(Convert.ToInt32(s2.Text), Math.Max(Convert.ToInt32(s3.Text), Convert.ToInt32(s4.Text)))));
                if (s1.Text.CompareTo(df) == 0) {
                    df = str[0];
                }
                else if (s2.Text.CompareTo(df) == 0)
                {
                    df = str[1];
                }
                else if (s3.Text.CompareTo(df) == 0)
                {
                    df = str[2];
                }
                else if (s4.Text.CompareTo(df) == 0)
                {
                    df = str[3];
                }
                NavigationService.Navigate(new Uri("/Page2.xaml?para="+df, UriKind.Relative));
            }
            else
            {
                counter = 1;
            ContentPanel.Visibility = Visibility.Visible;
            rect1.Visibility = Visibility.Visible;
            rect2.Visibility = Visibility.Visible;
            rect3.Visibility = Visibility.Visible;
            rect4.Visibility = Visibility.Visible;
            rect5.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            rect6.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            rect7.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            rect8.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

            //ContentPanel1.Visibility = Visibility.Collapsed;
            var r = new Random();
            int j = 0;
            //asd = NavigationContext.QueryString["para"];
            //char[] del = {';'};
            //str = asd.Split(del);
            int[] arr = new int[4] { 1, 2, 3, 4 };
            for (k = 0; k < 4; k++)
            {
                string f = "";
                if (k == 0) { f = "King"; }
                if (k == 1) { f = "Warrior"; }
                if (k == 2) { f = "Minister"; }
                if (k == 3) { f = "Thief"; }
                do
                {
                    j = r.Next(0, 4);
                } while (arr[j] == 0);
                val[j, 1] = f;
                arr[j] = 0;
                if (j == 0)
                {
                    t1.Text = f;
                }
                if (j == 1)
                {
                    t2.Text = f;
                }
                if (j == 2) t3.Text = f;
                if (j == 3) t4.Text = f;
                if (k == 1)
                {
                    warrior = j;

                }
                if (k == 3)
                {
                    theif = j;

                }

            }
            asde[0] = true;
            asde[1] = true;
            asde[2] = true;
            asde[3] = true;
                
            t1.Visibility = Visibility.Collapsed;
            t2.Visibility = Visibility.Collapsed;
            t3.Visibility = Visibility.Collapsed;
            t4.Visibility = Visibility.Collapsed;
            aman.Visibility = Visibility.Visible;
            if (warrior == 0)
            {
                t1.Visibility = Visibility.Visible;
            }
            if (warrior == 1)
            {
                t2.Visibility = Visibility.Visible;
            }
            if (warrior == 2)
            {
                t3.Visibility = Visibility.Visible;
            }
            if (warrior == 3)
            {
                t4.Visibility = Visibility.Visible;
            }
                if (!ft)
            {
                last = getaman();
                aman.Text = last + " choose";
            }
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            NavigationContext.QueryString.TryGetValue("para", out asd);
            str = asd.Split(';');
            p1.Text = str[0];
            p2.Text = str[1];
            p3.Text = str[2];
            p4.Text = str[3];
            val[0, 0] = str[0];
            val[1, 0] = str[1];
            val[2, 0] = str[2];
            val[3, 0] = str[3];
            last = getaman();
            aman.Text = last+" choose";
            ft = false;
        }
        public void done1(object sender, EventArgs e)
        {
            rect1.Visibility = Visibility.Collapsed;
            val[0, 0] = last;
            if (counter < 4)
            last = getaman();
            aman.Text = last + " choose";
            counter++;
            if (counter == 5)
            {
                aman.Visibility = Visibility.Collapsed;
                ContentPanel1.Visibility = Visibility.Visible;
                ContentPanel.Visibility = Visibility.Collapsed;
                if (val[0, 1].CompareTo("Warrior") == 0)
                {
                    rect5.Fill = new SolidColorBrush(Color.FromArgb(255, 102, 153, 255));

                }
                else if (val[1, 1].CompareTo("Warrior") == 0)
                {
                    rect6.Fill = new SolidColorBrush(Color.FromArgb(255, 102, 153, 255));
                }
                else if (val[2, 1].CompareTo("Warrior") == 0)
                {
                    rect7.Fill = new SolidColorBrush(Color.FromArgb(255, 102, 153, 255));
                }
                else if (val[3, 1].CompareTo("Warrior") == 0)
                {
                    rect8.Fill = new SolidColorBrush(Color.FromArgb(255, 102, 153, 255));
                }

            }
        }
        
        
        public void done2(object sender, EventArgs e)
        {
            
            rect2.Visibility = Visibility.Collapsed;
            
            val[1, 0] = last;
            if (counter < 4)
            last = getaman();
            aman.Text = last + " choose";
            counter++;
            if (counter == 5)
            {
                aman.Visibility = Visibility.Collapsed;
                ContentPanel1.Visibility = Visibility.Visible;
                ContentPanel.Visibility = Visibility.Collapsed;
                if (val[0, 1].CompareTo("Warrior") == 0)
                {
                    rect5.Fill = new SolidColorBrush(Color.FromArgb(255, 102, 153, 255));

                }
                else if (val[1, 1].CompareTo("Warrior") == 0)
                {
                    rect6.Fill = new SolidColorBrush(Color.FromArgb(255, 102, 153, 255));
                }
                else if (val[2, 1].CompareTo("Warrior") == 0)
                {
                    rect7.Fill = new SolidColorBrush(Color.FromArgb(255, 102, 153, 255));
                }
                else if (val[3, 1].CompareTo("Warrior") == 0)
                {
                    rect8.Fill = new SolidColorBrush(Color.FromArgb(255, 102, 153, 255));
                }

            }
        }
        public void done3(object sender, EventArgs e)
        {
            
            rect3.Visibility = Visibility.Collapsed;
            val[2, 0] = last ;
            if(counter<4)
            last = getaman();
            aman.Text = last + " choose"; 
            counter++;
            if (counter == 5)
            {
                aman.Visibility = Visibility.Collapsed;
                ContentPanel1.Visibility = Visibility.Visible;
                ContentPanel.Visibility = Visibility.Collapsed;
                if (val[0, 1].CompareTo("Warrior") == 0)
                {
                    rect5.Fill = new SolidColorBrush(Color.FromArgb(255, 102, 153, 255));

                }
                else if (val[1, 1].CompareTo("Warrior") == 0)
                {
                    rect6.Fill = new SolidColorBrush(Color.FromArgb(255, 102, 153, 255));
                }
                else if (val[2, 1].CompareTo("Warrior") == 0)
                {
                    rect7.Fill = new SolidColorBrush(Color.FromArgb(255, 102, 153, 255));
                }
                else if (val[3, 1].CompareTo("Warrior") == 0)
                {
                    rect8.Fill = new SolidColorBrush(Color.FromArgb(255, 102, 153, 255));
                }

            }
        }
        public void done4(object sender, EventArgs e)
        {
            
            rect4.Visibility = Visibility.Collapsed;
            val[3, 0] = last;
            if(counter<4)
            last = getaman();
            aman.Text = last + " choose"; 
            counter++;
            if (counter == 5)
            {
                aman.Visibility = Visibility.Collapsed;
                ContentPanel1.Visibility = Visibility.Visible;
                ContentPanel.Visibility = Visibility.Collapsed;
                if (val[0, 1].CompareTo("Warrior") == 0)
                {
                    rect5.Fill = new SolidColorBrush(Color.FromArgb(255, 102, 153, 255));

                }
                else if (val[1, 1].CompareTo("Warrior") == 0)
                {
                    rect6.Fill = new SolidColorBrush(Color.FromArgb(255, 102, 153, 255));
                }
                else if (val[2, 1].CompareTo("Warrior") == 0)
                {
                    rect7.Fill = new SolidColorBrush(Color.FromArgb(255, 102, 153, 255));
                }
                else if (val[3, 1].CompareTo("Warrior") == 0)
                {
                    rect8.Fill = new SolidColorBrush(Color.FromArgb(255, 102, 153, 255));
                }

            }
        }
        public void done5(object sender, EventArgs e)
        {
            if (val[0, 1].CompareTo("Thief") == 0)
            {
                rect5.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 102, 0));
                string ch = val[warrior, 0];
                if (ch.CompareTo(str[0]) == 0)
                {
                    s1.Text = Convert.ToString(Convert.ToInt32(s1.Text) + 50);
                }
                if (ch.CompareTo(str[1]) == 0)
                {
                    s2.Text = Convert.ToString(Convert.ToInt32(s1.Text) + 50);
                }
                if (ch.CompareTo(str[2]) == 0)
                {
                    s3.Text = Convert.ToString(Convert.ToInt32(s1.Text) + 50);
                }
                if (ch.CompareTo(str[3]) == 0)
                {
                    s4.Text = Convert.ToString(Convert.ToInt32(s1.Text) + 50);
                }
            }
            else
            {
                rect5.Fill = new SolidColorBrush(Color.FromArgb(255, 128, 0, 0));
                string ch = val[theif, 0];
                if (ch.CompareTo(str[0]) == 0)
                {
                    s1.Text = Convert.ToString(Convert.ToInt32(s1.Text) + 50);
                }
                if (ch.CompareTo(str[1]) == 0)
                {
                    s2.Text = Convert.ToString(Convert.ToInt32(s1.Text) + 50);
                }
                if (ch.CompareTo(str[2]) == 0)
                {
                    s3.Text = Convert.ToString(Convert.ToInt32(s1.Text) + 50);
                }
                if (ch.CompareTo(str[3]) == 0)
                {
                    s4.Text = Convert.ToString(Convert.ToInt32(s1.Text) + 50);
                }
            }
            setscore();
            qwe();

        }
        public async void qwe()
        {
            t1.Visibility = Visibility.Visible;
            t2.Visibility = Visibility.Visible;
            t3.Visibility = Visibility.Visible;
            t4.Visibility = Visibility.Visible;

            await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(3));
            doit1();
        }
        public void done6(object sender, EventArgs e)
        {
            if (val[1, 1].CompareTo("Thief") == 0)
            {
                rect6.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 102, 0));
                string ch = val[warrior, 0];
                if (ch.CompareTo(str[0]) == 0)
                {
                    s1.Text = Convert.ToString(Convert.ToInt32(s1.Text) + 50);
                }
                if (ch.CompareTo(str[1]) == 0)
                {
                    s2.Text = Convert.ToString(Convert.ToInt32(s1.Text) + 50);
                }
                if (ch.CompareTo(str[2]) == 0)
                {
                    s3.Text = Convert.ToString(Convert.ToInt32(s1.Text) + 50);
                }
                if (ch.CompareTo(str[3]) == 0)
                {
                    s4.Text = Convert.ToString(Convert.ToInt32(s1.Text) + 50);
                }

            }
            else
            {
                rect6.Fill = new SolidColorBrush(Color.FromArgb(255, 128, 0, 0));
                string ch = val[theif, 0];
                if (ch.CompareTo(str[0]) == 0)
                {
                    s1.Text = Convert.ToString(Convert.ToInt32(s1.Text) + 50);
                }
                if (ch.CompareTo(str[1]) == 0)
                {
                    s2.Text = Convert.ToString(Convert.ToInt32(s1.Text) + 50);
                }
                if (ch.CompareTo(str[2]) == 0)
                {
                    s3.Text = Convert.ToString(Convert.ToInt32(s1.Text) + 50);
                }
                if (ch.CompareTo(str[3]) == 0)
                {
                    s4.Text = Convert.ToString(Convert.ToInt32(s1.Text) + 50);
                }
            }
            setscore();
            qwe();

        }
        public void done7(object sender, EventArgs e)
        {
            if (val[2, 1].CompareTo("Thief") == 0)
            {
                rect7.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 102, 0));
                string ch = val[warrior, 0];
                if (ch.CompareTo(str[0]) == 0)
                {
                    s1.Text = Convert.ToString(Convert.ToInt32(s1.Text) + 50);
                }
                if (ch.CompareTo(str[1]) == 0)
                {
                    s2.Text = Convert.ToString(Convert.ToInt32(s1.Text) + 50);
                }
                if (ch.CompareTo(str[2]) == 0)
                {
                    s3.Text = Convert.ToString(Convert.ToInt32(s1.Text) + 50);
                }
                if (ch.CompareTo(str[3]) == 0)
                {
                    s4.Text = Convert.ToString(Convert.ToInt32(s1.Text) + 50);
                }

            }
            else
            {
                rect7.Fill = new SolidColorBrush(Color.FromArgb(255, 128, 0, 0));
                string ch = val[theif, 0];
                if (ch.CompareTo(str[0]) == 0)
                {
                    s1.Text = Convert.ToString(Convert.ToInt32(s1.Text) + 50);
                }
                if (ch.CompareTo(str[1]) == 0)
                {
                    s2.Text = Convert.ToString(Convert.ToInt32(s1.Text) + 50);
                }
                if (ch.CompareTo(str[2]) == 0)
                {
                    s3.Text = Convert.ToString(Convert.ToInt32(s1.Text) + 50);
                }
                if (ch.CompareTo(str[3]) == 0)
                {
                    s4.Text = Convert.ToString(Convert.ToInt32(s1.Text) + 50);
                }
            }
            setscore();
            qwe();

        }
        public void done8(object sender, EventArgs e)
        {
            if (val[3, 1].CompareTo("Thief") == 0)
            {
                rect8.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 102, 0));
                string ch = val[warrior, 0];
                if (ch.CompareTo(str[0]) == 0)
                {
                    s1.Text = Convert.ToString(Convert.ToInt32(s1.Text) + 50);
                }
                if (ch.CompareTo(str[1]) == 0)
                {
                    s2.Text = Convert.ToString(Convert.ToInt32(s1.Text) + 50);
                }
                if (ch.CompareTo(str[2]) == 0)
                {
                    s3.Text = Convert.ToString(Convert.ToInt32(s1.Text) + 50);
                }
                if (ch.CompareTo(str[3]) == 0)
                {
                    s4.Text = Convert.ToString(Convert.ToInt32(s1.Text) + 50);
                }

            }
            else
            {
                rect8.Fill = new SolidColorBrush(Color.FromArgb(255, 128, 0, 0));
                string ch = val[theif, 0];
                if (ch.CompareTo(str[0]) == 0)
                {
                    s1.Text = Convert.ToString(Convert.ToInt32(s1.Text) + 50);
                }
                if (ch.CompareTo(str[1]) == 0)
                {
                    s2.Text = Convert.ToString(Convert.ToInt32(s1.Text) + 50);
                }
                if (ch.CompareTo(str[2]) == 0)
                {
                    s3.Text = Convert.ToString(Convert.ToInt32(s1.Text) + 50);
                }
                if (ch.CompareTo(str[3]) == 0)
                {
                    s4.Text = Convert.ToString(Convert.ToInt32(s1.Text) + 50);
                }
            }
            setscore();
            qwe();

        }
        public string getaman() {

            var sw = new Random();
            int h;
            do {
                h = sw.Next(0, 4);
            } while (!asde[h]);
            asde[h] = false;
        return str[h];
        }
        public void setscore()
        {
            int k;
            for (k = 0; k < 4; k++)
            {
                if (val[k, 1].CompareTo("King") == 0)
                {

                    if (val[k, 0].CompareTo(str[0]) == 0)
                    {

                        s1.Text = Convert.ToString((Convert.ToInt32(s1.Text) + 100));

                    }

                    if (val[k, 0].CompareTo(str[1]) == 0)
                    {
                        s2.Text = Convert.ToString((Convert.ToInt32(s2.Text) + 100));

                    }
                    if (val[k, 0].CompareTo(str[2]) == 0)
                    {
                        s3.Text = Convert.ToString((Convert.ToInt32(s3.Text) + 100));

                    }
                    if (val[k, 0].CompareTo(str[3]) == 0)
                    {
                        s4.Text = Convert.ToString((Convert.ToInt32(s4.Text) + 100));

                    }

                }
                else
                    if (val[k, 1].CompareTo("Minister") == 0)
                    {

                        if (val[k, 0].CompareTo(str[0]) == 0)
                        {

                            s1.Text = Convert.ToString((Convert.ToInt32(s1.Text) + 75));

                        }

                        if (val[k, 0].CompareTo(str[1]) == 0)
                        {
                            s2.Text = Convert.ToString((Convert.ToInt32(s2.Text) + 75));

                        }
                        if (val[k, 0].CompareTo(str[2]) == 0)
                        {
                            s3.Text = Convert.ToString((Convert.ToInt32(s3.Text) + 75));

                        }
                        if (val[k, 0].CompareTo(str[3]) == 0)
                        {
                            s4.Text = Convert.ToString((Convert.ToInt32(s4.Text) + 75));

                        }

                    }

            }
        }

    }
}
