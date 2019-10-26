using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewebPay.Model {
    public class ParameterConfig {

        /// <summary>
        /// 商店代號
        /// </summary>
        public string MerchantID { get; set; }

        /// <summary>
        /// 支付完成 返回商店網址       
        /// </summary>
        public string ReturnURL { get; set; }

        /// <summary>
        /// 支付通知網址      
        /// </summary>
        public string NotifyURL { get; set; }

        /// <summary>
        /// 商店取號網址       
        /// </summary>
        public string CustomerURL { get; set; }

        /// <summary>
        /// 支付取消 返回商店網址        
        /// </summary>
        public string ClientBackURL { get; set; }


        /// <summary>
        /// AES 加密/SHA256 加密 Key
        /// </summary>
        public string HashKey { get; set; }

        /// <summary>
        /// AES 加密/SHA256 加密 IV
        /// </summary>
        public string HashIV { get; set; }

        /// <summary>
        /// 授權網址
        /// </summary>
        public string AuthUrl { get; set; }

        /// <summary>
        /// (取消)請退款網址
        /// </summary>
        public string CloseUrl { get; set; }


        public ParameterConfig(string HashKey, string HashIV) {            
            this.MerchantID = "MS17711113";
            this.HashKey = HashKey;
            this.HashIV = HashIV;
            this.ReturnURL = "http://localhost:1522/ReturnPage.aspx"; //feedback回傳網址          
            this.AuthUrl = "https://ccore.NewebPay.com/MPG/mpg_gateway"; //測試網址
            this.CloseUrl = "";
            this.NotifyURL = "";
            this.CustomerURL = "";
        }
    }
}