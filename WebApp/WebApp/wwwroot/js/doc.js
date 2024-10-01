$(document).ready(function () {
    GetAllParties();
    tocollect();
    topay();
});
document.getElementById('partyType').addEventListener('focus', function () {
    this.value = '';
});

function GetAllParties() {
    $.ajax({
        url: '/Parties/GetParties',
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8;',
        success: function (result, status, xhr) {
            $("#allparties").val(result.count);
        },
        error: function (xhr, status, error) {
            console.error("Error fetching data: ", error);
        }
    });
}

function tocollect() {
    $.ajax({
        url: '/Parties/GetParties',
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8;',
        success: function (result, status, xhr) {
            var totalToCollect = result.parties.reduce(function (sum, party) {

                if (party.topayTocollect === "To Collect") {
                    return sum + party.openingBalance;
                }
                return sum;
            }, 0);
            $("#totalToCollect").val(totalToCollect);
            console.log("Total to Collect: ", totalToCollect);
        },
        error: function (xhr, status, error) {
            console.error("Error fetching data: ", error);
        }
    });
}

function topay() {
    $.ajax({
        url: '/Parties/GetParties',
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8;',

        success: function (result, status, xhr) {
            var totaltopay = result.parties.reduce(function (sum, abcd) {
                if (abcd.topayTocollect === "To Pay") {
                    return sum + abcd.openingBalance;
                }
                return sum;
            }, 0);
            $("#totaltopay").val(totaltopay);
            console.log("Total to Pay: ", totaltopay);
        },
        error: function (xhr, status, error) {
            console.error("Error fetching data: ", error);
        }
    });
}

function searchparties() {
    var sdata = $("#search").val();
    $.ajax({
        url: '/Parties/SearchParties?categories=' + sdata,
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8;',

        success: function (result, status, xhr) {
            obj = ''
            $.each(result, function (index, item) {
                obj += "<tr>";
                obj += "<td>" + item.partyName + "</td>";
                obj += "<td>" + item.partyCategory + "</td>";
                obj += "<td>" + item.partyPhoneNo + "</td>";
                obj += "<td>" + item.partyType + "</td>";
                obj += "<td>" + item.openingBalance + "</td>";
                obj += "<tr>";
            });
            $("#tabledata").html(obj);
        },
        error: function () {
            alert('No data found for the input')
        }
    });
}


