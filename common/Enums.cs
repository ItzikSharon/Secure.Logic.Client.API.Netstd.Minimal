using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace securelogic.prosigner.client.api.common
{
    public  class Enums
    {
        public enum SIG_PARAM_ID
        {
            CRYPTO_USER_ID = 0,
            CRYPTO_USER_PIN,
            TBS_DATA ,
            FILE_NAME, 
            TOKEN_INDEX,
            SIGTYPE_ID,
            USE_COMPRESSION,

            //Visual Params
            IMAGE_DATA,
            IMAGE_X_POS,
            IMAGE_Y_POS,
            IMAGE_HEIGHT,
            IMAGE_WIDTH,
            FONT_ID,
            FONT_SIZE,
            IMAGE_MODE,

            //X509
            X509_Objects,

            //PDF
            PDF_Reason,
            PDF_Contact,
            PDF_Location,
            PDF_SigPage,
            PDF_MaxSigCount,


            //General 
            SIGNATURE_POLICY,
            TIMESTAMP_PROVIDER,
        }
    }
}
