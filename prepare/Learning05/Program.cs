using System;
using System.Collections.Generic;

namespace Learning05
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();

            // Create instances of shapes
            Square square = new Square("Red", 5);
            Rectangle rectangle = new Rectangle("Blue", 4, 6);
            Circle circle = new Circle("Green", 3);

            // Add shapes to the list
            shapes.Add(square);
            shapes.Add(rectangle);
            shapes.Add(circle);

            // Iterate through the list and display the color and area of each shape
            foreach (Shape shape in shapes)
            {
                Console.WriteLine($"Color: {shape.GetColor()}");
                Console.WriteLine($"Area: {shape.GetArea()}");
                Console.WriteLine();
            }
        }
    }

    // Base Shape class
    abstract class Shape
    {
        protected string color;

        public Shape(string color)
        {
            this.color = color;
        }

        public string GetColor()
        {
            return color;
        }

        public abstract double GetArea();
    }

    // Square class
    class Square : Shape
    {
        private double side;

        public Square(string color, double side) : base(color)
        {
            this.side = side;
        }

        public override double GetArea()
        {
            return side * side;
        }
    }

    // Rectangle class
    class Rectangle : Shape
    {
        private double length;
        private double width;

        public Rectangle(string color, double length, double width) : base(color)
        {
            this.length = length;
            this.width = width;
        }

        public override double GetArea()
        {
            return length * width;
        }
    }

    // Circle class
    class Circle : Shape
    {
        private double radius;

        public Circle(string color, double radius) : base(color)
        {
            this.radius = radius;
        }

        public override double GetArea()
        {
            return Math.PI * radius * radius;
        }
    }
}
