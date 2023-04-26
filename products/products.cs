using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products
{
    public class Products
    {
        public string Name { get; }
        public int count { get; }
        public int price { get;}
		public Products(string name, int count, int price)
		{
		
		}
	}
}
