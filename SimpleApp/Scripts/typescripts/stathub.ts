interface SignalR {
    statHub: IStatHubProxy;
}
interface IStatHubProxy {
    client: IStatHubClient;
    server: IStatHubServer;
}
interface IStatHubClient {
    loadPatientStatNumber: (username: string, count: string) => void;
    loadDonorStatNumber: (username: string, count: string) => void;
}
interface IStatHubServer {
    // send(message: string): JQueryPromise<void>;
}


$(() => {
    $.connection.hub.logging = true;
    var myhub = $.connection.statHub;

    //Function to load Patient table's count to the dashboard
    myhub.client.loadPatientStatNumber = (username, count) => {
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

        window.setTimeout(() => {
            $(".alert").fadeTo(1000, 0).slideUp(1000, function () {
                $(this).remove();
            });
        }, 4000);
    };

    //Function to load Donor table's count to the dashboard
    myhub.client.loadDonorStatNumber = (username, count) => {
        if (document.getElementById('donorCount') != null)
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

        window.setTimeout(() => {
            $(".alert").fadeTo(1000, 0).slideUp(1000, function () {
                $(this).remove();
            });
        }, 4000);
    };

    $.connection.hub.start().done(() => {
        //myhub.server.getPatientStat();
        //myhub.server.getDonorStat();
    });

});
