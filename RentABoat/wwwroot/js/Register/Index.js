function RegisterBoat() {
    var frmData = $("#newBoatForm").serializeArray();
    console.log(frmData);
    var name = $("#btName")[0].value
    var rate = $("#btRate")[0].value;
    console.log(name);
    console.log(rate);
    $.ajax({
        url: "Register/RegisterBoat",
        type: 'POST',
        data: { boatName:name, hourlyRate:rate},
        success: function (data) {
            if (data.success === true)
            {
                console.log(data);
                alert("Boat \"" + data.boatname + "\" has been successfully registered with ID: " + data.boatid);
               // $("#formDiv").hide();

              //  $("#RemarkDiv").show();
              //  $("#SuccessMsg")[0].textContent = "Boat \"" + data.boatname + "\" has been successfully registered with ID: " + data.boatid;
            }
            else {
                alert("Duplicate name found, try using a unique name. ");
            }
        },
        error: function (xhr) {
            alert("Error: " + xhr.statusText);
        }
    })
    
}
