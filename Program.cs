using System.Xml.Linq;
using System.IO;
using System;
class Program
{
  public static void Main(string[] args)
  {
    Menu();
  }
  static void Menu()
  {
    Console.Clear();
    Console.WriteLine(value: "O que você deseja fazer?");
    Console.WriteLine(value: "1 - Abrir arquivo");
    Console.WriteLine(value: "2  - Criar novo arquivo");
    Console.WriteLine(value: "0 - Sair");

    short option = short.Parse(s: Console.ReadLine());

    switch (option)
    {
      case 0: System.Environment.Exit(exitCode: 0); break;
      case 1: Abrir(); break;
      case 2: Editar(); break;
      default: Menu(); break;
    }
  }
  static void Abrir()
  {
    Console.Clear();
    Console.WriteLine("Qual o caminho do arquivo?");
    string path = Console.ReadLine();
    if (path != null)
      using (var file = new StreamReader(path: path))
      {
        string text = file.ReadToEnd();
        Console.WriteLine(value: text);
      }
    Console.WriteLine("");
    Console.ReadLine();
    Menu();

  }
  static void Editar()
  {
    Console.Clear();
    Console.WriteLine(value: "Digite seu texto abaixo (ESC para sair)");
    Console.WriteLine(value: "-----------------------");
    string text = "";
    do
    {
      text += Console.ReadLine();
      text += Environment.NewLine;
    }
    while (Console.ReadKey().Key != ConsoleKey.Escape);
    Salvar(text: text);
  }
  static void Salvar(string text)
  {
    Console.Clear();
    Console.WriteLine(value: "Qual caminho para salvar o arquivo?");
    var path = Console.ReadLine();
    if (path != null)
      using (var file = new StreamWriter(path: path))
      {
        file.Write(value: text);
      }
    Console.WriteLine(value: $"Arquivo {path} salvo com sucesso!");
    Menu();
  }
}