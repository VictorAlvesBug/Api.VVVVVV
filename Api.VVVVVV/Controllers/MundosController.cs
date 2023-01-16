using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.VVVVVV.Models;

namespace Api.VVVVVV.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class MundosController : ControllerBase
	{
		public MundosController()
		{
			
		}

		[HttpGet]
		[Route("{nomeMundo}")]
		public string Retornar(string nomeMundo)
		{
			string caminhoMundo = $@"C:\Users\Usuario\Desktop\Pessoal\JS Projects\Api.VVVVVV\Api.VVVVVV.Data\Mundos\{nomeMundo}.json";

			try
			{
				return System.IO.File.ReadAllText(caminhoMundo);
			}
			catch (Exception e)
			{

				return $"Ops! Arquivo '{caminhoMundo}' não encontrado. \n\nErro: {e}";
			}

		}

		[HttpPost]
		[Route("{nomeMundo}")]
		public bool Salvar(string nomeMundo, [FromBody] MundoModel mundo)
		{
			string caminhoMundo = $@"C:\Users\Usuario\Desktop\Pessoal\JS Projects\Api.VVVVVV\Api.VVVVVV.Data\Mundos\{nomeMundo}.json";

			try
			{
				System.IO.File.WriteAllLinesAsync(caminhoMundo, mundo.StrMundo.Split("\n"));
				return true;
			}
			catch (Exception e)
			{

				return false;
			}

		}
	}
}
