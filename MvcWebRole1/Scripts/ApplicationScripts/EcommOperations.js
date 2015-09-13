define(function () {
    //method to register the event
    function RegisterEvents() {
        document.getElementById("searchPage").addEventListener("keydown", GetPagesSearchResult);
        document.getElementById("nextSearchID").addEventListener("click", GetNextPagesSearchResult);
    }

    function LoadSummaryPage() {

        $.ajax({
            type: "POST",
            url: "Home/ProductSummary",
            contentType: "application/json; charset=utf-8",
            data: { a: "testing" },
            dataType: "json",
            success: function (result) {
                debugger;
                ShowProductSummary(result);
            },
            error: function () {
                alert('Error');
            }
        });
    }
   

    function ShowProductSummary(result) {
        var htmlString='';
        ///var htmlString = '<div style="color:#0000FF;background-color:white;display:inline-block"><table class="row" style="height:180px;width:195px;margin-top:5px;margin-left:5px;"><tbody><tr><td colspan="2">  <img src="/Images/' + result[1].IconPath + '" style="width:60px;height:60px"></td></tr><tr><label><font size="2">' + result[1].ProductName + '</font></label></tr><tr><label><font size="2">Price- ' + result[1].ProductPrice + '</font></label></tr><tr><td><input type="hidden" name="ProductId" value="' + result[1].ProductId + '"></td></tr><tr><td>*****</td><td><input type="button" value="Details"></td></tr></tbody></table></div>';
        for (var i = 0; i < result.length; i++) {
            htmlString = htmlString.concat('<div style="color:#0000FF;background-color:white;display:inline-block;margin-left:5px;margin-top:10px;" onclick="displayProductDetails(this)"><table class="row" style="height:180px;width:195px;margin-top:8px;margin-left:8px;"><tbody><tr><td colspan="2">  <img src="/Images/' + result[i].IconPath + '" style="width:60px;height:60px"></td></tr><tr><label><font size="2">' + result[i].ProductName + '</font></label></tr><tr><label><font size="2">Price- ' + result[i].ProductPrice + '$</font></label></tr><tr><td><input type="hidden" name="ProductId" value="' + result[i].ProductId + '"></td></tr><tr><td>' + Review(result[i].Ratings) + '</td><td><input  type="button" value="Details"></td></tr></tbody></table></div>');
        //    //Do something
        }
        debugger;
        $('#summaryDiv').text('');
        $('#summaryDiv').append(htmlString);
    }

    return {
        LoadSummaryPage: LoadSummaryPage,
       // displayProductDetails: displayProductDetails
        }
});
