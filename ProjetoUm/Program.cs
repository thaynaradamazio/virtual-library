// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using ProjetoUm;
using ProjetoUm.Aplicativos;

Menu menu = new Menu();
bool continuar = true;

while (continuar)
{
    menu.ExibirMenu();
    string escolha = Console.ReadLine();

    switch (escolha)
    {
        case "1":
            AddJaLidos();
            break;
         case "2":
             AddQueroLer();
             break;
         case "3":
             ListarJaLidos();
             break;
         case "4":
             ListarQueroLer();
             break;
         case "5":
             RemoverJaLidos();
             break;
         case "6":
             RemoverQueroLer();
             break;
        case "7":
            AtualizarJaLidos();
            break;
        case "8":
             AtualizarQueroLer();
             break;
         case "9":
             continuar = false;
             break;
         default:
             Console.WriteLine("Opção inválida. Tente novamente.");
             Console.ReadLine();
             break;
     }
}

 void AddJaLidos()
{
    Console.Write("Digite o nome do livro: ");
    string name = Console.ReadLine();
    
    Console.Write("Digite o nome do autor: ");
    string author = Console.ReadLine();
    
    Console.Write("Digite a sinopse do livro: ");
    string synopsis = Console.ReadLine();

    Console.Write("Digite a quantidade de páginas: ");
    int pages = int.Parse(Console.ReadLine());
    
    using (var context = new ApplicationDbContext())
    {
    
        var lido = new Lidos
        {
            Name = name,
            Author = author,
            Synopsis = synopsis,
            Pages = pages
        };

        context.Lido.Add(lido);
        context.SaveChanges(); 
    }

    Console.WriteLine("Livro já lido adicionado com sucesso!");
    Console.ReadLine();
}

 void AddQueroLer()
{
    Console.Write("Digite o nome do livro: ");
    string name = Console.ReadLine();
    
    Console.Write("Digite o nome do autor: ");
    string author = Console.ReadLine();
    
    Console.Write("Digite a sinopse do livro: ");
    string synopsis = Console.ReadLine();

    Console.Write("Digite a quantidade de páginas: ");
    int pages = int.Parse(Console.ReadLine());
    
    
    using (var context = new ApplicationDbContext())
    {
    
        var lerei = new Ler
        {
            Name = name,
            Author = author,
            Synopsis = synopsis,
            Pages = pages
        };

        context.Lerei.Add(lerei);
        context.SaveChanges(); 
    }

    Console.WriteLine("Livro para ler adicionado com sucesso!");
    Console.ReadLine();
}

  void ListarJaLidos()
  {

      using (var context = new ApplicationDbContext())
      {
          var lidos = context.Lido.ToList();

          if (lidos.Count == 0)
          {
              Console.WriteLine("Nenhum livro já lido cadastrado.");
          }
          
          Console.WriteLine("LIVROS JÁ LIDOS");
          foreach (var l in lidos)
          {
              Console.WriteLine($"Nome do livro: {l.Name}\nAutor: {l.Author}\nNúmero de páginas: {l.Pages}\nSinopse: {l.Synopsis}");
              Console.WriteLine("--------------------");
          }

          Console.ReadLine();
          
      }
  }
  
  void ListarQueroLer()
  {
      
      using (var context = new ApplicationDbContext())
      {
          var lerei = context.Lerei.ToList();

          if (lerei.Count == 0)
          {
              Console.WriteLine("Nenhum livro para ler cadastrado.");
          }

          Console.WriteLine("LIVROS PARA LER");
          foreach (var l in lerei)
          {
              Console.WriteLine($"Nome do livro: {l.Name}\nAutor: {l.Author}\nNúmero de páginas: {l.Pages}\nSinopse: {l.Synopsis}");
              Console.WriteLine("--------------------");
          }
          
          Console.ReadLine();
      }
      
  }
  
  void RemoverJaLidos()
  {
      using (var connection = new ApplicationDbContext())
      {
        Console.Write("Digite o nome do livro: ");
        var bookName = Console.ReadLine(); 
      
        Console.Write("Digite o nome do autor do livro: ");
        var bookAuthor = Console.ReadLine(); 
      
        var searchedBook = connection.Lido.FirstOrDefault(l => l.Name == bookName && l.Author == bookAuthor);
      
        if (searchedBook != null)
        {
          connection.Lido.Remove(searchedBook);
          connection.SaveChanges();

          Console.WriteLine("Livro removido");
          Console.ReadLine();
          return;
        }
        Console.WriteLine("Livro não encontrado");
        Console.ReadLine();
      
      }
          
  }

  void RemoverQueroLer()
  {
      using var connection = new ApplicationDbContext();
      
      Console.Write("Digite o nome do livro: ");
      var bookName = Console.ReadLine(); 
      
      Console.Write("Digite o nome do autor do livro: ");
      var bookAuthor = Console.ReadLine(); 
      
      var searchedBook = connection.Lerei.FirstOrDefault(l => l.Name == bookName && l.Author == bookAuthor);
      
      if (searchedBook != null)
      {
          connection.Lerei.Remove(searchedBook);
          connection.SaveChanges();

          Console.WriteLine("Livro removido");
          Console.ReadLine();
          return;
      }
      Console.WriteLine("Livro não encontrado");
      Console.ReadLine();
  }

  void AtualizarJaLidos()
  {
      using var context = new ApplicationDbContext();
      
      Console.Write("Digite o nome atual do livro: ");
      var bookName = Console.ReadLine();
          
      var book = context.Lido.FirstOrDefault(l => l.Name == bookName);

      if (book == null)
      {
          Console.Write("Livro não encontrado");
          return;
      }
          
      Console.Write("Qual informação você deseja atualizar? Opções - nome, autor, sinopse ou páginas: ");
      string info = Console.ReadLine();
          
      switch (info)
      {
          case "nome":
          {
              Console.Write("Digite o novo nome do livro: ");
              var newBookName = Console.ReadLine();
              book.Name = newBookName;
              break;
          }
          case "autor":
          {
              Console.Write("Digite o novo nome do autor do livro: ");
              var newAuthorName = Console.ReadLine();
              book.Author = newAuthorName;
              break;
          }
          case "sinopse":
          {
              Console.Write("Digite a nova sinopse do livro: ");
              var newSynopsis = Console.ReadLine();
              book.Synopsis = newSynopsis;
              break;
          }
          case "páginas":
          {
              Console.Write("Digite a nova quantidade de páginas: ");
              int newPages = int.Parse(Console.ReadLine());
              book.Pages = newPages;
              break;
          } 
          default:
          {
              Console.WriteLine("Opção inválida");
              Console.ReadLine();
              return;
          }
      }
      context.SaveChanges();

      string infoUpper = "";
      if (!string.IsNullOrEmpty(info))
      {
          infoUpper = char.ToUpper(info[0]) + info.Substring(1);
      }
      
      Console.WriteLine($"{infoUpper} alterado com sucesso.");
      Console.ReadLine();
  }

  void AtualizarQueroLer()
  {
      using var context = new ApplicationDbContext();
      
      Console.Write("Digite o nome atual do livro: ");
      var bookName = Console.ReadLine();
          
      var book = context.Lerei.FirstOrDefault(l => l.Name == bookName);

      if (book == null)
      {
          Console.Write("Livro não encontrado");
          return;
      }
          
      Console.Write("Qual informação você deseja atualizar? Opções - nome, autor, sinopse ou páginas: ");
      string info = Console.ReadLine();
          
      switch (info)
      {
          case "nome":
          {
              Console.Write("Digite o novo nome do livro: ");
              var newBookName = Console.ReadLine();
              book.Name = newBookName;
              break;
          }
          case "autor":
          {
              Console.Write("Digite o novo nome do autor do livro: ");
              var newAuthorName = Console.ReadLine();
              book.Author = newAuthorName;
              break;
          }
          case "sinopse":
          {
              Console.Write("Digite a nova sinopse do livro: ");
              var newSynopsis = Console.ReadLine();
              book.Synopsis = newSynopsis;
              break;
          }
          case "páginas":
          {
              Console.Write("Digite a nova quantidade de páginas: ");
              int newPages = int.Parse(Console.ReadLine());
              book.Pages = newPages;
              break;
          } 
          default:
          {
              Console.WriteLine("Opção inválida");
              Console.ReadLine();
              return;
          }
      }
      context.SaveChanges();

      string infoUpper = "";
      if (!string.IsNullOrEmpty(info))
      {
          infoUpper = char.ToUpper(info[0]) + info.Substring(1);
      }
      
      Console.WriteLine($"{infoUpper} alterado com sucesso.");
      Console.ReadLine();
  }
  
  
  
