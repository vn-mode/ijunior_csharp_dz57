using System;
using System.Collections.Generic;
using System.Linq;

public class Soldier
{
    public string Name { get; private set; }

    public Soldier(string name)
    {
        Name = name;
    }
}

public class Squad
{
    private List<Soldier> soldiers;

    public Squad()
    {
        soldiers = new List<Soldier>();
    }

    public List<Soldier> GetSoldiers()
    {
        return soldiers;
    }

    public void PrintSquad()
    {
        foreach (var soldier in soldiers)
        {
            Console.WriteLine(soldier.Name);
        }
    }
}

class Program
{
    private const string TransferNameStart = "Б";

    static void Main(string[] args)
    {
        var squad1 = new Squad();
        squad1.GetSoldiers().AddRange(new List<Soldier> {
            new Soldier("Белов"),
            new Soldier("Алексеев"),
            new Soldier("Быков")
        });

        var squad2 = new Squad();
        squad2.GetSoldiers().AddRange(new List<Soldier> {
            new Soldier("Сидоров"),
            new Soldier("Кузнецов")
        });

        Console.WriteLine("Отряд 1 до перевода:");
        squad1.PrintSquad();

        Console.WriteLine("\nОтряд 2 до перевода:");
        squad2.PrintSquad();

        TransferSoldiers(squad1, squad2);

        Console.WriteLine("\nОтряд 1 после перевода:");
        squad1.PrintSquad();

        Console.WriteLine("\nОтряд 2 после перевода:");
        squad2.PrintSquad();
    }

    private static void TransferSoldiers(Squad fromSquad, Squad toSquad)
    {
        var soldiersToTransfer = fromSquad.GetSoldiers().Where(soldier => soldier.Name.StartsWith(TransferNameStart)).ToList();

        fromSquad.GetSoldiers().RemoveAll(soldier => soldiersToTransfer.Contains(soldier));
        toSquad.GetSoldiers().AddRange(soldiersToTransfer);
    }
}
