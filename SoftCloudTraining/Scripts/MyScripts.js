function doPost()
{
    console.log("run : doPost");
    $.post("/softclouds/candidate",
    {
        "name": "John Artz",
        "yearsOfExperience": 6,
        "developer": true,
        "qa": false,
        "phone": "(888) 123-4567",
        "resumeId": 1
    },
    function(data, status,xhr){
        console.log("data: " + data);
        console.log("status: " + status);
        console.log("xhr.status: " + xhr.status);
        console.log("xhr.response : " + xhr.response );
        console.log("xhr.responseText : " + xhr.responseText );
        console.log("xhr.getAllResponseHeaders() : " +  xhr.getAllResponseHeaders());
    });
}

function doGet()
{
    console.log("run : doGet");
    $.get( "/softclouds/candidate/2", function( data) { 
        console.log("data: " + JSON.stringify(data));
        //console.log("status: " + status);
        //console.log("xhr.status: " + xhr.status);
        //console.log("xhr.response : " + xhr.response );
        //console.log("xhr.responseText : " + xhr.responseText );
        //console.log("xhr.getAllResponseHeaders() : " +  xhr.getAllResponseHeaders());
    });
}

function doDelete()
{

    console.log("run : doDelete");
    $.ajax({
        url: '/softclouds/candidate/2',
        type: 'DELETE',
        success: function(response) {
            console.log("response: " + JSON.stringify(response));
            console.log("response.response: " + result.response);
        }
    });
	
}

function doPut()
{
    console.log("run : doPut");
    var jsonData = {
        "id": 3,
        "name": "John Artz",
        "yearsOfExperience": 6,
        "developer": true,
        "qa": false,
        "phone": "(888) 123-4567",
        "resumeId": 1
    };
    $.ajax({
        url: '/softclouds/candidate',
        type: 'PUT',
        data: jsonData,
        success: function(response) {
            console.log("response: " + JSON.stringify(response));
            console.log("response.response: " + result.response);
        }
    });
	
}