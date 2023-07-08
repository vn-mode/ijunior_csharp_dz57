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

        var soldiersToTransfer = squad1.Soldiers.Where(s => s.Name.StartsWith("Б")).ToList();

        foreach (var soldier in soldiersToTransfer)
        {
            squad1.RemoveSoldier(soldier);
            squad2.AddSoldier(soldier);
        }

        Console.WriteLine("\nОтряд 1 после перевода:");
        squad1.PrintSquad();

        Console.WriteLine("\nОтряд 2 после перевода:");
        squad2.PrintSquad();
    }
}

public class Soldier
{
    public string Name { get; set; }

    public Soldier(string name)
    {
        Name = name;
    }
}

public class Squad
{
    public List<Soldier> Soldiers { get; private set; }

    public Squad()
    {
        Soldiers = new List<Soldier>();
    }

    public void AddSoldier(Soldier soldier)
    {
        Soldiers.Add(soldier);
    }

    public void RemoveSoldier(Soldier soldier)
    {
        Soldiers.Remove(soldier);
    }

    public void PrintSquad()
    {
        foreach (var soldier in Soldiers)
        {
            Console.WriteLine(soldier.Name);
        }
    }
}
