using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
	class Rectangle : Shape
	{
		double a, b;
		public Rectangle(double a, double b)
		{
			if (a == b)
			{
				type = "Square";
			}
			else
			{
				type = "Rectangle";
			}
			this.a = a;
			this.b = b;
		}
		public Rectangle(double a) : this(a, a)
		{

		}
		public override double Area()
		{
			return a * b;
		}
		public override double Perimeter()
		{
			return (2 * a) + (2 * b);
		}
		public override string ToString()
		{
			if (a != b)
			{ return $"{type} {a} {b}"; }
			else
			{ return $"{type} {a}"; }
		}
	}
}
