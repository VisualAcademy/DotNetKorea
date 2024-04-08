<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard/DashboardCore.Master" AutoEventWireup="true" CodeBehind="My.aspx.cs" Inherits="MemoEngine.My" %>

<%@ Register Src="~/Supports/Controls/MySummaryControl.ascx" TagPrefix="uc1" TagName="MySummaryControl" %>
<%@ Register Src="~/Supports/Controls/MySummaryControl2.ascx" TagPrefix="uc1" TagName="MySummaryControl2" %>
<%@ Register Src="~/Supports/Controls/MySummaryControl3.ascx" TagPrefix="uc1" TagName="MySummaryControl3" %>
<%@ Register Src="~/Supports/Controls/MySummaryControl4.ascx" TagPrefix="uc1" TagName="MySummaryControl4" %>
<%@ Register Src="~/Supports/Controls/MySummaryControl5.ascx" TagPrefix="uc1" TagName="MySummaryControl5" %>
<%@ Register Src="~/Supports/Controls/MySummaryControl6.ascx" TagPrefix="uc1" TagName="MySummaryControl6" %>






<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Breadcrumb-->
    <ol class="breadcrumb">
        <li class="breadcrumb-item">Home</li>
        <li class="breadcrumb-item active">MyPage</li>
        <!-- Breadcrumb Menu-->
        <li class="breadcrumb-menu d-md-down-none">
            <div class="btn-group" role="group" aria-label="Button group">
                <a class="btn" href="#">
                    <i class="icon-speech"></i>
                </a>
                <a class="btn" href="./">
                    <i class="icon-graph"></i>Dashboard</a>
                <a class="btn" href="#">
                    <i class="icon-settings"></i>Settings</a>
            </div>
        </li>
    </ol>

    <div class="container-fluid">
        <div class="animated fadeIn">

            <div class="row">
                <div class="col-sm-12 col-md-12">
                    <div class="card">
                        <div class="card-body">
                            <h2>MyPage</h2>
                            <hr />
                            <h4><%= Session["UserName"].ToString() %>님 반갑습니다.</h4>
                        </div>
                    </div>
                </div>
            </div>

            <uc1:MySummaryControl runat="server" ID="MySummaryControl" />

            <uc1:MySummaryControl2 runat="server" ID="MySummaryControl2" />

            <uc1:MySummaryControl3 runat="server" ID="MySummaryControl3" />

            <uc1:MySummaryControl4 runat="server" ID="MySummaryControl4" />

            <uc1:MySummaryControl5 runat="server" ID="MySummaryControl5" />

            <uc1:MySummaryControl6 runat="server" ID="MySummaryControl6" />


        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
