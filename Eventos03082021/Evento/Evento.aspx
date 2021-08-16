<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Evento.aspx.cs" Inherits="Evento.Evento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.9.0/themes/base/jquery-ui.css" />
    <script src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <script src="http://code.jquery.com/ui/1.9.0/jquery-ui.js"></script>
    <% if (!String.IsNullOrEmpty(lblmsg.Text))
        {%>
    <div class="alert alert-success">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <strong>
            <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label></strong>
    </div>
    <%} %>
    <br />
    <form id="form1" runat="server">
        <article class="kanban-entry grab" id="item1" draggable="true">
            <div class="kanban-entry-inner">
                <div class="kanban-label">
                    <h2><a href="#">Cadastrar Evento</a> </h2>
                    <p></p>
                </div>
            </div>
        </article>

        <div class="form-group">
            <label for="mes">Descrição:</label>
            <asp:TextBox class="form-control" name="txtMes" ID="txtDescricao" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="orgao">Data:</label>
            <asp:TextBox class="form-control" name="txtOrgao" ID="txtData" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="nome_orgao">Quantidade de Pessoas:</label>
            <asp:TextBox class="form-control" name="txtNomeOrgao" ID="txtQtdPessoas" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="sigla_orgao">Quantidade Máxima Permitida:</label>
            <asp:TextBox class="form-control" name="txtSigla" ID="txtQtdMaxPermitida" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="aprovadas">Valor por Pessoa:</label>
            <asp:TextBox class="form-control" name="txtAprovadas" ID="txtValorPorPessoa" runat="server"></asp:TextBox>
        </div>
        <asp:Button class="btn btn-primary" ID="btnCadastrar" runat="server" Text="Salvar"
            OnClick="btnCadastrar_Click" />
    </form>
</asp:Content>
