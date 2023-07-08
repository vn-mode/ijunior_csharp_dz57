using System;
using System.Collections.Generic;
using System.Linq;

public class Soldier
{
    private string name;

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

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

    public void AddSoldier(Soldier soldier)
    {
        soldiers.Add(soldier);
    }

    public void RemoveSoldier(Soldier soldier)
    {
        soldiers.Remove(soldier);
    }

    public IEnumerable<Soldier> GetSoldiers()
    {
        return soldiers.AsReadOnly();
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
    static void Main(string[] args)
    {
        var squad1 = new Squad();
        squad1.AddSoldier(new Soldier("Белов"));
        squad1.AddSoldier(new Soldier("Алексеев"));
        squad1.AddSoldier(new Soldier("Быков"));

        var squad2 = new Squad();
        squad2.AddSoldier(new Soldier("Сидоров"));
        squad2.AddSoldier(new Soldier("Кузнецов"));

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
        var soldiersToTransfer = fromSquad.GetSoldiers().Where(soldier => soldier.Name.StartsWith("Б")).ToList();

        foreach (var soldier in soldiersToTransfer)
        {
            fromSquad.RemoveSoldier(soldier);
            toSquad.AddSoldier(soldier);
        }
    }
}
