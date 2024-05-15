

function ringAlarm(id,id2) {
    // alert("2");
    // Play sound
    //id2 = "true";
    var txt = document.getElementById('txtAlarm').value;
    if (txt == 'a' || id2 == true) {
        startAlarm();
    }


}

var baseUrl = window.location.origin;

// Construct the relative path to the audio file
var audioUrl = baseUrl + '/audio/alarm.mp3';

// Create an Audio object with the constructed URL
var audio = new Audio(audioUrl);

// Relative path to the audio file

// Function to start the alarm
function startAlarm() {
    // Get the base URL of the current page

    var alarmButton = document.getElementById('alarmButton');
    //var audio = new Audio('~/audio/alarm.mp3'); 

    audio.addEventListener('play', function () {
        console.log('Audio playback started');
    });
    // Start audio playback
    audio.loop = true; // Loop the audio
    audio.play();
    alarmButton.classList.add('blinking');
    //alert("Alarm activated!");
}

// Function to stop the alarm
function stopAlarm() {
    //var audio = new Audio('audio/alarm.mp3');
    // Stop audio playback
    var alarmButton = document.getElementById('alarmButton');
    audio.pause();
    audio.currentTime = 0; // Reset audio to beginning
    showBSAlert(__WARNING, "Alarm Stopped", __WARNING);
    alarmButton.classList.remove('blinking');
}



// Function to update live time
function updateTime() {
    var now = new Date();
    var date = now.toLocaleDateString();
    var hours = now.getHours().toString().padStart(2, '0');
    var minutes = now.getMinutes().toString().padStart(2, '0');
    var seconds = now.getSeconds().toString().padStart(2, '0');
    var timeString = date + '  ' + hours + ':' + minutes + ':' + seconds;
    $("#liveTime").text(timeString);
}

// Call updateTime() to initialize time immediately when the page loads
updateTime();

// Update time every second after the initial call
setInterval(updateTime, 1000);

function TurnOnOffLed(id) {

    if (id == true) {
        startAlarm();
    }

    var buttonName = $("#ledTurnOnOff")
    var id = 0;
    var button = document.getElementById("ledTurnOnOff");
    if (button.textContent === "Turn Off Led") {
        button.textContent = "Turn On Led";
        id = 1;
    } else {
        button.textContent = "Turn Off Led";
        id = 0;
    }
   
    $.ajax({
        url: '/Home/TurnOnOffLed',
        data: {"id":id},
        type: "POST",
        cache: false,
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        success: function (result) {
           
            //  $("#btnUnAssign").attr("class", "btn btn-primary disabled");
            // $("#nxtUnassigned").attr("class", "btn btn-primary disabled");
        },
        error: function (xhr, ajaxOptions, thrownError) {
            removeLoader("#divPri1");
        }   
    });
}


        