
$(document).ready(function () {
    $("#btnLoadReport").click(function () {
        ReportManager.LoadReport();
    });
});

var ReportManager = {
    LoadReport: function () {
        var jsonParam = "";
        var serviceUrl = "../OrderReport/GenerateOrderReport/";
        ReportManager.GetReport(serviceUrl, jsonParam, OnFailed);
        function OnFailed(error) {
            alert("Report Load Error!");
        }
    },
    GetReport: function (serviceUrl, jsonParams, ErrorCallback) {
        jQuery.ajax({
            url: serviceUrl,
            async: false,
            type: "POST",
            data: "{" + jsonParams + "}",
            contentType: "application/json; charset=utf-8",
            success: function () {
                window.open('../Report/ReportViewer.aspx', '_newtab');
            },
            error: ErrorCallback
        });
    }
}