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
    private List<Soldier> _soldiers;

    public Squad()
    {
        _soldiers = new List<Soldier>();
    }

    public void AddSoldier(Soldier soldier)
    {
        _soldiers.Add(soldier);
    }

    public void AddSoldiers(IEnumerable<Soldier> soldiersToAdd)
    {
        _soldiers.AddRange(soldiersToAdd);
    }

    public IEnumerable<Soldier> TransferSoldiers(Func<Soldier, bool> predicate)
    {
        var soldiersToTransfer = _soldiers.Where(predicate).ToList();

        _soldiers = _soldiers.Except(soldiersToTransfer).ToList();

        return soldiersToTransfer;
    }

    public void PrintSquad()
    {
        foreach (var soldier in _soldiers)
        {
            Console.WriteLine(soldier.Name);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        string transferNameStart = "Б";

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

        var soldiersToTransfer = squad1.TransferSoldiers(soldier => soldier.Name.StartsWith(transferNameStart));
        squad2.AddSoldiers(soldiersToTransfer);

        Console.WriteLine("\nОтряд 1 после перевода:");
        squad1.PrintSquad();

        Console.WriteLine("\nОтряд 2 после перевода:");
        squad2.PrintSquad();
    }
}
