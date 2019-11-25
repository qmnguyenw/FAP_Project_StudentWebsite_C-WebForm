<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UniversityCourses.aspx.cs" Inherits="Project_PRN292_FAP.UniversityCourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FPT University Academic Portal</title>
    <link href="CustomCSS/lib.css" rel="stylesheet" />
    <style>
        h1 {
            font-family: Helvetica;
            font-size: 36px;
            font-weight: 100;
            margin-left: 200px;
        }

        p {
            margin-top: 3px;
            margin-right: 0;
            margin-bottom: 0;
            margin-left: 0;
            padding: 0;
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
        }

        .extense {
            font-family: Helvetica;
            font-weight: 200;
            padding-top: 10px;
            padding-left: 20px;
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

        .light-blue {
            color: #337ab7;
        }

        .blue {
            color: #234166;
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

        .wrapper-content {
            margin-left: 200px;
            margin-right: 200px;
            font-family: Helvetica;
        }

        h2 {
            font-weight: 100;
            font-size: 28px;
        }

        h3 {
            font-weight: 100;
            font-size: 22px;
            text-align: center;
        }

        tr {
            background-color: #fff;
            border-bottom: 1px solid #f0f0f0;
            display: table-row;
        }

        tbody th {
            text-align: left;
            padding: 2px;
        }

        th {
            border-right: 1px #fff;
            text-align: center;
            padding: 2px;
            text-transform: uppercase;
            height: 23px;
            background-color: #6b90da;
            font-weight: normal;
        }

        table {
            font-size: 13px;
        }

        td {
            vertical-align: top;
        }

        .tableWrap {
            width: 1100px;
        }

            .tableWrap table {
                width: 100%;
            }

        .tdLeft {
            margin-top: 0px;
        }

        .auto-style1 {
            width: 137px;
        }

        .auto-style2 {
            width: 81px;
        }

        .auto-style3 {
            width: 107px;
            height: 23px;
        }

        .auto-style4 {
            height: 23px;
        }

        .auto-style5 {
            height: 23px;
            width: 80px;
        }

        .absent-per {
            font-size: 15px;
            font-weight: bold;
        }

        .border-bottom {
            border-bottom: 1px solid #e6e6e6;
            padding-bottom: 5px;
        }


    </style>
</head>
<body>
    <form id="form2" runat="server">
        <div class="header">
            <h1>
                <span>FPT University Academic Portal</span>
            </h1>
        </div>
        <div class="navigator">
            <div class="user">
                <asp:Button class="label a-reset" ID="btnStudent" runat="server" Text="huynqhe130069" OnClick="btnStudent_Click" />
                |  
            <asp:Button class="label a-reset" ID="btnLogOut" runat="server" Text="logout" OnClick="btnLogOut_Click" />
                |  
            <span class="label">CAMPUS: FPTU-Hòa Lạc</span>
            </div>
            <li class="extense">
                <span>
                    <asp:LinkButton ID="linkHome" runat="server" Style="text-decoration: none; cursor: pointer; color: #337ab7;" OnClick="linkHome_Click">Home</asp:LinkButton>
                    &nbsp;|&nbsp;
                    <b>Courses</b>
                </span>
            </li>
        </div>
        <table>
            <tbody>
                <tr style="border-bottom: 0 none">
                    <td>
                        <div class="wrapper-content">
                            <h2>Select campus, term ...
                            </h2>
                            <table class="tableWrap">
                                <tbody>
                                    <tr>
                                        <td class="tdLeft">
                                            <table>
                                                <thead>
                                                    <tr>
                                                        <th class="auto-style1">CAMPUS/PROGRAM</th>
                                                        <th class="auto-style2">TERM</th>
                                                        <th style="width: 200px;">DEPARTMENT</th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <p style="font-weight: bold">FU-HL</p>
                                                        </td>
                                                        <td>
                                                            <asp:Repeater ID="rpTerm" runat="server">
                                                                <ItemTemplate>
                                                                    <p class="font-bold" runat="server" visible='<%# (Eval("TID").ToString() == termID) %>'>
                                                                        <%# Eval("TName")%>
                                                                    </p>
                                                                    <p runat="server" visible='<%# (Eval("TID").ToString() != termID) %>'>
                                                                        <a class="a-reset" href="UniversityCourses.aspx?term=<%# Eval("TID")%>"><span><%# Eval("TName")%></span></a>
                                                                    </p>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </td>
                                                        <td>
                                                            <asp:Repeater ID="rpDep" runat="server">
                                                                <ItemTemplate>
                                                                    <p class="font-bold" runat="server" visible='<%# Container.DataItem.ToString() == currentDep %>'>
                                                                        <%# Container.DataItem.ToString() %>
                                                                    </p>
                                                                    <p runat="server" visible='<%# Container.DataItem.ToString() != currentDep %>'>
                                                                        <a class="a-reset" href="UniversityCourses.aspx?term=<%=termID%>&dep=<%# Container.DataItem.ToString() %>">
                                                                            <span><%# Container.DataItem.ToString() %></span>

                                                                        </a>
                                                                    </p>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </td>
                                                    </tr>
                                                </thead>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <br />
                            <br />
                            <br />
                            <h2>... then see list of courses
                            </h2>
                            <table class="tableWrap">
                                <tbody>
                                    <tr>
                                        <td class="tdLeft">
                                            <table>
                                                <thead>
                                                    <tr>
                                                        <th style="width: 200px;">SUBJECT</th>
                                                        <th style="width: 200px;">COURSE DETAIL</th>
                                                        <th style="width: 200px;">TEACHER</th>
                                                        <th style="width: 400px;">COURSES</th>
                                                    </tr>

                                                </thead>
                                                <tbody>
                                                    <%
                                                        int recCount = recList.Count;
                                                        for (int i = 0; i < recCount; i++)
                                                        {
                                                    %>
                                                    <tr>
                                                        <td class="border-bottom">
                                                            <p>
                                                                <%=
                                                                recList[i].CourseCode
                                                                %>
                                                            </p>
                                                        </td>
                                                        <td class="border-bottom">
                                                            <p>
                                                                <%=
                                                                recList[i].CourseName
                                                                %>
                                                            </p>
                                                        </td>
                                                        <td class="border-bottom">
                                                            <%
                                                                int teacherCount = recList[i].Teachers.Count;
                                                                for (int j = 0; j < teacherCount; j++)
                                                                {
                                                            %>
                                                            <p>
                                                                <%= recList[i].Teachers[j] %>
                                                            </p>
                                                            <%
                                                                }
                                                            %>
                                                        </td>
                                                        <td class="border-bottom">
                                                            <%
                                                                int courseDetailCount = recList[i].CouresDetailGroup.Count;
                                                                for (int j = 0; j < courseDetailCount; j++)
                                                                {
                                                            %>
                                                            <p>
                                                                <a class="a-reset" href="CourseGroupDetail.aspx?term=<%=termID%>&dep=<%=currentDep%>&course=<%=recList[i].CouresDetailGroup[j].CdID%>">
                                                                    <span>
                                                                        <%=
                                                                            recList[i].CouresDetailGroup[j].Classname
                                                                        %>
                                                                    </span>
                                                                </a>
                                                                <%=
                                                                            "-("+recList[i].CouresDetailGroup[j].StudentNum+")"
                                                                %>
                                                                <span style="color: red; font-weight: bold">
                                                                    <%=
                                                                            recList[i].CouresDetailGroup[j].LecturerShort
                                                                    %>
                                                                </span>
                                                            </p>
                                                            <%
                                                                }
                                                            %>
                                                        </td>
                                                    </tr>
                                                    <%
                                                        }
                                                    %>
                                                </tbody>

                                            </table>
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
