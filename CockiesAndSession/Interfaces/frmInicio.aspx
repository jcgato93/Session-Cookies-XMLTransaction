<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmInicio.aspx.cs" Inherits="CockiesAndSession.Interfaces.frmInicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
        <table style="width:100%">
            <tr>
                <td>Usuario</td>
                <td>
                    <asp:Label runat="server" ID="lblUsuario"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Codigo:</td>
                <td>Descripcion:</td>
                <td>Cantidad:</td>
                <td>Valor:</td>
            </tr>
            <tr>
                <td><asp:TextBox runat="server" ID="txtCodigo"></asp:TextBox></td>
                <td><asp:TextBox runat="server" ID="txtDescripcion"></asp:TextBox> </td>
                <td><asp:TextBox runat="server" ID="txtCantidad"></asp:TextBox></td>
                <td><asp:TextBox runat="server" ID="txtValor"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button runat="server" ID="btnAgregar" Text="Aceptar" OnClick="btnAgregar_Click"/>
                    <asp:Button runat="server" ID="btnLimpiar" Text="Limpiar" OnClick="btnLimpiar_Click"/>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView runat="server" ID="gvwDatos" Width="100%" OnRowCommand="gvwDatos_RowCommand" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField  HeaderText="Codigo" DataField="prodCodigo"/>
                        
                        
                            <asp:BoundField  HeaderText="Descripcion" DataField="prodDescripcion"/>
                        
                            <asp:BoundField  HeaderText="Cantidad" DataField="prodCantidad"/>
                        
                            <asp:BoundField  HeaderText="Valor" DataField="prodValor"/>
                        
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="iEliminar" CommandName="Eliminar" CommandArgument="<% ((GridViewRows)Container).RowIndex  %>"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                            </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>

    </form>
</body>
</html>
