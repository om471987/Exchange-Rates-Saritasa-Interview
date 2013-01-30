<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Chart.aspx.vb" Inherits="ExchangeRates.VB.Web.Chart" %>

<%@ Import Namespace="Newtonsoft.Json" %>

<!DOCTYPE html>
<html>
<body>
   <div id="container"></div>
   <form id="form1" runat="server">
      <asp:Button ID="BackButton" runat="server" Text="Back" />
   </form>
</body>
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6.1/jquery.min.js"></script>
<script src="http://code.highcharts.com/highcharts.js"></script>
<script type="text/javascript">
   jQuery(document).ready(function () {
      var chart = new Highcharts.Chart(
        {
           chart: {
              renderTo: "container",
              type: 'line',
              height: 300
           },
           title: {
              text: "Exchange Rates"
           },
           xAxis: {
               //categories: ['2013-01-03', '2013-01-04', '2013-01-05']
               categories: <%= JsonConvert.SerializeObject(chartModel.Dates)%>
           },
           yAxis: {
              title: {
                 text: 'Rate'
              }
           },
           series: [{
               name: "Date",
               //data: [3.124, 5, 234]
               data: <%= JsonConvert.SerializeObject(chartModel.Rates)%>
           }]
        }
        );
   });
</script>
</html>
