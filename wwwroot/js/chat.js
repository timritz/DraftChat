"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + " says: " + msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
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

// document.getElementsByClassName("select").addEventListener("click", function (event) {
$('.select-btn').click(function(){
    console.log($(this).attr("data-player"));
    console.log($(this).attr("data-name"));

    var user = $(this).attr("data-name");
    var player = $(this).attr("data-player");

    countDownDate = Date.now();
    var stringDate = countDownDate.toString();
    console.log(stringDate);

    connection.invoke("UpdateTimer", stringDate).catch(function (err) {
        console.log("got to updateTimer invoke error")
        return console.log(err.toString());
    });

    connection.invoke("SendPick", user, player).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});