<%@ Page Language="VB" AutoEventWireup="false" CodeFile="GamePage.aspx.vb" Inherits="GamePage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Муушиг</title>
    <link rel="Stylesheet" type="text/css" href="CSS/Common.css" />
    <link rel="Stylesheet" type="text/css" href="CSS/Card.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Button ID="btn_quit" runat="server" Text="Тоглоомноос Гарах" />
    <div>
        Tоглогчид
        <hr />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label ID="lbl_players_name"  runat="server">
                </asp:Label>
                <br />
                Хөзөр<br />
                <asp:Label ID="lbl_huzur" runat="server"></asp:Label>
                <hr />
                Газар <br />
                <asp:Label ID="lbl_gazar" runat="server"></asp:Label>
                <hr />
                Өөрийн мод 
                <br />
                <asp:Label ID="my_hand" runat="server"></asp:Label>
                <asp:Label ID="my_round_point" runat="server">
                </asp:Label>
                <br />
                <asp:Button id="btn_in" runat="server" Text="Орох" Visible="false" />
                <asp:Button id="btn_out" runat="server" Text="Өнжих" Visible="false" />

                <asp:Panel ID="pnl_change" runat="server" Visible="false">
                    <asp:Label ID="lbl_remain" runat="server"></asp:Label>
                    <asp:CheckBoxList id="change_list" runat="server" RepeatDirection="Horizontal">                    
                    </asp:CheckBoxList>
                    <asp:Button ID="btn_change" runat="server" Text="Солих" />
                </asp:Panel>

                <asp:Panel ID="pnl_play" runat="server" Visible="false">
                    <asp:RadioButtonList  id="play_list" runat="server" RepeatDirection="Horizontal">                    
                    </asp:RadioButtonList>
                    <asp:Button ID="btn_play" runat="server" Text="Гарах" />
                </asp:Panel>

                <asp:Timer ID="timer" runat="server" Interval="1000">
                </asp:Timer>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="timer" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
