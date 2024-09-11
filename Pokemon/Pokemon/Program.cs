using System;

interface IPokemon
{
    int Atacar();
    double Defender();
}

abstract class PokemonBase : IPokemon
{
    private string nombre;
    private string tipo;
    private int[] ataques = new int[3];
    private int defensa;

    public PokemonBase(string nombre, string tipo, int[] ataques, int defensa)
    {
        this.nombre = nombre;
        this.tipo = tipo;
        this.ataques = ataques;
        this.defensa = defensa;
    }

    public abstract int Atacar();
    public abstract double Defender();

    public string GetNombre() => nombre;
    public string GetTipo() => tipo; // Añadido para obtener el tipo
    public int[] GetAtaques() => ataques;
    public int GetDefensa() => defensa;
}

class Pokemon : PokemonBase
{
    private static Random rand = new Random();

    public Pokemon(string nombre, string tipo, int[] ataques, int defensa) 
        : base(nombre, tipo, ataques, defensa) { }

    public override int Atacar()
    {
        int ataqueSeleccionado = rand.Next(0, 3);
        int multiplicador = rand.Next(0, 2);
        int resultado = GetAtaques()[ataqueSeleccionado] * multiplicador;

        // Agregamos depuración para verificar valores
        return resultado;
    }

    public override double Defender()
    {
        double multiplicador = rand.Next(0, 2) == 0 ? 0.5 : 1;
        double resultado = GetDefensa() * multiplicador;

        // Agregamos depuración para verificar valores
        return resultado;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Ingrese los datos del Pokémon 1:");
        Console.Write("Nombre: ");
        string nombre1 = Console.ReadLine() ?? "Desconocido";
        Console.Write("Tipo: ");
        string tipo1 = Console.ReadLine() ?? "Desconocido";
        Console.Write("Ataque 1 (0-40): ");
        int ataque1_1 = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Ataque 2 (0-40): ");
        int ataque1_2 = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Ataque 3 (0-40): ");
        int ataque1_3 = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Defensa (10-35): ");
        int defensa1 = int.Parse(Console.ReadLine() ?? "10");

        Pokemon pokemon1 = new Pokemon(nombre1, tipo1, new[] { ataque1_1, ataque1_2, ataque1_3 }, defensa1);

        Console.WriteLine("Ingrese los datos del Pokémon 2:");
        Console.Write("Nombre: ");
        string nombre2 = Console.ReadLine() ?? "Desconocido";
        Console.Write("Tipo: ");
        string tipo2 = Console.ReadLine() ?? "Desconocido";
        Console.Write("Ataque 1 (0-40): ");
        int ataque2_1 = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Ataque 2 (0-40): ");
        int ataque2_2 = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Ataque 3 (0-40): ");
        int ataque2_3 = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Defensa (10-35): ");
        int defensa2 = int.Parse(Console.ReadLine() ?? "10");

        Pokemon pokemon2 = new Pokemon(nombre2, tipo2, new[] { ataque2_1, ataque2_2, ataque2_3 }, defensa2);

        int puntosP1 = 0, puntosP2 = 0;
        Console.WriteLine("\nIniciando combate...");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"\n--- Turno {i + 1} ---");

            int ataqueP1 = pokemon1.Atacar();
            double defensaP2 = pokemon2.Defender();
            int dañoP1 = (int)Math.Max(ataqueP1 - defensaP2, 0); 
            puntosP1 += dañoP1;
            Console.WriteLine($"{pokemon1.GetNombre()} ataca con {ataqueP1}, {pokemon2.GetNombre()} defiende con {defensaP2}, daño infligido: {dañoP1}");

            int ataqueP2 = pokemon2.Atacar();
            double defensaP1 = pokemon1.Defender();
            int dañoP2 = (int)Math.Max(ataqueP2 - defensaP1, 0); 
            puntosP2 += dañoP2;
            Console.WriteLine($"{pokemon2.GetNombre()} ataca con {ataqueP2}, {pokemon1.GetNombre()} defiende con {defensaP1}, daño infligido: {dañoP2}");
        }

        Console.WriteLine("\n--- Resultado del combate ---");
        Console.WriteLine($"{pokemon1.GetNombre()} ({pokemon1.GetTipo()}) - Puntos totales: {puntosP1}");
        Console.WriteLine($"{pokemon2.GetNombre()} ({pokemon2.GetTipo()}) - Puntos totales: {puntosP2}");

        if (puntosP1 > puntosP2)
            Console.WriteLine($"{pokemon1.GetNombre()} ({pokemon1.GetTipo()}) ganó el combate.");
        else if (puntosP1 < puntosP2)
            Console.WriteLine($"{pokemon2.GetNombre()} ({pokemon2.GetTipo()}) ganó el combate.");
        else
            Console.WriteLine("El combate terminó en empate.");
    }
}
