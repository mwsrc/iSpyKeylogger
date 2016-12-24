<?php
/**
 * Author: https://github.com/rogierkn
 * Date: 14-2-14
 * Time: 18:37
 *
 */

namespace PayPal;


/**
 * Class IPN
 * @package PayPal
 * @description Class to verify IPN payments through PayPal
 * @author https://github.com/rogierkn
 * @copyright (c) 2014 - Rogier Knoester
 *
 * LICENSE
 * ----------------------------------------------------------------------------
 * "THE BEER-WARE LICENSE" (Revision 42):
 * <phk@FreeBSD.ORG> wrote this file. As long as you retain this notice you
 * can do whatever you want with this stuff. If we meet some day, and you think
 * this stuff is worth it, you can buy me a beer in return Poul-Henning Kamp
 * ----------------------------------------------------------------------------
 */

class IPN {

    /*
     *
     * @string $log TRUE if you want the whole communication with PayPal to be logged.
     * NOTE: The check for TRUE/FALSE is made in the log() function
     */
    public $log = FALSE;

    /*
     * @string $logFile the file the log should be put in
     */
    public $logFile = 'IPNLog.txt';

    /*
     * @array $parameters used to store parameters for the class
     */
    private $parameters = array();

    /*
     * @array $ipnVars variables that get returned by PayPal's IPN
     */
    private $ipnVars = array();

    /*
     * @string $response string of PayPal's response
     */
    private $response;

    /*
     * @string $formString string that holds the generated form
     */
    private $formString;

    /*
     * @boolean $sandbox Boolean to check if the requests should be to PayPal's sandbox or live environment
     */
    private $sandbox = FALSE;

    /*
     * @string $live_endpoint endpoint used for live environment
     */
    private $live_endpoint = "https://www.paypal.com/cgi-bin/webscr";

    /*
     * @string $sandbox_endpoint endpoint used for sandbox environment
     */
    private $sandbox_endpoint = "https://www.sandbox.paypal.com/cgi-bin/webscr";

    /*
     * Construct the class
     *
     * @param mixed $parameters optional set parameters for the class
     */
    public function __construct($parameters = NULL, $sandbox = FALSE)
    {
        if(is_array($parameters))
        {
            // Default currency
            $this->parameters['currency_code'] = 'USD';
            // Default "buy now" button text used in the form generation
            $this->parameters['submit'] = 'Buy now';

            foreach($parameters as $key => $val)
            {
                $this->parameters[$key] = $val;
            }
        }

        $this->sandbox = $sandbox;
        return $this;
    }


    public function __get($name)
    {
        if(array_key_exists($name, $this->ipnVars))
        {
            return $this->ipnVars[$name];
        }
        return FALSE;
    }

    /*
     * Returns the data from the transaction sent by PayPal
     *
     * @param boolean @toArray optional pass TRUE if you want an array to be returned
     */
    public function getData($toArray = FALSE)
    {
        if($toArray)
        {
            return $this->ipnVars;
        }
        return (object) $this->ipnVars;
    }

    /*
     * Get the endpoint that will be used
     * @return string
     */
    public function getEndpoint()
    {
        if(!$this->sandbox)
        {
            return $this->live_endpoint;
        }
        return $this->sandbox_endpoint;
    }

    /*
     * Set whether sandbox is true or false
     * @param boolean $sandbox use sandbox, true or false
     */
    public function setSandbox($sandbox = TRUE)
    {
        $this->sandbox = $sandbox;
        return $this;
    }

    /*
     * a cURL function to post the PayPal
     * @param string $postData the data to send in the POST request
     */
    public function postCurl($postData)
    {
        $curlOptions = array(
            CURLOPT_URL => $this->getEndpoint(),
            CURLOPT_POST => TRUE,
            CURLOPT_POSTFIELDS => $postData,
            CURLOPT_TIMEOUT => 30,
            CURLOPT_RETURNTRANSFER => TRUE,
            CURLOPT_HEADER => TRUE
        );

        if($this->sandbox){
            $curlOptions += array(
                CURLOPT_SSL_VERIFYHOST => FALSE,
                CURLOPT_SSL_VERIFYPEER => FALSE
            );
        }

        $ch = curl_init();
        curl_setopt_array($ch, $curlOptions);

        $this->response = curl_exec($ch);
        if(strpos(curl_getinfo($ch, CURLINFO_HTTP_CODE), "200") === FALSE)
        {
            $this->log("cURL HTTP error: ".curl_getinfo($ch, CURLINFO_HTTP_CODE));
            throw new \Exception("Unexpected HTTP code: ".curl_getinfo($ch, CURLINFO_HTTP_CODE));
        }
    }


    /*
     * Verify the transaction
     *
     * @return boolean whether transaction was verified by PayPal
     */
    public function verify()
    {
        $this->log("Starting verify (".date("H:i:s / d-m-Y").") \n _____________");

        if(empty($_POST))
        {
            $this->log('$_POST is empty');
            throw new \Exception("Empty POST data");
        }

        // Return a self-made 200 OK header, as requested by PayPal
        header('X-PHP-Response-Code: 200', true, 200);

        $this->ipnVars = $_POST;

        $postData = 'cmd=_notify-validate';
        $postData .= '&'. file_get_contents('php://input');

        $this->postCurl($postData);

        if(strpos($this->response, 'VERIFIED') !== FALSE)
        {
            $this->log("VERIFIED - Transaction ID: ".$this->txn_id);
            return TRUE;
        }
        elseif(strpos($this->response, 'INVALID') !== FALSE)
        {
            $this->log("INVALID - Transaction ID: ".$this->txn_id);
            return FALSE;
        }

        $this->log("Unkown response from PayPal - Transaction ID: ".$this->txn_id);
        throw new \Exception("Unknown response from PayPal");
    }


    /*
     * Generate a payment form that utilizes PayPal's IPN
     * @param array $parameters All parameters necessary for generating the form, such as price and receiver.
     * @return object
     */
    public function generateForm($parameters)
    {

        foreach($parameters as $key => $val)
        {
            $this->parameters[$key] = $val;
        }

        $this->formString =  '<form name="_xclick" action="' . $this->getEndpoint() . '" method="POST">'; 
        $this->formString .= '<input type="hidden" name="cmd" value="_xclick">';

        foreach($this->parameters as $key => $val)
        {
            // Skip the submit button
            if($key === "submit") { continue; }

            // Opening the HTML element
            $buildString = "<input name='{$key}'";
            if(is_array($val))
            {
                foreach($val as $attribute => $attributeValue)
                {
                    $buildString .= " {$attribute}='{$attributeValue}'";
                }
                if(!array_key_exists('type', $val))
                {
                    $buildString .= " type='text'";
                }
                $buildString .= ">";
            }
            else
            {
                $buildString .= " type='hidden' value='{$val}'>";
            }

            $this->formString .= $buildString;

        }

        // Append the submit button and form closing
        $submitValue = $this->parameters['submit'];
        $this->formString .= "<input type='submit' class='paypalSubmit' name='submit' value='{$submitValue}'>";
        $this->formString .= "</form>";
        return $this;
    }

    /*
     * Print the HTML form
     */
    public function printForm()
    {
        echo $this->formString;
    }

    /*
     * Logging if set to TRUE
     */
    public function log($text)
    {
        if($this->log)
        {
            file_put_contents($this->logFile, "\n" . $text, FILE_APPEND);
        }
    }

}


