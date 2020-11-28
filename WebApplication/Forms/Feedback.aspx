<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="WebApplication.Forms.Feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:SqlDataSource ID="sdsEmployee" runat="server"></asp:SqlDataSource>

    <!-- Прелоадер -->
    <div class="preloader" id="preloader">
        <div class="cssload-thecube">
            <div class="cssload-cube cssload-c1"></div>
            <div class="cssload-cube cssload-c2"></div>
            <div class="cssload-cube cssload-c4"></div>
            <div class="cssload-cube cssload-c3"></div>
        </div>
    </div>

    <!-- Форма Контактной информации -->
    <main class="my-form" style="margin-bottom: 40px; margin-top: 55px;">

        <!-- Alert -->
        <div id="Success" visible="false" runat="server">
            <div class="alert alert-success alert-dismissible fade show" role="alert">
                <strong>Выполнено!</strong> Сообщение отправлено
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                <span aria-hidden="true">&times;</span>
            </button>
            </div>
        </div>
        <div id="Warning" visible="false" runat="server">
            <div class="alert alert-warning alert-dismissible fade show" role="alert">
                <strong>Ошибка!</strong> Ошибка во время выполнения
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                <span aria-hidden="true">&times;</span>
            </button>
            </div>
        </div>

        <!-- Контактная информация -->
        <div class="container">
            <div class="card">
                <div class="card-body md-form mt-0">
                    <div class="card-header" style="font-size:48px">Написать сообщение</div>
                    <div class="row">
                        <asp:DropDownList ID="dlReason" runat="server" CssClass="form-control mb-2 ml-2 mr-2 mt-2">
                            <asp:ListItem Selected="true">Ошибки/Баги</asp:ListItem>
                            <asp:ListItem>Вопрос</asp:ListItem>
                            <asp:ListItem>Предложения по улучшению</asp:ListItem>
                            <asp:ListItem>Другое</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox id="tbFull_Name" runat="server" CssClass="form-control mb-2 ml-2 mr-2 mt-2" placeholder="ФИО сотрудника"></asp:TextBox>
                        <asp:TextBox id="tbMail" TextMode="Email" runat="server" CssClass="form-control mb-2 ml-2 mr-2 mt-2" placeholder="Почта сотрудника"></asp:TextBox>
                        <asp:TextBox id="tbMessage" TextMode="MultiLine" runat="server" CssClass="form-control mb-2 ml-2 mr-2 mt-2" placeholder="Сообщение..."></asp:TextBox>
                    </div>
                    <div class="text-center">
                        <asp:Button Id="btSend" runat="server" Text="Отправить" Width="180" CssClass="btn btn-outline-secondary" OnClick="btSend_Click"/>
                    </div>
                </div>
            </div>
        </div>
    </main>

</asp:Content>
