function RentToCustomer() {
    var boatId = $("#boatList").val();
    var cusName = $("#cusName")[0].value;
    var contactNo = $("#contactNo")[0].value;
    $.ajax({
        url: "Rent/RentToCustomer",
        type: 'POST',
        data: { BoatId: boatId, CustomerName: cusName, ContactNo: contactNo},
        success: function (data) {
            console.log(data);
           
            if (data.success === true) {
                console.log(data);
                alert("The boat with Id: " + data.boatid + " has been successfully assigned to " + data.cusname);
           }
            else {
                alert(data.errortext);
            }
        },
        error: function (xhr) {
            alert("Error: " + xhr.statusText);
        }
    })

}