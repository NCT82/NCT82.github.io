<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Followers.aspx.cs" Inherits="Zalo_TestAPI.Followers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Zalo OA</title>
    <link rel="stylesheet" href="Css/StyleSheet1.css" />
    <script src="Script/JavaScript.js" ></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="header">
        <header>
            <div>
                <a href="Followers.aspx">
                    <img src="Image/HopNhatLogo.png"/>
                </a>
            </div>
        </header>
    </div>
    <div class="center">
        <div class="show_followers">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="User ID" HeaderText="User ID" SortExpression="User ID"/>
                <asp:BoundField DataField="stt" HeaderText="STT" SortExpression="stt" />
                <asp:ImageField DataImageUrlField="Ảnh đại diện" HeaderText="Ảnh đại diện">
                    <ItemStyle HorizontalAlign="Center" CssClass="img"></ItemStyle>
                </asp:ImageField>
                <asp:BoundField DataField="Tên hiển thị" HeaderText="Tên hiển thị" SortExpression="Tên hiển thị" />
                <asp:ButtonField CommandName="Select" Text="Select" HeaderStyle-HorizontalAlign="Left">
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:ButtonField>
            </Columns>
        </asp:GridView></div>
        <div>
            <div id="space"></div>
            
            <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" Height="134px" Width="678px"></asp:TextBox><br />
            <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="True" /><br />  
            <asp:Button ID="Button1" runat="server" Text="Send" OnClick="Button1_Click" /><br />
            <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" Text="Get Json" OnClick="Get_json" />
            
        </div>
        
    </div>
    </form>
</body>
</html>
