$(function () {

    //#region Event

    // 寫入客戶
    $("#insertCustomer").on("click", function () {
        InsertCustomer();
    });

    // 更新客戶
    $("#updateCustomer").on("click", function () {
        UpdateCustomer();
    });

    // 刪除客戶
    $("#deleteCustomer").on("click", function () {
        DeleteCustomer();
    });

    //#endregion

    //#region Private Method

    function InsertCustomer() {
        
        var data = {
            "CustomerID": "8787R",
            "CompanyName": "defaultCompanyName"
        };

        $.ajax({
            type: "POST",
            crossDomain: true,
            url: "https://localhost:44339/Customers/Insert",
            headers: {
                "Content-Type": "application/json"
            },
            data: JSON.stringify(data),
            success: function (data) {
                console.log(data);
            },
            error: function (xhr, responseText) {
                console.log(xhr);
                console.log(responseText);
            }
        });
    }

    function UpdateCustomer() {

        var data = {
            "CustomerID": "8787R",
            "CompanyName": "CompanyNameUpdated"
        };

        $.ajax({
            type: "PUT",
            crossDomain: true,
            url: "https://localhost:44339/Customers/Update",
            headers: {
                "Content-Type": "application/json"
            },
            data: JSON.stringify(data),
            success: function (data) {
                console.log(data);
            },
            error: function (xhr, responseText) {
                console.log(xhr);
                console.log(responseText);
            }
        });
    }

    function DeleteCustomer() {

        $.ajax({
            type: "DELETE",
            crossDomain: true,
            url: "https://localhost:44339/Customers/Delete/".concat("8787R"),
            headers: {
                "Content-Type": "application/json"
            },
            success: function (data) {
                console.log(data);
            },
            error: function (xhr, responseText) {
                console.log(xhr);
                console.log(responseText);
            }
        });
    }
    
    //#endregion
});