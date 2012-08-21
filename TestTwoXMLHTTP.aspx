<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TestTwoXMLHTTP.aspx.vb" Inherits="TestTwoXMLHTTP" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function f1() {
            httpObj = new XMLHttpRequest();
            httpObj.onreadystatechange = function () {
                if (httpObj.readyState == 4 && httpObj.status == 200) {
                    document.getElementById("tb1").innerHTML = httpObj.responseText;
                }
            }
            httpObj.open("get", "./TestGetTime.aspx", true);
            httpObj.send(null); 
        }
        function f2() {
            httpObj = new XMLHttpRequest();
            httpObj.onreadystatechange = function () {
                if (httpObj.readyState == 4 && httpObj.status == 200) {
                    document.getElementById("tb2").innerHTML = httpObj.responseText;
                }
            }
            httpObj.open("get", "./TestGetTime2.aspx", true);
            httpObj.send(null);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input type="button" value="1" onclick="f1()" />
    <div id="tb1"></div>
    <hr />

    <input type="button" value="2" onclick="f2()" />
    <div id="tb2"></div>
    
    </div>
    </form>
</body>
</html>
