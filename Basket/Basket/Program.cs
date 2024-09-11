using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Partido partido = new Partido();
        
        partido.AgregarJugador(new Jugador("Juan", "Base", 10));
        partido.AgregarJugador(new Jugador("Pedro", "Ala", 7));
        partido.AgregarJugador(new Jugador("Luis", "Pivot", 6));
        partido.AgregarJugador(new Jugador("Carlos", "Base", 5));
        partido.AgregarJugador(new Jugador("Andrés", "Ala", 8));
        partido.AgregarJugador(new Jugador("Miguel", "Pivot", 9));

        partido.SeleccionarEquipos();
        partido.JugarPartido();
    }
}

interface IJugador
{
    string GetNombre();
    int GetRendimiento();
}

class Jugador : IJugador
{
    private string nombre;
    private string posicion;
    private int rendimiento;

    public Jugador(string nombre, string posicion, int rendimiento)
    {
        this.nombre = nombre;
        this.posicion = posicion;
        this.rendimiento = rendimiento;
    }

    public string GetNombre() => nombre;
    public int GetRendimiento() => rendimiento;
}

class Partido
{
    private List<Jugador> jugadores = new List<Jugador>();
    private List<Jugador> equipo1 = new List<Jugador>();
    private List<Jugador> equipo2 = new List<Jugador>();

    public void AgregarJugador(Jugador jugador)
    {
        jugadores.Add(jugador);
    }

    public void SeleccionarEquipos()
    {
        Random rand = new Random();
        List<Jugador> jugadoresDisponibles = new List<Jugador>(jugadores);

        while (equipo1.Count < 3)
        {
            int index = rand.Next(jugadoresDisponibles.Count);
            equipo1.Add(jugadoresDisponibles[index]);
            jugadoresDisponibles.RemoveAt(index);
        }

        equipo2.AddRange(jugadoresDisponibles);
    }

    public void JugarPartido()
    {
        int puntajeEquipo1 = 0, puntajeEquipo2 = 0;

        Console.WriteLine("\nDetalles del Partido:");

        Console.WriteLine("Equipo 1:");
        foreach (var jugador in equipo1)
        {
            int rendimiento = jugador.GetRendimiento();
            puntajeEquipo1 += rendimiento;
            Console.WriteLine($"- {jugador.GetNombre()} ({rendimiento})");
        }
        Console.WriteLine($"Puntaje Total del Equipo 1: {puntajeEquipo1}");

        Console.WriteLine("\nEquipo 2:");
        foreach (var jugador in equipo2)
        {
            int rendimiento = jugador.GetRendimiento();
            puntajeEquipo2 += rendimiento;
            Console.WriteLine($"- {jugador.GetNombre()} ({rendimiento})");
        }
        Console.WriteLine($"Puntaje Total del Equipo 2: {puntajeEquipo2}");

        if (puntajeEquipo1 > puntajeEquipo2)
        {
            Console.WriteLine($"\nEl equipo 1 ganó el partido con un puntaje de {puntajeEquipo1}.");
        }
        else if (puntajeEquipo1 < puntajeEquipo2)
        {
            Console.WriteLine($"\nEl equipo 2 ganó el partido con un puntaje de {puntajeEquipo2}.");
        }
        else
        {
            Console.WriteLine($"\nEl partido terminó en empate con ambos equipos teniendo un puntaje de {puntajeEquipo1}.");
        }
    }
}
