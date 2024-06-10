// See https://aka.ms/new-console-template for more information
int[] ages = { 20, 28, 29, 69, 7 };
string[] names = { "Pepe", "Anthony", "Pablo", "Juana", "Leticia" };

for(int i = 0; i < ages.Length; i++)
{
    Console.WriteLine($"Nombre: {names[i]}, Edad: {ages[i]}");
}


for(int i = 0;i < ages.Length; i++)
{
    Saludo(ages[i], names[i]);
}

static void Saludo(int age, string name)
{
    Console.WriteLine($"Say Hello World! {name}. Is your birthday number {age}");
}

Console.ReadKey();