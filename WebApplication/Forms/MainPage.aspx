<%@ Page Title="Главная страница" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="WebApplication.MainPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ddd" ContentPlaceHolderID="body" runat="server">

    <!-- Прелоадер -->
        <div class="preloader" id="preloader">
            <div class="cssload-thecube">
	            <div class="cssload-cube cssload-c1"></div>
	            <div class="cssload-cube cssload-c2"></div>
	            <div class="cssload-cube cssload-c4"></div>
	            <div class="cssload-cube cssload-c3"></div>
            </div>
        </div>

    <!-- Шапка сайта -->
    <div style="margin-top:55px; background: #343a40; font-size: 48px; color: white; font-family: Arial">
        <div class="row">
            <div class="col-xl">
                <label style="margin-left:20px; margin-top:20px; margin-bottom:20px">Федеральное государственное бюджетное образовательное учреждение высшего образования "Российский экономический  университет имени Г.В. Плеханова"</label>
            </div>
        </div>
    </div>

    <!-- Описание вкладок -->
    <div>
        <div class="container text-xl-center">
            <label style="font-size:48px; font-family:Arial">Описание вкладок</label>
        </div>
        <div>
            <div class="card" style="width: 18rem;">
              <canvas id="circlecanvas" width="100" height="100">
                  <i class="fa fa-file-text"></i>
              </canvas>
              <div class="card-body">
                <h5 class="card-title text-center">Заказ</h5>
                <p class="card-text">Производится оценка выполненной работы сотрудника другими лицами по указанным метрикам</p>
              </div>
            </div>
            <div class="card" style="width: 18rem;">
            <canvas id="circlecanvas1" width="100" height="100">
                  <i class="fa fa-users"></i>
              </canvas>
              <div class="card-body">
                <h5 class="card-title text-center">Сотрудники</h5>
                <p class="card-text">Просмотр характеристика сотрудника по результатам его работы</p>
              </div>
            </div>
            <div class="card" style="width: 18rem;">
              <canvas id="circlecanvas2" width="100" height="100">
                  <i class="fa fa-bar-chart"></i>
              </canvas>
              <div class="card-body">
                <h5 class="card-title text-center">Заказ</h5>
                <p class="card-text">Просмотр списка сотрудников, который формируется по их значимости и качеству выполненных работ</p>
              </div>
            </div>
        </div>
    </div>

    <!-- Краткая история -->
    <div style="background: #e9ebea">
        <div class="row" >
            <div class="col-4 m-auto">
                <img src="https://mpt.ru/images/informatsiya-o-tekhnikume/1.jpg" class="rounded" alt="Cinque Terre" style="margin-bottom: 30px; margin-left:20px">
                <img src="https://mpt.ru/images/informatsiya-o-tekhnikume/2.jpg" class="rounded" alt="Cinque Terre" style="margin-top: 30px; margin-right:25px">
            </div>
            <div class="col-8">
                <div class="container text-xl-center">
                    <label style="font-size:48px; font-family:Arial; margin-top:25px">Краткая история</label>
                </div>
                <div style="margin-right:20px">
                    <label style="font-size:18px; font-family:Verdana">1940 год, канун большой войны: требовались специалисты по минному вооружению. При московском заводе «Компрессор» организован машиностроительный техникум. Ускоренно, в 1942 г., в самый разгар войны, техникум выпустил первых специалистов по производству «минных», или, вернее, ракетных установок, получивших впоследствии знаменитое наименование «Катюша».</label>
                    <label style="font-size:18px; font-family:Verdana">Такое боевое начало имеет учебное заведение, которое в 1956 г. было переименовано в Московский приборостроительный техникум и сохранило этот «титул» до сего дня. В том же году одним из первых в системе среднего профессионального образования техникум начал подготовку специалистов по вычислительной технике, и это стало определяющим фактором на все его дальнейшее развитие. За 60 с лишним лет выпущено более 15 тыс. специалистов в машиностроение и приборостроение, в проектные и научные организации, специалистов по вычислительной технике, приборостроению и другим направлениям.</label>
                    <button class="btn btn-outline-secondary" style="margin-bottom:25px">ПОДРОБНЕЕ</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>




