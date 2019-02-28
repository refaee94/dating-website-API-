using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security;
using System.Security.Claims;
using System.Text;
using dating_app.dtos;
using dating_app.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace dating_app.Controllers {
    [Route ("api/[controller]")]
    public class authcontroller : Controller {
        private readonly authrepositry _repo;

        public authcontroller (authrepositry repo) {

            _repo = repo;

        }

        [HttpPost ("register")]
        public IActionResult Register ([FromBody] userregto u) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);
            u.uname = u.uname.ToLower ();
            if (_repo.exist (u.uname))
                return BadRequest ("already taken");
            var utocreate = new user {

                Name = u.uname
            };
            _repo.register (utocreate, u.pass);

            return StatusCode (201);
        }

        [HttpPost ("login")]
        public IActionResult login ([FromBody] userlog u) {

            var userrepo = _repo.login (u.uname, u.pass);
            if (userrepo == null)
                return Unauthorized ();

            var thandeler = new JwtSecurityTokenHandler ();
            var key = Encoding.ASCII.GetBytes ("super secret key");

            var tdesc = new SecurityTokenDescriptor {

                Subject = new ClaimsIdentity (new Claim[] {
                new Claim (ClaimTypes.NameIdentifier, userrepo.ProductId.ToString ()),
                new Claim (ClaimTypes.Name, userrepo.Name)

                }),
                Expires = DateTime.Now.AddDays (1),

                SigningCredentials = new SigningCredentials (new SymmetricSecurityKey (key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = thandeler.CreateToken (tdesc);
            var tstring = thandeler.WriteToken (token);
            return Ok (new { tstring });
        }

    }
}