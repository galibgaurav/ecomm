define(function () {
    //method to register the event
    function RegisterEvents() {
        document.getElementById("searchPage").addEventListener("keydown", GetPagesSearchResult);
        document.getElementById("nextSearchID").addEventListener("click", GetNextPagesSearchResult);
    }

    var pagingAfter;
    function GetNextPagesSearchResult() {
        debugger;
        var eventNext = { keyCode: '-99', nextPage: true };
        GetPagesSearchResult(eventNext);
    }



    //getting the page search result
    function GetPagesSearchResult(event) {
        debugger;
        //function will execute if enter button is pressed
        if ((event.keyCode === 13 || event.keyCode == -99) && document.getElementById("searchPage").value != '') {
            var tBody = document.getElementById("pageTableBody"), row, cell;
            //testing if app is logged in m if not login process will happen;
            FB.getLoginStatus(function (response) {
                if (response.status === 'connected') {
                    console.log('Logged in.');
                }
                else {
                    FB.login();
                }
            });
            var searchResult = document.getElementById("searchPage").value;
            //calling Facebook page search API
            if (event.nextPage == true && pagingAfter != '') {

                FB.api('/search', 'get', { q: searchResult, type: 'page', after: pagingAfter }, function (response) {
                    if (!response || response.error) {
                        alert('Error occured');
                    }
                    else if (response.data.length > 0) {
                        debugger;
                        var count = response.data.length;
                        //response.data will contain page with id; 
                        for (index = 0; index < response.data.length; index++) {
                            //filling table with page name
                            row = tBody.insertRow(0);
                            cell = row.insertCell();
                            //content of each column
                            cell.innerHTML = '<div onclick="AboutSelectedPage(this)" ><a>' + count + '. ' + response.data[index].name + '</a><div data-pageid="' + response.data[index].id + '" id="aboutPage" style="color:aqua; Background: darkblue"></div></div><div onclick="LikePage(this)" data-pageid="' + response.data[index].id + '" ><a style="color:blue">Like/Unlike</a></div>';
                            count--;
                        }
                        pagingAfter = response.paging.cursors.after;
                    }
                });

            }
            else {
                FB.api('/search', 'get', { q: searchResult, type: 'page' }, function (response) {
                    if (!response || response.error) {
                        alert('Error occured');
                    }
                    else if (response.data.length > 0) {
                        debugger;
                        var count = response.data.length;
                        //response.data will contain page with id; 
                        for (index = 0; index < response.data.length; index++) {
                            //filling table with page name
                            row = tBody.insertRow(0);
                            cell = row.insertCell();
                            //content of each column
                            cell.innerHTML = '<div onclick="AboutSelectedPage(this)" ><a>' + count + '. ' + response.data[index].name + '</a><div data-pageid="' + response.data[index].id + '" id="aboutPage" style="color:aqua; Background: darkblue"></div></div><div onclick="LikePage(this)" data-pageid="' + response.data[index].id + '" ><a style="color:blue">Like/Unlike</a></div>';
                            count--;
                        }
                        pagingAfter = response.paging.cursors.after;
                    }
                });
            }
        }
    }
    return {
        RegisterEvents: RegisterEvents,
        GetPagesSearchResult: GetPagesSearchResult,
        GetNextPagesSearchResult: GetNextPagesSearchResult
    }
});
