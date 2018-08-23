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


    $(document).on("click", "#GetByAvail", function(){
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

    $(document).on("click", '.sortHead', function(){
        var sortVal = Number($(this).data('idx'));
        var direction = $(this).data('direction');
        var tBody = document.getElementById("pTableBody");
        var rows = tBody.rows;
        var arrRows = Array.prototype.slice.call( rows );
        var sortedRows = mergeSort(arrRows, sortVal);
        console.log("done!");
        $('#pTableBody').empty();
        if(direction == 'forward'){
            for (i = 0 ; i < (sortedRows.length); i++){
                $('#pTableBody').append(sortedRows[i]);
            }
            $(this).data('direction', 'reverse');
        } else {
            for (i = (sortedRows.length) ; i > 0; i--){
                $('#pTableBody').append(sortedRows[i]);
            }
            $(this).data('direction', 'forward');
        }

    });

    function mergeSort (arr, idx) {
        if (arr.length === 1) {
          // return once we hit an array with a single item
            return arr;
        }
      
        const middle = Math.floor(arr.length / 2); // get the middle item of the array rounded down
        const left = arr.slice(0, middle); // items on the left side
        const right = arr.slice(middle); // items on the right side
        if((idx == 0) || (idx == 2) || (idx == 3)){
            return mergeString(
                mergeSort(left, idx),
                mergeSort(right, idx),
                idx
            )
        } else {
            return mergeNum(
                mergeSort(left, idx),
                mergeSort(right, idx),
                idx
            )
        }
    }
      
      // compare the arrays item by item and return the concatenated result
    function mergeString (left, right, idx) {
        let result = [];
        let indexLeft = 0;
        let indexRight = 0;
      
        while (indexLeft < left.length && indexRight < right.length) {
            var leftName = left[indexLeft].getElementsByTagName("TD")[idx].innerHTML.toLowerCase();
            var rightName = right[indexRight].getElementsByTagName("TD")[idx].innerHTML.toLowerCase();
            if (leftName < rightName) {
                result.push(left[indexLeft])
                indexLeft++
            } else {
                result.push(right[indexRight])
                indexRight++
            }
        }
      
        return result.concat(left.slice(indexLeft)).concat(right.slice(indexRight))
      }

      function mergeNum (left, right, idx) {
        let result = [];
        let indexLeft = 0;
        let indexRight = 0;
      
        while (indexLeft < left.length && indexRight < right.length) {
            var leftName = Number(left[indexLeft].getElementsByTagName("TD")[idx].innerHTML);
            var rightName = Number(right[indexRight].getElementsByTagName("TD")[idx].innerHTML);
            if (leftName < rightName) {
                result.push(left[indexLeft])
                indexLeft++
            } else {
                result.push(right[indexRight])
                indexRight++
            }
        }
      
        return result.concat(left.slice(indexLeft)).concat(right.slice(indexRight))
      }

});


