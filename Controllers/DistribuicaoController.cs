using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bonus.API.Context;
using Bonus.API.Models;

namespace Bonus.API.Controllers
{
    public class Distribuicao : Models.Funcionario
    {
        public int PAA { get; set; }
        public int PFS { get; set; }
        public int PTA { get; set; }
        public double QtdSalarios { get; set; }
        public double TempoCasa { get; set; }
        public double Peso { get; set; }
        public double Bonus { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class DistribuicaoController : ControllerBase
    {
        private readonly BonusDbContext _context;

        public DistribuicaoController(BonusDbContext context)
        {
            _context = context;
        }

        // GET: api/Distribuicao
        [HttpGet("{valorDisponibilizado}")]
        public List<Distribuicao> GetDistribuicao(double valorDisponibilizado)
        {

            List<Distribuicao> distribuicaoLista = new List<Distribuicao>();
            double salarioMinimo = 1000;

            if (valorDisponibilizado != 0)
            {

                IEnumerable<Funcionario> funcionarioLista = _context.Funcionarios.ToList();
                double fator = 0;
                double parcela = 0;

                foreach (Funcionario funcionario in funcionarioLista)
                {
                    Distribuicao distribuicao = new Distribuicao();
                    CopiaItem(funcionario, distribuicao);
                    CalculaPesoPorAreaAtuacao(distribuicao);
                    CalculaPesoPorFaixaSalarial(distribuicao, salarioMinimo);
                    CalculaPesoPorTempoDeAdmissao(distribuicao);
                    CalculaPesoFinal(distribuicao);
                    fator += distribuicao.Peso;
                    distribuicaoLista.Add(distribuicao);
                }

                parcela = valorDisponibilizado / fator;

                foreach (Distribuicao distribuicao in distribuicaoLista)
                {
                    distribuicao.Bonus = parcela * distribuicao.Peso;
                }

            }

            return distribuicaoLista.ToList();

        }

        private void CopiaItem(Funcionario funcionario, Distribuicao distribuicao)
        {
            distribuicao.Id = funcionario.Id;
            distribuicao.CodigoMatricula = funcionario.CodigoMatricula;
            distribuicao.NomeCompleto = funcionario.NomeCompleto;
            distribuicao.AreaAtuacao = funcionario.AreaAtuacao;
            distribuicao.Cargo = funcionario.Cargo;
            distribuicao.SalarioBruto = funcionario.SalarioBruto;
            distribuicao.DataAdmissao = funcionario.DataAdmissao;
        }

        private void CalculaPesoPorAreaAtuacao(Distribuicao distribuicao)
        {
            if (distribuicao.AreaAtuacao == "Diretoria")
            {
                distribuicao.PAA = 1;
            }
            else if (distribuicao.AreaAtuacao == "Contabilidade" || distribuicao.AreaAtuacao == "Financeiro" || distribuicao.AreaAtuacao == "Tecnologia")
            {
                distribuicao.PAA = 2;
            }
            else if (distribuicao.AreaAtuacao == "Serviços gerais")
            {
                distribuicao.PAA = 3;
            }
            else if (distribuicao.AreaAtuacao == "Relacionamento com cliente")
            {
                distribuicao.PAA = 4;
            }
            else
            {
                distribuicao.PAA = 0;
            }
        }

        private void CalculaPesoPorFaixaSalarial(Distribuicao distribuicao, Double salarioMinimo)
        {
            distribuicao.QtdSalarios = distribuicao.SalarioBruto / salarioMinimo;

            if (distribuicao.Cargo == "Estagiário")
            {
                distribuicao.PFS = 1;
            }
            else
            {
                if (distribuicao.QtdSalarios >= 8)
                {
                    distribuicao.PFS = 5;
                }
                else if (distribuicao.QtdSalarios >= 5 && distribuicao.QtdSalarios < 8)
                {
                    distribuicao.PFS = 3;
                }
                else if (distribuicao.QtdSalarios >= 3 && distribuicao.QtdSalarios < 5)
                {
                    distribuicao.PFS = 2;
                }
                else if (distribuicao.QtdSalarios < 3)
                {
                    distribuicao.PFS = 1;
                }
            }
        }
        private void CalculaPesoPorTempoDeAdmissao(Distribuicao distribuicao)
        {
            distribuicao.TempoCasa = (double)(DateTime.Today.Subtract(distribuicao.DataAdmissao).TotalDays / 365);

            if (distribuicao.TempoCasa >= 8)
            {
                distribuicao.PTA = 4;
            }
            else if (distribuicao.TempoCasa >= 3 && distribuicao.TempoCasa < 8)
            {
                distribuicao.PTA = 3;
            }
            else if (distribuicao.TempoCasa >= 1 && distribuicao.TempoCasa < 3)
            {
                distribuicao.PTA = 2;
            }
            else
            {
                distribuicao.PTA = 1;
            }
        }

        private void CalculaPesoFinal(Distribuicao distribuicao)
        {
            distribuicao.Peso = (double)((
                                            ((distribuicao.SalarioBruto * (double)distribuicao.PTA) + (distribuicao.SalarioBruto * (double)distribuicao.PAA))
                                            /
                                            (distribuicao.SalarioBruto * (double)distribuicao.PFS)
                                         ) * 12.0);
        }

    }

}