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
