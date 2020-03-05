var EmployeeDetailsController = function (pageElementHelpers, employeeService) {

    var animations = function () {
        nameAnimations();
        jobAnimations();
        phoneAnimations();
        emailAnimations();
        buttonAnimations();
    };

    var nameAnimations = function () {
        pageElementHelpers.toggleEditIcon(".card-header", "#inputEmpName", "#nameEmpEdit");
        pageElementHelpers.toggleEditIcon(".card-header", "#inputEmpSurname", "#nameEmpEdit");

        $("#nameEmpEdit").on('click', function () {
            $("#nameEmpEdit").hide();
            $("#employeeName").css({ 'display': "none" });
            $("#employeeSurname").css({ 'display': "none" });
            $("#inputEmpName").css({ 'display': 'inline-block' });
            $("#inputEmpSurname").css({ 'display': 'inline-block' });
            $("#inputEmpName").focus();
            $("#inputEmpName").val($("#employeeName").html());
            $("#inputEmpSurname").val($("#employeeSurname").html());

            $(document).mouseup(function (e) {
                if (!$(".card-header").is(e.target) && $(".card-header").has(e.target).length === 0) {

                    $("#employeeName").html($("#inputEmpName").val());
                    $("#inputEmpName").css({ 'display': 'none' });
                    $("#employeeName").css({ 'display': "inline-block", "margin-top": "2px" });
                    $("#employeeSurname").html($("#inputEmpSurname").val());
                    $("#inputEmpSurname").css({ 'display': 'none' });
                    $("#employeeSurname").css({ 'display': "inline-block", "margin-top": "2px" });
                }
            });
        });  
    };

    var jobAnimations = function () {
        pageElementHelpers.toggleEditIcon(".card-header", "#inputType", "#typeEdit");
        pageElementHelpers.onClickEditIcon("#typeEdit", "#skillType", "#inputType");
        pageElementHelpers.onEditUnfocus("#inputType", "#skillType");
    };

    var phoneAnimations = function () {
        pageElementHelpers.toggleEditIcon(".phone", "#inputEmpPhone", "#phoneEmpEdit");
        pageElementHelpers.onClickEditIcon("#phoneEmpEdit", "#employeePhone", "#inputEmpPhone");
        pageElementHelpers.onEditUnfocus("#inputEmpPhone", "#employeePhone");
    };

    var emailAnimations = function () {
        pageElementHelpers.toggleEditIcon(".email", "#inputEmpEmail", "#emailEmpEdit");
        pageElementHelpers.onClickEditIcon("#emailEmpEdit", "#employeeEmail", "#inputEmpEmail");
        pageElementHelpers.onEditUnfocus("#inputEmpEmail", "#employeeEmail");
    };

    var buttonAnimations = function () {
        $("#discardEmpChanges").click(function () {
            location.reload();
        });

        pageElementHelpers.onInputChange("#inputEmpName", "#submitEmpChanges", "#discardEmpChanges");
        pageElementHelpers.onInputChange("#inputEmpSurname", "#submitEmpChanges", "#discardEmpChanges");
        pageElementHelpers.onInputChange("#inputEmpPhone", "#submitEmpChanges", "#discardEmpChanges");
        pageElementHelpers.onInputChange("#inputEmpEmail", "#submitEmpChanges", "#discardEmpChanges");
        pageElementHelpers.onInputChange(".form-check", "#submitEmpChanges", "#discardEmpChanges");
    };

    var updateEmployee = function (id) {

        var updateSuccess = function () {
            pageElementHelpers.toggleModal("green", "Employee updated");

            setTimeout(function () {
                location.reload();
            }, 2500);
        };

        var updateFail = function (xhr, textStatus, errorThrown) {
            var errorMessage = xhr.status + ': ' + xhr.statusText;
            pageElementHelpers.toggleModal("red", "Employee not updated!" + errorThrown + errorMessage);
        };

        var patch = [];
        employeeService.getEmployeePatchDocument(patch);

        $("#submitEmpChanges").click(function (e) {
            employeeService.getEmployeeSkillsPatchDocument(patch);
            employeeService.patchEmployee(id, patch, updateSuccess, updateFail);

            $("#submitEmpChanges").hide();
            $("#discardEmpChanges").hide();
            e.preventDefault();
        });
    };

    var deleteEmployee = function (id) {
        var deleteSuccess = function () {
            pageElementHelpers.toggleModal("green", "Employee deleted");
            reload();
        };

        var deleteFail = function () {
            pageElementHelpers.toggleModal("red", "Employee not deleted!" + errorThrown);
            reload();
        };

        var reload = function () {
            setTimeout(function () {
                window.location.href = "https://localhost:44375/Employees/AllEmployees"
            }, 2500);
        };

        var deleteCallback = function () {
            employeeService.deleteEmployee(id, deleteSuccess, deleteFail);
        };

        $("#deleteEmployee").click(function () {
            pageElementHelpers.deleteToggleModal("this employee", deleteCallback);
        });
    };

    return {
        animations: animations,
        updateEmployee: updateEmployee,
        deleteEmployee: deleteEmployee
    }
}(PageElementHelpers, EmployeeService);