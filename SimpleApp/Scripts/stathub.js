$(function () {
    $.connection.hub.logging = true;
    var myhub = $.connection.statHub;

    myhub.client.addCount = function (count) {
        $('#panelHead').append('<div><strong>' + count + '</strong> has joined the page. <div>');
    };

    myhub.client.loadPatientStatNumber = function (count) {
        $('#patientCount').text(count);
    };

    myhub.client.loadDonorStatNumber = function (count) {
        $('#donorCount').text(count);
        $('#transplantCount').text(count);

    };

    $.connection.hub.start().done(function () {
        myhub.server.getPatientStat();
        myhub.server.getDonorStat();
    });

});

$(document).ready(function () {

});
