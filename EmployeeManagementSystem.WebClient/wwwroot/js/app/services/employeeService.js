var EmployeeService = function () {

    var getAllEmployeesDatatable = function () {
        return {
            url: "http://localhost:5001/api/employees",
            dataSrc: ""
        };
    };

    var getSelectedEmployeesIds = function (table) {
        var employeeIds = [];

        $("#allEmployees").dataTable().$("tr.selected").each(function () {
            var data = table.row(this).data();
            employeeIds.push(data.id);
        });

        return employeeIds.join();
    };

    var deleteEmployeesCollection = function (employeesIds, success, fail) {
        $.ajax({
            url: "http://localhost:5001/api/employeecollections?ids=" + employeesIds,
            method: "DELETE"
        })
            .then(success)
            .fail(fail);
    };

    return {
        getAllEmployeesDatatable: getAllEmployeesDatatable,
        getSelectedEmployeesIds: getSelectedEmployeesIds,
        deleteEmployeesCollection: deleteEmployeesCollection
    }
}();