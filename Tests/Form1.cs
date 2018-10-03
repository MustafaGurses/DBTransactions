using System.Windows.Forms;
using Interface;
using DataBase;
using System.Data.SqlClient;
using System.Data;

namespace Tests
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Transactions ts = new Transactions();
            Connect con = new Connect(@"Data Source=.\SQLEXPRESS;Initial Catalog=cafeOtomasyon;Integrated Security=True;MultipleActiveResultSets=True");// Enter your connection string
            using (Command cd = new Command())
            {
                using (Connect.Connection)
                {
                    Connect.Connection.Open();
                    SqlCommand Com = cd.SqlCommand("select urunAdi from urunler where id = 2");
                    var data = ts.GetData(Com, Connect.Connection, Interface.Enums.ReturnType.String);
                   //MessageBox.Show(data.ToString());
                    SqlCommand Comm = cd.SqlCommand("select * from urunler ");
                    var data2 = ts.GetFirstData(Comm, Connect.Connection);
                    //MessageBox.Show(data2.ToString());
                    foreach (IDataRecord item in ts.GetAll(Comm, Connect.Connection))
                    {
                        //MessageBox.Show(item.GetValue(0).ToString());
                    }
                    foreach(IDataRecord item in ts.GetAll(Comm, Connect.Connection))
                    {
                        var values = item.GetValue(3);// insert column index -> GetValue(index)
                        MessageBox.Show(values.ToString());
                    }
                    SqlCommand Com3 = cd.SqlCommand("select urunAdet from urunler where id = 2");
                    var data3 = ts.GetData(Com3, Connect.Connection, Interface.Enums.ReturnType.Integer);
                    //MessageBox.Show(data3.ToString());
                }
            }
        }
        private void button2_Click(object sender, System.EventArgs e)
        {
            Connect.Connection.Open();
            dataGridView1.DataSource = ts.GetTable("select * from urunler", Connect.Connection);// Get Table from MS SQL
        }
    }
}
