"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();



connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + " says: " + msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

connection.on("ReceiveNewTeam", function (TeamName, TeamId) {
    var li = document.createElement("li");
    li.textContent = TeamName;
    li.className = "team-icon";
    li.id = "team-icon-"+TeamId;
    document.getElementById("teamList").appendChild(li);
});

connection.on("ReceiveTimer", function (counter) {
    console.log("got to recieveTimer")
    countDownDate = counter;
    
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

var countDownDate = new Date().getTime();

// Update the count down every 1 second
var x = setInterval(function() {
    
    // Get todays date and time
    var now = new Date().getTime();
    
    // Find the distance between now and the count down date
    var distance = countDownDate - now;
    
    // Time calculations for days, hours, minutes and seconds
    var days = Math.floor(distance / (1000 * 60 * 60 * 24));
    var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
    var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
    var seconds = 31 + Math.floor((distance % (1000 * 60)) / 1000);
    
    // Display the result in the element with id="demo"
    document.getElementById("demo").innerHTML = seconds + "s ";
    // console.log(distance)
    
    // If the count down is finished, write some text 
    if (distance <=-30000) {
        countDownDate = Date.now();
        connection.invoke("UpdateTimer", countDownDate).catch(function (err) {
            return console.error(err.toString());
        });
    }
}, 1000);

var pickNumber = 1;

connection.on("ReceivePick", function (user, player) {
    console.log("got to recieve pick")
    var ModifiedPlayer = player.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var NewPick = "Pick " + pickNumber +": "+ user + " - " + ModifiedPlayer;
    var li = document.createElement("li");
    li.textContent = NewPick;
    document.getElementById("RecentPickList").appendChild(li);
    pickNumber += 1;
});


connection.on("ReceiveNewCurrentTeam", function (nextPickTeamId) {

        var FantasyTeamId = document.getElementById("TeamId").value;
        
        console.log("RNCW FantasyTeamId: " + FantasyTeamId);
    
        console.log(" RNCW got to 'are you up next?'")
        console.log("RNCW my team " + FantasyTeamId)
        console.log("RNCW new team " + nextPickTeamId)
        // $('.select-btn').css('display', "none");
        $('.owner').css('display', "none");
        var elements = document.getElementsByClassName("select-btn");
        var textElements = document.getElementsByClassName("owner");
        if(FantasyTeamId != nextPickTeamId){
            for(var i =0; i< elements.length; i++){
                elements[i].style.display = "none";
                textElements[i].style.display = "block";
    
            }
        } else {
            for(var i =0; i< elements.length; i++){
                var FantasyTeamId = $(textElements[i]).attr("data-FantasyTeamId");
                console.log(FantasyTeamId)
                if(FantasyTeamId == null){
                    console.log("Fantasy Team Id is null")
                    elements[i].style.display = "block";
                    textElements[i].style.display = "none";
                } else {
                    elements[i].style.display = "none";
                    textElements[i].style.display = "block";
                }
                
            }
        }

});


// document.getElementsByClassName("select").addEventListener("click", function (event) {
    // $('.select-btn').click(function(){
$(document).on("click", ".select-btn", function(){
    
    var FantasyTeamId = document.getElementById("TeamId").value;
    var player = $(this).attr("data-player");
    var playerId = $(this).attr("data-playerId");
    
    countDownDate = Date.now();
    var stringDate = countDownDate.toString();
    console.log(stringDate);
    
    
    connection.invoke("UpdateDb", FantasyTeamId, playerId).catch(function (err) {
        console.log("got to UpdateDb invoke error");
        return console.log(err.toString());
    });
    
  
    // $.ajax({
    //     type: 'GET',
    //     url: '/Ajax/UpdateTable',
    //     cache: false,
    //     contentType: 'application/json; charset=utf-8'
    // })
    // .done(function(partialViewResult) {
    //     $("#tData").html(partialViewResult)
    // });



    connection.invoke("UpdateTimer", stringDate).catch(function (err) {
        console.log("got to updateTimer invoke error");
        return console.log(err.toString());
    });
    
    connection.invoke("SendPick", FantasyTeamId, player).catch(function (err) {
        return console.error(err.toString());
    });

    connection.invoke("UpdateTurn", FantasyTeamId).catch(function (err) {
        console.log("got to update turn");
        console.log("my team " + FantasyTeamId);
        return console.error(err.toString());
    });

    event.preventDefault();
});
        

setTimeout(function(){
    $(document).ready(function() {
        var element = $('#TeamId');
        console.log(element.val());
        var FantasyTeamId = element.val();
        connection.invoke("NewTeam", FantasyTeamId).catch(function (err) {
            return console.error(err.toString());
        });
    });
}, 1000);


//add player to roster on change of recent picks
$(document).on("click", ".select-btn", function(){
    setTimeout(function(){
            console.log("RPL********");
            var FantasyTeamId = document.getElementById("TeamId").value;
            console.log("fantasy team id RPL "+FantasyTeamId);
            $.ajax({
                type: 'GET',
                url: '/Ajax/RosterUpdate',
                cache: false,
                contentType: 'application/json; charset=utf-8',
                data: { 'FantasyTeamId': FantasyTeamId },
            })
            .done(function(partialViewResult) {
                console.log("RPL**********DONE");
                $("#update-roster").html(partialViewResult)
            });
    }, 500);
        });