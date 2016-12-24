<!DOCTYPE html>
<html lang="en">
<head>
    <!-- META SECTION -->
    <title>iSpy Keylogger :: Subscribe</title>
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
        <li class="active">
            <a href="subscribe"><span class="fa fa-calendar"></span> <span class="xn-text">Subscribe</span></a>
        </li>
        <li>
            <a><span class="fa fa-book"></span> <span class="xn-text">Terms Of Service</span></a>
        </li>
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
        <li class="active">Subscribe</li>
    </ul>
    <!-- END BREADCRUMB -->

    <div class="page-title">
        <h2><span class="fa fa-calendar"></span> Subscribe</h2>
    </div>

    <!-- PAGE CONTENT WRAPPER -->
    <div class="page-content-wrap">

        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">Plans</h3>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-4">

                                <div class="pricing-block">
                                    <div class="pb-block">
                                        <h3>1 Month - $15</h3>
                                        <p>30 days access to iSpy Keylogger</p>
                                    </div>
                                    <hr />
                                    <div class="pb-block">
                                        <p><span class="fa fa-check"></span> RuneScape Pinlogger</p>
                                        <p><span class="fa fa-check"></span> Multiple Password Recoveries</p>
                                        <p><span class="fa fa-check"></span> No Anti-Virus False Positives</p>
                                        <p><span class="fa fa-check"></span> No Email Required, View Logs From Panel</p>
                                        <p><span class="fa fa-check"></span> Windows XP, Vista, 7 & 8 Support</p>
                                        <p><span class="fa fa-check"></span> Encrypted Logs</p>
                                        <p><span class="fa fa-check"></span> No UAC Needed</p>
                                        <p><span class="fa fa-check"></span> No Port Forwarding Required</p>
                                    </div>
                                    <div class="pb-block">
                                        <form style="display: inline-block" action="https://www.coinpayments.net/index.php" method="post">
                                            <input type="hidden" name="cmd" value="_pay">
                                            <input type="hidden" name="reset" value="1">
                                            <input type="hidden" name="merchant" value="d519eba1265d5b5e86d7e459c7cd7e4f">
                                            <input type="hidden" name="item_name" value="iSpy Keylogger 1 Month Access">
                                            <input type="hidden" name="currency" value="USD">
                                            <input type="hidden" name="amountf" value="15.00">
                                            <input type="hidden" name="quantity" value="1">
                                            <input type="hidden" name="allow_quantity" value="0">
                                            <input type="hidden" name="want_shipping" value="0">
                                            <input type="hidden" name="ipn_url" value="http://ispy.pw/panel/ipn/btc">
                                            <input type="hidden" name="allow_extra" value="0">
                                            <input type="hidden" name="custom" value="<?php echo $this->security->xss_clean($uid); ?>">
                                            <input type='submit' class='btn btn-success btn-sm' name='submit' value='Bitcoin'>
                                        </form>
                                        <form style="display: inline-block" name="_xclick" action="https://www.paypal.com/cgi-bin/webscr" method="POST"><input name='currency_code' type='hidden' value='USD'><input name='business' type='hidden' value='siderow@ymail.com'><input type="hidden" name="cmd" value="_xclick"><input name='item_name' type='hidden' value='iSpy 1 Month'><input name='amount' type='hidden' value='15.00'><input name='custom' type='hidden' value='<?php echo $this->security->xss_clean($uid); ?>'><input name='notify_url' type='hidden' value='http://ispy.pw/panel/ipn/PayPal'><input name='return' type='hidden' value='http://ispy.pw/panel/index'><input name='cancel_return' type='hidden' value='http://ispy.pw/panel/subscribe#cancelled'><input type='submit' class='btn btn-success btn-sm' name='submit' value='PayPal'></form>
                                    </div>
                                </div>

                            </div>
                            <div class="col-md-4">

                                <div class="pricing-block active">
                                    <div class="pb-block">
                                        <h3>3 Months - $28</h3>
                                        <p>90 days access to iSpy Keylogger</p>
                                    </div>
                                    <hr />
                                    <div class="pb-block">
                                        <p><span class="fa fa-check"></span> RuneScape Pinlogger</p>
                                        <p><span class="fa fa-check"></span> Multiple Password Recoveries</p>
                                        <p><span class="fa fa-check"></span> No Anti-Virus False Positives</p>
                                        <p><span class="fa fa-check"></span> No Email Required, View Logs From Panel</p>
                                        <p><span class="fa fa-check"></span> Windows XP, Vista, 7 & 8 Support</p>
                                        <p><span class="fa fa-check"></span> Encrypted Logs</p>
                                        <p><span class="fa fa-check"></span> No UAC Needed</p>
                                        <p><span class="fa fa-check"></span> No Port Forwarding Required</p>
                                    </div>
                                    <div class="pb-block">
                                        <form style="display: inline-block" action="https://www.coinpayments.net/index.php" method="post">
                                            <input type="hidden" name="cmd" value="_pay">
                                            <input type="hidden" name="reset" value="1">
                                            <input type="hidden" name="merchant" value="d519eba1265d5b5e86d7e459c7cd7e4f">
                                            <input type="hidden" name="item_name" value="iSpy Keylogger 3 Months Access">
                                            <input type="hidden" name="currency" value="USD">
                                            <input type="hidden" name="amountf" value="28.00">
                                            <input type="hidden" name="quantity" value="1">
                                            <input type="hidden" name="allow_quantity" value="0">
                                            <input type="hidden" name="want_shipping" value="0">
                                            <input type="hidden" name="ipn_url" value="http://ispy.pw/panel/ipn/btc">
                                            <input type="hidden" name="allow_extra" value="0">
                                            <input type="hidden" name="custom" value="<?php echo $this->security->xss_clean($uid); ?>">
                                            <input type='submit' class='btn btn-success btn-sm' name='submit' value='Bitcoin'>
                                        </form>
                                        <form style="display: inline-block" name="_xclick" action="https://www.paypal.com/cgi-bin/webscr" method="POST"><input name='currency_code' type='hidden' value='USD'><input name='business' type='hidden' value='siderow@ymail.com'><input type="hidden" name="cmd" value="_xclick"><input name='item_name' type='hidden' value='iSpy 3 Months'><input name='amount' type='hidden' value='28.00'><input name='custom' type='hidden' value='<?php echo $this->security->xss_clean($uid); ?>'><input name='notify_url' type='hidden' value='http://ispy.pw/panel/ipn/PayPal'><input name='return' type='hidden' value='http://ispy.pw/panel/index'><input name='cancel_return' type='hidden' value='http://ispy.pw/panel/subscribe#cancelled'><input type='submit' class='btn btn-success btn-sm' name='submit' value='PayPal'></form>
                                    </div>
                                </div>

                            </div>
                            <div class="col-md-4">

                                <div class="pricing-block">
                                    <div class="pb-block">
                                        <h3>1 Year - $60</h3>
                                        <p>365 days access to iSpy Keylogger</p>
                                    </div>
                                    <hr />
                                    <div class="pb-block">
                                        <p><span class="fa fa-check"></span> RuneScape Pinlogger</p>
                                        <p><span class="fa fa-check"></span> Multiple Password Recoveries</p>
                                        <p><span class="fa fa-check"></span> No Anti-Virus False Positives</p>
                                        <p><span class="fa fa-check"></span> No Email Required, View Logs From Panel</p>
                                        <p><span class="fa fa-check"></span> Windows XP, Vista, 7 & 8 Support</p>
                                        <p><span class="fa fa-check"></span> Encrypted Logs</p>
                                        <p><span class="fa fa-check"></span> No UAC Needed</p>
                                        <p><span class="fa fa-check"></span> No Port Forwarding Required</p>
                                    </div>
                                    <div class="pb-block">
                                        <form style="display: inline-block" action="https://www.coinpayments.net/index.php" method="post">
                                            <input type="hidden" name="cmd" value="_pay">
                                            <input type="hidden" name="reset" value="1">
                                            <input type="hidden" name="merchant" value="d519eba1265d5b5e86d7e459c7cd7e4f">
                                            <input type="hidden" name="item_name" value="iSpy Keylogger 1 Year Access">
                                            <input type="hidden" name="currency" value="USD">
                                            <input type="hidden" name="amountf" value="60.00">
                                            <input type="hidden" name="quantity" value="1">
                                            <input type="hidden" name="allow_quantity" value="0">
                                            <input type="hidden" name="want_shipping" value="0">
                                            <input type="hidden" name="ipn_url" value="http://ispy.pw/panel/ipn/btc">
                                            <input type="hidden" name="allow_extra" value="0">
                                            <input type="hidden" name="custom" value="<?php echo $this->security->xss_clean($uid); ?>">
                                            <input type='submit' class='btn btn-success btn-sm' name='submit' value='Bitcoin'>
                                        </form>

                                        <form style="display: inline-block" name="_xclick" action="https://www.paypal.com/cgi-bin/webscr" method="POST"><input name='currency_code' type='hidden' value='USD'><input name='business' type='hidden' value='siderow@ymail.com'><input type="hidden" name="cmd" value="_xclick"><input name='item_name' type='hidden' value='iSpy 1 Year'><input name='amount' type='hidden' value='60.00'><input name='custom' type='hidden' value='<?php echo $this->security->xss_clean($uid); ?>'><input name='notify_url' type='hidden' value='http://ispy.pw/panel/ipn/PayPal'><input name='return' type='hidden' value='http://ispy.pw/panel/index'><input name='cancel_return' type='hidden' value='http://ispy.pw/panel/subscribe#cancelled'><input type='submit' class='btn btn-success btn-sm' name='submit' value='PayPal'></form>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="panel-footer">
                        <form action="coupon" method="post">

                            <div class="input-group">
                                <input id="code" class="form-control" placeholder="Enter your gift code..." type="text">
                                <span class="input-group-btn">
                                    <button id="redeem" onclick="checkCoupon(); return false;" class="btn btn-default" type="button">Redeem</button>
                                </span>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div style="display: none;" id="error" class="alert alert-danger" role="alert">
                    Sorry, the gift code you entered doesn't seem to exist.
                </div>
                <div style="display: none;" id="success" class="alert alert-success" role="alert">
                    The gift code you entered was valid, you now have a subscription! redirecting to the dashboard...
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
<div class="modal" id="terms" tabindex="-1" role="dialog" aria-labelledby="largeModalHead" aria-hidden="true">
    <div class="modal-dialog modal-lg">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                <h4 class="modal-title" id="largeModalHead">Terms Of Service</h4>
            </div>
            <div class="modal-body">
                <h1> Terms of Service for iSpy Keylogger</h1>
                <p> If you require any more information or have any questions about our Terms of Service, please feel free to contact us by email at <a name="contactlink"></a> <a href="mailto:admin@ispy.pw">admin@ispy.pw</a>.<h2>Introduction</h2>

                <p>These terms and conditions govern your use of this website; by using this website, you accept these terms and conditions in full and without reservation. If you disagree with these terms and conditions or any part of these terms and conditions, you must not use this website.</p>

                <p>You must be at least 18 [eighteen] years of age to use this website.  By using this website and by agreeing to these terms and conditions, you warrant and represent that you are at least 18 years of age.</p>


                <h2>License to use website</h2>
                <p>Unless otherwise stated, www.ispy.pw and/or its licensors own the intellectual property rights published on this website and materials used on www.ispy.pw.  Subject to the license below, all these intellectual property rights are reserved.</p>

                <p>You may view, download for caching purposes only, and print pages, files or other content from the website for your own personal use, subject to the restrictions set out below and elsewhere in these terms and conditions.</p>

                <p>You must not:</p>
                <ul>
                    <li>republish material from this website in neither print nor digital media or documents (including republication on another website);</li>
                    <li>sell, rent or sub-license material from the website;</li>
                    <li>show any material from the website in public;</li>
                    <li>reproduce, duplicate, copy or otherwise exploit material on this website for a commercial purpose;</li>
                    <li>edit or otherwise modify any material on the website;</li>
                    <li>redistribute material from this website - except for content specifically and expressly made available for redistribution; or</li>
                    <li>republish or reproduce any part of this website through the use of iframes or screenscrapers.</li>
                </ul>
                <p>Where content is specifically made available for redistribution, it may only be redistributed within your organisation.</p>

                <h2>Acceptable use</h2>

                <p>You must not use this website in any way that causes, or may cause, damage to the website or impairment of the availability or accessibility of www.ispy.pw or in any way which is unlawful, illegal, fraudulent or harmful, or in connection with any unlawful, illegal, fraudulent or harmful purpose or activity.</p>

                <p>You must not use this website to copy, store, host, transmit, send, use, publish or distribute any material which consists of (or is linked to) any spyware, computer virus, Trojan horse, worm, keystroke logger, rootkit or other malicious computer software.</p>

                <p>You must not conduct any systematic or automated data collection activities on or in relation to this website without www.ispy.pw's express written consent.<br />
                    This includes:
                <ul><li>scraping</li>
                    <li>data mining</li>
                    <li>data extraction</li>
                    <li>data harvesting</li>
                    <li>'framing' (iframes)</li>
                    <li>Article 'Spinning'</li>
                </ul>
                </p>

                <p>You must not use this website or any part of it to transmit or send unsolicited commercial communications.</p>

                <p>You must not use this website for any purposes related to marketing without the express written consent of www.ispy.pw.</p>

                <!-- If password protected areas BEGIN -->
                <h2>Restricted access</h2>

                <p>Access to certain areas of this website is restricted. www.ispy.pw reserves the right to restrict access to certain areas of this website, or at our discretion, this entire website. www.ispy.pw may change or modify this policy without notice.</p>

                <p>If www.ispy.pw provides you with a user ID and password to enable you to access restricted areas of this website or other content or services, you must ensure that the user ID and password are kept confidential. You alone are responsible for your password and user ID security..</p>

                <p>www.ispy.pw may disable your user ID and password at www.ispy.pw's sole discretion without notice or explanation.</p>

                <h2>User content</h2>

                <p>In these terms and conditions, “your user content” means material (including without limitation text, images, audio material, video material and audio-visual material) that you submit to this website, for whatever purpose.</p>

                <p>You grant to www.ispy.pw a worldwide, irrevocable, non-exclusive, royalty-free license to use, reproduce, adapt, publish, translate and distribute your user content in any existing or future media.  You also grant to www.ispy.pw the right to sub-license these rights, and the right to bring an action for infringement of these rights.</p>

                <p>Your user content must not be illegal or unlawful, must not infringe any third party's legal rights, and must not be capable of giving rise to legal action whether against you or www.ispy.pw or a third party (in each case under any applicable law).</p>

                <p>You must not submit any user content to the website that is or has ever been the subject of any threatened or actual legal proceedings or other similar complaint.</p>

                <p>www.ispy.pw reserves the right to edit or remove any material submitted to this website, or stored on the servers of www.ispy.pw, or hosted or published upon this website.</p>

                <p>www.ispy.pw's rights under these terms and conditions in relation to user content, www.ispy.pw does not undertake to monitor the submission of such content to, or the publication of such content on, this website.</p>

                <h2>No warranties</h2>

                <p>This website is provided “as is” without any representations or warranties, express or implied.  www.ispy.pw makes no representations or warranties in relation to this website or the information and materials provided on this website.</p>

                <p>Without prejudice to the generality of the foregoing paragraph, www.ispy.pw does not warrant that:</p>
                <ul>
                    <li>this website will be constantly available, or available at all; or</li>
                    <li>the information on this website is complete, true, accurate or non-misleading.</li>
                </ul>
                <p>Nothing on this website constitutes, or is meant to constitute, advice of any kind.  If you require advice in relation to any legal, financial or medical matter you should consult an appropriate professional.</p>

                <h2>Limitations of liability</h2>

                <p>www.ispy.pw will not be liable to you (whether under the law of contact, the law of torts or otherwise) in relation to the contents of, or use of, or otherwise in connection with, this website:</p>
                <ul>
                    <li>to the extent that the website is provided free-of-charge, for any direct loss;</li>
                    <li>for any indirect, special or consequential loss; or</li>
                    <li>for any business losses, loss of revenue, income, profits or anticipated savings, loss of contracts or business relationships, loss of reputation or goodwill, or loss or corruption of information or data.</li>
                </ul>
                <p>These limitations of liability apply even if www.ispy.pw has been expressly advised of the potential loss.</p>

                <h2>Exceptions</h2>

                <p>Nothing in this website disclaimer will exclude or limit any warranty implied by law that it would be unlawful to exclude or limit; and nothing in this website disclaimer will exclude or limit the liability of iSpy Keylogger in respect of any:</p>
                <ul>
                    <li>death or personal injury caused by the negligence of www.ispy.pw or its agents, employees or shareholders/owners;</li>
                    <li>fraud or fraudulent misrepresentation on the part of www.ispy.pw; or</li>
                    <li>matter which it would be illegal or unlawful for www.ispy.pw to exclude or limit, or to attempt or purport to exclude or limit, its liability.</li>
                </ul>
                <h2>Reasonableness</h2>

                <p>By using this website, you agree that the exclusions and limitations of liability set out in this website disclaimer are reasonable.</p>

                <p>If you do not think they are reasonable, you must not use this website.</p>

                <h2>Other parties</h2>

                <p>You accept that, as a limited liability entity, www.ispy.pw has an interest in limiting the personal liability of its officers and employees.  You agree that you will not bring any claim personally against www.ispy.pw's officers or employees in respect of any losses you suffer in connection with the website.</p>

                <p>Without prejudice to the foregoing paragraph, you agree that the limitations of warranties and liability set out in this website disclaimer will protect www.ispy.pw's officers, employees, agents, subsidiaries, successors, assigns and sub-contractors as well as www.ispy.pw.</p>

                <h2>Unenforceable provisions</h2>

                <p>If any provision of this website disclaimer is, or is found to be, unenforceable under applicable law, that will not affect the enforceability of the other provisions of this website disclaimer.</p>

                <h2>Indemnity</h2>

                <p>You hereby indemnify www.ispy.pw and undertake to keep www.ispy.pw indemnified against any losses, damages, costs, liabilities and expenses (including without limitation legal expenses and any amounts paid by www.ispy.pw to a third party in settlement of a claim or dispute on the advice of www.ispy.pw's legal advisers) incurred or suffered by www.ispy.pw arising out of any breach by you of any provision of these terms and conditions, or arising out of any claim that you have breached any provision of these terms and conditions.</p>

                <h2>Breaches of these terms and conditions</h2>

                <p>Without prejudice to www.ispy.pw's other rights under these terms and conditions, if you breach these terms and conditions in any way, www.ispy.pw may take such action as www.ispy.pw deems appropriate to deal with the breach, including suspending your access to the website, prohibiting you from accessing the website, blocking computers using your IP address from accessing the website, contacting your internet service provider to request that they block your access to the website and/or bringing court proceedings against you.</p>

                <h2>Variation</h2>

                <p>www.ispy.pw may revise these terms and conditions from time-to-time.  Revised terms and conditions will apply to the use of this website from the date of the publication of the revised terms and conditions on this website.  Please check this page regularly to ensure you are familiar with the current version.</p>

                <h2>Assignment</h2>

                <p>www.ispy.pw may transfer, sub-contract or otherwise deal with www.ispy.pw's rights and/or obligations under these terms and conditions without notifying you or obtaining your consent.</p>

                <p>You may not transfer, sub-contract or otherwise deal with your rights and/or obligations under these terms and conditions.</p>

                <h2>Severability</h2>

                <p>If a provision of these terms and conditions is determined by any court or other competent authority to be unlawful and/or unenforceable, the other provisions will continue in effect.  If any unlawful and/or unenforceable provision would be lawful or enforceable if part of it were deleted, that part will be deemed to be deleted, and the rest of the provision will continue in effect.</p>

                <h2>Entire agreement</h2>

                <p>These terms and conditions, together with www.ispy.pw's Privacy Policy constitute the entire agreement between you and www.ispy.pw in relation to your use of this website, and supersede all previous agreements in respect of your use of this website.</p>

                <h2>Law and jurisdiction</h2>

                <p>These terms and conditions will be governed by and construed in accordance with the laws of NEVADA, USA, and any disputes relating to these terms and conditions will be subject to the exclusive jurisdiction of the courts of NEVADA, USA.</p>

                <h2>About these website Terms of Service</h2>
                <p>We created these website terms and conditions using the TOS/T&C generator available from <a href="http://www.PrivacyPolicyOnline.com">Privacy Policy Online</a>.
                </p>












                <h2>www.ispy.pw's details</h2>

                <p>The full name of www.ispy.pw is iSpy Keylogger.</p>




                <p>
                </p>
                <a href="http://www.PrivacyPolicyOnline.com" title="PrivacyPolicyOnline.com Approved Site" target="_blank"><img src="http://www.privacypolicyonline.com/images/privacypolicyonline-seal.png" border="0" alt="Privacy Policy Online Approved Site" align="right" /></a>

                <p>You can contact www.ispy.pw by email at our email address link at the <a href="#contactlink">top of this Terms of Service document</a>.</p>

            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
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
<script type="text/javascript" src="js/gift.js"></script>
<!-- END TEMPLATE -->
<!-- END SCRIPTS -->
</body>
</html>