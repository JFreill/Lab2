<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Strings.aspx.cs" Inherits="_Strings" %>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8" />
    <title></title>    
</head>
<body>
    <form id="form1" runat="server">   
        <div id="input" runat="server">
            <h2>Input</h2>
            <asp:TextBox ID="inputTextBox" runat="server" TextMode="MultiLine" Width="450px" Height="75px" />
            <br />
            <br />
            <asp:Button ID="inputButton" runat="server" Text="Transform User Text" OnClick="inputButton_OnClick"/>
            <br />
        </div>
        <div id="output" runat="server">
            <h2>Output</h2>
            <asp:Literal ID="outputLiteral" runat="server"/>
        </div>
    </form>
</body>
</html>
