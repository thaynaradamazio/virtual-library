namespace ProjetoUm;

public class Lidos
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public string Synopsis { get; set; }
    public int Pages { get; set; }

    public Lidos()
    {
        
    }
    
    public Lidos(string name, string author, string synopsis, int pages)
    {
        Name = name;
        Author = author;
        Synopsis = synopsis;
        Pages = pages;
    }
    
    public void ExibirInformacoesLidos()
    {
        Console.WriteLine($"Nome do livro: {Name}\nAutor: {Author}\nSinopse: {Synopsis}\nNumero de paginas: {Pages}");
    }
}
