$(document).ready(function () {
    //alert("1");
});

function ringAlarm() {
   // alert("2");
    // Play sound
    var txt = document.getElementById('txtAlarm').value;
    if (txt == 'ajay') {
        startAlarm();
    }
    
    
}


var audio = new Audio('audio/alarm.mp3'); // Relative path to the audio file
var alarmButton = document.getElementById('alarmButton');
// Function to start the alarm
function startAlarm() {
    // Start audio playback
    audio.loop = true; // Loop the audio
    audio.play();
    alarmButton.classList.add('blinking');
    //alert("Alarm activated!");
}

// Function to stop the alarm
function stopAlarm() {
    // Stop audio playback
    audio.pause();
    audio.currentTime = 0; // Reset audio to beginning
    alert("Alarm stopped!");
    alarmButton.classList.remove('blinking');
}