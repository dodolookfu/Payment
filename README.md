# 綠界金流串接(C#)
串接筆記 </br>
1.ECPay.Payment是綠界提供的範例程式 </br>
2.綠界有滿完整的範例程式可以參考，包含檢查碼、傳送需要的類別model都有 </br>
3.串接一樣是a=123&b=456的方式進行，但是他所需要的加解密方法都有提供 </br>
4.有修改的部分是組合html並POST的部分，改用FormPost這個類別去進行 </br>
5.因為他會去抓範例中.aspx本身的form，所以裡面有預留一個id為form1的form(否則無法順利進行) </br>
6.記得修改return url，KEY跟IV都是測試用的卡號在綠界API的PDF中也有，但使用ATM進行測試付款可以教快速的進行測試(選擇台新) </br>

佛心範本跟PDF
<a href="https://www.ecpay.com.tw/Content/files/ecpay_011.pdf">PDF</a>
<a href="https://www.ecpay.com.tw/Service/API_Dwnld">SDK</a>
