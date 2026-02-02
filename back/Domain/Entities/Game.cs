namespace Domain.Entities;
public class Game
{
    public Guid Id {get; private set; } = Guid.NewGuid();
    public string Name {get; private set; }
    public string Description {get; private set; }
    public string LogoPath {get; private set;}
    public DateTime CreatedAt {get; private set; } = DateTime.UtcNow;

    public Genre Genre {get; private set; }
    public Game()
    {
        
    }

    public Game(Guid id, string name, string description, string logoPath, Genre genre)
    {
        Id = id;
        Name = name;
        LogoPath = logoPath;
        Description = description;
        Genre = genre;
    }
}

 public enum Genre
    {
        Action,
        Shooter,
    }