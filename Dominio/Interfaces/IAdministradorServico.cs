using System;
using minimal_api.Dominio.DTOs;
using minimal_api.Dominio.Entidades;

namespace minimal_api.Infraestrutura.Interfaces
{
    public interface IAdministradorServico
    {
        Administrador? Login(LoginDTO loginDTO);

        Administrador Incluir(Administrador administrador);

        List<Administrador> Todos(int? pagina);
    }
}