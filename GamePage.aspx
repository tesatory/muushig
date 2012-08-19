<%@ Page Language="VB" AutoEventWireup="false" CodeFile="GamePage.aspx.vb" Inherits="GamePage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        Tоглогчид
        <hr />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label ID="lbl_players_name" runat="server">
                </asp:Label>
                <hr />
                <asp:Label ID="my_hand" runat="server">
                </asp:Label>
                <asp:Button id="btn_in" runat="server" Text="Орох" Visible="false" />
                <asp:Button id="btn_out" runat="server" Text="Орохгүй" Visible="false" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="timer" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:Timer ID="timer" runat="server" Interval="1000">
        </asp:Timer>
    </div>
    </form>
</body>
</html>
