$(document).ready(function () {
    $.fn.dataTable.ext.errMode = 'throw';
    $("#Customers").dataTable({
        "serverSide": true,
        "filter": true,

     
        "ajax":{
            "url": "/api/Customers",
            "type": "POST",
            "datatype": "json"

        },
        "columnDefs": [
            { targets: [0], visible: false, searchable: false },
          
        ],
        
        "columns": [
            { "data": "id", "name": "Id", "autowidth": true },
            { "data": "firstName", "name": "FirstName", "autowidth": true },
            { "data": "lastName", "name": "LastName", "autowidth": true },
            { "data": "contact", "name": "Contact", "autowidth": true },
            { "data": "email", "name": "Email", "autowidth": true },
            /*            { "data": "dateOfBith", "name": "DateOfBith", "autowidth": true }*/
                {
                "render": function (data, type, row) { return `<span>${row.dateOfBith.split('T')[0]}</span>` },
                "name":"DateOfBith"
                }
            ,
            {
                "render": function (data, type, row) { return `<a href="#" class="btn btn-sm btn-danger text-white" onclick=DeleteCustomer(${row.id})>Delete</a>` }, "orderable": false },
         
        ],


    });
});