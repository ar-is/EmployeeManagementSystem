var EmployeesController = function (pageElementHelpers, employeeService) {

    var animations = function (table, employeeDetailsAction) {
        $("#deleteEmployees").css('display', 'none');
        $("#editEmployee").css('display', 'none');

        table.on('select deselect', function (e, dt, type, indexes) {
            var count = table.rows({ selected: true }).count();

            if (count > 0) {
                $("#deleteEmployees").show();
                $("#deleteEmployees").text((count > 1) ? 'Delete Selected' : 'Delete');

                if (count == 1)
                    $("#editEmployee").show();
                else
                    $("#editEmployee").hide();

            } else {
                $("#deleteEmployees").hide();
            }
        });

        $("#editEmployee").click(function () {
            $("#allEmployees").dataTable().$("tr.selected").each(function () {
                var data = table.row(this).data();
                location.href = employeeDetailsAction + "/" + data.id;
            });
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
            PageElementHelpers.toggleModal("green", "Employees successfully deleted!");
            reload();
        };

        var deleteMultipleEmployeesFail = function (xhr, textStatus, errorThrown) {
            pageElementHelpers.toggleModal("red", "Employees not deleted!" + errorThrown);
            reload();
        };

        var reload = function () {
            setTimeout(function () {
                window.location.href = "https://localhost:44375/Employees/AllEmployees"
            }, 2500);
        };

        var deleteCallback = function () {
            var employeeIds = employeeService.getSelectedEmployeesIds(table);

            employeeService.deleteEmployeesCollection(employeeIds, deleteMultipleEmployeesSuccess, deleteMultipleEmployeesFail);
        };

        $("#deleteEmployees").click(function () {
            pageElementHelpers.deleteToggleModal("these employees", deleteCallback);
        });
    };

    return {
        animations: animations,
        allEmployeesInit: allEmployeesInit,
        deleteMultipleEmployees: deleteMultipleEmployees
    }

}(PageElementHelpers, EmployeeService);