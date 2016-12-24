<!DOCTYPE html>
<html lang="en">
<head>
    <!-- META SECTION -->
    <title>iSpy Keylogger :: Admin - Users</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <link rel="icon" href="favicon.ico" type="image/x-icon" />
    <!-- END META SECTION -->

    <!-- CSS INCLUDE -->
    <link rel="stylesheet" type="text/css" id="theme" href="../css/theme-serenity.css"/>
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
                        <img src="../img/avatar.png" alt="ava"/>
                    </div>
                    <div class="profile-data">
                        <div class="profile-data-name"><?php echo $this->security->xss_clean($username); ?></div>
                        <div class="profile-data-title"><?php if ($this->security->xss_clean($group) == 0) { echo 'Administrator'; } else if ($this->security->xss_clean($group) == 1) { echo 'Standard User'; }; ?></div>
                    </div>
                </div>
            </li>
            <li class="xn-title">Navigation</li>
            <li>
                <a href="../index"><span class="fa fa-home"></span> <span class="xn-text">Dashboard</span></a>
            </li>
            <li>
                <a href="../logs"><span class="fa fa-keyboard-o"></span> <span class="xn-text">My Logs</span></a>
            </li>
            <li class="xn-openable">
                <a href="#"><span class="fa fa-cloud-download"></span> <span class="xn-text">Downloads</span></a>
                <ul>
                    <li><a href="../builder"><span class="xn-text">Builder</span></a></li>
                </ul>
            </li>
            <li>
                <a href="../account"><span class="fa fa-cogs"></span> <span class="xn-text">Account Settings</span></a>
            </li>
            <li>
                <a href="terms"><span class="fa fa-book"></span> <span class="xn-text">Terms Of Service</span></a>
            </li>
            <?php if ($this->security->xss_clean($group) == 0) { ?>
                <li class="active">
                    <a href="../admin/overview"><span class="fa fa-users"></span> <span class="xn-text">Admin</span></a>
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
            <li class="active">Admin - Users
            </li>
        </ul>
        <!-- END BREADCRUMB -->

        <div class="page-title">
            <h2>Admin - Users</h2>
        </div>

        <!-- PAGE CONTENT WRAPPER -->
        <div class="page-content-wrap">

            <div class="row">
                <div class="col-md-4">
                    <div class="list-group border-bottom">
                        <a href="overview" class="list-group-item"><span class="fa fa-bar-chart-o"></span> Overview</a>
                        <a href="users" class="list-group-item active"><span class="fa fa-users"></span> Users</a>
                        <a href="settings" class="list-group-item"><span class="fa fa-cog"></span> Settings</a>
                    </div>
                </div>
                <div class="col-md-8">
                <table class="table datatable_simple table-striped">
                <thead>
                <tr>
                    <th>Username</th>
                    <th>Email</th>
                    <th>Subscription</th>
                    <th>Upload Key</th>
                    <th>Actions</th>
                </tr>
                </thead>
                <tbody>
                <?php foreach ($users as $user) { ?>
                <tr>
                    <td><?php echo $this->security->xss_clean($user->username); ?></td>
                    <td><?php echo $this->security->xss_clean($user->email); ?></td>
                    <?php if ($this->security->xss_clean($user->subscription) == 1) { ?>
                    <td><span class="label label-success">Yes</span></td>
                    <?php } else if ($this->security->xss_clean($user->subscription) == 0) { ?>
                    <td><span class="label label-danger">No</span></td>
                    <?php } ?>
                    <td><?php echo $this->security->xss_clean($user->upload_key); ?></td>
                    <td><i onclick="edituser('<?php echo $this->security->xss_clean($user->uid); ?>', '<?php echo $this->security->xss_clean($user->username); ?>', '<?php echo $this->security->xss_clean($user->email); ?>', '<?php echo $this->security->xss_clean($user->subscription); ?>', '<?php echo $this->security->xss_clean($user->expiration); ?>');" data-original-title="Edit User" class="fa fa-pencil" data-toggle="tooltip" data-placement="top" title=""></i> <i class="fa fa-ban"></i> <i class="fa fa-trash-o"></i></td>
                </tr>
                <?php } ?>
                </tbody>
                </table>
                </div>
            </div>
        </div>
        <!-- END PAGE CONTENT WRAPPER -->
    </div>
    <!-- END PAGE CONTENT -->
</div>
<!-- END PAGE CONTAINER -->
<!-- MESSAGE BOX-->
<div class="modal" id="edituserModal" tabindex="-1" role="dialog" aria-labelledby="defModalHead" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                <h4 class="modal-title" id="defModalHead">Edit User</h4>
            </div>
            <div class="modal-body">
                <form class="form-horizontal">
                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">User ID</label>
                        <div class="col-md-9 col-xs-12">
                                <input id="user_id" type="text" class="form-control" disabled/>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">Username</label>
                        <div class="col-md-9 col-xs-12">
                                <input id="username" type="text" class="form-control"/>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">Email</label>
                        <div class="col-md-9 col-xs-12">
                                <input id="email" type="text" class="form-control"/>
                        </div>
                    </div>
                </form>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
            </div>
        </div>
    </div>
</div>
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
<audio id="audio-alert" src="../audio/alert.mp3" preload="auto"></audio>
<audio id="audio-fail" src="../audio/fail.mp3" preload="auto"></audio>
<!-- END PRELOADS -->

<!-- START SCRIPTS -->
<!-- START PLUGINS -->
<script type="text/javascript" src="../js/plugins/jquery/jquery.min.js"></script>
<script type="text/javascript" src="../js/plugins/jquery/jquery-ui.min.js"></script>
<script type="text/javascript" src="../js/plugins/bootstrap/bootstrap.min.js"></script>
<!-- END PLUGINS -->

<!-- THIS PAGE PLUGINS -->
<script type="text/javascript" src="../js/plugins/mcustomscrollbar/jquery.mCustomScrollbar.min.js"></script>
<script type="text/javascript" src="../js/plugins/datatables/jquery.dataTables.min.js"></script>
<!-- END PAGE PLUGINS -->
<!-- START TEMPLATE -->
<script type="text/javascript" src="../js/plugins.js"></script>
<script type="text/javascript" src="../js/actions.js"></script>
<script>
    function edituser(uid, username, email, subscription, expiration)
    {
        $("#edituserModal").modal("show");
        $("#user_id").val(uid);
        $("#username").val(username);
        $("#email").val(email);
    }
</script>
<!-- END TEMPLATE -->
<!-- END SCRIPTS -->
</body>
</html>