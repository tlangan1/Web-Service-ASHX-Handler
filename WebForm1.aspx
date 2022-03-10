<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Web_Service_ASHX_Handler.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="shortcut icon" type="image/jpg" href="favicon.png"/>
</head>
    <script>
        function getData() {
            var url = new URL("https://localhost:44357/HandlerResponseJson.ashx");
            url.searchParams.append("type", "PasswordCode")
            var y = 1;
            var fetchPromise = fetch(url);

            fetchPromise.then(function (resp) {
                console.log(resp)
                return resp.json()
            }).then(function (json) {
                document.getElementById('JsonResponse').innerText = json
            }).catch (function (err) {
                console.log(err)
            });
        }

        function clearData() {
            document.getElementById('JsonResponse').innerText = '';
        }

        console.log('loading the page')
    </script>
<body>
    <div>
        <a href="HandlerResponseFile.ashx">click to get csv file</a>
        <button onclick="getData()">Download data</button>
        <label id="JsonResponse"></label>
        <button onclick="clearData()">Clear data</button>
    </div>
</body>
</html>
