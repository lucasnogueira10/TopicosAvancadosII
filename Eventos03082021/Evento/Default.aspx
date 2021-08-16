<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Evento.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function MostrarPopupMensagem() {
            $("#modalMsg").modal('show');
        }
        function EsconderPopupDados() {
            $("#modalDados").modal('hide');
        }
    </script>
    <div class="modal fade" id="modalMsg">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">

                    <button type="button" class="close" data-dismiss="modal">
                        <span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>

                    <h4 class="modal-title" id="h1" runat="server">Modal title</h4>
                </div>
                <div class="modal-body">
                    <p>
                        <label id="lblMsgPopup" runat="server">
                        </label>
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Ok</button>
                </div>
            </div>
        </div>
    </div>
    <form runat="server">
        <asp:GridView ID="GVEventos" runat="server" CellPadding="4" CssClass="table" ForeColor="#333333"
            GridLines="None" AutoGenerateColumns="False" OnRowCommand="GVEventos_RowCommand" DataKeyNames="Id" DataSourceID="SqlDataSource1">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Descricao" HeaderText="Descricao" SortExpression="Descricao" />
                <asp:BoundField DataField="Data" HeaderText="Data" SortExpression="Data" />
                <asp:BoundField DataField="QtdPessoas" HeaderText="QtdPessoas" SortExpression="QtdPessoas" />
                <asp:BoundField DataField="QtdMaxPermitida" HeaderText="QtdMaxPermitida" SortExpression="QtdMaxPermitida" />
                <asp:BoundField DataField="ValorPorPessoa" HeaderText="ValorPorPessoa" SortExpression="ValorPorPessoa" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EventoDBConnectionString %>" SelectCommand="SELECT [Id], [Descricao], [Data], [QtdPessoas], [QtdMaxPermitida], [ValorPorPessoa] FROM [TB_Evento]"></asp:SqlDataSource>
    </form>
</asp:Content>
