$(document).ready(function () {
    $(".deleteBtn").click(function () {
        var id = $(this).val();
        if (confirm("Are you sure to delete?")) {
            $.ajax({
                url: "/City/Delete",
                data: { id: id },
                type: "POST",
                success: function (response) {
                    location.reload();
                },
                error: function (response) {
                    alert(response);
                }
            })
        }
    })
})