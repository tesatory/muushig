<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CreatePlayer.aspx.vb" Inherits="CreatePlayer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Нэр: <asp:TextBox ID="tb_player_name" runat="server"></asp:TextBox>
    <asp:Button ID="btn_ok" runat="server" Text="OK" />
    </div>
    </form>
</body>
</html>
