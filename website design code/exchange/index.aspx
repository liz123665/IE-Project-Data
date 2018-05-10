<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="IE5120.exchange.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="Developed By M Abdur Rokib Promy">
    <meta name="author" content="cosmic">
    <meta name="keywords" content="Bootstrap 3, Template, Theme, Responsive, Corporate, Business">
    <link rel="shortcut icon" href="img/favicon.png">
    <link href="../css/main.css" rel="stylesheet" />
    <title>
      CulKeeper
    </title>

    <!-- Bootstrap core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/theme.css" rel="stylesheet">
    <link href="css/bootstrap-reset.css" rel="stylesheet">
    <!-- <link href="css/bootstrap.min.css" rel="stylesheet">-->

    <!--external css-->
    <link href="assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/flexslider.css"/>
    <link href="assets/bxslider/jquery.bxslider.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/animate.css">
    <link rel="stylesheet" href="assets/owlcarousel/owl.carousel.css">
    <link rel="stylesheet" href="assets/owlcarousel/owl.theme.css">

    <link href="css/superfish.css" rel="stylesheet" media="screen">
    <link href='http://fonts.googleapis.com/css?family=Lato' rel='stylesheet' type='text/css'>
    <!-- <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css'> -->

    <link rel="icon" href="../indexcss/images/ICON.png" type="images/x-icon" />

    <!-- Custom styles for this template -->
    <link rel="stylesheet" type="text/css" href="css/component.css">
    <link href="css/style.css" rel="stylesheet">
    <link href="css/style-responsive.css" rel="stylesheet" />

    <link rel="stylesheet" type="text/css" href="css/parallax-slider/parallax-slider.css" />
    <script type="text/javascript" src="js/parallax-slider/modernizr.custom.28468.js">
    </script>

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 tooltipss and media queries -->
    <!--[if lt IE 9]>
    <script src="js/html5shiv.js">
    </script>
    <script src="js/respond.min.js">
    </script>
    <![endif]-->
</head>
<body>
    <form id="form1" runat="server">
    <!--header start-->
    <header class="head-section">
      <div class="navbar navbar-default navbar-static-top container">
          <div class="navbar-header">
              <button class="navbar-toggle" data-target=".navbar-collapse" data-toggle="collapse" type="button">
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
              </button>
              <a class="navbar-brand" href="index.aspx"><img src="../indexcss/images/ICON.png" style="width:40px; display:inline" /></a>
              <a class="navbar-brand" href="index.aspx">Cul<span>Keeper</span></a>
          </div>
          <div class="navbar-collapse collapse">
              <ul class="nav navbar-nav">
                  <li>

                      <a href="index.aspx"><span class="glyphicon glyphicon-home"></span> Home</a>
                  </li>                  
                  <li>
                      <a href="Culture.aspx"><span class="glyphicon glyphicon-tasks"></span> Explore your location</a>
                  </li>
                  <li>
                      <a href="../events_china.html"><span class="glyphicon glyphicon-map-marker"></span> Cultural Events</a>
                  </li>
                  <li>
                      <a href="Introduction.aspx"><span class="glyphicon glyphicon-book"></span> Books Exchange Market</a>
                  </li>
                  <li class="dropdown">
                      <div id="google_translate_element"></div><script type="text/javascript">
                        function googleTranslateElementInit() {
                         new google.translate.TranslateElement({pageLanguage: 'en', includedLanguages: 'hi,it,zh-CN'}, 'google_translate_element');
                         }
                        </script>
                      <script type="text/javascript" src="//translate.google.com/translate_a/element.js?cb=googleTranslateElementInit">
                      </script>
                  </li>
              </ul>
          </div>
      </div>
    </header>
    <!--header end-->

    <!-- Sequence Modern Slider -->
    <div id="da-slider" class="da-slider">
            <div class="da-slide">
            <div class="container">                
                <div class="row">
                <div class="col-md-12">
              <h2>
                Explore Your Culture
              </h2>
              <p style="margin-top:-10%;height:auto;width:96%">
                  Australia is a country with many immigrants, 
                  some of the immigants do not want their culture and language                  
                  to disappear in the course of their integration into Australia society,                  
                  and they try to preserve their language and culture through various ways.
              </p>
              <a href="Culture.aspx" class="btn btn-info btn-lg da-link" style="width:auto;height:auto;margin-top:auto">
                Click here to explore your suburb
              </a>
            </div>
          </div>
            </div>

        </div>
      </div>


    <div class="container">
      <div class="row mar-b-50">
        <div class="col-md-12">
          <div class="text-center feature-head wow fadeInDown">
            <b><h1 class="" style="color:black">
              Welcome to CulKeeper
            </h1>
                </b>
          </div>
          <div class="feature-box">
            <div class="col-md-4 col-sm-4 text-center wow fadeInUp">
              <div class="feature-box-heading">
                <em>
                    <a href="Dashboard.aspx">
                        <img src="img/dashboard.jpg" alt="" width="100" height="100" />
                    </a>
                </em>
                <h4>
                    <a href="Culture.aspx"><b>Explore your suburb</b></a>                  
                </h4>
              </div>
              <p class="text-center">
                Click here to find government primary schools,
                  libraries resources, Saturday schools and 
                  religious places in your culture by suburb.
              </p>
            </div>
            <div class="col-md-4 col-sm-4 text-center wow fadeInUp">
              <div class="feature-box-heading">
                <em>
                    <a href="Events.aspx">
                        <img src="img/events.png" alt="" width="100" height="100" />
                    </a>
                </em>
                <h4>
                  <a href="Events.aspx"><b>Cultural Events</b></a>
                </h4>
              </div>
              <p class="text-center">
                Click here to find out more about the cultural events taking place in Victoria.
                  Explore different cultural events with your family.
              </p>
            </div>
            <div class="col-md-4 col-sm-4 text-center wow fadeInUp">
              <div class="feature-box-heading">
                <em>
                    <a href="ExchangeHomepage.aspx">
                        <img src="img/books.png" alt="" width="100" height="100" />
                    </a>
                </em>
                <h4>
                  <a href="ExchangeHomepage.aspx"><b>Book Exchange Market</b></a>
                </h4>
              </div>
              <p class="text-center">
                Click here to participant in culture book exchange program.
                  Book exchange program provides you a platform to exchange 
                  books with others people of same or different culture.
              </p>
            </div>
          </div>

          <!--feature end-->
        </div>
      </div>
    </div>
        <footer class="footer-small">
        <div class="container">
            <div class="row">
                
                <div class="col-md-4">
                  <div class="copyright"> <p>Copyright &copy; 2018&nbsp IT&nbsp MANIACS.</p>
                  </div>
                </div>
            </div>
        </div>
    </footer>
    <!--small footer end-->

    <!-- js placed at the end of the document so the pages load faster
<script src="js/jquery.js">
</script>
-->
    <script src="js/jquery-1.8.3.min.js">
    </script>
    <script src="js/bootstrap.min.js">
    </script>
    <script type="text/javascript" src="js/hover-dropdown.js">
    </script>
    <script defer src="js/jquery.flexslider.js">
    </script>
    <script type="text/javascript" src="assets/bxslider/jquery.bxslider.js">
    </script>

    <script type="text/javascript" src="js/jquery.parallax-1.1.3.js">
    </script>
    <script src="js/wow.min.js">
    </script>
    <script src="assets/owlcarousel/owl.carousel.js">
    </script>

    <script src="js/jquery.easing.min.js">
    </script>
    <script src="js/link-hover.js">
    </script>
    <script src="js/superfish.js">
    </script>
    <script type="text/javascript" src="js/parallax-slider/jquery.cslider.js">
    </script>
    <script type="text/javascript">
      $(function() {

        $('#da-slider').cslider({
          autoplay    : true,
          bgincrement : 100
        });

      });
    </script>



    <!--common script for all pages-->
    <script src="js/common-scripts.js">
    </script>

    <script type="text/javascript">
      jQuery(document).ready(function() {


        $('.bxslider1').bxSlider({
          minSlides: 5,
          maxSlides: 6,
          slideWidth: 360,
          slideMargin: 2,
          moveSlides: 1,
          responsive: true,
          nextSelector: '#slider-next',
          prevSelector: '#slider-prev',
          nextText: 'Onward →',
          prevText: '← Go back'
        });

      });


    </script>


    <script>
      $('a.info').tooltip();

      $(window).load(function() {
        $('.flexslider').flexslider({
          animation: "slide",
          start: function(slider) {
            $('body').removeClass('loading');
          }
        });
      });

      $(document).ready(function() {

        $("#owl-demo").owlCarousel({

          items : 4

        });

      });

      jQuery(document).ready(function(){
        jQuery('ul.superfish').superfish();
      });

      new WOW().init();


    </script>
    </form>
</body>
</html>
