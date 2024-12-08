using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace secure.logic.client.api.netstd.minimal.rest.v91
{
    public class APIV91
    {
        public class MESSAGE_REPLY
        {
            public int return_code { get; set; } = (int)RETURN_CODES.SUCCESS;
            public string return_msg { get; set; } = "Success";
            public string extended_msg { get; set; } = string.Empty;
            public string request_uri { get; set; } = string.Empty;
        }

        public class STATUS_REQUEST
        {

        }
        public class STATUS_REPLY : MESSAGE_REPLY
        {
            public string version { get; set; } = string.Empty;
            public string status { get; set; } = string.Empty;
        }

        public class API_LOGIN_REQUEST
        {
            public string api_id { get; set; } = string.Empty;
            public string api_key { get; set; } = string.Empty;
        }
        public class API_LOGIN_REPLY : MESSAGE_REPLY
        {
            public string auth_token { get; set; } = string.Empty;
            public bool use_compression { get; set; } = false;
        }

        public class SIGNER_LOGIN_INIT_REQUEST
        {
            public string crypto_uid { get; set; } = string.Empty;
            public int key_index { get; set; } = 0;
            public int auth_type { get; set; } = 0;  // password =0 (default), PSK-AES256=1, OTP=2
        }
        public class SIGNER_LOGIN_INIT_REPLY : MESSAGE_REPLY
        {
            public string challenge { get; set; } = string.Empty;
            public string iv { get; set; } = string.Empty;
        }


        public class SIGNER_LOGIN_REQUEST
        {
            public string crypto_uid { get; set; } = string.Empty;
            public string access_code { get; set; } = string.Empty;
            public int auth_type { get; set; } = 0;  // password =0 (default), PSK-AES256=1, OTP=2
            public int key_index { get; set; } = 0;

        }
        public class SIGNER_LOGIN_REPLY : MESSAGE_REPLY
        {
            public string signing_token { get; set; } = string.Empty;
        }

        public class SIGN_PDF_REQUEST
        {
            public string cu_id { get; set; } = string.Empty;
            public string cu_pass { get; set; } = string.Empty;
            public int token_index { get; set; } = 0;
            public string value_b64 { get; set; } = string.Empty;
            public string file_name { get; set; } = string.Empty;
            public int sigtype_id { get; set; } = 0;

            //optional
            public string image_b64 { get; set; } = string.Empty;
            public int width { get; set; } = 0;
            public int height { get; set; } = 0;
            public int x_position { get; set; } = 0;
            public int y_position { get; set; } = 0;
            public string reason { get; set; } = string.Empty;
            public int sigcount { get; set; } = 1;
        }

        public class SIGN_PDF_REPLY : MESSAGE_REPLY
        {
            public string value_b64 { get; set; } = string.Empty;
        }
        // ================================  SIGN_CUSTOMS =================================================
        public class SIGN_CUSTOMS_REQUEST
        {
            public string cu_id { get; set; } = string.Empty;
            public string cu_pass { get; set; } = string.Empty;
            public int token_index { get; set; } = 0;
            public string value_b64 { get; set; } = string.Empty;
            public string file_name { get; set; } = string.Empty;
            public int sigtype_id { get; set; } = 0;
        }

        public class SIGN_CUSTOMS_REPLY : MESSAGE_REPLY
        {
            public string value_b64 { get; set; } = string.Empty;
        }

        // ================================  SIGN_XML =================================================
        public class SIGN_XML_REQUEST
        {
            public string cu_id { get; set; } = string.Empty;
            public string cu_pass { get; set; } = string.Empty;
            public int token_index { get; set; } = 0;
            public string value_b64 { get; set; } = string.Empty;
            public string file_name { get; set; } = string.Empty;
            public int sigtype_id { get; set; } = 0;
            public string[] elements { get; set; } = new string[0];
        }

        public class SIGN_XML_REPLY : MESSAGE_REPLY
        {
            public string value_b64 { get; set; } = string.Empty;

        }

        // ================================  TEST_CRED =================================================
        public class SIGN_TEST_REQUEST
        {
            public string cu_id { get; set; } = string.Empty;
            public string cu_pass { get; set; } = string.Empty;
            public int token_index { get; set; } = 0;
        }

        public class SIGN_TEST_REPLY : MESSAGE_REPLY
        {
            public bool login_result { get; set; } = false;
        }



        // ================================  SIGN_HASH =================================================
        public class SIGN_HASH_REQUEST
        {
            public string cu_id { get; set; } = string.Empty;
            public string cu_pass { get; set; } = string.Empty;
            public int token_index { get; set; } = 0;
            public string value_b64 { get; set; } = string.Empty;
            public string file_name { get; set; } = string.Empty;
            public bool fetch_timestamp { get; set; } = false;
        }

        public class SIGN_HASH_REPLY : MESSAGE_REPLY
        {
            public string value_b64 { get; set; } = string.Empty;
            public string timestamp_token { get; set; } = string.Empty;
        }

        // ================================  SIGN_CMS =================================================

        public class SIGN_CMS_REQUEST
        {
            public string cu_id { get; set; } = string.Empty;
            public string cu_pass { get; set; } = string.Empty;
            public int token_index { get; set; } = 0;
            public string tbs_value_b64 { get; set; } = string.Empty;
            public string file_name { get; set; } = string.Empty;
            public int hash_alg { get; set; } = 0;
        }

        public class SIGN_CMS_REPLY : MESSAGE_REPLY
        {
            public string result_b64 { get; set; } = string.Empty;
        }

        public class CONFIG_REQUEST
        {
            public string cu_id { get; set; } = string.Empty;
            public int token_index { get; set; } = 0;
            public int sig_type { get; set; } = 0;
        }


        public class CONFIG_REPLY : MESSAGE_REPLY
        {
            public int x_pos { get; set; }
            public int y_pos { get; set; }
            public int width { get; set; }
            public int heigth { get; set; }
            public string image_b64 { get; set; }
            public string reasone { get; set; }
            public string contact { get; set; }
            public string location { get; set; }
            public int image_only { get; set; } = 0;
            public string sig_page { get; set; }
            public List<string> ChainB64Values;
            public int font_size { get; set; } = 0;
            public string font_id { get; set; } = null;
            public int policy_id { get; set; } = 0;
            public int max_sig_count { get; set; } = 1;

        }

        public class SIGN_CONFIG_REQUEST
        {
            public string cu_id { get; set; } = string.Empty;
            public int token_index { get; set; } = 0;
        }


        public class SIGN_CONFIG_REPLY : MESSAGE_REPLY
        {
            public string user_cert_b64 { get; set; } = string.Empty;
            public string timestamp_token { get; set; } = string.Empty;
        }



        // Key Activation API messages 


        public class KEY_ACTIVATION_KEY_INFO_REQUEST
        {
            public string otp { get; set; } = string.Empty; // otp1
        }

        public class TokenMetaData
        {
            public string id { get; set; } = string.Empty;
            public string status { get; set; } = string.Empty;
        }

        public class KEY_ACTIVATION_KEY_INFO_REPLY : MESSAGE_REPLY
        {
            public TokenMetaData[] tokens_md { get; set; } = new TokenMetaData[0];
        }



        public class KEY_ACTIVATION_KEY_ACTIVATE_REQUEST
        {
            public string token_id { get; set; } = string.Empty;
            public long expiration_ts { get; set; } = 0;
        }

        public class KEY_ACTIVATION_KEY_ACTIVATE_REPLY : MESSAGE_REPLY
        {
        }


        public class KEY_ACTIVATION_SUBMIT_KEY_ACTIVATE_REQUEST
        {
            public string otp { get; set; } = string.Empty; // otp2
        }

        public class KEY_ACTIVATION_SUBMIT_KEY_ACTIVATE_REPLY : MESSAGE_REPLY
        {
        }

        //Password Set 


        public class PASSWORD_SET_REQUEST
        {
            public string access_token { get; set; } = string.Empty;
            public string otp { get; set; } = string.Empty;
            public string pwd { get; set; } = string.Empty;
            public string retype_pwd { get; set; } = string.Empty;
        }

        public class PASSWORD_SET_REPLY : MESSAGE_REPLY
        {
            //TODO
        }


        //=========    User certificate info

        public class USER_TOKEN_INFO_REQUEST
        {
            public string cu_id { get; set; } = string.Empty;
        }

        public class USER_TOKEN_INFO_REPLY : MESSAGE_REPLY
        {
            public string cu_id { get; set; } = string.Empty;
            public List<USER_TOKEN_INFO> user_tokens { get; set; } = new List<USER_TOKEN_INFO>();
        }

        public class USER_TOKEN_INFO
        {
            public string token_id { get; set; } = string.Empty;
            public int token_index { get; set; } = 0;
            public int status { get; set; } = 0;
            public string certificate_subject { get; set; } = string.Empty;
            public string certificate_issuer { get; set; } = string.Empty;
            public DateTime certificate_not_before { get; set; } = DateTime.Now;
            public DateTime certificate_not_after { get; set; } = DateTime.Now;
            public bool certificate_is_valid { get; set; } = false;
        }




        public enum RETURN_CODES
        {
            SUCCESS = 0,
            WRONG_USER_PIN = 1,
            API_LOGIN_FAILURE = 2,
            API_LOGIN_FAILURE_INVALID_KEY = 222,
            API_LOGIN_FAILURE_USER_MISMATCH = 223,
            API_LOGIN_FAILURE_USER_DISABLE = 224,
            API_LOGIN_FAILURE_USER_LOCKED = 225,

            UNKNOWN_ERROR = 3,
            GENERAL_ERROR = 4,
            CLIENT_CONFIG_ERROR = 5,
            SERVER_NOT_AVAILABLE = 6,
            INVALID_FILE_FORMAT = 7,
            INVALID_CRYPTO_USER = 8,
            FILE_SIGNATURE_FAILD = 9,
            INVALID_TOKEN = 10,
            API_LOGOUT_ERROR = 11,
            HSM_DEVICE_ERROR = 12,
            INVALID_REQUEST_PARAMETER = 13,

            //New HSM Token Model 
            INVALID_HSM_TOKEN = 18,
            API_LOGIN_FAILURE_MAX_RETRIES_EXCEEDED = 19,
            //Node Model
            NODE_BAD_CONFIGURATION = 60,
            UNKNOWN_FILE_FORMAT = 70,
            UNSUPPORTED_FILE_FORMAT = 71,
            API_COMPRESSION_ERROR = 72,
            ACCOUNT_SIGNATURE_EXCEEDED = 73,
            FAILD_TO_LOAD_SIGTYPE = 74,


            XMLDSIG_MISSING_ELEMENTS = 75,

            //Access Token
            INVALID_ACCESS_TOKEN = 80,
            RESET_PASSWORD_ERROR = 81,
        }
    }
}
