﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TestTwoUpdatePanel.aspx.vb" Inherits="TestTwoUpdatePanel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div>
    <asp:UpdatePanel ID="up1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
    <ContentTemplate>
        <asp:Button ID="btn1" runat="server" Text="update" />
        <asp:Label ID="lbl1" runat="server"></asp:Label>    
    </ContentTemplate>
    </asp:UpdatePanel>
    <hr />
     <asp:UpdatePanel ID="up2" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
    <ContentTemplate>
        <asp:Button ID="btn2" runat="server" Text="update" />
        <asp:Label ID="lbl2" runat="server"></asp:Label>    
    </ContentTemplate>
    </asp:UpdatePanel>

    </div>
    </form>
</body>
</html>
