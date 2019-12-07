using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
	class Circle:Shape
	{
		double r;
		public Circle(double r)
		{
			this.r = r;
			type = "Circle";
		}
		public override double Area()
		{
			return Math.Pow(r,2)*Math.PI;
		}
		public override double Perimeter()
		{
			return 2*r*Math.PI;
		}

		public override string ToString()
		{
			return $"{type} {r}";
		}
	}
}
