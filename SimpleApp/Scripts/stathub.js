$(function () {
    $.connection.hub.logging = true;
    var myhub = $.connection.statHub;

    myhub.client.addCount = function (count) {
        $('#panelHead').append('<div><strong>' + count + '</strong> has joined the page. <div>');
    };

    //Function to load Patient table's count to the dashboard
    myhub.client.loadPatientStatNumber = function (username, count) {
        if (document.getElementById('patientCount') != null)
            var pcount = document.getElementById('patientCount').innerHTML;

        //Append notification above Dashboard
        if (pcount !== "" && count > pcount) {
            $('#donornotification').append(
                        '<div>' +
                        '    <div class="alert alert-warning" role="alert">' +
                        '        <a href="#" class="close" data-dismiss="alert">&times;</a>' +
                        '        <strong>Patient - </strong><em>' + username + ' </em> has created a new patient.' +
                        '    </div>' +
                        '</div>');
        }

        //Append patient count to the patient board
        $('#patientCount').text(count);

        window.setTimeout(function() {
            $(".alert").fadeTo(500, 0).slideUp(500, function () {
                $(this).remove();
            });
        }, 4000);
    };

    //Function to load Donor table's count to the dashboard
    myhub.client.loadDonorStatNumber = function (username, count) {
        if(document.getElementById('donorCount') != null)
            var dcount = document.getElementById('donorCount').innerHTML;

        //Append notification above Dashboard
        if (dcount !== "" && count > dcount) {
            $('#donornotification').append(
                        '<div>' +
                        '    <div class="alert alert-success" role="alert">' +
                        '        <a href="#" class="close" data-dismiss="alert">&times;</a>' +
                        '        <strong>Donor - </strong><em>' + username + ' </em> has created a new donor.' +
                        '    </div>' +
                        '</div>');
        }

        //Append count to the donor board
        $('#donorCount').text(count);
        $('#transplantCount').text(count);

        window.setTimeout(function () {
            $(".alert").fadeTo(1000, 0).slideUp(1000, function () {
                $(this).remove();
            });
        }, 4000);
    };

    $.connection.hub.start().done(function () {
        //myhub.server.getPatientStat();
        //myhub.server.getDonorStat();
    });

});

$(document).ready(function () {

});
