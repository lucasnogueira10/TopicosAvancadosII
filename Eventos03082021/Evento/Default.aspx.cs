using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Evento
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarLista();
        }

        private void CarregarLista()
        {
            EventoDBEntities context = new EventoDBEntities();
            List<TB_Evento> lstEventos = context.TB_Evento.ToList<TB_Evento>();

            GVEventos.DataSource = lstEventos;
            GVEventos.DataBind();
        }

        protected void GVEventos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            EventoDBEntities contextEventos = new EventoDBEntities();
            TB_Evento evento = new TB_Evento();

            evento = contextEventos.TB_Evento.First(i => i.Id == id);

            if (e.CommandName == "ALTERAR")
            {
                Response.Redirect("Eventos.aspx?id=" + id);
            }
            else if (e.CommandName == "EXCLUIR")
            {
                contextEventos.TB_Evento.Remove(evento);
                contextEventos.SaveChanges();
                string msg = "Evento excluído com sucesso!";
                string titulo = "Informação";
                CarregarLista();
                DisplayAlert(titulo, msg, this);
            }
        }

        public void DisplayAlert(string titulo, string mensagem, System.Web.UI.Page page)
        {
            h1.InnerText = titulo;
            lblMsgPopup.InnerText = mensagem;
            ClientScript.RegisterStartupScript(typeof(Page), Guid.NewGuid().ToString(),
                "MostrarPopupMensagem();", true);
        }
    }
}