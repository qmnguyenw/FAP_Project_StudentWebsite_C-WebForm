<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentDetail.aspx.cs" Inherits="Project_PRN292_FAP.StudentDetail" %>

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

        #imageStudent {
            width: 315px;
            height: 379px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
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
                    <b>User Detail</b>
                </span>
            </li>
        </div>
        <table class="content">
            <tbody>
                <tr>
                    <td>
                        <div>
                            <h2>User Detail</h2>
                            <div class="contentNavigator">
                                <asp:LinkButton ID="linkAttendance" runat="server" Style="text-decoration: none; cursor: pointer; color: #337ab7;" OnClick="linkAttendance_Click">Course attendance</asp:LinkButton>
                                &nbsp;|&nbsp;
                                <asp:LinkButton ID="linkGrade" runat="server" Style="text-decoration: none; cursor: pointer; color: #337ab7;">Grade</asp:LinkButton>
                            </div>
                            <table class="mainTable">
                                <tbody>
                                    <tr>
                                        <td style="width: 184px; border-bottom-style: groove; border-bottom-width: thin;">
                                            <b>Login</b>
                                        </td>
                                        <td style="width: 936px; border-bottom-style: groove; border-bottom-width: thin;">
                                            <asp:Label ID="lbLogin" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 184px; border-bottom-style: groove; border-bottom-width: thin;">
                                            <b>Full name</b>
                                        </td>
                                        <td style="width: 936px; border-bottom-style: groove; border-bottom-width: thin;">
                                            <asp:Label ID="lbName" runat="server" ></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 184px; border-bottom-style: groove; border-bottom-width: thin;">
                                            <b>Image</b>
                                        </td>
                                        <td style="border-bottom-style: groove; border-bottom-width: thin;">
                                            <img src="<%= imgPath %>" style="width:330px;" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 184px; border-bottom-style: groove; border-bottom-width: thin;">
                                            <b>Email</b>
                                        </td>
                                        <td style="width: 936px; border-bottom-style: groove; border-bottom-width: thin;">
                                            <asp:Label ID="lbEmail" runat="server" ></asp:Label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
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
