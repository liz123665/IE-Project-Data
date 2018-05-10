$(document).ready(
    //Example
    //https://www.eventbriteapi.com/v3/events/search/?token=G3QK7LM2TK72FXM56F2F
    //https://www.eventbriteapi.com/v3/events/search/?q=chinese&location.address=victoria&token=G3QK7LM2TK72FXM56F2F

    function() {

        var query='india';
        var location = 'victoria';

        var endpoint = 'https://www.eventbriteapi.com/v3/events/search/?';

        var accessToken ="&token=G3QK7LM2TK72FXM56F2F";

        var url = endpoint + 'q=' + query + '&location.address=' + location + accessToken;
        $.get(url,function(data){

            $('#datatable').DataTable({
                data:data.events,
                columns:[
                    { data: 'name.html' },
                    {data:'start.local'},
                    {data:'end.local'},
                    {data: 'description.text' }, 
                ]
            })
        })


        // $('#datatable').DataTable({
        //     ajax:{
        //         url:url + accessToken,
        //         type:'GET',
        //         dataSrc:'events',
        //     },

        //     columns:[
        //         {events:'name.text'},
        //     ]
        // });

    }
)