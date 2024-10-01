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
        url: '/Party/GetParties',
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
        url: '/Party/GetParties',
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8;',
        success: function (result) {
            var totalToCollect = 0;
            result.parties.forEach(function (party) {
                if (party.toPayToCollect === "To Collect") {
                    totalToCollect += party.openingBalance;
                    var partyElement = $("#party-" + party.id);
                    if (partyElement.find('.collect-arrow').length === 0) {
                        partyElement.append('<span class="collect-arrow" style="color:green;">&#9650;</span>');
                    }
                }
            });

            $("#totalToCollect").val(totalToCollect);
            console.log("Total to Collect: ", totalToCollect);
        },
        error: function (xhr, error) {
            console.error("Error fetching data: ", error);
        }
    });
}

function topay() {
    $.ajax({
        url: '/Party/GetParties',
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8;',
        success: function (result) {
            var totaltopay = 0;
            $("#tabledata").empty();
            result.parties.forEach(function (party) {
                if (party.toPayToCollect === "To Pay") {
                    totaltopay += party.openingBalance;
                }
                var newRow = `<tr id="party-${party.id}">
                    <td>${party.partyName}</td>
                    <td>${party.partyCategory}</td>
                    <td>${party.partyPhoneNo}</td>
                    <td>${party.partyType}</td>
                    <td>${party.openingBalance} 
                        ${party.toPayToCollect === "To Collect" ? '<span class="collect-arrow" style="color:green;">&#129033;</span>' : ''}
                        ${party.toPayToCollect === "To Pay" ? '<span class="pay-arrow" style="color:red;">&#129035;</span>' : ''}
                    </td>
                </tr>`;
                $("#tabledata").append(newRow);
            });
            $("#totaltopay").val(totaltopay);
            console.log("Total to Pay: ", totaltopay);
        },
        error: function (xhr, error) {
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
//document.getElementById('totalToCollect').addEventListener('click', function () {
//    clickontocollect();
//});

//function clickontocollect() {
//    $.ajax({
//        url: '/Parties/GetParties',
//        type: 'GET',
//        dataType: 'json',
//        contentType: 'application/json;charset=utf-8;',

//        success: function (result) {
//            $("#tabledata").empty(); // Clear previous data

//            // Filter and display only the "To Collect" rows
//            result.parties
//                .filter(function (party) {
//                    return party.topayTocollect === "To Collect"; // Only collect rows
//                })
//                .forEach(function (party) {
//                    var newRow = `<tr id="party-${party.id}">
//                        <td>${party.partyName}</td>
//                        <td>${party.partyCategory}</td>
//                        <td>${party.partyPhoneNo}</td>
//                        <td>${party.partyType}</td>
//                        <td>${party.openingBalance} 
//                            <span class="collect-arrow" style="color:green;">&#129033;</span>
//                        </td>
//                    </tr>`;
//                    $("#tabledata").append(newRow);
//                });

//            // Optional: Handle the case where no "To Collect" records are found
//            if ($("#tabledata").children().length === 0) {
//                $("#tabledata").append('<tr><td colspan="5">No "To Collect" records found.</td></tr>');
//            }
//        },
//        error: function (xhr, error) {
//            console.error("Error fetching data: ", error);
//        }
//    });
//}