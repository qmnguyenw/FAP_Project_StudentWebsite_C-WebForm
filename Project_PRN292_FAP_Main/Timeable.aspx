<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Timeable.aspx.cs" Inherits="Project_PRN292_FAP.Timeable" %>

<!DOCTYPE html>
<link href="CustomCSS/lib.css" rel="stylesheet" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Schedule</title>
    <style>
        body {
            font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
        }

        h1 {
            font-family: Helvetica;
            font-size: 36px;
            font-weight: 100;
            margin-left: 300px;
        }

        h2 {
            font-family: inherit;
            font-weight: 500;
            line-height: 1.1;
            color: inherit;
        }

        .navigator {
            margin-bottom: 20px;
            list-style: none;
            background-color: #f5f5f5;
            border-radius: 4px;
            display: block;
            height: 41px;
            margin-left: 300px;
            margin-right: 320px;
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

        .extense {
            font-family: Helvetica;
            font-weight: 200;
            padding-top: 10px;
            padding-left: 20px;
        }

        .content {
            margin-left: 300px;
            margin-right: 200px;
            display: flex;
            font-size: 13px;
        }

        .auto-style1 {
            width: 1056px;
        }

        .auto-style2 {
            width: 36px;
        }

        .auto-style3 {
            width: 140px;
        }

        table {
            border-spacing: 0;
            border-collapse: collapse;
        }

        tr {
            border-bottom: 1px solid #f0f0f0;
        }

        tbody th {
            text-align: left;
            padding: 2px;
        }

        th {
            border-right: 1px solid #fff;
            text-align: center;
            text-transform: uppercase;
            height: 23px;
            background-color: #6b90da;
            font-weight: normal;
        }

        .timeable {
            width: 100%;
        }

        p {
            margin: 0 0 10px;
            text-align: left;
        }
        .light-blue {
            color: #337ab7;
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
                <asp:Button class="label" ID="btnStudent" runat="server" Text="huynqhe130069" OnClick="btnStudent_Click"/>
                |  
            <asp:Button class="label" ID="btnLogOut" runat="server" Text="logout" OnClick="btnLogOut_Click" />
                |  
            <span class="label">CAMPUS: FPTU-Hòa Lạc</span>
            </div>
            <li class="extense">
                <span>
                    <asp:LinkButton ID="linkHome" runat="server" Style="text-decoration: none; cursor: pointer; color: #337ab7;" OnClick="linkHome_Click">Home</asp:LinkButton>
                    &nbsp;|&nbsp;
                    <b>View Schedule</b>
                </span>
            </li>
        </div>
        <table class="content">
            <tbody>
                <tr style="border-bottom: 0 none">
                    <td class="auto-style1">
                        <div>

                            <h2>Activities for
                                <asp:Label ID="ctl00_mainContent_lblStudent" runat="server" Text="TuanTMHE130569 (Tống Minh Tuấn)"></asp:Label>
                            </h2>
                            <p>
                                <b>Note</b>: These activities do not include extra-curriculum activities, such as
        club activities ...
                            </p>
                            <p>
                                <b>Chú thích</b>: Các hoạt động trong bảng dưới không bao gồm hoạt động ngoại khóa,
        ví dụ như hoạt động câu lạc bộ ...
                            </p>
                            <div id="ghichu">
                                <p>
                                    Các phòng bắt đầu bằng AL thuộc tòa nhà Alpha.<br>
                                    Các phòng bắt đầu bằng BE thuộc tòa nhà Beta.<br>
                                    Các phòng bắt đầu bằng G thuộc tòa nhà Gamma (mới xây, gần canteen).<br>
                                    Các phòng tập bằng đầu bằng R thuộc khu vực sân tập Vovinam.
                                </p>
                            </div>
                            <!-- start timetable -->
                            <table class="timeable">
                                <thead>
                                    <tr>
                                        <th rowspan="2" style="width: 300px;">Week
                                            <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="cbbWeek_SelectedIndexChanged" ID="cbbWeek" runat="server"></asp:DropDownList>
                                        </th>
                                        <th class="auto-style3">Mon</th>
                                        <th class="auto-style3">Tue</th>
                                        <th class="auto-style3">Wed</th>
                                        <th class="auto-style3">Thu</th>
                                        <th class="auto-style3">Fri</th>
                                        <th class="auto-style3">Sat</th>
                                        <th class="auto-style2">Sun</th>
                                    </tr>
                                    <tr>
                                        <asp:Repeater ID="rpWeekday" runat="server">
                                            <ItemTemplate>
                                                <th><%# Container.DataItem.ToString() %></th>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tr>
                                </thead>
                                <tbody>
                                    <% 
                                        for (int i = 0; i < cells.GetLength(0); i++)
                                        {
                                    %>
                                    <tr>
                                        <td> Slot <%=i+1%>
                                        </td>
                                        <%
                                            for (int j = 0; j < cells.GetLength(1); j++)
                                            {
                                        %>
                                        <td>
                                            <%
                                                if (cells[i, j] == null || cells[i, j].IsEmpty)
                                                {
                                            %>-<%
                                                   }
                                                   else
                                                   {
                                            %>
                                            <a class="a-reset"><span>
                                                <%=
                                                    cells[i,j].CourseCode
                                                %>
                                                <br />
                                                at AL-R206
                                            </span></a>
                                            <br />
                                            <span class="light-blue">(</span><%
                                                if (cells[i, j].AttendStatus == "present")
                                                {
                                            %><span class="hover-underline" style="color: green">attended</span><%
                                                }
                                                else
                                                {
                                            %><span class="hover-underline" style="color: red"><%=cells[i,j].AttendStatus %></span><%
                                                }
                                            %><span class="light-blue">)</span>
                                            <%
                                                }
                                            %>

                                        </td>
                                        <%
                                            }
                                        %>
                                    </tr>
                                    <%
                                        }
                                    %>
                                </tbody>
                            </table>
                            <p>
                                <b>More note / Chú thích thêm</b>:
                            </p>
                            <div id="ctl00_mainContent_divfoot">
                                <ul>
                                    <li>(<font color="green">attended</font>): <asp:Label ID="attendShort" runat="server" Text="Label"></asp:Label> had attended this activity / Học sinh này đã tham gia hoạt động này</li>
                                    <li>(<font color="red">absent</font>): <asp:Label ID="absentShort" runat="server" Text="Label"></asp:Label> had NOT attended this activity / Học sinh này đã vắng mặt buổi này</li>
                                    <li>(-): no data was given / chưa có dữ liệu</li>
                                </ul>
                            </div>
                            <p>
                            </p>


                        </div>
                    </td>
                </tr>
                <tr style="border-bottom: 0 none">
                    <td class="auto-style1">
                        <br>

                        <table width="100%" style="border: 1px solid transparent;" id="cssTable">

                            <tbody>
                                <tr>
                                    <td>
                                        <div id="ctl00_divSupport">
                                            <br>
                                            <b>Mọi góp ý, thắc mắc xin liên hệ: </b>
                                            <span>Phòng TC&amp;QLĐT Hòa Lạc</span>: Email: <a href="mailto:acad.hn@fpt.edu.vn">acad.hl@fpt.edu.vn</a>.
                                               Điện thoại: <span>(024)66805916 </span>
                                            <br>
                                            <span>Phòng Kế toán</span>
                                            Điện thoại: <span>(024)66805914 </span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
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
                                    </td>
                                </tr>
                            </tbody>
                        </table>

                    </td>
                </tr>
            </tbody>
        </table>
    </form>
</body>
</html>
