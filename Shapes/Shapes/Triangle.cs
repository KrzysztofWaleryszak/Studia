using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
	class Triangle:Shape
	{
		double a, b, c;

		public Triangle(double a,double b, double c)
		{
			double[] buf = new double[3];
			buf[0]= a;
			buf[1]= b;
			buf[2]= c;
			Array.Sort(buf);
			if(buf[2]>buf[1]+buf[0])
			{
				throw new ArgumentException("Invalid side's");
			}
			type = "Triangle";
			this.a = buf[0];
			this.b = buf[1];
			this.c = buf[2];
		}
		public override double Area()
		{
			return Math.Sqrt(Perimeter()*(Perimeter()-a)*(Perimeter()-b)*(Perimeter()-c))  ;
		}
		public override double Perimeter()
		{
			return a+b+c;
		}
		public override string ToString()
		{
			return $"{type} {a} {b} {c}";
		}

	}
}
