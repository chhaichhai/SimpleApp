$(function () {
    $.connection.hub.logging = true;
    var myhub = $.connection.statHub;

    myhub.client.addCount = function (count) {
        $('#panelHead').append('<div><strong>' + count + '</strong> has joined the page. <div>');
    };

    myhub.client.loadStatNumber = function (count) {
        $('#counter').text(count);
    };

    $.connection.hub.start().done(function () {
        myhub.server.getPatientStat();
    });

});

$(document).ready(function () {

});
