<%@ Page Title="" Language="C#" MasterPageFile="~/UI/MainUi.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="full_project.UI.WebForm2" %>
<asp:content contentplaceholderid="head" runat="server">
 <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" type="text/css" media="screen"/>
    <link href="../My%20Css/Style.css" rel="stylesheet" />
</asp:content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <section id="feature">
        <div class="container">
           <div class="center wow fadeInDown">
                <h2 style="margin-top: 50px">Features</h2>
                <p class="lead">Distributed dealership network analyzer and sales moritoring for automobile company <br/> to ease the analysis and help to make decisions on production and sales cost</p>
            </div>

            <div class="row">
                <div class="features">
                    <div class="col-md-4 col-sm-6 wow fadeInDown" data-wow-duration="1000ms" data-wow-delay="600ms">
                        <div class="feature-wrap">                           
                           <i class="fa fa-link"></i>
                            <h2>Completly Online</h2>
                            <h3>Online application makes it portable</h3>
                        </div>
                    </div><!--/.col-md-4-->

                    <div class="col-md-4 col-sm-6 wow fadeInDown" data-wow-duration="1000ms" data-wow-delay="600ms">
                        <div class="feature-wrap">
                            <i class="fa fa-files-o"></i>
                            <h2>Sales repport</h2>
                            <h3>admin and dealer can easily show sales report</h3>
                        </div>
                    </div><!--/.col-md-4-->

                    <div class="col-md-4 col-sm-6 wow fadeInDown" data-wow-duration="1000ms" data-wow-delay="600ms">
                        <div class="feature-wrap">
                            <i class="fa fa-file"></i>
                            <h2>Generate reports</h2>
                            <h3>The application generate reports based on user choice</h3>
                        </div>
                    </div><!--/.col-md-4-->
                
                    <div class="col-md-4 col-sm-6 wow fadeInDown" data-wow-duration="1000ms" data-wow-delay="600ms">
                        <div class="feature-wrap">
                            <i class="fa fa-shield"></i>
                            <h2>Security</h2>
                            <h3>The application is fully secure based on user role</h3>
                        </div>
                    </div><!--/.col-md-4-->

                    <div class="col-md-4 col-sm-6 wow fadeInDown" data-wow-duration="1000ms" data-wow-delay="600ms">
                        <div class="feature-wrap">
                           <i class="fa fa-cogs" aria-hidden="true"></i>
                            <h2>Dashboard</h2>
                            <h3>The application has a dashboard to control all user access</h3>
                        </div>
                    </div><!--/.col-md-4-->

                    <div class="col-md-4 col-sm-6 wow fadeInDown" data-wow-duration="1000ms" data-wow-delay="600ms">
                        <div class="feature-wrap">
                            <i class="fa fa-tablet" aria-hidden="true"></i>
                            <h2>Device Independent</h2>
                            <h3>It is device independent accessible from any device having internet access</h3>
                        </div>
                    </div><!--/.col-md-4-->
                </div><!--/.services-->
            </div><!--/.row-->    
        </div><!--/.container-->
    </section>
</asp:Content>
