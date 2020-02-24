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
                    data: "hiringDate"
                    //render: function (data, type, row) {
                    //    return moment(data).format('M/D/YYYY hh:mm:ss a');
                    //}
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
            columnDefs:
            {
                targets: 2,
                render: function (data, type, full, meta) {
                    if (type == 'display') {
                        if (data) {
                            var mDate = moment(data);
                            data = (mDate && mDate.isValid()) ? mDate.format("dddd, MMMM Do YYYY, h:mm:ss a") : '';
                        }
                    }
                    return data;
                }
            }
        });
    };

    return {
        allEmployeesInit: allEmployeesInit
    }

}(EmployeeService);