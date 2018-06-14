using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico;
using App01_ConsultarCEP.Servico.Modelo;
using App01_ConsultarCEP.Servico.PCMsys;

namespace App01_ConsultarCEP
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            BOTAO.Clicked += BuscarCEP;

            btnUser.Clicked += BuscarUser;
		}

        private void BuscarCEP(object sender, EventArgs args) {
            // todo validações
            string cep = CEP.Text.Trim();
            string erro = isValidCEP(cep);

            if (erro.Length==0)
            {
                // todo pesquisa na internet
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if (end!=null)
                    {
                        // todo coloca o resultado da pesquisa
                        RESULTADO.Text = string.Format("Endereço:\n{2}\n{3}\n{0} - {1}\nCEP {4}", end.localidade, end.uf, end.logradouro, end.bairro, end.cep);
                    }
                    else
                    {
                        RESULTADO.Text = string.Format("Não foi localizado endereço para o CEP {0}", cep);
                    }

                }
                catch (Exception e)
                {
                    DisplayAlert("Erro crítico", e.Message, "ok");
                    //throw;
                }
            }
            else
            {
                RESULTADO.Text = string.Format("CEP digitado não é valido. Corrija e tente novamente\n{0}",erro);
            }

        }

        private void BuscarUser(object sender, EventArgs args)
        {
            string projeto = "1";
            string netUserID = CEP.Text.Trim();
            DisplayAlert("Pesquisa de usuário", "Começará a rotina de busca de usuário", "vai lá!");
            string userValidation = isValidNetUser(netUserID);

            if (userValidation.Length > 0)
            {
                RESULTADO.Text = userValidation;
            }
            else
            {
                RESULTADO.Text = "Usuário válido: " + netUserID;
                /**/
                try
                {
                    User usuario = GetUser.buscarUser(projeto, netUserID);
                    RESULTADO.Text = string.Format("UserId: {0}\nNome: {1}\nE-mail: {2}\nÚltimo Acesso: {3}\nEmpresa: {4}\nProjeto: {5}\nSenha: {6}",
                                                    usuario.UserId, usuario.Name, usuario.emailAddress, usuario.LastAccess, usuario.CompanyDescription,
                                                    usuario.projectDescription, usuario.Pwd);
                }
                catch (Exception e)
                {
                    DisplayAlert("Erro crítico", e.Message, "ok");
                }
                /**/
            }
        }

        private string isValidNetUser(string netUser)
        {
            string retorno = "";

            if (netUser.Length < 4) retorno = "Usuário inválido";

            return retorno;
        }

        private string isValidCEP(string cep)
        {
            string retorno = "";
            //substitui "-" por nada
            cep = cep.Replace("-", "");

            // testa tamanho do CEP (tem de ser 8)
            if (cep.Length != 8) retorno = "\nO CEP deve possuir 8 dígitos";

            // testa se somente contém números
            int cepInteger = 0;
                if(!int.TryParse(cep, out cepInteger))
                {
                    retorno += "\nO CEP só pode possuir dígitos (caracteres e símbolos não são permitidos)";
                }
            return retorno;
        }
	}
}
