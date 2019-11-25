<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="Project_PRN292_FAP.UpdateProfile" %>

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
            border-width: thin;
            cursor: pointer;
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
            height: 500px;
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

        td {
            padding: 0px;
            vertical-align: top;
            border-left-width: 0px;
            border-right-width: 0px;
            display: table-cell;
        }

            td a {
                color: #337ab7;
                text-decoration: none;
            }

                td a:hover {
                    cursor: pointer;
                    color: #234166;
                    text-decoration: underline;
                }

        h2 {
            padding: 10px;
            text-align: left;
            margin-top: 0px;
            margin-bottom: 0px;
            font-family: Helvetica;
            font-weight: 200;
            font-size: 30px;
            border-bottom-style: none;
        }

        .contact {
            margin-left: 200px;
            margin-right: 200px;
            border-bottom-style: groove;
            border-bottom-width: thin;
        }

            .contact a {
                color: #337ab7;
                text-decoration: none;
            }

                .contact a:hover {
                    cursor: pointer;
                    color: #234166;
                    text-decoration: underline;
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

        .extense {
            font-family: Helvetica;
            font-weight: 200;
            padding-top: 10px;
            padding-left: 20px;
        }

        .contentNavigator {
            font-family: Helvetica;
            font-weight: 200;
        }

        .mainTable {
            font-family: Helvetica;
        }

        .panel {
            margin-bottom: 20px;
            background-color: #fff;
            border: 1px solid transparent;
            border-radius: 4px;
            font-family: Helvetica;
            font-weight: 100;
            width: 1120px;
        }

        .panel-warning {
            border-color: #faebcc;
        }

        .panel-heading {
            color: #8a6d3b;
            background-color: #fcf8e3;
            border-color: #faebcc;
            padding: 10px 15px;
            border-bottom: 1px solid transparent;
            border-top-left-radius: 3px;
            border-top-right-radius: 3px;
            text-align: center;
        }

        .panel-body {
            padding-top: 20px;
            padding-left: 40px;
        }

        .form-group {
            display: flex;
        }

        label {
            display: inline-block;
            max-width: 100%;
            margin-bottom: 5px;
            font-weight: 700;
        }

        .form-control {
            display: block;
            width: 500px;
            padding: 6px 12px;
            font-size: 14px;
            line-height: 1.42857143;
            color: #555;
            background-color: #fff;
            background-image: none;
            border: 1px solid #ccc;
            border-radius: 4px;
            margin-left: 100px;
        }

        #taAddress {
            width: 200px;
            height: 100px;
            margin-left: 97px;
        }

        #tbPhoneStudent {
            margin-left: 91px;
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

        #btnSave {
            margin-left: 300px;
            margin-bottom: 10px;
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
                <asp:Button class="label" ID="btnStudent" runat="server" OnClick="btnStudent_Click" />
                |  
            <asp:Button class="label" ID="btnLogOut" runat="server" Text="logout" OnClick="btnLogOut_Click" />
                |  
            <span class="label">CAMPUS: FPTU-Hòa Lạc</span>
            </div>
            <li class="extense">
                <span>
                    <asp:LinkButton ID="linkHome" runat="server" Style="text-decoration: none; cursor: pointer; color: #337ab7;" OnClick="linkHome_Click">Home</asp:LinkButton>
                    &nbsp;|&nbsp;
                    <b>Update Profile</b>
                </span>
            </li>
        </div>
        <table class="content">
            <tbody>
                <tr>
                    <td>
                        <div>
                            <div class="row">
                                <div>
                                    <div class="panel panel-warning">
                                        <div class="panel-heading">
                                            <h3 class="panel-title">
                                                <i class="livicon"></i>
                                                Update Profile
                                            </h3>
                                        </div>
                                        <div class="panel-body">
                                            <div class="row">
                                                <div>
                                                    <div class="form-group">
                                                        <label class="control-label">Số điện thoại sinh viên:</label>
                                                        <div>
                                                            <asp:TextBox ID="tbPhoneStudent" class="form-control" runat="server"></asp:TextBox>
                                                        </div>
                                                        <asp:Label ID="Error1" runat="server" ForeColor="Red"></asp:Label>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="control-label">Họ và Tên phụ huynh:</label>
                                                        <div>
                                                            <asp:TextBox ID="tbNameParent" class="form-control" runat="server"></asp:TextBox>
                                                        </div>
                                                        <asp:Label ID="Error2" runat="server" ForeColor="Red"></asp:Label>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="control-label">Điện thoại phụ huynh:</label>
                                                        <div>
                                                            <asp:TextBox ID="tbPhoneParent" class="form-control" runat="server"></asp:TextBox>
                                                        </div>
                                                        <asp:Label ID="Error3" runat="server" ForeColor="Red"></asp:Label>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="control-label">
                                                            Địa chỉ thường trú phụ
                                                            <br />
                                                            huynh:</label>
                                                        <div>
                                                            <textarea id="taAddress" class="form-control" cols="20" rows="2" runat="server"></textarea>
                                                        </div>
                                                        <asp:Label ID="Error4" runat="server" ForeColor="Red"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-primary" OnClick="btnSave_Click" />
                                                    <asp:Label ID="success" runat="server" Text="" ForeColor="Green"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
        <div class="contact" style="font-family: Helvetica;">
            <br />
            <b>Mọi thắc mắc xin liên hệ: </b>
            <span>Phòng TC&QLĐT Hòa Lạc</span>
            : Email:
            <a href="#">acad.hl@fpt.edu.vn</a>
            . Điện thoại:
            <span>(024)66805916</span>
            <br />
            <span>Phòng Kế toán</span>
            Điện thoại:
            <span>(024)66805916</span>
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
