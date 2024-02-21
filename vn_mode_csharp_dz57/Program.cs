using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        char letter = 'Б';

        List<Soldier> squad1 = new List<Soldier>();
        squad1.Add(new Soldier("Белов"));
        squad1.Add(new Soldier("Алексеев"));
        squad1.Add(new Soldier("Быков"));

        List<Soldier> squad2 = new List<Soldier>();
        squad2.Add(new Soldier("Сидоров"));
        squad2.Add(new Soldier("Кузнецов"));

        Console.WriteLine("Отряд 1 до перевода:");
        PrintList(squad1);

        Console.WriteLine("\nОтряд 2 до перевода:");
        PrintList(squad2);

        List<Soldier> soldiersToTransfer = squad1.Where(soldier => soldier.Name.StartsWith(letter)).ToList();
        squad2 = squad2.Concat(soldiersToTransfer).ToList();
        squad1 = squad1.Where(soldier => !soldier.Name.StartsWith(letter)).ToList();

        Console.WriteLine("\nОтряд 1 после перевода:");
        PrintList(squad1);

        Console.WriteLine("\nОтряд 2 после перевода:");
        PrintList(squad2);
    }

    static void PrintList(List<Soldier> list)
    {
        foreach (var item in list)
        {
            Console.WriteLine(item.Name);
        }
    }
}

public class Soldier
{
    public Soldier(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }
}
