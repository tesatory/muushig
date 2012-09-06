<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server" ></asp:ScriptManager>
    <div>
    Одоо байгаа тоглогчид
    <hr />
    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:Label id="lbl_players_name" runat="server">
    </asp:Label>
    <hr />
    <asp:Button ID="btn_start" runat="server" Text="Тоглолтыг эхлэх" />
    <asp:Button ID="btn_logout" runat="server" Text="Гарах" />
    </ContentTemplate>
    <Triggers>
    <asp:AsyncPostBackTrigger ControlID="timer" EventName="Tick" />
    </Triggers>
    </asp:UpdatePanel>
    <asp:Timer ID="timer" runat="server" Interval="1000"></asp:Timer>
    </div>
    </form>
</body>
</html>
