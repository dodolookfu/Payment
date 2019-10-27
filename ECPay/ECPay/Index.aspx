<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ECPay.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <script src="https://code.jquery.com/jquery-3.3.1.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" hidden="hidden" runat="server">    
    </form>
    <div class="container mt-3 p-3 border">
        <h1>綠界金流串接</h1>
        <form method="post" action="Index.aspx">    
            <div class="form-group">                
                <label>商品名稱</label>
                <input type="text" name="name" class="form-control" value="手機" />
            </div>
            <div class="form-group">                
                <label>金額</label>
                <input type="number" name="amount" class="form-control" value="5000" />
            </div>
            <button type="submit" id="submit"  class="btn btn-primary">Submit</button>
        </form>
    </div>
</body>
</html>
