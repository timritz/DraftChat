$(document).ready( function() {
    // console.log("Here here here ")
//     //Query to populate table by team name
    $(document).on("change", "#GetByTeam", function(){
        var enterData = $(this).val();
        console.log("I'm here!");
        console.log(enterData);
        $.ajax({
            type: 'GET',
            url: '/Ajax/AllOfTeam',
            cache: false,
            contentType: 'application/json; charset=utf-8',
            data: { 'team': enterData },
        })
        .done(function(partialViewResult) {
            $("#tData").html(partialViewResult)
        });
    });


// query to populate by position
$(document).on("change", "#GetByPos", function(){
    console.log("I'm here!");
    var enterData = $(this).val();
    console.log(enterData);
    $.ajax({
        type: 'GET',
        url: '/Ajax/AllOfPos',
        cache: false,
        contentType: 'application/json; charset=utf-8',
        data: { 'position': enterData },
    })
    .done(function(partialViewResult) {
        console.log("Here!!!")
        $("#tData").html(partialViewResult)
    });
});


$(document).on("click", ".GetByAvail", function(){
    var enterData = $(this).val();
    console.log("I'm here!");
    console.log(enterData);
    $.ajax({
        type: 'GET',
        url: '/Ajax/AllOfAvail',
        cache: false,
        contentType: 'application/json; charset=utf-8',
        data: { 'avail': enterData },
    })
    .done(function(partialViewResult) {
        $("#tData").html(partialViewResult)
    });
});

$('.select').click(function(){
    console.log($(this).attr("data-player"));
    console.log($(this).attr("data-name"));
});
$('#SortPName').click(function(){

});
$('#SortAge').click(function(){

});
$('#SortTName').click(function(){

});
$('#SortPos').click(function(){

});
$('#SortFPoints').click(function(){

});
$('SortRank').click(function(){
});
});


