using ECPay.Model;
using ECPay.Payment.Integration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ECPay {
    public partial class ReturnPage : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Request.HttpMethod == "POST") {
                
                List<string> enErrors = new List<string>();
                Hashtable htFeedback = null;
                
                OutputData data = new OutputData(); //回傳資料model
                try {
                    using (AllInOne oPayment = new AllInOne()) {
                        oPayment.HashKey = "5294y06JbISpM5x9";//ECPay 提供的 HashKey
                        oPayment.HashIV = "v77hoKGq4kWxNNIS";//ECPay 提供的 HashIV                    
                        /* 取回付款結果 */
                        enErrors.AddRange(oPayment.CheckOutFeedback(ref htFeedback));
                    }
                    // 取回所有資料
                    if (enErrors.Count() == 0) {
                        /* 支付後的回傳的基本參數 */                        
                        // 取得資料
                        foreach (string szKey in htFeedback.Keys) {
                            switch (szKey) {
                                /* 支付後的回傳的基本參數 */
                                case "CustomField1": data.CustomField1 = htFeedback[szKey].ToString(); break;
                                case "CustomField2": data.CustomField2 = htFeedback[szKey].ToString(); break;
                                case "CustomField3": data.CustomField3 = htFeedback[szKey].ToString(); break;
                                case "MerchantID": data.szMerchantID = htFeedback[szKey].ToString(); break;
                                case "MerchantTradeNo": data.szMerchantTradeNo = htFeedback[szKey].ToString(); break;
                                case "PaymentDate": data.szPaymentDate = htFeedback[szKey].ToString(); break;
                                case "PaymentType": data.szPaymentType = htFeedback[szKey].ToString(); break;
                                case "PaymentTypeChargeFee": data.szPaymentTypeChargeFee = htFeedback[szKey].ToString(); break;
                                case "RtnCode": data.szRtnCode = htFeedback[szKey].ToString(); break;
                                case "RtnMsg": data.szRtnMsg = htFeedback[szKey].ToString(); break;
                                case "SimulatePaid": data.szSimulatePaid = htFeedback[szKey].ToString(); break;
                                case "TradeAmt": data.szTradeAmt = htFeedback[szKey].ToString(); break;
                                case "TradeDate": data.szTradeDate = htFeedback[szKey].ToString(); break;
                                case "TradeNo": data.szTradeNo = htFeedback[szKey].ToString(); break;
                                default: break;
                            }
                        }                        
                    }
                    else {
                        // 其他資料處理。
                    }
                }
                catch (Exception ex) {
                    // 例外錯誤處理。
                    enErrors.Add(ex.Message);
                }
                finally {
                    this.Response.Clear();

                    // 回覆成功訊息。   
                    string json = new JavaScriptSerializer().Serialize(data); ;
                    var message = enErrors.Count() == 0 ? "交易成功!" : "交易發生錯誤!";
                    this.Response.Write(json);
                    this.Response.Write("<script type=\"text/javascript\">");
                    this.Response.Write(string.Format("alert('{0}');", message));                    
                    this.Response.Write("</script>");
                    this.Response.Flush();
                    this.Response.End();
                }
            }
        }
    }    
}