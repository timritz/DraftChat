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
    console.log("FantasyTeamId: " + FantasyTeamId);

    console.log("got to 'are you up next?'")
    console.log("my team " + FantasyTeamId)
    console.log("new team " + nextPickTeamId)
    // $('.select-btn').css('display', "none");
    var elements = document.getElementsByClassName("select-btn");
    if(FantasyTeamId != nextPickTeamId){
        for(var i =0; i< elements.length; i++){
            elements[i].style.display = "none";
        }
    } else {
        for(var i =0; i< elements.length; i++){
            elements[i].style.display = "block";
        }
    }
});

// document.getElementsByClassName("select").addEventListener("click", function (event) {
    // $('.select-btn').click(function(){
$(document).on("click", ".select-btn", function(){
    console.log($(this).attr("data-player"));
    console.log($(this).attr("data-name"));
    console.log($(this).attr("data-playerId"));
    console.log($(this).attr("data-userId"));
    
    var user = $(this).attr("data-name");
    var player = $(this).attr("data-player");
    var userId = $(this).attr("data-userId");
    var playerId = $(this).attr("data-playerId");
    
    countDownDate = Date.now();
    var stringDate = countDownDate.toString();
    console.log(stringDate);
    
    
    connection.invoke("UpdateDb", userId, playerId).catch(function (err) {
        console.log("got to UpdateDb invoke error");
        return console.log(err.toString());
    });
    
    connection.invoke("UpdateTimer", stringDate).catch(function (err) {
        console.log("got to updateTimer invoke error");
        return console.log(err.toString());
    });
    
    connection.invoke("SendPick", user, player).catch(function (err) {
        return console.error(err.toString());
    });
    
    var FantasyTeamId = document.getElementById("TeamId").value;
    console.log("FantasyTeamId: " + FantasyTeamId);

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
}, 200);