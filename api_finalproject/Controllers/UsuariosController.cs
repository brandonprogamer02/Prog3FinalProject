using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_finalproject.Models;
using api_finalproject.Models.Response;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace api_finalproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly db_finalprojectContext _context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration configuration;
        private readonly SignInManager<IdentityUser> signInManager;

        public UsuariosController(db_finalprojectContext context, UserManager<IdentityUser> manager ,
            IConfiguration configuration,
            SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            userManager = manager;
            this.configuration = configuration;
            this.signInManager = signInManager;
        }

        // GET: api/Usuarios
       
        [HttpPost("registrar")] // api/Usuarios/registrar

        public async Task<ActionResult<Response_Authentication>> Registrar(Credenciales credenciales)
        {
            var usuario = new IdentityUser { UserName = credenciales.Email, Email = credenciales.Email };

            var resultado = await userManager.CreateAsync(usuario, credenciales.password);

            if (resultado.Succeeded)
            {
                return ConstruirToken(credenciales);
            }
            else
            {
                return BadRequest(resultado.Errors);
            }
        }


        [HttpPost("login")]

        public async Task<ActionResult<Response_Authentication>> Login(Credenciales credencialesUsuario)
        {
            var resultado = await signInManager.PasswordSignInAsync(credencialesUsuario.Email,
                credencialesUsuario.password, isPersistent: false, lockoutOnFailure: false);

            if (resultado.Succeeded)
            {
                return ConstruirToken(credencialesUsuario);
            }
            else
            {
                return BadRequest("Login incorrecto");
            }
        }



        private Response_Authentication ConstruirToken(Credenciales credenciales)
        {
            var Claims = new List<Claim>()
            {
                new Claim("Email", credenciales.Email)


            };

            var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["llaveJwt"]));

            var creds = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);

            var expirar = DateTime.UtcNow.AddYears(1);

            var securityToken = new JwtSecurityToken(issuer: null, audience: null, claims: Claims,
                expires: expirar, signingCredentials: creds);

            return new Response_Authentication()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                Fecha_Expira = expirar
            };
        }
    }
}
