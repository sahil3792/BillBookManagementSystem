$(document).ready(function () {

    var parties = [];

    getadd();
});
//function Demo() {
//    var d = $('#d').serialize();
//    var obj = {
//        invoiceDate: d.invoiceDate,
//        invoiceID: d.invoiceID,
//        partyName: d.partyName,
//        shippingAddress: d.shippingAddress,
//        dueDate: d.dueDate,
//        Amount: d.Amount,
//        Status: d.status,
//        paymentMode: d.paymentMode,
//        invoicepdf: "null"
//    }
//    console.log(obj);

//}
$("#GetpartyName").change(function () {
    var selectedPartyId = parseInt($(this).val());
    console.log("Prties", parties);
    var selectedParty = parties.find(p => p.salesInvoiceId == selectedPartyId);
    if (selectedParty) {
        $('#partyAddress').val(selectedParty.shippingAddress);
    } else {
        $("#partyAddress").val("");
    }
})

//$('#GetItemName').change(function () {
function getadd() {
    $.ajax({
        url: '/Consuming/Index2',
        type: 'GET',
        dataType: 'json',
        success: function (result, status, xhr) {
            console.log("Party Data: ", result);
            parties = result;
            console.log("This is Parties Data", parties);
            var options = '<option value="">Select Party</option>';
            $.each(result, function (index, item) {
                console.log(item);
                options += "<option value='" + item.salesInvoiceId + "'>" + item.partyName + "</option>";
            });
            $("#GetpartyName").html(options);
        },
        error: function (xhr, status, error) {
            console.error("Error fetching data: ", error);
            alert("Failed to load subjects: " + xhr.status + " - " + error);
        }
    })
}



//function getadd() {
//    $.ajax({
//        url: '/Consuming/Index', // Ensure this URL is correct
//        type: 'GET',
//        dataType: 'json',
//        success: function (result, status, xhr) {
//            console.log("AJAX call successful. Result:", result); // Debugging the result

//            var options = '<option value="">Select Party</option>';
//            if (result && result.length > 0) {
//                $.each(result, function (index, item) {
//                    console.log("Processing item:", item); // Debugging each item
//                    options += "<option value='" + item.salesInvoiceId + "'>" + item.partyName + "</option>";
//                });
//                $("#GetpartyName").html(options); // Updating dropdown
//            } else {
//                console.warn("No data returned or invalid format"); // Debugging if no data
//                alert("No parties found.");
//            }
//        },
//        error: function (xhr, status, error) {
//            console.error("Error fetching data: ", error);
//            alert("Failed to load parties: " + xhr.status + " - " + xhr.responseText);
//        }
//    });
//}


function saveInvoice() {
    var invoiceData = {
        InvoiceNo: $('#InvoiceNo').val(),
        InvoiceDate: $('#InvoiceDate').val(),
        // Add more fields as necessary
    };

    $.ajax({
        type: "POST",
        url: "https://localhost:7254/api/Adding/AddSalesInvoice",
        data: JSON.stringify(invoiceData),
        contentType: "application/json",
        success: function (response) {
            alert(response); // Handle success
        },
        error: function (error) {
            alert("Error: " + error.responseText); // Handle error
        }
    });
}


