using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECPay.Model {
    public class OutputData {        
        public string szMerchantID { get; set; }
        public string szMerchantTradeNo { get; set; }
        public string szPaymentDate { get; set; }
        public string szPaymentType { get; set; }
        public string szPaymentTypeChargeFee { get; set; }
        public string szRtnCode { get; set; }
        public string szRtnMsg { get; set; }
        public string szSimulatePaid { get; set; }
        public string szTradeAmt { get; set; }
        public string szTradeDate { get; set; }
        public string szTradeNo { get; set; }
        public string CustomField1 { get; set; }
        public string CustomField2 { get; set; }
        public string CustomField3 { get; set; }    
    }
}