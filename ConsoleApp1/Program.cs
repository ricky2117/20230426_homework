using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			test obj = new test();
			obj.Test = 3;

			Console.WriteLine(obj.Test);

			test obj1 = new test(2);
			//obj1.Test = 1;
            Console.WriteLine(obj1.Test);
        }
	}
	public class test
	{
        public int Test { get; set; }

		public test() { }
		public test(int test) => Test = test;




    }




}
