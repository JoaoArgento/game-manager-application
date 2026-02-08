using System.Data.Common;
using Domain.Entities;
namespace Domain.Repositories;

public interface IGameRepository
{
    public Task AddAsync(Game game);
    public Task RemoveByIdAsync(Guid id);
    public Task<IEnumerable<Game>> GetAllAsync();
    public Task<Game> UpdateByIdAsync(Guid id, string name, string description, string logoPath);
    public Task<Game?> GetOneByIdAsync(Guid id);
    public bool CanConnectToDB();
}