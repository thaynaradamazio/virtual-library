namespace ProjetoUm;

public class Ler
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public string Synopsis { get; set; }
    public int Pages { get; set; }

    public Ler()
    {
        
    }
    public Ler(string name, string author, string synopsis, int pages)
    {
        Name = name;
        Author = author;
        Synopsis = synopsis;
        Pages = pages;
    }
    
    public void ExibirInformacoesLer()
    {
        Console.WriteLine($"Nome do livro: {Name}\nAutor: {Author}\n Sinopse: {Synopsis}\nNumero de paginas: {Pages}");
    }
}