<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="WebApplication.Registration" %>
<asp:Content ID="cHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="cBody" ContentPlaceHolderID="body" runat="server">

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

    <!-- Форма регистрации -->
    <main class="my-form" style="margin-bottom:40px; margin-top: 55px;">

    <!-- Alert -->
    <div id="Success" visible="false" runat="server">
        <div class="alert alert-success alert-dismissible fade show" role="alert">
            <strong>Выполнено!</strong> Запись добавлена
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

    <!-- Поля -->
    <div class="cotainer" style="margin-top:20px;">
        <div class="row justify-content-center">
            <div class="col-md-8">
                    <div class="card">
                        <div class="card-header text-center" style="font-family:Arial; font-weight:bold; font-size:48px">Регистрация сотрудника</div>
                        <div class="card-body">

                                <!-- Поле Фамилия -->
                                <div class="form-group row">
                                    <label for="Surname_Employee" class="col-md-4 col-form-label text-md-right">Фамилия сотрудника</label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="tbSurname_Employee" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                
                                <!-- Поле Имя -->
                                <div class="form-group row">
                                    <label for="Name_Employee" class="col-md-4 col-form-label text-md-right">Имя сотрудника</label>
                                    <div class="col-md-6">
                                       <asp:TextBox ID="tbName_Employee" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <!-- Поле Отчество -->
                                <div class="form-group row">
                                    <label for="Middlename_Employee" class="col-md-4 col-form-label text-md-right">Отчество сотрудника</label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="tbMiddlename_Employee" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <!-- Поле Логин -->
                                <div class="form-group row">
                                    <label for="Login" class="col-md-4 col-form-label text-md-right">Логин</label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="tbLogin" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <!-- Поле Пароль -->
                                <div class="form-group row">
                                    <label for="Password" class="col-md-4 col-form-label text-md-right">Пароль</label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="tbPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
    
                                <!-- Поле Должность -->
                                <div class="form-group row">
                                    <label for="Positionr" class="col-md-4 col-form-label text-md-right">Должность</label>
                                    <div class="col-md-6">
                                        <asp:DropDownList runat="server" ID="dlPosition" CssClass="form-control">
                                            <asp:ListItem Selected="true">Программист</asp:ListItem>
                                            <asp:ListItem>Дизайнер</asp:ListItem>
                                            <asp:ListItem>Тестировщик</asp:ListItem>
                                            <asp:ListItem>Аналитик</asp:ListItem>
                                            <asp:ListItem>Тимлидер</asp:ListItem>
                                            <asp:ListItem>Эксперт</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                
                                <!-- Поле Номер телефона -->
                                <div class="form-group row">
                                    <label for="Phone_Number" class="col-md-4 col-form-label text-md-right">Номер телефона</label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="tbPhone_Number" runat="server" ClientIDMode="static" CssClass="form-control"  placeholder="+7 (999) 999-99-99"></asp:TextBox>
                                    </div>
                                </div>

                                <!-- Поле Почта -->
                                <div class="form-group row">
                                    <label for="Mail" class="col-md-4 col-form-label text-md-right">E-Mail адрес</label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="tbMail" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <!-- Поле Роль -->
                                <div class="form-group row">
                                    <label for="Role" class="col-md-4 col-form-label text-md-right">Роль</label>
                                    <div class="col-md-6">
                                        <asp:DropDownList runat="server" ID="dlRole" CssClass="form-control">
                                            <asp:ListItem Selected="True">Сотрудник</asp:ListItem>
                                            <asp:ListItem>Администратор</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                    
                                    <!-- Поле Кнопки -->
                                    <div class="text-center" style="margin-bottom:15px">
                                        <div>
                                            <asp:Button ID="btRegister" runat="server" CssClass="btn btn-outline-secondary" Text="Зарегистрировать" OnClick="btRegister_Click" Width="200" />
                                        </div>
                                        <div style="margin-top:5px">
                                            <asp:Button ID="btBack" runat="server" CssClass="btn btn-outline-secondary" Text="Назад" Width="200" OnClick="btBack_Click"/>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
        </main>

    <!-- Маска -->
    <script src="https://cdn.jsdelivr.net/npm/jquery@3.2.1/dist/jquery.min.js" type="text/javascript"></script>
    <script src="https://cdn.jsdelivr.net/npm/jquery.maskedinput@1.4.1/src/jquery.maskedinput.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#tbPhone_Number").mask("+7 (999) 999-99-99");
        });
    </script>
</asp:Content>
