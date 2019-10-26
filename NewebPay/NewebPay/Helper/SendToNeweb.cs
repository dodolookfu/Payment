using System;
using System.Reflection;
using System.Text;
using System.Web;
using NewebPay.Helper;
using NewebPay.Model;

namespace NewebPay {
    public class SendToNeweb {

        TradeInfo tradeInfo = new TradeInfo();
        ParameterConfig storeConfig;

        /// <summary>
        /// 藍新付款物件
        /// </summary>
        /// <param name="orderNumber">訂單編號</param>
        /// <param name="amount">金額</param>
        /// <param name="type">String or JSON</param>
        public SendToNeweb(int amount, string iv, string key) {

            storeConfig = new ParameterConfig(key, iv);
            DateTime gtm = new DateTime(1970, 1, 1);//宣告一個GTM時間出來
            DateTime utc = DateTime.UtcNow.AddHours(8);//宣告一個目前的時間
            int timeStamp = Convert.ToInt32(((TimeSpan)utc.Subtract(gtm)).TotalSeconds);

            //商店代號
            tradeInfo.MerchantID = storeConfig.MerchantID;
            //回傳格式
            tradeInfo.RespondType = "String";
            //TimeStamp
            tradeInfo.TimeStamp = timeStamp.ToString();
            //串接程式版本
            tradeInfo.Version = "1.5";
            //商店訂單編號            
            tradeInfo.MerchantOrderNo = "TestOrder" + timeStamp;
            //訂單金額
            tradeInfo.Amt = amount;
            //商品資訊
            tradeInfo.ItemDesc = key+","+iv;
            // 繳費有效期限(適用於非即時交易)
            tradeInfo.ExpireDate = null;
            // 支付完成 返回商店網址
            tradeInfo.ReturnURL = storeConfig.ReturnURL;
            // 支付通知網址
            tradeInfo.NotifyURL = storeConfig.NotifyURL;
            // 商店取號網址
            tradeInfo.CustomerURL = storeConfig.CustomerURL;
            // 支付取消 返回商店網址
            tradeInfo.ClientBackURL = null;
            //付款人電子信箱
            tradeInfo.Email = string.Empty;
            // 付款人電子信箱 是否開放修改(1=可修改 0=不可修改)
            tradeInfo.EmailModify = 0;
            // 商店備註
            tradeInfo.OrderComment = null;
            // 信用卡 一次付清啟用(1=啟用、0或者未有此參數=不啟用)
            tradeInfo.CREDIT = 1; //固定用信用卡
            // WEBATM啟用(1=啟用、0或者未有此參數，即代表不開啟)
            tradeInfo.WEBATM = null;
            // ATM 轉帳啟用(1=啟用、0或者未有此參數，即代表不開啟)
            tradeInfo.VACC = null;
            // 超商代碼繳費啟用(1=啟用、0或者未有此參數，即代表不開啟)(當該筆訂單金額小於 30 元或超過 2 萬元時，即使此參數設定為啟用，MPG 付款頁面仍不會顯示此支付方式選項。)
            tradeInfo.CVS = null;
            // 超商條碼繳費啟用(1=啟用、0或者未有此參數，即代表不開啟)(當該筆訂單金額小於 20 元或超過 4 萬元時，即使此參數設定為啟用，MPG 付款頁面仍不會顯示此支付方式選項。)
            tradeInfo.BARCODE = null;

        }

        /// <summary>
        /// 進行付款
        /// </summary>
        /// <returns></returns>
        public string Checkout() {

            var tradeQueryPara = "";
            foreach (PropertyInfo property in tradeInfo.GetType().GetProperties()) {
                tradeQueryPara += property.Name + "=" + property.GetValue(tradeInfo) + "&";
                //var tradeQueryPara = string.Join("&", tradeData.Select(x => $"{property.Key}={property.Value}"));
            }
            tradeQueryPara = tradeQueryPara.Substring(0, tradeQueryPara.Length - 1);
            //// AES 加密
            var aes = CryptoHelper.EncryptAESHex(tradeQueryPara, storeConfig.HashKey, storeConfig.HashIV);
            //// SHA256 加密
            var sha = CryptoHelper.EncryptSHA256($"HashKey={storeConfig.HashKey}&{aes}&HashIV={storeConfig.HashIV}");

            HttpContext.Current.Response.Clear();

            StringBuilder s = new StringBuilder();
            s.Append("<html>");
            s.AppendFormat("<body onload='document.forms[\"form\"].submit()'>");
            s.AppendFormat("<form name='form' action='{0}' method='post'>", storeConfig.AuthUrl);
            s.AppendFormat("<input type='hidden' name='{0}' value='{1}' />", "TradeInfo", aes);
            s.AppendFormat("<input type='hidden' name='{0}' value='{1}' />", "TradeSha", sha);
            s.AppendFormat("<input type='hidden' name='{0}' value='{1}' />", "Version", tradeInfo.Version);
            s.AppendFormat("<input type='hidden' name='{0}' value='{1}' />", "MerchantID", tradeInfo.MerchantID);
            s.Append("</form></body></html>");
            HttpContext.Current.Response.Write(s.ToString());
            HttpContext.Current.Response.End();

            //沒有順利POST
            return "無法進行付款，請確認訂單金額/編號/回傳格式";
        }

    }
}