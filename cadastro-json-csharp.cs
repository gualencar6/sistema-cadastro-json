using System;
using System.Text.Json;
using System.IO;

class FichaCAD
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string DocumentoRG { get; set; }
    public bool Work { get; set; }
    public decimal Income { get; set; }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Digite suas informações: ");

        Console.Write("Nome: ");
        string name = Console.ReadLine();

        Console.Write("Sobrenome: ");
        string lastName = Console.ReadLine();

        Console.Write("Idade: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write("Documento: ");
        string document = Console.ReadLine();

        Console.Write("Trabalha: (SIM/NAO): ");
        bool work = false;
        string trabalha = Console.ReadLine();

        if (trabalha.ToUpper() == "SIM")
        {
            work = true;
        }
        else if (trabalha.ToUpper() == "NAO" || trabalha.ToUpper() == "NÃO")
        {
            work = false;
        }
        else
        {
            Console.WriteLine("Resposta inválida! Considerando como NÃO.");
        }

        Console.Write("Ganho mensal: ");
        decimal income = decimal.Parse(Console.ReadLine());

        FichaCAD ficha = new()
        {
            Name = name,
            LastName = lastName,
            Age = age,
            DocumentoRG = document,
            Work = work,
            Income = income
        };

        string json = JsonSerializer.Serialize(ficha, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText("sistemaCAD.json", json);

        Console.WriteLine("\nArquivo JSON criado:");
        Console.WriteLine(json);

        string conteudo = File.ReadAllText("sistemaCAD.json");

        FichaCAD fichaLida = JsonSerializer.Deserialize<FichaCAD>(conteudo);

        Console.WriteLine("\nDados lidos do arquivo JSON:");
        Console.WriteLine($"Nome: {fichaLida.Name}");
        Console.WriteLine($"Sobrenome: {fichaLida.LastName}");
        Console.WriteLine($"Idade: {fichaLida.Age}");
        Console.WriteLine($"Documento: {fichaLida.DocumentoRG}");
        Console.WriteLine($"Trabalha: {fichaLida.Work}");
        Console.WriteLine($"Renda: {fichaLida.Income}");
    }
}