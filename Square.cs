using System;

public class Squares
{
	interface ICircle
	{
		double circleSquare(float r);
	}

	interface ITriangle
	{
		double triangleSquare(float a, float b, float c);
	}

	class Circle : ICircle
	{
		public double circleSquare(float r)
		{
			double S = Math.PI * r * r;
			return S;
		}
	}

	class Triangle : ITriangle
	{
		public double triangleSquare(float a, float b, float c)
		{
			float p = (a + b + c) / 2;
			double S = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
			return S;
		}
	}

	static void Main()
	{
		Console.WriteLine("Choose the figure what square you want to get:\n 1. Circle\n 2. Triangle\n Write a number:");
		string choice = Console.ReadLine();
		int number = Int32.Parse(choice);
		double S = getSquare(number);
		Console.WriteLine("Square = " + S);
	}

	private static double getSquare(int number)
	{
		double S = 0;
		if (number == 1)
		{
			Circle circle = new Circle();
			Console.WriteLine("Choose a radius of circle (>=0):");
			float r = float.Parse(Console.ReadLine());
			S = circle.circleSquare(r);
		}
		if (number == 2)
		{
			Triangle triangle = new Triangle();
			Console.WriteLine("Write sides of triangle through the enter (>=0):\n Side a: ");
			float a = float.Parse(Console.ReadLine());
			Console.WriteLine("Side b: ");
			float b = float.Parse(Console.ReadLine());
			Console.WriteLine("Side c: ");
			float c = float.Parse(Console.ReadLine());
			S = triangle.triangleSquare(a, b, c);
			if (checkTriangle(a, b, c))
			{
				Console.WriteLine("This is the rigth triangle!");
			}
			else
				Console.WriteLine("This is not the rigth triangle!");
		}
		return S;
	}

	static bool checkTriangle(float a, float b, float c)
	{
		if (a > b && a > c)
		{
			if (a * a == b * b + c * c)
				return true;
		}
		else if (b > a && b > c)
		{
			if (b * b == a * a + c * c)
				return true;
		}
		else
		{
			if (c * c == a * a + b * b)
				return true;
		}
		return false;
	}
}