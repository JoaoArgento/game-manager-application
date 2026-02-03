
namespace Application.DTOs;

public record UpdateGameRequest(Guid Id, string Name, string Description, string LogoPath);
 