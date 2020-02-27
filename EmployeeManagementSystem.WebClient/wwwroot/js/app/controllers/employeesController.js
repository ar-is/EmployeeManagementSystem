var EmployeesController = function (employeeService) {

    var allEmployeesInit = function (container, employeeDetailsAction) {
        $(container).DataTable({
            ajax: employeeService.getAllEmployeesDatatable(),
            columns: [
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
            ]
        });
    };

    return {
        allEmployeesInit: allEmployeesInit
    }

}(EmployeeService);