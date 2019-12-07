using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
	enum Method {perimeter, area };
	class Sorting : IComparer<Shape>
	{
		Method method;
		public Sorting(Method met)
		{
			method = met;
		}
		public int Compare(Shape x, Shape y)
		{
			switch (method)
			{
				case Method.perimeter:
					return x.Perimeter().CompareTo(y.Perimeter());

				case Method.area:
					return x.Area().CompareTo(y.Area());
				default:
					return 0;
			}
		}
	}
}
