using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Squad squad1 = new Squad();
        squad1.AddSoldier(new Soldier("Белов"));
        squad1.AddSoldier(new Soldier("Алексеев"));
        squad1.AddSoldier(new Soldier("Быков"));

        Squad squad2 = new Squad();
        squad2.AddSoldier(new Soldier("Сидоров"));
        squad2.AddSoldier(new Soldier("Кузнецов"));

        Console.WriteLine("Отряд 1 до перевода:");
        squad1.PrintSquad();

        Console.WriteLine("\nОтряд 2 до перевода:");
        squad2.PrintSquad();

        IEnumerable<Soldier> soldiersToTransfer = squad1.ExtractSoldiers(soldier => soldier.Name.StartsWith("Б"));
        squad2.IncludeSoldiers(soldiersToTransfer);

        Console.WriteLine("\nОтряд 1 после перевода:");
        squad1.PrintSquad();

        Console.WriteLine("\nОтряд 2 после перевода:");
        squad2.PrintSquad();
    }
}

public class Soldier
{
    private string _name;

    public Soldier(string name)
    {
        _name = name;
    }

    public string Name
    {
        get { return _name; }
        private set { _name = value; }
    }
}

public class Squad
{
    private readonly List<Soldier> _soldiers;

    public Squad()
    {
        _soldiers = new List<Soldier>();
    }

    public void AddSoldier(Soldier soldier)
    {
        _soldiers.Add(soldier);
    }

    public IEnumerable<Soldier> ExtractSoldiers(Func<Soldier, bool> predicate)
    {
        List<Soldier> soldiersToExtract = _soldiers.Where(predicate).ToList();
        _soldiers.RemoveAll(soldier => soldiersToExtract.Contains(soldier));
        return soldiersToExtract;
    }

    public void IncludeSoldiers(IEnumerable<Soldier> soldiersToInclude)
    {
        _soldiers.AddRange(soldiersToInclude);
    }

    public void PrintSquad()
    {
        foreach (var soldier in _soldiers)
        {
            Console.WriteLine(soldier.Name);
        }
    }
}
