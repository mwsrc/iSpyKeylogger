<!DOCTYPE html>
<html lang="en">
<head>
    <!-- META SECTION -->
    <title>iSpy Keylogger :: Terms Of Service</title>
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
            <li class="xn-openable">
                <a href="#"><span class="fa fa-cloud-download"></span> <span class="xn-text">Downloads</span></a>
                <ul>
                    <li><a href="builder"><span class="xn-text">Builder</span></a></li>
                </ul>
            </li>
            <li>
                <a href="account"><span class="fa fa-cogs"></span> <span class="xn-text">Account Settings</span></a>
            </li>
            <li class="active">
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
            <li class="active">Terms Of Service</li>
        </ul>
        <!-- END BREADCRUMB -->

        <div class="page-title">
            <h2><span class="fa fa-cloud-download"></span> Terms Of Service</h2>
        </div>

        <!-- PAGE CONTENT WRAPPER -->
        <div class="page-content-wrap">

            <div class="row">
                <div class="col-sm-12">
                    <font face="verdana">
                        <p>This web page represents a legal document that serves as our Terms of Service and it governs the legal terms of our website, http://ispy.pw, sub-domains, and any associated web-based and mobile applications (collectively, "Website"), as owned and operated by iSpy Software.</p>
                        <p>Capitalized terms, unless otherwise defined, have the meaning specified within the Definitions section below. This Terms of Service, along with our Privacy Policy, any mobile license agreement, and other posted guidelines within our Website, collectively "Legal Terms", constitute the entire and only agreement between you and iSpy Software, and supersede all other agreements, representations, warranties and understandings with respect to our Website and the subject matter contained herein. We may amend our Legal Terms at any time without specific notice to you. The latest copies of our Legal Terms will be posted on our Website, and you should review all Legal Terms prior to using our Website. After any revisions to our Legal Terms are posted, you agree to be bound to any such changes to them. Therefore, it is important for you to periodically review our Legal Terms to make sure you still agree to them.</p>
                        <p>By using our Website, you agree to fully comply with and be bound by our Legal Terms. Please review them carefully. If you do not accept our Legal Terms, do not access and use our Website. If you have already accessed our Website and do not accept our Legal Terms, you should immediately discontinue use of our Website.</p>
                        <p>The last update to our Terms of Service was posted on December 4, 2014.</p><br />

                        <p><strong><u>Definitions</u></strong><br /><br />The terms "us" or "we" or "our" refers to iSpy Software, the owner of the Website.</p>
                        <p>A "Visitor" is someone who merely browses our Website, but has not registered as Member.</p>
                        <p>A "Member" is an individual that has registered with us to use our Service.</p>
                        <p>Our "Service" represents the collective functionality and features as offered through our Website to our Members.</p>
                        <p>A "User" is a collective identifier that refers to either a Visitor or a Member.</p>
                        <p>All text, information, graphics, audio, video, and data offered through our Website are collectively known as our "Content".</p><br />

                        <p><strong><u>Intellectual Property</u></strong><br /><br />Our Website may contain our service marks or trademarks as well as those of our affiliates or other companies, in the form of words, graphics, and logos. Your use of our Website does not constitute any right or license for you to use such service marks/trademarks, without the prior written permission of the corresponding service mark/trademark owner. Our Website is also protected under international copyright laws. The copying, redistribution, use or publication by you of any portion of our Website is strictly prohibited. Your use of our Website does not grant you ownership rights of any kind in our Website.</p><br />

                        <p><strong><u>Links to Other Websites</u></strong><br /><br />Our Website may contain links to third party websites. These links are provided solely as a convenience to you. By linking to these websites, we do not create or have an affiliation with, or sponsor such third party websites. The inclusion of links within our Website does not constitute any endorsement, guarantee, warranty, or recommendation of such third party websites. iSpy Software has no control over the legal documents and privacy practices of third party websites; as such, you access any such third party websites at your own risk.</p><br />

                        <p><strong><u>General Terms</u></strong><br /><br />Our Legal Terms shall be treated as though it were executed and performed in Netherlands, and shall be governed by and construed in accordance with the laws of Netherlands, without regard to conflict of law principles. In addition, you agree to submit to the personal jurisdiction and venue of such courts. Any cause of action by you with respect to our Website, must be instituted within one (1) year after the cause of action arose or be forever waived and barred. Should any part of our Legal Terms be held invalid or unenforceable, that portion shall be construed consistent with applicable law and the remaining portions shall remain in full force and effect. To the extent that any Content in our Website conflicts or is inconsistent with our Legal Terms, our Legal Terms shall take precedence. Our failure to enforce any provision of our Legal Terms shall not be deemed a waiver of such provision nor of the right to enforce such provision. The rights of iSpy Software under our Legal Terms shall survive the termination of our Legal Terms.</p><br />

                        <p><strong><u>Keylogging</u></strong><br /><br />

                        <p> - You must have permission from the owner of the computer to keylog it. Parents may keylog their child's computer.


                        <p> - The Developers and Sellers of this product are not to be held responsible for any of the customers' actions. </p>


                        <p> - We have the right to restrict or limit service at any time with or without notice. Notice will of course be provided however as we're not that type of company. If there is a problem we will let you know. </p>


                        <p> - Please contact our support team regarding any issues and concerns, do not post on the sales thread. Continuing to do so will effectively ban your license.</p>


                        <p> - You are forbidden from sharing or hosting a service with your provided stubs. Any leakers will have their license terminated and their services blacklisted. </p>


                        <p> - All stubs built are not allowed to be scanned on Anti-Virus software that distribute samples as this will cause false detections. </p>


                        <p> - After each sale we request a vouch to authenticate our sales and to have your feedback for others on display. </p>


                        <p> - Refunds will not be acceptable in any matter, shape or form unless granted by us. We will review your case and problems, and decide or fix your keylogger if necessary.  </p>


                        <p> - Chargebacks or disputing your payment without asking for help or any form of communication will end up getting yourself banned on iSpy Keylogger and blacklisted from buying any other software we offer, and the dispute will result in a scam report. </p>
                    </font>
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