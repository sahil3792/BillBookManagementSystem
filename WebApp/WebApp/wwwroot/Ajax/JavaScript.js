/// <reference path="javascript1.js" />
$(document).ready(function () {
    loadPartyCategoriesforItem();
    loadPartyNamesforItem();
    var items = [];
    getItem();
});
    $(document).on('change', '#partyCategory', function () {
        var id = parseInt($(this).val());
        $.ajax({
            url: '/Report/FetchItemReportByPartyData',
            type: 'GET',
            data: { id: id },
            success: function (data) {
                console.log("Data from server:", data);
                alert("fetchitemreportbypartydata success");
                $('#salesTableBody').html('');
                /*if (data && data.length > 0) {*/
                    $.each(data, function (index, party) {
                        $('#salesTableBody').append(
                            `<tr>
                            <td>${party.itemName}</td>
                            <td>${party.itemCode}</td>
                            <td>${party.openingStock}</td>
                            <td>${party.salesQuantity}</td>
                            <td>${party.salesPrice}</td>
                            <td>${party.purchasePrice}</td>
                        </tr>`
                        );
                    });
                //}
                //else {
                //    $('#salesTableBody').append(
                //        `<tr>
                //            <td colspan="4">No parties found for this category.</td>
                //        </tr>`
                //    );
                //}
            },
            error: function (xhr, status, error) {
                console.error("Error fetching data: ", error);
                console.log("Response: ", xhr.responseText); // Log the response text for more details
                alert("Failed to load data: " + xhr.status + " - " + error);
            }
        });
    });

$(document).on('change', '#partyName', function () {
    var id = parseInt($(this).val());
    $.ajax({
        url: '/Report/FetchItemReportByPartyName',
        type: 'GET',
        data: { id: id },
        success: function (data) {
            console.log("Data from server:", data);
            $('#salesTableBody').html('');
            if (data && data.length > 0) {
                $.each(data, function (index, party) {
                    $('#salesTableBody').append(
                        `<tr>
                            <td>${party.itemName}</td>
                            <td>${party.itemCode}</td>
                            <td>${party.openingStock}</td>
                            <td>${party.salesQuantity}</td>
                            <td>${party.salesPrice}</td>
                            <td>${party.purchasePrice}</td>
                        </tr>`
                    );
                });
            }
            else {
                $('#salesTableBody').append(
                    `<tr>
                            <td colspan="6">No parties found for this category.</td>
                        </tr>`
                );
            }
        },
        error: function (xhr, status, error) {
            console.error("Error fetching data: ", error);
            console.log("Response: ", xhr.responseText); // Log the response text for more details
            alert("Failed to load data: " + xhr.status + " - " + error);
        }
    });
});


function loadPartyCategoriesforItem() {
    $.ajax({
        url: '/Report/GetPartyCategories', // Ensure this URL is correct
        method: 'GET',
        dataType: 'json',
        success: function (result) {
            var options = '<option value="">Show All Parties</option>';
            $.each(result, function (index, item) {
                options += `<option asp-for="id" value="${item.id}">${item.categoryName}</option>`;
            });
            $("#partyCategory").html(options); // Populate the dropdown
        },
        error: function (xhr, status, error) {
            console.error("Error fetching data: ", error);
            alert("Failed to load categories: " + xhr.status + " - " + error);
        }
    });
}

function loadPartyNamesforItem() {
    $.ajax({
        url: '/Report/GetPartyNameforItem', // Ensure this URL is correct
        method: 'GET',
        dataType: 'json',
        success: function (result) {
            var options = '<option value="">Show Parties</option>';
            $.each(result, function (index, item) {
                options += `<option asp-for="id" value="${item.id}">${item.partyName}</option>`;
            });
            $("#partyName").html(options); // Populate the dropdown
        },
        error: function (xhr, status, error) {
            console.error("Error fetching data: ", error);
            alert("Failed to load categories: " + xhr.status + " - " + error);
        }
    });
}

function demotp(element) {
    var selectitem = $(element).val();
    var $row = $(element).closest('tr');
    console.log("Items", items);

    var item = items.find(p => p.itemId == selectitem);
    if (item) {

        $row.find('.hsncode').val(item.hsnCode);
        $row.find('.qty').val(item.openingStock);
        $row.find('.rate').val(item.salesPrice);
        $row.find('.tax').val(item.gstTaxRate);


    } else {

        $row.find('.hsncode').val("");
        $row.find('.qty').val("");
        $row.find('.rate').val("");
        $row.find('.tax').val("");
    }
}



function getItem() {
    $.ajax({
        url: '/Consuming/GetItem',
        type: 'GET',
        dataType: 'json',
        success: function (result, status, xhr) {

            console.log("Item Data: ", result); // Check the structure of the result
            items = result;
            var options2 = '<option value="">Select Item</option>';
            $.each(result, function (index, item) {

                options2 += "<option value='" + item.itemId + "'>" + item.itemName + "</option>";
            });
            $("#GetItemName").html(options2);
        },
        error: function (xhr, status, error) {
            console.error("Error fetching data: ", error);
            alert("Failed to load subjects: " + xhr.status + " - " + error);
        }
    })
}