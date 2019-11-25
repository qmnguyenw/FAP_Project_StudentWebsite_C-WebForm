<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Project_PRN292_FAP.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FPT University Academic Portal</title>
    <style>
        h1 {
            font-family: Helvetica;
            font-size: 36px;
            font-weight: 100;
            margin-left: 200px;
        }

        .navigator {
            margin-bottom: 20px;
            list-style: none;
            background-color: #f5f5f5;
            border-radius: 4px;
            display: block;
            height: 41px;
            margin-left: 200px;
            margin-right: 200px;
        }

        .user {
            float: right;
            margin-right: 16px;
        }

        .label {
            font-family: Helvetica;
            display: inline;
            padding: .2em .6em .3em;
            font-size: 75%;
            font-weight: 700;
            line-height: 1;
            color: #fff;
            text-align: center;
            white-space: nowrap;
            vertical-align: baseline;
            border-radius: .25em;
            background-color: #5cb85c;
        }

        .content {
            margin-left: 200px;
            margin-right: 200px;
            display: flex;
        }

        .box h3 {
            height: 34px;
            line-height: 34px;
            display: inline-block;
            color: #fff;
            border-radius: 5px 5px 0 0;
            background-position: 0 -100px;
            font-family: Helvetica;
            font-size: 24px;
            font-weight: 100;
            padding: 0px 15px;
            margin-top: -20px;
        }

        div .topAthletes {
            width: 400px;
            float: left;
            padding-top: 0px;
            height: 100px;
        }

        .between {
            width: 50px;
        }

        div .academic {
            width: 800px;
            float: right;
            margin-right: 0px;
            padding-top: 0px;
            font-family: Helvetica;
            font-weight: 100;
        }

        .newsTextbox, .newsButton {
            border-radius: 5px;
        }

        .box {
            border-radius: 5px;
            background: rgba(255,255,255,0.7);
            position: relative;
            color: #234166;
            box-shadow: 0 0 5px #c4cacc;
            padding: 15px 17px;
            margin: 34px 0 50px;
        }

        h4 {
            font-size: 20px;
            text-align: center;
            margin-top: 0px;
            margin-bottom: 0px;
            font-family: Helvetica;
            font-weight: 200;
        }

        .final a {
            color: #337ab7;
            text-decoration: none;
        }

            .final a:hover {
                cursor: pointer;
                color: #234166;
                text-decoration: underline;
            }

        .btn {
            display: inline-block;
            padding: 6px 12px;
            margin-bottom: 0;
            font-size: 14px;
            font-weight: 400;
            line-height: 1.42857143;
            text-align: center;
            white-space: nowrap;
            vertical-align: middle;
            cursor: pointer;
            border-radius: 5px;
        }

        .btn-primary {
            color: #fff;
            background-color: #337ab7;
            border-radius: 5px;
            border-width: thin;
        }

        .login {
            text-align: center;
            font-family: Helvetica;
            font-weight: 200;
        }

        .cbbCampus {
            color: #333;
            background-color: #fff;
            border-color: #ccc;
        }

        .inputText {
            color: #333;
            background-color: #fff;
            border-color: #ccc;
            border-width: thin;
            width: 230px;
            cursor: auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" autocomplete="off" spellcheck="false">
        <div class="header">
            <h1>
                <span>FPT University Academic Portal</span>
            </h1>
        </div>
        <div class="navigator">
            <div class="user">
            </div>
        </div>
        <div class="content">
            <div class="box topAthletes">
                <h3 style="background-color: #ef8d01;">Phụ huynh</h3>
                <div class="login">
                    <a href="#">
                        <span class="btn btn-primary">
                            <b>Đăng nhập</b>
                        </span>
                    </a>
                </div>
            </div>
            <div class="between"></div>
            <div class="box academic">
                <h3 style="background-color: #ef8d01;">Sinh viên, Giảng viên, Cán bộ ĐH-FPT</h3>
                <div class="login">
                    <asp:DropDownList ID="selectCampus" runat="server" CssClass="btn cbbCampus" AutoPostBack="false">
                        <asp:ListItem Selected="True">Select Campus</asp:ListItem>
                        <asp:ListItem>FU-Hòa Lạc</asp:ListItem>
                        <asp:ListItem>FU-Hồ Chí Minh</asp:ListItem>
                        <asp:ListItem>FU-Đà Nẵng</asp:ListItem>
                        <asp:ListItem>FU-Cần Thơ</asp:ListItem>
                        <asp:ListItem>MSE</asp:ListItem>
                        <asp:ListItem>SWINBURNE-Hà Nội</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="btnSignIn" runat="server" Text="Sign in" class="btn btn-primary" OnClick="btnSignIn_Click" />
                    <br />
                    <asp:Label ID="lbErrorCampus" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                    &nbsp;<asp:TextBox ID="tbUsername" runat="server"  class="btn inputText" placeholder="Username"></asp:TextBox>
                    <br />
                    <asp:Label ID="lbErrorName" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                    &nbsp;<asp:TextBox ID="tbPassword" runat="server" class="btn inputText" placeholder="Password" TextMode="Password"></asp:TextBox>
                    <br />
                    <asp:Label ID="lbErrorPass" runat="server" ForeColor="Red"></asp:Label>
                </div>
            </div>
        </div>
        <p style="text-align: center; font-family: Helvetica;" class="final">
            © Powered by 
        <a href="#">FPT University</a>
            |  
        <a href="#">CMS</a>
            |  
        <a href="#">library</a>
            |  
        <a href="#">books24x7</a>
        </p>
    </form>
</body>
</html>
