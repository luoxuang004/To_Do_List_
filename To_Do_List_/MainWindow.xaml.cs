using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace To_Do_List_
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // 開啟檔案
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\user\Desktop\github.txt");

            // 分析
            foreach (string line in lines)
            {
                // 隔開
                string[] parts = line.Split(',');


                ToDoItem price = new ToDoItem();

                //讀取
                price.Date.Text = parts[0];
                price.Item.Text = parts[1];
                price.Price.Text = parts[2];

                //增加項目
                LedgerTask.Children.Add(price);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs Total)
        {

            int addPrice = 0;

            //按enter計算
            if (Total.Key == Key.Enter)
            {

                foreach (ToDoItem prices in LedgerTask.Children)
                {

                    addPrice += prices.PriceValue;
                }

                //顯示總支出
                total.Text = addPrice.ToString();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            // 增加串列裝文字
            List<string> datas = new List<string>();

            // 轉換項目
            foreach (ToDoItem price in LedgerTask.Children)
            {
                //設置字串
                string data = "";

                //資料區隔
                data += price.Date.Text + "," + price.Item.Text + "," + price.Price.Text;


                datas.Add(data);
            }

            System.IO.File.WriteAllLines(@"C:\Users\user\Desktop\github.txt", datas);
        }


        private void addTask_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // 產生
            ToDoItem price = new ToDoItem();

            //放入清單
            LedgerTask.Children.Add(price);
        }
    }
}