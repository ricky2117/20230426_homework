using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products
{
	public  class Products_statistics 
	{
		private List<Products> _products = new List<Products>();
		public Products_statistics() { }
		public Products_statistics(List<Products> products)
		{
			_products = products;
		}

		public  List<Products> GetProductStatistics()
		{
			Dictionary<string, int[]> products = new Dictionary<string, int[]>();
			foreach (Products product in _products)
			{
				if (products.ContainsKey(product.Name))
				{
					int[] values = products[product.Name];
					values[0] += product.Count;
					values[1] += product.Count * product.Price;
					products[product.Name] = values;
				}
				else
				{
					int[] values = { product.Count, product.Price * product.Count };
					products.Add(product.Name, values);
				}
			}
			List<Products> productList = products.OrderBy(e=>e.Key).Select(x => new Products(x.Key,x.Value[0],x.Value[1])).ToList();
			return productList;
		}

	}
}
