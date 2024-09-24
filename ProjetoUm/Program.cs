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
    string name = ReadLineWithText("Digite o nome do livro: ");
    
    string author = ReadLineWithText("Digite o nome do autor: ");
 
    string synopsis = ReadLineWithText("Digite a sinopse do livro: ");

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

    ReadLineWithText("Livro já lido adicionado com sucesso!");
}

 void AddQueroLer()
{
    string name = ReadLineWithText("Digite o nome do livro: ");
    
    string author = ReadLineWithText("Digite o nome do autor: ");
 
    string synopsis = ReadLineWithText("Digite a sinopse do livro: ");

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

    ReadLineWithText("Livro para ler adicionado com sucesso!");
}

  void ListarJaLidos()
  {
      using var context = new ApplicationDbContext();
      
      string bookName = ReadLineWithText("Digite o nome do livro a ser pesquisado (Para listar todos os livros tecle 'ENTER'): ");
          
      var lidos = context.Lido.ToList();
      
      if (lidos.Count == 0)
      {
          ReadLineWithText("Nenhum livro já lido cadastrado.");
          return;
      }

      if (string.IsNullOrEmpty(bookName) == false)
      {
          lidos = lidos.Where(book => book.Name == bookName).ToList();
      }
          
      Console.WriteLine("LIVROS JÁ LIDOS");
      Console.WriteLine("--------------------");
      foreach (var l in lidos)
      {
          Console.WriteLine($"Nome do livro: {l.Name}\nAutor: {l.Author}\nNúmero de páginas: {l.Pages}\nSinopse: {l.Synopsis}");
          Console.WriteLine("--------------------");
      }

      Console.ReadLine();
  }
  
  void ListarQueroLer()
  {
      using var context = new ApplicationDbContext();
      
      string bookName = ReadLineWithText("Digite o nome do livro a ser pesquisado (Para listar todos os livros tecle 'ENTER'): ");
          
      var lerei = context.Lerei.ToList();
      
      if (lerei.Count == 0)
      {
          ReadLineWithText("Nenhum livro para ler cadastrado.");
          return;
      }

      if (string.IsNullOrEmpty(bookName) == false)
      {
          lerei = lerei.Where(book => book.Name == bookName).ToList();
      }
          
      Console.WriteLine("LIVROS PARA LER");
      Console.WriteLine("--------------------");
      foreach (var l in lerei)
      {
          Console.WriteLine($"Nome do livro: {l.Name}\nAutor: {l.Author}\nNúmero de páginas: {l.Pages}\nSinopse: {l.Synopsis}");
          Console.WriteLine("--------------------");
      }

      Console.ReadLine();
  }
  
  void RemoverJaLidos()
  {
      using var connection = new ApplicationDbContext();
      
      var bookName = ReadLineWithText("Digite o nome do livro: ");
          
      var bookAuthor = ReadLineWithText("Digite o nome do autor: ");
          
      var searchedBook = connection.Lido.FirstOrDefault(l => l.Name == bookName && l.Author == bookAuthor);
      
      if (searchedBook != null)
      {
          connection.Lido.Remove(searchedBook);
          connection.SaveChanges();

          ReadLineWithText("Livro removido.");
          return;
      }
      ReadLineWithText("Livro não encontrado.");
  }

  void RemoverQueroLer()
  {
      using var connection = new ApplicationDbContext();

      var bookName = ReadLineWithText("Digite o nome do livro: ");

      var bookAuthor = ReadLineWithText("Digite o nome do autor: ");
      
      var searchedBook = connection.Lerei.FirstOrDefault(l => l.Name == bookName && l.Author == bookAuthor);
      
      if (searchedBook != null)
      {
          connection.Lerei.Remove(searchedBook);
          connection.SaveChanges();

          ReadLineWithText("Livro removido.");
          return;
      }
      ReadLineWithText("Livro não encontrado.");
  }

  void AtualizarJaLidos()
  {
      using var context = new ApplicationDbContext();
      
      var bookName = ReadLineWithText("Digite o nome atual do livro: ");
          
      var book = context.Lido.FirstOrDefault(l => l.Name == bookName);

      if (book == null)
      {
          ReadLineWithText("Livro não encontrado.");
      }
          
      string info = ReadLineWithText("Qual informação você deseja atualizar? Opções - nome, autor, sinopse ou páginas: ");
          
      switch (info)
      {
          case "nome":
          {
              var newBookName = ReadLineWithText("Digite o novo nome do livro: ");
              book.Name = newBookName;
              break;
          }
          case "autor":
          {
              var newAuthorName = ReadLineWithText("Digite o novo nome do autor do livro: ");
              book.Author = newAuthorName;
              break;
          }
          case "sinopse":
          {
              var newSynopsis = ReadLineWithText("Digite a nova sinopse do livro: ");
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
              ReadLineWithText("Opção inválida.");
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
      
      var lidos = context.Lido.ToList();
      
      if (string.IsNullOrEmpty(bookName) == false)
      {
          lidos = lidos.Where(book => book.Name == bookName).ToList();
      }
      foreach (var l in lidos)
      {
          Console.WriteLine("--------------------");
          Console.WriteLine($"Nome do livro: {l.Name}\nAutor: {l.Author}\nNúmero de páginas: {l.Pages}\nSinopse: {l.Synopsis}");
          Console.WriteLine("--------------------");
      }
      Console.ReadLine();
  }

  void AtualizarQueroLer()
  {
      using var context = new ApplicationDbContext();
      
      var bookName = ReadLineWithText("Digite o nome atual do livro: ");
          
      var book = context.Lerei.FirstOrDefault(l => l.Name == bookName);

      if (book == null)
      {
          ReadLineWithText("Livro não encontrado.");
      }
          
      string info = ReadLineWithText("Qual informação você deseja atualizar? Opções - nome, autor, sinopse ou páginas: ");
          
      switch (info)
      {
          case "nome":
          {
              var newBookName = ReadLineWithText("Digite o novo nome do livro: ");
              book.Name = newBookName;
              break;
          }
          case "autor":
          {
              var newAuthorName = ReadLineWithText("Digite o novo nome do autor do livro: ");
              book.Author = newAuthorName;
              break;
          }
          case "sinopse":
          {
              var newSynopsis = ReadLineWithText("Digite a nova sinopse do livro: ");
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
              ReadLineWithText("Opção inválida.");
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
      var lerei = context.Lerei.ToList();
      
      if (string.IsNullOrEmpty(bookName) == false)
      {
          lerei = lerei.Where(book => book.Name == bookName).ToList();
      }
      foreach (var l in lerei)
      {
          Console.WriteLine("--------------------");
          Console.WriteLine($"Nome do livro: {l.Name}\nAutor: {l.Author}\nNúmero de páginas: {l.Pages}\nSinopse: {l.Synopsis}");
          Console.WriteLine("--------------------");
      }
      Console.ReadLine();
  }

    string ReadLineWithText(string text) 
    { 
        Console.WriteLine(text); 
        return Console.ReadLine();
    }  
  
