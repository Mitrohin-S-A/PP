<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="WebApplication.Employee" %>
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

    <!-- Форма просмотра данных о пользователе -->
    <div style="margin-top:55px;">

    <!-- Alert -->
    <div id="SuccessDelete" visible="false" runat="server">
        <div class="alert alert-success alert-dismissible fade show" role="alert">
            <strong>Выполнено!</strong> Запись удалена
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                <span aria-hidden="true">&times;</span>
            </button>
        </div>
    </div>
    <div id="WarningDelete" visible="false" runat="server">
        <div class="alert alert-warning alert-dismissible fade show" role="alert">
            <strong>Ошибка!</strong> Вы не выбрали сотрудника!
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                <span aria-hidden="true">&times;</span>
            </button>
        </div>
    </div>
        <div id="SuccessUpdate" visible="false" runat="server">
        <div class="alert alert-success alert-dismissible fade show" role="alert">
            <strong>Выполнено!</strong> Запись изменина
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                <span aria-hidden="true">&times;</span>
            </button>
        </div>
    </div>
    <div id="WarningUpdate" visible="false" runat="server">
        <div class="alert alert-warning alert-dismissible fade show" role="alert">
            <strong>Ошибка!</strong> Ошибка во время выполнения
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                <span aria-hidden="true">&times;</span>
            </button>
        </div>
    </div>


        <div class="text-center" runat="server" id="divLabel">
            <label style="font-family:Arial; font-size:48px">Сотрудники</label>
        </div>
        <div>

            <br />

            <!-- Поисковая строка -->
            <div class="form-inline d-flex justify-content-center md-form form-sm container" style="width:400px" runat="server" id="divSearch">
                <asp:TextBox ID="tbSearch" runat="server" CssClass="form-control form-control-sm mr-3 w-75" type="text" placeholder="Поиск.." aria-label="Search"></asp:TextBox>
                <asp:ImageButton ID="ibSearch" runat="server" AlternateText="Поиск данных" ImageAlign="Left" ImageUrl="~/Source/Image/Buttons/Search.png" OnClick="ibSearch_Click"/>
            </div>

            <br />

            <!-- Выбранный пользователь -->
            <div class="text-center" runat="server" id="divSelected">
                <asp:Label ID="lblChoose" runat="server" Text="Выбран:" Font-Size="14"></asp:Label>
                <asp:Label ID="lblSelected" runat="server" Font-Size="14"></asp:Label>
            </div>

            <!-- Поля для изменения данных -->
            <div class="container" runat="server" visible="false" id="divUpdate">
                <div class="card">
                    <div class="card-body md-form mt-0">
                        <div class="card-header text-center" style="font-family:Arial; font-weight:bold; font-size:48px">Изменить данные сотрудника</div>
                        <div>
                            <div class="row">
                                <div class="col">
                                    <asp:TextBox ID="tbSurname_Employee" runat="server" CssClass="form-control mt-2 mb-2" placeholder="Фамилия сотрудника"></asp:TextBox>
                                </div>
                                <div class="col">
                                    <asp:TextBox ID="tbName_Employee" runat="server" CssClass="form-control mt-2 mb-2" placeholder="Имя сотрудника"></asp:TextBox>
                                </div>
                                <div class="col">
                                    <asp:TextBox ID="tbMiddlename_Employee" runat="server" CssClass="form-control mt-2 mb-2" placeholder="Отчество сотрудника"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <asp:TextBox ID="tbLogin" runat="server" CssClass="form-control mt-2 mb-2" placeholder="Логин"></asp:TextBox>
                                </div>
                                <div class="col">
                                    <asp:TextBox ID="tbPassword" runat="server" CssClass="form-control mt-2 mb-2" placeholder="Пароль"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <asp:TextBox ID="tbPhone_Number" runat="server" ClientIDMode="Static" CssClass="form-control mt-2 mb-2" placeholder="+7 (999) 999-99-99"></asp:TextBox>
                                </div>
                                <div class="col">
                                    <asp:TextBox ID="tbMail" runat="server" TextMode="Email" CssClass="form-control mt-2 mb-2" placeholder="Почта сотрудника"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <asp:DropDownList runat="server" ID="dlPosition" CssClass="form-control mt-2 mb-2">
                                        <asp:ListItem Selected="true">Программист</asp:ListItem>
                                        <asp:ListItem>Дизайнер</asp:ListItem>
                                        <asp:ListItem>Тестировщик</asp:ListItem>
                                        <asp:ListItem>Аналитик</asp:ListItem>
                                        <asp:ListItem>Тимлидер</asp:ListItem>
                                        <asp:ListItem>Эксперт</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col">
                                    <asp:DropDownList runat="server" ID="dlRole" CssClass="form-control mt-2 mb-2">
                                        <asp:ListItem Selected="True">Сотрудник</asp:ListItem>
                                        <asp:ListItem>Администратор</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <asp:Button ID="btUpdate" runat="server" CssClass="btn btn-outline-secondary m-auto" Width="300" Text="Изменить" OnClick="btUpdate_Click"/>
                            </div>
                            <div class="row" style="margin-top:5px">
                                <asp:Button ID="btCancel" runat="server" CssClass="btn btn-outline-secondary m-auto" Width="300" Text="Отменить" OnClick="btCancel_Click"/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="container">

                <!-- Кнопки -->
                <div runat="server" id="divButton">
                    <asp:ImageButton ID="ibInsert" runat="server" AlternateText="Добавить данные" ImageAlign="Left" ImageUrl="~/Source/Image/Buttons/Insert.png" CssClass="Insert" ToolTip="Добавить данные" OnClick="ibInsert_Click"/>
                    <asp:ImageButton ID="ibDelete" runat="server" AlternateText="Просмотр данных" ImageAlign="Right" ImageUrl="~/Source/Image/Buttons/Delete.png" CssClass="Delete" ToolTip="Удалить данные" OnClick="ibDelete_Click"/>
                    <asp:ImageButton ID="ibUpdate" runat="server" AlternateText="Обновить данные" ImageAlign="Right" ImageUrl="~/Source/Image/Buttons/Update.png" CssClass="Update" ToolTip="Обновить данные" OnClick="ibUpdate_Click"/>
                    <asp:ImageButton ID="ibCheck" runat="server" AlternateText="Удалить данные" ImageAlign="Right" ImageUrl="~/Source/Image/Buttons/Check.png" CssClass="Check" ToolTip="Просмотр данны"/>
                </div>

                <!-- Таблица -->
                <div style="margin-top:15px">
                    <asp:GridView ID="gvEmployee" runat="server" AllowSorting="true" CssClass="table table-striped table-bordered" UseAccessibleHeader="true" CurrentSortDirection="ASC" Font-Size="14px" AlternatingRowStyle-Wrap="false" HeaderStyle-HorizontalAlign="Center" OnRowDataBound="gvEmployee_RowDataBound" OnSelectedIndexChanged="gvEmployee_SelectedIndexChanged" OnSorting="gvEmployee_Sorting">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="Black" ForeColor="White" CssClass="Center-text-grid"/>
                        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Center-text-grid"/>
                        <Columns>
                            <asp:CommandField ShowSelectButton ="true" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

    <!-- Маска -->
    <script src="https://cdn.jsdelivr.net/npm/jquery@3.2.1/dist/jquery.min.js" type="text/javascript"></script>
    <script src="https://cdn.jsdelivr.net/npm/jquery.maskedinput@1.4.1/src/jquery.maskedinput.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#tbPhone_Number").mask("+7 (999) 999-99-99");
        });
    </script>
</asp:Content>
