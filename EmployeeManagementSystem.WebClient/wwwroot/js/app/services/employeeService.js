var EmployeeService = function () {

    var getAllEmployeesDatatable = function () {
        return {
            url: "http://localhost:5001/api/employees",
            dataSrc: ""
        };
    };

    return {
        getAllEmployeesDatatable: getAllEmployeesDatatable
    }
}();