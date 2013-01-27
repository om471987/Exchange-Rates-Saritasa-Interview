<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Index.aspx.vb" Inherits="ExchangeRates.VB.Web.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   
    <form id="form1" runat="server">
    <div>
       <div>
         <asp:TextBox ID="StartDate" runat="server"></asp:TextBox>
       </div>
       <div>
         <asp:TextBox ID="EndDate" runat="server"></asp:TextBox>
       </div>
       <div>
       <asp:DropDownList ID="list1" runat="server">
          <asp:ListItem Value="1" Text="Russian ruble" />
          <asp:ListItem Value="2" Text="Euro" />
          <asp:ListItem Value="3" Text="United States dollar" />
          <asp:ListItem Value="4" Text="Pound sterling" />
          <asp:ListItem Value="5" Text="Japanese yen" />
       </asp:DropDownList>
       </div>
       <div>
       <asp:DropDownList ID="list2" runat="server">
          <asp:ListItem Value="1" Text="Russian ruble" />
          <asp:ListItem Value="2" Text="Euro" />
          <asp:ListItem Value="3" Text="United States dollar" />
          <asp:ListItem Value="4" Text="Pound sterling" />
          <asp:ListItem Value="5" Text="Japanese yen" />
       </asp:DropDownList>
       </div>
       <div>
         <asp:Label ID="ErrorLabel" ForeColor="Red" runat="server" Text="" ></asp:Label>
       </div>
       <div>
         <asp:Button ID="SubmitButton" runat="server" Text="Submit" />
       </div>
    </div>
    </form>
   <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.0/themes/base/jquery-ui.css" />
   <script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.0/jquery.min.js"></script>
   <script src="//ajax.googleapis.com/ajax/libs/jqueryui/1.9.2/jquery-ui.min.js"></script>
   <script type="text/javascript">
      $(document).ready(function () {
         var myDate = new Date();
         var prettyDate = (myDate.getMonth() + 1) + '/' + myDate.getDate() + '/' + myDate.getFullYear();
         $('#StartDate').datepicker().val(prettyDate);
         $('#EndDate').datepicker().val(prettyDate);
      });
   </script>
</body>
</html>
