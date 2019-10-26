using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewebPay.Model {
    public class TradeInfo {

        /// <summary>
        /// 商店代號
        /// </summary>
        public string MerchantID { get; set; }

        /// <summary>
        /// 回傳格式
        /// <paramm>JSON or String</paramm>
        /// </summary>
        public string RespondType { get; set; }

        /// <summary>
        /// TimeStamp
        /// <param>自從 Unix 纪元（格林威治時間 1970 年 1 月 1 日 00:00:00）到當前時間的秒數。</param>
        /// </summary>
        public string TimeStamp { get; set; }

        /// <summary>
        /// 串接程式版本
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 語系
        /// <param>英文版參數為en、繁體中文版參數為zh-tw</param>
        /// </summary>
        public string LangType { get; set; }

        /// <summary>
        /// 商店訂單編號
        /// <param>限英、數字、_ 格式</param>        
        /// <param>不可重覆。</param>
        /// </summary>
        public string MerchantOrderNo { get; set; }

        /// <summary>
        /// 訂單金額
        /// </summary>
        public int Amt { get; set; }

        /// <summary>
        /// 商品資訊
        /// <param>限制長度為50字。</param>
        /// <param>編碼為Utf-8格式。</param>
        /// <param>請勿使用斷行符號、單引號等特殊符號，避免無法顯示完整付款頁面。</param>
        /// <param>若使用特殊符號，系統將自動過濾。</param>
        /// </summary>
        public string ItemDesc { get; set; }

        /// <summary>
        /// 交易限制秒數
        /// <param>限制交易的秒數，當秒數倒數至0時，交易當做失敗。</param>
        /// <param>僅可接受數字格式。</param>
        /// <param>秒數下限為60秒，當秒數介於1 ~59秒時，會以60秒計算。</param>
        /// <param>秒數上限為900秒，當超過900秒時，會以900秒計算。</param>
        /// <param>若未帶此參數，或是為0時，會視作為不啟用交易限制秒數。</param>
        /// </summary>
        public int TradeLimit { get; set; }

        /// <summary>
        /// 繳費有效期限(適用於非即時交易)
        /// <param>格式為 date('Ymd') ，例：20140620</param>
        /// <param>此參數若為空值，系統預設為7天。自取號時間起算至第7天23:59:59。 例：2014-06-23 14:35:51完成取號，則繳費有效期限為2014-06-29 23:59:59。</param>
        /// <param>可接受最大值為180天。</param>
        /// </summary>
        public string ExpireDate { get; set; }

        /// <summary>
        /// 支付完成 返回商店網址
        /// <param>交易完成後，以 Form Post 方式導回商店頁面。</param>
        /// <param>若為空值，交易完成後，消費者將停留在智付通付款或取號完成頁面。</param>
        /// <param>只接受80與443 Port。</param>
        /// </summary>
        public string ReturnURL { get; set; }

        /// <summary>
        /// 支付通知網址
        /// <param>以幕後方式回傳給商店相關支付結果資料</param>
        /// <param>只接受80與443 Port。</param>
        /// </summary>
        public string NotifyURL { get; set; }

        /// <summary>
        /// 商店取號網址
        /// <param>系統取號後以 form post 方式將結果導回商店指定的網址</param>
        /// <param>此參數若為空值，則會顯示取號結果在智付通頁面。</param>
        /// </summary>
        public string CustomerURL { get; set; }

        /// <summary>
        /// 支付取消 返回商店網址
        /// <param>當交易取消時，平台會出現返回鈕，使消費者依以此參數網址返回商店指定的頁面。</param>
        /// <param>此參數若為空值時，則無返回鈕。</param>
        /// </summary>
        public string ClientBackURL { get; set; }

        /// <summary>
        /// 付款人電子信箱
        /// <param>於交易完成或付款完成時，通知付款人使用。</param>
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 付款人電子信箱 是否開放修改
        /// <param>1可修改 0不可修改</param>
        /// </summary>
        public int EmailModify { get; set; }

        /// <summary>
        /// 智付通會員
        /// <param>0不須登入藍新會員</param>
        /// <param>1須要登入藍新會員</param>
        /// </summary>
        public int LoginType { get; set; }

        /// <summary>
        /// 商店備註
        /// <param>限制長度為300字。</param>
        /// <param>若有提供此參數，將會於MPG頁面呈現商店備註內容。</param>
        /// </summary>
        public string OrderComment { get; set; }

        /// <summary>
        /// 信用卡 一次付清啟用
        /// <param>設定是否啟用信用卡一次付清支付方式。</param>
        /// <param>1啟用</param>
        /// <param>0或者未有此參數不啟用</param>
        /// </summary>
        public int? CREDIT { get; set; }

        /// <summary>
        /// Google Pay 啟用
        /// <param>設定是否啟用Google Pay支付方式。</param>
        /// <param>1啟用</param>
        /// <param>0或者未有此參數=不啟用</param>
        /// </summary>
        public int? ANDROIDPAY { get; set; }

        /// <summary>
        /// Samsung Pay 啟用
        /// <param>設定是否啟用Samsung Pay支付方式。</param>
        /// <param>1啟用</param>
        /// <param>0或者未有此參數=不啟用</param>
        /// </summary>
        public int? SAMSUNGPAY { get; set; }

        /// <summary>
        /// 信用卡 分期付款啟用
        /// <param>此欄位值=1 時，即代表開啟所有分期期別，且不可帶入其他期別參數。</param>
        /// <param>此欄位值為下列數值時，即代表開啟該分期期別。(3=分 3 期功能、6=分 6 期功能、12=分 12 期功能、18=分 18 期功能、24=分 24 期功能、30=分 30 期功能)</param>
        /// <param>同時開啟多期別時，將此參數用"，"(半形)分隔，例如：3,6,12，代表開啟分3、6、12 期的功能。</param>
        /// <param>此欄位值=0或無值時，即代表不開啟分期。</param>
        /// </summary>
        public string InstFlag { get; set; }

        /// <summary>
        /// 信用卡 紅利啟用
        /// <param>設定是否啟用信用卡紅利支付方式。</param>
        /// <param>1啟用</param>
        /// <param>0或者未有此參數=不啟用</param>
        /// </summary>
        public int? CreditRed { get; set; }

        /// <summary>
        /// 信用卡 銀聯卡啟用
        /// <param>設定是否啟用銀聯卡支付方式。</param>
        /// <param>1啟用</param>
        /// <param>0或者未有此參數=不啟用</param>
        /// </summary>
        public int? UNIONPAY { get; set; }

        /// <summary>
        /// WEBATM啟用
        /// <param>設定是否啟用WEBATM支付方式。</param>
        /// <param>1啟用</param>
        /// <param>0 或者未有此參數，即代表不開啟</param>
        /// </summary>
        public int? WEBATM { get; set; }

        /// <summary>
        /// ATM 轉帳啟用
        /// <param>設定是否啟用ATM 轉帳支付方式。</param>
        /// <param>1啟用</param>
        /// <param>0 或者未有此參數，即代表不開啟</param>
        /// </summary>
        public int? VACC { get; set; }

        /// <summary>
        /// 超商代碼繳費啟用
        /// <param>設定是否啟用超商代碼繳費支付方式。</param>
        /// <param>1啟用</param>
        /// <param>0 或者未有此參數，即代表不開啟</param>
        /// <param>當該筆訂單金額小於 30 元或超過 2 萬元時，即使此參數設定為啟用，MPG 付款頁面仍不會顯示此支付方式選項。</param>
        /// </summary>
        public int? CVS { get; set; }

        /// <summary>
        /// 超商條碼繳費啟用
        /// <param>設定是否啟用超商條碼繳費支付方式。</param>
        /// <param>1啟用</param>
        /// <param>0或者未有此參數，即代表不開啟</param>
        /// <param>當該筆訂單金額小於 20 元或超過 4 萬元時，即使此參數設定為啟用，MPG 付款頁面仍不會顯示此支付方式選項。</param>
        /// </summary>
        public int? BARCODE { get; set; }

        /// <summary>
        /// Pay2go 電子錢包啟用
        /// <param>設定是否啟用Pay2go 電子錢包支付方式。</param>
        /// <param>1啟用</param>
        /// <param>0 或者未有此參數，即代表不開啟</param>
        /// </summary>
        public int? P2G { get; set; }

        /// <summary>
        /// 物流啟用
        /// <param>1.使用前，須先登入智付通會員專區啟用物流並設定退貨門市與取貨人相關資訊。
        /// <param>  1啟用超商取貨不付款<param>
        /// <param>  2啟用超商取貨付款<param>
        /// <param>  3啟用超商取貨不付款及超商取貨付款<param>
        /// <param>  0或者未有此參數，即代表不開啟。<param>
        /// <param>2.當該筆訂單金額小於 30 元或大於 2 萬元時，即使此參數設定為啟用，MPG 付款頁面仍不會顯示此支付方式選項。</param>
        /// </summary>
        public int? CVSCOM { get; set; }

    }
}