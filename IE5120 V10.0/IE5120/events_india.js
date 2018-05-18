function format(d) {
    return '<table cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;">' +
        '<tr>' +
        '<td> Detail Description:' +
            d.description.html +
        '<td>'+
        '</tr>';
};




$(document).ready(
    //Example
    //https://www.eventbriteapi.com/v3/events/search/?token=G3QK7LM2TK72FXM56F2F
    //https://www.eventbriteapi.com/v3/events/search/?q=chinese&location.address=victoria&token=G3QK7LM2TK72FXM56F2F

    function () {

        var query = 'india';
        var location = 'victoria';

        var endpoint = 'https://www.eventbriteapi.com/v3/events/search/?';

        var accessToken = "&token=G3QK7LM2TK72FXM56F2F";

        var url = endpoint + 'q=' + query + '&location.address=' + location + accessToken;



        $.get(url, function (data) {
            var temp = data;

            for (var i = 0; i < temp.events.length; i++) {
                var item = temp.events[i];
                var dateStart = new Date(item.start.local).getDate();
                var monthStart = new Date(item.start.local).getMonth() + 1;
                var yearStart = new Date(item.start.local).getFullYear();

                item.start.local = 'Start Date: ' + dateStart + '/' + monthStart + '/' + yearStart;


                var dateEnd = new Date(item.end.local).getDate();
                var monthEnd = new Date(item.end.local).getMonth() + 1;
                var yearEnd = new Date(item.end.local).getFullYear();

                item.end.local = 'End Date: ' + dateEnd + '/' + monthEnd + '/' + yearEnd;
            }

            var table = $('#datatable').DataTable({
                data: temp.events,
                columns: [
                    
                    { data: 'name.html' },
                    { data: 'start.local' },
                    { data: 'end.local' },
                    {
                        data: 'url',
                        render: function (data, type, row, meta) {
                            if (type === 'display') 
                                data = '<a href="' + data + '">' + data + '</a>';
                            return data;
                        }
                    },

                    {
                        "className": 'details-control',
                        "defaultContent": '',
                        "data": null,
                        "orderable": false
                    }

                ]
            });

            $('#datatable tbody').on('click', 'td.details-control', function () {
                var tr = $(this).closest('tr');
                var row = table.row(tr);

                if (row.child.isShown()) {

                    row.child.hide();
                    tr.removeClass('shown');
                }
                else {
                    row.child(format(row.data())).show();
                    tr.addClass('shown');
                }
            })


        })
    }
);
