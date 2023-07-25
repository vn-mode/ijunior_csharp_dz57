using System;
using System.Collections.Generic;
using System.Linq;

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

        squad1.TransferSoldiers(squad2, soldier => soldier.Name.StartsWith("Б"));

        Console.WriteLine("\nОтряд 1 после перевода:");
        squad1.PrintSquad();

        Console.WriteLine("\nОтряд 2 после перевода:");
        squad2.PrintSquad();
    }
}

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
    private List<Soldier> _soldiers;

    public Squad()
    {
        _soldiers = new List<Soldier>();
    }

    public void AddSoldier(Soldier soldier)
    {
        _soldiers.Add(soldier);
    }

    public void TransferSoldiers(Squad toSquad, Func<Soldier, bool> predicate)
    {
        var soldiersToTransfer = _soldiers.Where(predicate).ToList();

        _soldiers = _soldiers.Except(soldiersToTransfer).ToList();
        toSquad._soldiers.AddRange(soldiersToTransfer);
    }

    public void PrintSquad()
    {
        foreach (var soldier in _soldiers)
        {
            Console.WriteLine(soldier.Name);
        }
    }
}