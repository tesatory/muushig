<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TimerTest.aspx.vb" Inherits="TimerTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>    

    <asp:UpdatePanel runat="server">
    <ContentTemplate>
    <asp:Label ID="lbl" runat="server"></asp:Label>
    <asp:Button ID="btn_off" runat="server" Text="OFF" />
    <asp:Button ID="btn_on" runat="server" Text="ON" />
    </ContentTemplate>
    <Triggers>
    <asp:AsyncPostBackTrigger ControlID="tmr" EventName="Tick" />
    </Triggers>
    </asp:UpdatePanel>
    <asp:Timer ID="tmr" runat="server" Interval="1000"></asp:Timer>
    <asp:Label ID="lbl2" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
