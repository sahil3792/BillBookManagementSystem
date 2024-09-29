//// PDF download function
//async function downloadPDF() {
//    try {
//        const response = await fetch('Report/downloadpdf');
//        if (response.ok) {
//            const blob = await response.blob(); // Get the PDF blob
//            const url = window.URL.createObjectURL(blob); // Create a URL for the blob
//            const a = document.createElement('a'); // Create a link element
//            a.href = url;
//            a.download = 'Report.pdf'; // Set the file name
//            document.body.appendChild(a); // Append link to the body
//            a.click(); // Trigger download
//            a.remove(); // Remove the link after download

//            // Show notification after successful download
//            alert('PDF Successfully Downloaded!');
//        } else {
//            alert('Error downloading PDF.');
//        }
//    } catch (error) {
//        console.error('Download failed:', error);
//        alert('An error occurred while downloading PDF.');
//    }
//}
//// Excel download function
//async function downloadExcel() {
//    try {
//        const response = await fetch('Report/downloadexcel');
//        if (response.ok) {
//            const blob = await response.blob(); // Get the Excel blob
//            const url = window.URL.createObjectURL(blob); // Create a URL for the blob
//            const a = document.createElement('a'); // Create a link element
//            a.href = url;
//            a.download = 'Report.xlsx'; // Set the file name
//            document.body.appendChild(a); // Append link to the body
//            a.click(); // Trigger download
//            a.remove(); // Remove the link after download

//            // Show notification after successful download 
//            alert('Excel Successfully Downloaded!');
//        } else {
//            alert('Error downloading Excel.');
//        }
//    } catch (error) {
//        console.error('Download failed:', error);
//        alert('An error occurred while downloading Excel.');
//    }
//}
