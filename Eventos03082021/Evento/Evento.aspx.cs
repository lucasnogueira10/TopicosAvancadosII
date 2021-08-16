using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Evento
{
    public partial class Evento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarDadosPagina();
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            string descricao = txtDescricao.Text;
            string data = txtData.Text;
            int qtdPessoas = Convert.ToInt32(txtQtdPessoas.Text);
            int qtdMaxPermitida = Convert.ToInt32(txtQtdMaxPermitida.Text);
            decimal valorPorPessoa = Convert.ToDecimal(txtValorPorPessoa.Text);
            TB_Evento te = new TB_Evento()
            {
                Descricao = descricao,
                Data = Convert.ToDateTime(data),
                QtdPessoas= qtdPessoas,
                QtdMaxPermitida = qtdMaxPermitida,
            };
            EventoDBEntities contextEvento = new EventoDBEntities();

            string valor = Request.QueryString["Id"];

            if (String.IsNullOrEmpty(valor))
            {
                contextEvento.TB_Evento.Add(te);
                lblmsg.Text = "Registro Inserido!";
                Clear();
            }
            else
            {
                int id = Convert.ToInt32(valor);
                TB_Evento eventos = contextEvento.TB_Evento.First(ev => ev.Id == id);
                eventos.Id = te.Id;
                eventos.Descricao = te.Descricao;
                eventos.Data = te.Data;
                eventos.QtdPessoas = te.QtdPessoas;
                eventos.QtdMaxPermitida = te.QtdMaxPermitida;
                eventos.ValorPorPessoa = te.ValorPorPessoa;
                lblmsg.Text = "Registro Alterado";
            }
            contextEvento.SaveChanges();
        }

        private void Clear()
        {
            txtDescricao.Text = "";
            txtData.Text = "";
            txtQtdPessoas.Text = "";
            txtQtdMaxPermitida.Text = "";
            txtValorPorPessoa.Text = "";
            txtDescricao.Focus();
        }

        private void CarregarDadosPagina()
        {
            string valor = Request.QueryString["Id"];
            int id = 0;
            TB_Evento eventos = new TB_Evento();


            if (!String.IsNullOrEmpty(valor))
            {
                EventoDBEntities contextEventos = new EventoDBEntities();
                id = Convert.ToInt32(valor);
                eventos = contextEventos.TB_Evento.First(ev => ev.Id == id);

                txtDescricao.Text = eventos.Descricao;
                txtData.Text = eventos.Data.ToString();
                txtQtdPessoas.Text = eventos.QtdPessoas.ToString();
                txtQtdMaxPermitida.Text = eventos.QtdMaxPermitida.ToString();
                txtValorPorPessoa.Text = eventos.ValorPorPessoa.ToString();
            }
        }
    }
}