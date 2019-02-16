$(document).ready(function () {
    $('#confirmDeleteModal').hide();

    $('#countryId').change(function () {
        var countryId = $('#countryId').val();
        if (countryId >0) {
            $.ajax({
                url: "/Student/GetCityByCountry",
                data: { countryId: countryId },
                type: "POST",
                success: function (response) {
                    var option = "<option value=''>---Select City---</option>";
                    $('#cityId').empty();
                    $.each(response, function (key, city) {
                        option += "<option value='" + city.Id + "'>" + city.Name + "</option>";
                    })
                    $('#cityId').append(option);
                },
                error: function (response) {
                    alert("City can't load for " + response);
                }
            })
        }
    })

    //Get Student Id No.
    $('#sessionId').change(function () {
        GetStudentIdNo();
    })
    $('#deptId').change(function () {
        GetStudentIdNo();
    })

    function GetStudentIdNo() {
        var deptId = $('#deptId').val();
        var sessionId = $('#sessionId').val();

        if (deptId>0 && sessionId>0) {
            $.ajax({
                url: "/Student/GetStudentIdNo",
                data: { deptId: deptId, sessionId: sessionId },
                type: "POST",
                success: function (response) {
                    $('#StudentIdNo').val(response);
                },
                error: function (response) {
                    alert(response);
                }
            })
        }
    }

    ////Image preview
    //$("#StudentImage").change(function () {

    //    if (this.files && this.files[0]) {

    //        if (this.files[0].name.match(/\.(jpg|jpeg|png)$/)) {

    //            if (!(this.files[0].size > (1024* 1024))) {

    //                var reader = new FileReader();
    //                reader.onload = function (element) {
    //                    $("#ImagePreview").attr('src', element.target.result);
    //                };
    //                reader.readAsDataURL(this.files[0]);
    //            } else {
    //                alert("Image size larger than 1 MB");
    //                $(this).val(null);
    //                $("#ImagePreview").attr('src', null);
    //            }
    //        } else {
    //            alert("This is not image file");
    //            $(this).val(null);
    //            $("#ImagePreview").attr('src', null);
    //        }
    //    } else {
    //        $("#ImagePreview").attr('src', null);
    //    }
    //    $('#ImagePreview').css({
    //        "height": "150px",
    //        "width": "150px"
    //    });
    //});

    //Image preview
    $("#StudentImage").on('change', function (e) {
        $('#preview').empty();
        var files = e.target.files;
        
        $.each(files, function (i, file) {
            if (!(file.name.match(/\.(jpg|jpeg|png)$/)) || file.size > (1024 * 512)) {
                var reader = new FileReader();
                reader.readAsDataURL(file);
                reader.onload = function (e) {
                    var preview = "<img src='' alt='recommend format is jpg/jpeg/png and less than 100KB' class='img-responsive' style='float:left; height:80px; width:80px; margin: 2px;'>";
                    $('#preview').append(preview);
                }
            }
                else
                {
                    var reader = new FileReader();
                    reader.readAsDataURL(file);
                    reader.onload = function (e) {
                        var preview = "<img src='" + e.target.result + "' alt='image' class='img-responsive' style='float:left; height:80px; width:80px; margin: 2px;'>";
                        $('#preview').append(preview);
                    }
                }
        })
    });

    //Delete student
    $(".deleteBtn").click(function () {
        var id = $(this).val();
        if (confirm("Are you sure to delete?")) {
            $.ajax({
                url: "/Student/Delete",
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
    });

    //Password Confirmation
    $('#ConfirmPass').keyup(function () {
        var pass = $('#Password').val();
        var conPass = $('#ConfirmPass').val();

        if (pass != conPass) {
            $('#ConfirmPass').css({
                "border": "1px solid red"
            })
        }
        else {
            $('#ConfirmPass').css({
                "border": "1px solid green"
            })
        }
    });

    //Dashboard Search Section
    $('#CountryId').change(function () {
        SearchStudent()
    });
    $('#DepartmentId').change(function () {
        SearchStudent()
    });
    $('#SearchQuery').keyup(function () {
        SearchStudent()
    })

    function SearchStudent() {
        var deptId = $('#DepartmentId').val();
        var countryId = $('#CountryId').val();
        var searchQuery = $('#SearchQuery').val();
        $.ajax({
            url: "/Home/Search",
            data: { deptId: deptId, countryId: countryId, searchQuery: searchQuery },
            typr: "POST",
            success: function (tbody) {
                $('#tbody').empty();
                $('#tbody').append(tbody);
                
            },
            error: function (response) { }

        });
    }//End Search function


})