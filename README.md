# 藍新金流串接(C#)

需要注意的點 </br>
1.測試串接網址：https://ccore.newebpay.com/MPG/mpg_gateway </br>
2.到藍新測試平台進行註冊 https://cwww.newebpay.com/ ，取得hash key跟hash IV(有效使用天數30天) </br>
3.在商店資料設定中，開啟欲用的支付方式(本程式使用一次付清信用卡) </br>
4.測試卡號4000-2211-1111-1111（一次付清與分期付款），其他隨意填寫(年月日必須大於現在的年/月) </br>
5.記得替換自己的hash key、hash IV與return url </br>

串接筆記 </br>
1.參數的串接方式為a=123&b=456 </br>
2.POST的出去的參數有4個MerchantID(代號)、TradeInfo(Key及IV進行AES加密)、TradeSha(AES加密後再用Key及IV進行SHA256加密)、Version(程式版本) </br>

加解密與寫法參考於<a href="https://gitlab.com/harrylin/spgateway">此網站<a/> 


