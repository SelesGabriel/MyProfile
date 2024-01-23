
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace TechChallengeFiap.Application.Helpers;

public class ResultObject : ObjectResult
{
    public ResultObject(HttpStatusCode statusCode, object value) : base(value)
    {
        StatusCode = (int)statusCode;
    }
}

//////////////////////////////////////////////////////////
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallengeFiap.Application.DTOs;
using TechChallengeFiap.Domain.Entities;

namespace TechChallengeFiap.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> UsuarioComConsultas(int id);
        Task<List<UsuarioViewModel>> ObterTodos();
        Usuario ObterPorId(int id);
        Task<IActionResult> CriarUsuario(CadastrarUsuarioDTO usuarioDto);
        Task<IActionResult> AlterarUsuario(AlterarUsuarioDTO usuarioDto);
        Task<IActionResult> DeletarUsuario(int id);

    }
}
/////////////////////////////////////////////////////////////

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TechChallengeFiap.Application.DTOs;
using TechChallengeFiap.Application.Helpers;
using TechChallengeFiap.Application.Services;
using TechChallengeFiap.Domain.Entities;
using TechChallengeFiap.Domain.Interfaces;
using Tests.Helpers;

namespace Tests.Services;

[TestClass]
public sealed class UsuarioServiceTests
{
    private Mock<IUsuarioRepository> _repositoryMock;

    [TestInitialize]
    public void Setup()
    {
        _repositoryMock = new Mock<IUsuarioRepository>();
    }

    Usuario RetornaUsuario()
    {
        return new Usuario()
        {
            Id = 1,
            Nome = "teste",
            NomeUsuario = "teste",
            Permissao = TechChallengeFiap.Domain.Enums.TipoPermissao.Administrador,
            Senha = "teste"
        };
    }

    CadastrarUsuarioDTO RetornaCadastrarUsuarioDTO()
    {
        return new CadastrarUsuarioDTO()
        {
            Nome = "teste",
            NomeUsuario = "teste",
            Senha = "teste"
        };
    }

    List<Usuario> RetornaListaUsuario()
    {
        return new List<Usuario>
        {
            new Usuario()
            {
                Id = 1,
                Nome = "teste",
                NomeUsuario = "teste",
                Permissao = TechChallengeFiap.Domain.Enums.TipoPermissao.Administrador,
                Senha = "teste"
            },
            new Usuario()
            {
                Id = 2,
                Nome = "testes",
                NomeUsuario = "teste2",
                Permissao = TechChallengeFiap.Domain.Enums.TipoPermissao.Usuario,
                Senha = "teste2"
            }
        };
    }

    public UsuarioService CreateServiceInstance()
    {
        return new UsuarioService(
            usuarioRepository: _repositoryMock.Object);
    }

    [TestMethod]
    public async Task ObterPorId_Should_Return_By_Id()
    {
        var user = RetornaUsuario();
        _repositoryMock.Setup(x => x.ObterPorId(1)).Returns(user);

        var service = CreateServiceInstance();
        var response = service.ObterPorId(1);

        Assert.IsNotNull(response);
        Assert.AreEqual(response, user);
    }

    [TestMethod]
    public async Task ObterTodos_Should_Return_Users()
    {
        List<Usuario> user = RetornaListaUsuario();

        _repositoryMock.Setup(x => x.ObterTodosUsuariosAsync()).ReturnsAsync(user);

        var service = CreateServiceInstance();
        var response = service.ObterTodos();

        Assert.IsNotNull(response);
        Assert.IsTrue(response.Result.Count > 0);
    }


    [TestMethod]
    public async Task UsuarioComConsultas_Should_Return_Users()
    {
        var user = new Usuario()
        {
            Id = 1,
            Nome = "teste",
            NomeUsuario = "teste",
            Permissao = TechChallengeFiap.Domain.Enums.TipoPermissao.Administrador,
            Senha = "teste"
        };

        _repositoryMock.Setup(x => x.ObterComConsultas(1)).ReturnsAsync(user);

        var service = CreateServiceInstance();
        var response = service.UsuarioComConsultas(1);

        Assert.IsNotNull(response);
    }


    [TestMethod]
    public async Task CriarUsuario_Should_Return_Ok()
    {
        var userDto = RetornaCadastrarUsuarioDTO();

        var user = RetornaUsuario();

        _repositoryMock.Setup(x => x.Cadastrar(user));

        var service = CreateServiceInstance();
        var response = service.CriarUsuario(userDto);

        Assert.IsNotNull(response);
    }



}

//////////////////////////////////////////////////////////////

global using Microsoft.VisualStudio.TestTools.UnitTesting;

//////////////////////////////////////////////////////////


using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TechChallengeFiap.Application.DTOs;
using TechChallengeFiap.Application.Helpers;
using TechChallengeFiap.Application.Interfaces;
using TechChallengeFiap.Domain.Entities;
using TechChallengeFiap.Domain.Interfaces;
using TechChallengeFiap.Infra.Data;

namespace TechChallengeFiap.Application.Services;

public class UsuarioService : IUsuarioService
{
    private IUsuarioRepository _usuarioRepository;


    public UsuarioService(IUsuarioRepository usuarioRepository)
    {

        _usuarioRepository = usuarioRepository;
    }
    public async Task<Usuario> UsuarioComConsultas(int id) => await _usuarioRepository.ObterComConsultas(id);

    public async Task<List<UsuarioViewModel>> ObterTodos()
    {
        var usuarios = await _usuarioRepository.ObterTodosUsuariosAsync();

        var usuariosViewModel = new List<UsuarioViewModel>();
        foreach (var usuario in usuarios)
        {
            var usuarioViewModel = new UsuarioViewModel(usuario.Nome, usuario.NomeUsuario);
            usuariosViewModel.Add(usuarioViewModel);
        }

        return usuariosViewModel;
    }


    public Usuario ObterPorId(int id) => _usuarioRepository.ObterPorId(id);
    public async Task<IActionResult> CriarUsuario(CadastrarUsuarioDTO usuarioDto)
    {
        var usuario = new Usuario()
        {
            Nome = usuarioDto.Nome,
            NomeUsuario = usuarioDto.NomeUsuario,
            Senha = usuarioDto.Senha,
        };
        _usuarioRepository.Cadastrar(new Usuario(usuario));
        return new ResultObject(HttpStatusCode.Created, usuario);
    }
    public async Task<IActionResult> AlterarUsuario(AlterarUsuarioDTO usuarioDto)
    {
        var usuario = _usuarioRepository.ObterPorId(usuarioDto.Id);

        usuario.Nome = usuarioDto.Nome;
        _usuarioRepository.Alterar(usuario);
        return new ResultObject(HttpStatusCode.OK, usuario);

    }
    public async Task<IActionResult> DeletarUsuario(int id)
    {
        _usuarioRepository.Deletar(id);
        return new ResultObject(HttpStatusCode.OK, $"Usuario {id} removido");
    }
}


