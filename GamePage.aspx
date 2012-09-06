<%@ Page Language="VB" AutoEventWireup="false" CodeFile="GamePage.aspx.vb" Inherits="GamePage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Муушиг</title>
    <link rel="Stylesheet" type="text/css" href="CSS/Common.css" />
    <link rel="Stylesheet" type="text/css" href="CSS/Card.css" />
    <script type="text/javascript" src="JS/Game.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Button ID="btn_quit" runat="server" Text="Тоглоомноос Гарах" />
    <table width="100%">
        <tr>
            <td>
            </td>
            <td width="600px">
                <div id="game_table">
                    <asp:UpdatePanel ID="up_main" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Label ID="lbl_players_name" runat="server">
                            </asp:Label>
                            <br />
                            <div id="center_part">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_huzur" runat="server"></asp:Label>
                                        </td>
                                        <td width="50px"></td>
                                        <td>
                                            <asp:Label ID="lbl_gazar" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="hand_part">
                            Өөрийн мод
                            <br />
                            <asp:Label ID="my_hand" runat="server"></asp:Label>
                            <asp:Label ID="my_round_point" runat="server">
                            </asp:Label>
                            <br />
                            <asp:Button ID="btn_in" runat="server" Text="Орох" Visible="false" />
                            <asp:Button ID="btn_out" runat="server" Text="Өнжих" Visible="false" />
                            <asp:Panel ID="pnl_change" runat="server" Visible="false">
                                <asp:Label ID="lbl_remain" runat="server"></asp:Label>
                                <div style="display:none;">
                                <asp:CheckBoxList ID="change_list" runat="server" RepeatDirection="Horizontal">
                                </asp:CheckBoxList>
                                </div>
                                <asp:Button ID="btn_change" runat="server" Text="Солих" />
                            </asp:Panel>
                            <asp:Panel ID="pnl_play" runat="server" Visible="false">
                                <div style="display:none;">
                                <asp:RadioButtonList ID="play_list" runat="server" RepeatDirection="Horizontal">
                                </asp:RadioButtonList>
                                </div>
                                <asp:Button ID="btn_play" runat="server" Text="Гарах" />
                            </asp:Panel>
                            </div>
                            <asp:HiddenField ID="min_card_num" runat="server" />
                            <asp:HiddenField ID="max_card_num" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="up_timer" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true" >
                        <ContentTemplate>
                            <asp:Timer ID="timer" runat="server" Interval="1000" >
                            </asp:Timer>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </td>
            <td>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
