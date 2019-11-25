<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Project_PRN292_FAP.Home" %>

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
            height: 540px;
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
            border-bottom-style: solid;
            border-bottom-width: 1px;
            border-bottom-color: #e6e6e6;
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

        h4 {
            font-size: 20px;
            text-align: center;
            margin-top: 0px;
            margin-bottom: 0px;
            font-family: Helvetica;
            font-weight: 200;
        }

        .contact {
            margin-left: 200px;
            margin-right: 200px;
            border-bottom-style: solid;
            border-bottom-width: 1px;
            border-bottom-color: #e6e6e6;
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

        .date {
            font: 12px Arial, "Times New Roman", Times, serif;
            color: #737373;
        }

        .anew {
            text-decoration: none;
            color: #4169E1;
            font-weight: bold;
            line-height: 15px;
            font-family: Helvetica;
            font-size: 14px;
        }

        .content-div {
            padding-top: 20px;
            width: 55%;
            overflow: hidden;
        }

        ul li {
            list-style-type: none;
            position: relative;
        }

            ul li::before {
                content: '\2022';
                position: absolute;
                left: -1em;
                font-size: 15px;
            }

        ul li {
            margin-bottom: 10px;
            font-size: 14px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" action="#">
        <div class="header">
            <h1>
                <span>FPT University Academic Portal</span>
            </h1>
        </div>
        <div class="navigator">
            <div class="user">
                <asp:Button class="label" ID="btnStudent" runat="server" Text="huynqhe130069" OnClick="btnStudent_Click" />
                |  
            <asp:Button class="label" ID="btnLogOut" runat="server" Text="logout" OnClick="btnLogOut_Click" />
                |  
            <span class="label">CAMPUS: FPTU-Hòa Lạc</span>
            </div>
        </div>
        <div class="content">
            <div class="box topAthletes">
                <h3 style="background-color: #0f4086;">News</h3>
                <div class="listBoxWrapper">
                    
                    <div class="listNews">
                        <ul>
                            <asp:Repeater runat="server" ID="rpNews">
                                <ItemTemplate>
                                    <li>
                                        <em class="date"><%# Eval("UploadTimeFormat") %></em>
                                        <a class="anew" href="NewsDetail.aspx?ar_id=<%# Eval("ID") %>">
                                            <%# Eval("Title") %>
                                        </a>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="between"></div>
            <div class="box academic">
                <h3 style="background-color: #ef8d01;">Academic Information</h3>
                <div class="listBoxWrapper">
                    <table>
                        <tbody>
                            <tr>
                                <td style="width: 55%">
                                    <h4>Registration/Application(Thủ tục/đơn từ)</h4>
                                    <ul>
                                        <li>
                                            <a href="#">Suspend one semester to take repeated course</a>
                                            &nbsp; | &nbsp;
                                                        <a href="#">Cancel</a>
                                            (Xin tạm hoãn tiến độ một học kỳ để học lại | Hủy bỏ việc xin tạm hoãn)
                                        </li>
                                        <li>
                                            <a href="#">Suspend one semester</a>
                                            &nbsp; | &nbsp;
                                                        <a href="#">Cancel</a>
                                            (Xin tạm nghỉ một học kỳ | Hủy bỏ việc xin tạm nghỉ)
                                        </li>
                                        <li>
                                            <a href="#">Move out class, suspend subject</a>
                                            &nbsp; | &nbsp;
                                                        <a href="#">Cancel</a>
                                            (Xin chuyển lớp, tạm ngừng môn học, ...)
                                        </li>
                                        <li>
                                            <a href="#">Register extra courses</a>
                                            (Đăng ký môn học đi chậm kỳ)
                                        </li>
                                        <li>
                                            <a href="#">Register to improve mark</a>
                                            (Đăng ký học cải thiện điểm)
                                        </li>
                                        <li>
                                            <a href="#">Register to repeat a course</a>
                                            (Đăng ký học lại)
                                        </li>
                                        <li>
                                            <a href="#">Cancel registration</a>
                                            (Hủy đăng ký học)
                                        </li>
                                        <li>
                                            <a href="#">Register Free Elective Courses</a>
                                            (Đăng ký môn tự chọn)
                                        </li>
                                        <li>
                                            <a href="#">Send Application</a>
                                            (Xem đơn)
                                                        &nbsp; | &nbsp;
                                                        <a href="#">View Application</a>
                                            (Xem đơn)
                                        </li>
                                    </ul>
                                </td>
                                <td>
                                    <h4>Information Access(Tra cứu thông tin)</h4>
                                    <ul>
                                        <li>
                                            <a href="UniversityCourses.aspx">University timetable</a>
                                            (Lịch học)
                                        </li>
                                        <li>
                                            <a href="#">Tuition fee per course</a>
                                            (Biểu học phí)
                                        </li>
                                        <li>
                                            <a href="Timeable.aspx">Weekly timetable</a>
                                            (Thời khóa biểu từng tuần)
                                        </li>
                                        <li>
                                            <a href="#">Blended Online Course (BLOC) Schedules</a>
                                            (Lịch học các môn theo phương pháp BLOC trong kỳ)
                                        </li>
                                        <li>
                                            <a href="#">Class timetable</a>
                                            (Xem thời khóa biểu của một lớp)
                                        </li>
                                        <li>
                                            <a href="ExamSchedules.aspx">View exam schedule </a>
                                            (Xem lịch thi)
                                        </li>
                                    </ul>
                                </td>
                            </tr>
                            <tr>
                                <td class="content-div">
                                    <h4>Feedback(Ý kiến)</h4>
                                    <ul>
                                        <li>
                                            <a href="#">Feedback about teaching</a>
                                            (Ý kiến về việc giảng dạy)
                                        </li>
                                    </ul>
                                </td>
                                <td class="content-div">
                                    <h4>Reports(Báo cáo)</h4>
                                    <ul>
                                        <li>
                                            <a href="Attendance.aspx">Attendance report</a>
                                            (Báo cáo điểm danh)
                                        </li>
                                        <li>
                                            <a href="#">Mark Report</a>
                                            (Báo cáo điểm)
                                        </li>
                                        <li>
                                            <a href="#">Academic Transcript</a>
                                            (Báo cáo điểm)
                                        </li>
                                        <li>
                                            <a href="#">Curriculum</a>
                                            (Khung chương trình)
                                        </li>
                                        <li>
                                            <a href="#">Student Fee</a>
                                            (Tra cứu học phí theo kỳ)
                                        </li>
                                    </ul>
                                </td>
                            </tr>
                            <tr>
                                <td class="content-div">
                                    <h4>Others(Khác)</h4>
                                    <ul>
                                        <li>
                                            <a href="#">View semester, room</a>
                                            (Xem thông tin về học kỳ, phòng)
                                        </li>
                                        <li>
                                            <a href="#">Công nhận và chuyển đổi tín chỉ các học phần của Đại học trực tuyến (FUNiX)</a>
                                        </li>
                                        <li>
                                            <a href="UpdateProfile.aspx">Cập nhật thông tin cá nhân (Update Profile)</a>
                                        </li>
                                        <li>
                                            <a href="#">Xin xác nhận sinh viên</a>
                                        </li>
                                        <li>
                                            <a href="#">Danh sách các môn học lại chờ xếp lớp</a>
                                        </li>
                                        <li>
                                            <a href="#">Giấy khen(Certificate of merit)</a>
                                        </li>
                                    </ul>
                                </td>
                                <td class="content-div">
                                    <h4>Reports(Báo cáo)</h4>
                                    <ul>
                                        <li>
                                            <a href="#">Regulations...</a>
                                        </li>
                                        <li>
                                            <a href="#">Dormitory regulations (Nội quy KTX)</a>
                                        </li>
                                    </ul>
                                </td>
                            </tr>
                            <tr>
                                <td class="content-div">
                                    <h4>Courses on FPTU-Coursera</h4>
                                    <ul>
                                        <li>
                                            <a href="#">Announcement</a>
                                        </li>
                                        <li>
                                            <a href="#">Ask mentor</a>
                                        </li>
                                        <li>
                                            <a href="#">View answer</a>
                                        </li>
                                    </ul>
                                </td>
                                <td class="content-div"></td>
                            </tr>
                        </tbody>
                    </table>
                    <%--</td>--%>
                </div>
            </div>
        </div>
        <div class="contact" style="font-family: Helvetica; font-size: 14px;">
            <br />
            <b>Mọi góp ý, thắc mắc xin liên hệ: </b>
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
        <p style="text-align: center; font-family: Helvetica; font-size: 14px;" class="final">
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
