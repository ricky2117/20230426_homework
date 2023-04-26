using products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Xml.Linq;

namespace good_shop
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//List<Products> products = new List<Products>();12
			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				string name = dataGridView1.CurrentRow.Cells["product_name"].Value.ToString();
				int count = int.Parse(dataGridView1.CurrentRow.Cells["product_count"].Value.ToString());
				int price = int.Parse(dataGridView1.CurrentRow.Cells["product_price"].Value.ToString());
				var obj = new Products_statistics<Products>(new Products(name,count,price));
				//products.Add(new Products(name, count, price));
			}
			//Products_statistics<Products> obj = new Products_statistics<Products>(products);
			//123151515
		}

		private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}
	}
}
