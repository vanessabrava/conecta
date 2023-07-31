using SME.Conecta.Infra.CrossCutting.Model;
using SME.Conecta.Infra.CrossCutting.Model.ModelRules;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SME.Conecta.Services.Models
{
    public class Cliente : IAggregateRoot
    {
        private Cliente() { }

        private Cliente(string nome)
            : this()
        {
            Nome = nome;
           
        }
        public string Nome { get; private set; }
        public object? IdCliente { get; set; }

        public static ModelResult<Cliente> Novo(string nome)
        {
            var result = new ModelResult<Cliente>();

            ValidarCampos(result, nome);

            if (result.EhModelResultValido())
                result.SetModel(new Cliente(nome));

            return result;

        }

        private static void ValidarCampos(ModelResult result, string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                result.AdicionarValidacao("Nome", "O campo é obrigatório.");
        }

    }
}