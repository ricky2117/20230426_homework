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
		private List<Products> _products = new List<Products>();
		public Form1()
		{
			InitializeComponent();
		}
		private void button1_Click(object sender, EventArgs e)
		{
			int rowCount = dataGridView1.RowCount;
			List<Products> products = new List<Products>();
			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				if(row.Index == rowCount - 1) { break; }  //最後一筆離開(因輸入完都會多一空白行)
				foreach (DataGridViewCell cell in row.Cells) //判斷每欄每行是否有欄位有null或空白(不包含最後一行)
				{
					if (cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
					{
						MessageBox.Show("您輸入有空字串，請修正再執行", "run error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
						return;
					}
				}

				string name = dataGridView1.Rows[row.Index].Cells["product_name"].Value.ToString();
				int count,price;
				if(!int.TryParse(dataGridView1.Rows[row.Index].Cells["product_count"].Value.ToString(),out count))
				{
					MessageBox.Show("您輸入數量有非整數，請修正再執行", "run error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				else if(!int.TryParse(dataGridView1.Rows[row.Index].Cells["product_price"].Value.ToString(),out price))
				{
					MessageBox.Show("您輸入價錢有非整數，請修正再執行", "run error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				// 該產品名稱已存在且售價key不同，進行錯誤處理
				else if(products.Any(p => p.Name == name && p.Price != price))
				{
					MessageBox.Show("您輸入有重複產品價格不一情形，請修正再執行", "run error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
					return;
				}
				else
				{
					products.Add(new Products(name, count, price));
				}			
			}
			var obj = new Products_statistics(products);
			_products = obj.GetProductStatistics();
			ShowResult();
			
		}
		public void ShowResult()
		{
			dataGridView2.Rows.Clear();
			foreach (Products list in _products)
			{
				dataGridView2.Rows.Add(list.Name, list.Count, list.Price);
			}
		}

	}
}
