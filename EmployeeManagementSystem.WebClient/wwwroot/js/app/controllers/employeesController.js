var EmployeesController = function (employeeService) {

    var allEmployeesInit = function (container, employeeDetailsAction) {
        $(container).DataTable({
            ajax: employeeService.getAllEmployeesDatatable(),
            columns: [
                {
                    data: null
                    //className: "empCheckbox",
                    //data: "id",
                    //render: function (data, type, row) {
                    //    return '<input class="emp" type="checkbox" data-id=' + row.id + ' /> ';
                    //}
                },
                {
                    data: "name"
                },
                {
                    data: "surname"
                },
                {
                    data: "hiringDate",
                    render: function (data, type, row) {
                        return moment(data).format('dddd, MMMM Do, YYYY');
                    }
                },
                {
                    data: "job"
                },
                {
                    data: "id",
                    render: function (data, type, row) {
                        return '<a href="' + employeeDetailsAction + "/" + row.id + '">Details</a>';
                    }
                }
            ],
            columnDefs: [
                {
                    targets: [0],
                    orderable: false,
                    render: function (data, type, row) {
                        return '<input class="emp" type="checkbox" data-id=' + row.id + ' /> ';
                    }
                }
            ]
        });
    };

    return {
        allEmployeesInit: allEmployeesInit
    }

}(EmployeeService);