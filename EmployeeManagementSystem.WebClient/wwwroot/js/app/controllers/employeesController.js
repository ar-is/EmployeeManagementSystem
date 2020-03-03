var EmployeesController = function (pageElementHelpers, employeeService) {

    var animations = function (table) {
        $("#deleteEmployees").css('display', 'none');

        table.on('select deselect', function (e, dt, type, indexes) {
            var count = table.rows({ selected: true }).count();

            if (count > 0) {
                $("#deleteEmployees").show();
                $("#deleteEmployees").text((count > 1) ? 'Delete All' : 'Delete');
            } else {
                $("#deleteEmployees").hide();
            }
        });
    };

    var allEmployeesInit = function (container, employeeDetailsAction) {
        var table = $(container).DataTable({
            ajax: employeeService.getAllEmployeesDatatable(),
            columnDefs: [
                {
                    targets: 0,
                    data: null,
                    defaultContent: '',
                    orderable: false,
                    className: 'select-checkbox',
                },
                {
                    targets: 1,
                    data: "name"
                },
                {
                    targets: 2,
                    data: "surname"
                },
                {
                    targets: 3,
                    data: "hiringDate",
                    render: function (data, type, row) {
                        return moment(data).format('dddd, MMMM Do, YYYY');
                    }
                },
                {
                    targets: 4,
                    data: "job"
                },
                {
                    targets: 5,
                    data: "id",
                    render: function (data, type, row) {
                        return '<a href="' + employeeDetailsAction + "/" + row.id + '">Details</a>';
                    }
                }],
            select: {
                style: 'multi',
                selector: 'td:first-child'
            },
            order: [[1, "asc"]]
        });

        $(container).on('click', '#select_all', function () {
            if ($('#select_all:checked').val() === 'on')
                table.rows().select();
            else
                table.rows().deselect();
        });	

        return table;
    };

    var deleteMultipleEmployees = function (table) {

        var deleteMultipleEmployeesSuccess = function () {
            PageElementHelpers.toggleModal("green", "Employee(s) successfully deleted!");

            setTimeout(function () {
                window.location.href = "https://localhost:44375/Employees/AllEmployees"
            }, 2500);
        };

        var deleteMultipleEmployeesFail = function (xhr, textStatus, errorThrown) {
            pageElementHelpers.toggleModal("red", "Employee(s) not deleted!" + errorThrown);
        };

        $("#deleteEmployees").click(function () {
            var employeeIds = employeeService.getSelectedEmployeesIds(table);

            employeeService.deleteEmployeesCollection(employeeIds, deleteMultipleEmployeesSuccess, deleteMultipleEmployeesFail);
        });
    };

    return {
        animations: animations,
        allEmployeesInit: allEmployeesInit,
        deleteMultipleEmployees: deleteMultipleEmployees
    }

}(PageElementHelpers, EmployeeService);