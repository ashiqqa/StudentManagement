$(document).ready(function () {
        //Date field
        $('#searchBtn').click(function () {
            var fromDate = $('#fromDate').val();
            var toDate = $('#toDate').val();
            $.ajax({
                url: "/Home/GetByBirthDate",
                data: { fromDate: fromDate, toDate: toDate },
                type: "POST",
                success: function (result) {
                    $('#tbody').empty();
                    $('#tbody').append(result);
                },
                error: function (e) { alert("Sorry... failed to load") }
            })
        });

        $('#lessThanAge').click(function () {
            var age = $('#ageField').val();
            $.ajax({
                url: "/Home/GetByAgeLess",
                data: { age: age },
                type: "POST",
                success: function (result) {
                    $('#tbody').empty();
                    $('#tbody').append(result);
                },
                error: function (result) {
                    alert("Sorry, Failed to load")
                }
            })
        })

        $('#ageField').on('keypress change',function () {
            var age = $(this).val();
            if (age==""){return null}
            $.ajax({
                url: "/Home/GetByAge",
                data: { age: age },
                type: "POST",
                success: function (result) {
                    $('#tbody').empty();
                    $('#tbody').append(result);
                },
                error: function (result) {
                    alert("Sorry, Failed to load")
                }
            })
        })
        $('#greaterThanAge').click(function () {
            var age = $('#ageField').val();
            $.ajax({
                url: "/Home/GetByAgeGreater",
                data: { age: age },
                type: "POST",
                success: function (result) {
                    $('#tbody').empty();
                    $('#tbody').append(result);
                },
                error: function (result) {
                    alert("Sorry, Failed to load")
                }
            })
        })

        $('#fromDate').datepicker({
            dateFormat: "dd M, yy",
            changeYear: true,
            changeMonth: true,
            changeHours:true,
            yearRange: "1920:2005"
        })
        $('#toDate').datepicker({
            dateFormat: "dd M, yy",
            changeYear: true,
            changeMonth: true,
            yearRange: "1920:2005"
        })

        //Data table
        $('#example').DataTable({
            dom: 'Bfrtip',
            buttons: [
                'copy', 'csv', 'excel', 'pdf', 'print'
            ]
        });
    });
//Delete student
function Delete() {
    var id = $('.deleteBtn').val();
    if (confirm("Are you sure to delete?")) {
        $.ajax({
            url: "/Student/Delete",
            data: { id: id },
            type: "POST",
            success: function (response) {
                $('#deleteBtn').remove();
            },
            error: function (response) {
                alert(response);
            }
        })
    }
}