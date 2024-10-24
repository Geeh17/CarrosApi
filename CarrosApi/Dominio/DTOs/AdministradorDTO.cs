
using MinimalApi.Dominio.Enuns;

namespace MinimalApi.DTOs;
public class AdministradorDTO
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public string Perfil { get; set; } = string.Empty;
}