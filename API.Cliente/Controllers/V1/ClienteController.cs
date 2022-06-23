using Microsoft.AspNetCore.Mvc;
using API.Cliente.Modelo;


namespace API.Cliente.Controllers.V1
{
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private static List<ClienteModelo> Lista = new List<ClienteModelo>()
        {
            new ClienteModelo()
            {
               Nome = "Luanna",
                Sobrenome = "Silva",
                Cpf = "11111111111",
                DataDeNascimento = new DateTime(1996,01,26)
            },
            new ClienteModelo()
            {
                Nome = "Adriana",
                Sobrenome = "Alexandre",
                Cpf = "00000000000",
                DataDeNascimento = new DateTime(1972,03,18)
            }
        };

        public ClienteController()
        {
            var cliente = new ClienteModelo();
        }



        // Buscar todos os clientes
        [HttpGet]
        [Route("api/v1/cliente")]
        public ActionResult<List<ClienteModelo>> ObterTodosClientes()
        {
            if (Lista == null || Lista.Count == 0)
            {
                return NotFound("Nenhum cliente encontrado.");
            }
            return Ok(Lista);
        }


        //Buscar Clientes por cpf
        [HttpGet("api/v1/cliente/{cpf}")]
        public ActionResult<ClienteModelo> ObterCliente(string cpf)
        {
            var cliente = Lista.FirstOrDefault(cliente => cliente.Cpf  == cpf);
            if (cliente == null ) 
            {
                return NotFound("Cliente não encontrado.");
            }
            return Ok(cliente);
        }


        [HttpPost]
        [Route("api/v1/clientes")]

        public ActionResult<string> CadastrarClientes([FromBody] ClienteModelo cliente)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                Lista.Add(cliente);
                return Ok("Cliente cadastrado.");
            }
            catch
            {
                return BadRequest("Erro ao cadastrar cliente.");
            }
        }




        [HttpPut]
        [Route("api/v1/clientes{cpf}")]
        public ActionResult<string> AlterarClientes(string cpf, [FromBody] ClienteModelo cliente)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var BuscaCliente = Lista.FirstOrDefault(cliente => cliente.Cpf == cpf);
                if (BuscaCliente != null)
                {
                    BuscaCliente.Nome = cliente.Nome;
                    BuscaCliente.Sobrenome = cliente.Sobrenome;
                }
                return Ok("Atualizado com sucesso.");
            }
            catch
            {
                return NotFound("Cliente não encontrado.");
            }
            
        }

        [HttpDelete]
        [Route("api/v1/clientes{cpf}")]
        public ActionResult<string> DeletarClientes(string cpf)
        {
            var  cliente = Lista.FirstOrDefault(cliente => cliente.Cpf == cpf);
            if (Lista.Remove(cliente!) == false)
            {
                return NotFound("Cliente não encontrado.");
            }

            return Ok("Cliente removido.");
        }



    }
}
