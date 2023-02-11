// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// lets create new row for adding new developer
$(function() {
    $("#addmore").click(function (e) {
        e.preventDefault();
        // lets find the last row
        var $tblnew = $("#tblCreateNew");
        var $trLast = $tblnew.find("tr:last");
        var $trNew = $trLast.clone();
        var $suffix = $trNew.find(":input:first").attr("name").match(/\d+/);
        $.each($trNew.find(":input"), function (i, val) {
            var $oldName = $(this).attr("name");
            var $NewName = $oldName.replace("[" + $suffix + "]", "[" + (parseInt($suffix) + 1) + "]");

            $(this).attr("name", $NewName);
        });
        $trLast.after($trNew);
    });
});