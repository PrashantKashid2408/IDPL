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

var baseUrl = window.location.origin;

// Construct the relative path to the audio file
var audioUrl = baseUrl + '/audio/alarm.mp3';

// Create an Audio object with the constructed URL
var audio = new Audio(audioUrl);

// Relative path to the audio file
var alarmButton = document.getElementById('alarmButton');
// Function to start the alarm
function startAlarm() {
    // Get the base URL of the current page
   

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
    audio.pause();
    audio.currentTime = 0; // Reset audio to beginning
    showBSAlert(__WARNING, "Alarm Stopped", __WARNING);
    alarmButton.classList.remove('blinking');
}