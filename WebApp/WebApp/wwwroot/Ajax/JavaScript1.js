$(document).ready(function () {
    loadPartyCategories();
    $(document).on('change', '#partyCategory', function () {
        var id = parseInt($(this).val());
        $.ajax({
            url: '/Report/FetchPartywiseOutstandingData',
            type: 'GET',
            data: { categoryid: id}, 
            success: function (data) {
                console.log("Data from server:", data); 
                $('#salesTableBody').html('');
                if (data && data.length > 0) {
                    $.each(data, function (index, party) {
                        $('#salesTableBody').append(
                            `<tr>
                            <td>${party.partyName}</td>
                            <td>${party.partyCategory}</td>
                            <td>${party.phoneNumber}</td>
                            <td>${party.openingBalance}</td>
                        </tr>`
                        );
                    });
                }
                else {
                    $('#salesTableBody').append(
                        `<tr>
                            <td colspan="4">No parties found for this category.</td>
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
});

function loadPartyCategories() {
    $.ajax({
        url: '/Report/GetPartyCategories', // Ensure this URL is correct
        method: 'GET',
        dataType: 'json',
        success: function (result) {
            var options = '<option value="">Show All Parties</option>';
            $.each(result, function (index, item) {
                options += `<option value="${item.id}">${item.categoryName}</option>`;
            });
            $("#partyCategory").html(options); // Populate the dropdown
        },
        error: function (xhr, status, error) {
            console.error("Error fetching data: ", error);
            alert("Failed to load categories: " + xhr.status + " - " + error);
        }
    });
}