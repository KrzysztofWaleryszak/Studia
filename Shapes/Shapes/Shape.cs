using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
	abstract class Shape : IShape
	{
		protected string type;

		public virtual double Area()
		{
			throw new NotImplementedException();
		}

		public virtual double Perimeter()
		{
			throw new NotImplementedException();
		}
		public string GetShapeType() { return type; }
	}
}
