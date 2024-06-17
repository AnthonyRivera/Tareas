// See https://aka.ms/new-console-template for more information
using Lecture7_TareaArea;

Console.WriteLine("Hello, World!");
Circle circulo = new Circle();
Rectangle rectangulo = new Rectangle(6,9);
circulo.radius = 1;
Console.WriteLine($"The area of a circle wth radius {circulo.radius} is {circulo.GetArea()}");
Console.WriteLine($"The area of a rectangle wth length {rectangulo.Length} and width {rectangulo.Width} is {rectangulo.GetArea()}");
Console.WriteLine($"The area of a rectangle wth length {rectangulo.Length} and width {rectangulo.Width} in cm is {rectangulo.GetArea("cm")}");
Console.WriteLine($"The area of a rectangle wth length {rectangulo.Length} and width {rectangulo.Width} in m is {rectangulo.GetArea("m")}");