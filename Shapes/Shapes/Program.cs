using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
	enum State { exit, generate, sordD, sortP, filter, display, menu }
	enum ShapeType { none, circle, square, rectangle, triangle }
	class Program
	{
		static List<Shape> shapes = new List<Shape>();
		static void Main(string[] args)
		{
			shapes.Add(new Triangle(1, 2, 3));
			shapes.Add(new Circle(5));
			shapes.Add(new Rectangle(6));
			shapes.Add(new Rectangle(2, 7));
			shapes.Add(new Triangle(4, 2, 3));
			shapes.Add(new Circle(2));
			shapes.Add(new Rectangle(3));
			shapes.Add(new Rectangle(5, 2));

			State state = State.menu;
			while (state != State.exit)
			{
				Console.Clear();
				switch (state)
				{
					case State.generate:
						GenerateShapes();
						state = State.menu;
						break;
					case State.sordD:
						shapes.Sort(new Sorting(Method.area));
						state = State.menu;
						break;
					case State.sortP:
						shapes.Sort(new Sorting(Method.perimeter));
						state = State.menu;
						break;
					case State.filter:
						FilterShape();
						state = State.menu;
						break;
					case State.display:
						DisplayShapes();
						state = State.menu;
						break;
					case State.menu:
						DisplayMenu();
						state = SelectMode();
						break;
				}
				Console.ReadLine();
			}


		}

		private static void FilterShape()
		{
			ShapeType type = SelectShapeType();
			foreach (var item in shapes)
			{
				if (item.GetShapeType().ToLower() == type.ToString())
				{
					item.ToString();
				}
			}
		}

		private static void DisplayShapes()
		{
			
			foreach (var item in shapes)
			{
				
					Console.WriteLine(item.ToString());
				
			}
			Console.ReadLine();
		}

		private static void GenerateShapes()
		{
			bool buf = true;
			do
			{
				ShapeType type = SelectShapeType();
				if (type == ShapeType.none)
				{
					break;
				}
				switch (type)
				{
					case ShapeType.none:
						buf = false;
						break;
					case ShapeType.circle:
						GenerateCircle();
						break;
					case ShapeType.square:
						GenerateSquare();
						break;
					case ShapeType.rectangle:
						GenerateRectangle();
						break;
					case ShapeType.triangle:
						GenerateTriangle();
						break;
					default:
						break;
				}

			} while (buf);
		}

		private static ShapeType SelectShapeType()
		{
			ShapeType type = ShapeType.none;
			try
			{
				Console.Clear();
				type = (ShapeType)GetInt(0, 4,
							  "Select type\n" +
							  "[1] Circle\n" +
							  "[2] Square\n" +
							  "[3] Rectangle\n" +
							  "[4] Triangle\n" +
							  "[0] Back to menu");
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				Console.ReadLine();
			}

			return type;
		}

		private static State SelectMode()
		{
			State ret = State.menu;
			try
			{
				ret = (State)GetInt(0, 5);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}


			return ret;

		}

		#region helpers
		private static void GenerateTriangle()
		{
			try
			{
				shapes.Add(new Triangle(GetDouble("Input a side"), GetDouble("Input b side"), GetDouble("Input c side")));
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				Console.WriteLine("Triangle not create");
				Console.ReadLine();
			}
		}

		private static void GenerateRectangle()
		{
			try
			{
				shapes.Add(new Rectangle(GetDouble("Input a side"), GetDouble("Input b side")));
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				Console.WriteLine("Rectangle not create");
				Console.ReadLine();
			}
		}

		private static void GenerateSquare()
		{
			try
			{
				shapes.Add(new Rectangle(GetDouble("Input square side")));
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				Console.WriteLine("Square not create");
				Console.ReadLine();
			}
		}

		private static void GenerateCircle()
		{
			try
			{
				shapes.Add(new Circle(GetDouble("Input circle radius")));
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				Console.WriteLine("Shape not create");
				Console.ReadLine();
			}
		}

		static double GetDouble(string msg)
		{
			double r = 0;
			if (!double.TryParse(Console.ReadLine(), out r)||(0>=r))
			{
				throw new ArgumentException("Couldn't parse input into double");
			}

			return r;
		}

		private static int GetInt(int min, int max)
		{
			int r = 0;
			if (!int.TryParse(Console.ReadLine(), out r))
			{
				throw new ArgumentException("Couldn't parse input into integer");
			}
			else
			{
				if (r < min || r > max)
				{
					throw new IndexOutOfRangeException("Selected option isn't on list");
				}
			}
			return r;
		}

		private static int GetInt(int min, int max, string msg)
		{
			Console.WriteLine(msg);
			int r = 0;
			if (!int.TryParse(Console.ReadLine(), out r))
			{
				throw new ArgumentException("Couldn't parse input into integer");
			}
			else
			{
				if (r < min || r > max)
				{
					throw new ArgumentException("Wrong value");
				}
			}
			return r;
		}

		private static void DisplayMenu()
		{
			Console.WriteLine("[1] Generate sample data");
			Console.WriteLine("[2] Default sort");
			Console.WriteLine("[3] Sort by Perimeter");
			Console.WriteLine("[4] Filter by Shape type");
			Console.WriteLine("[5] Display shapes");
			Console.WriteLine("[0] Exit");
		}
		#endregion
	}
}
