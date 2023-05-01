using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace products
{
    public class Products
    {
        public string Name { get; }
        public int Count { get; }
        public int Price { get;}
		public Products() { }
		public Products(string name, int count, int price)
		{
			Name= name;
			Count= count;
			Price= price;
		}
	}
}
