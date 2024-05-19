

//function ringAlarm(id,id2) {
//    // alert("2");
//    // Play sound
//    //id2 = "true";
//    var txt = document.getElementById('txtAlarm').value;
//    if (id == true) {
//        startAlarm();
//    }


//}

//var baseUrl = window.location.origin;

//// Construct the relative path to the audio file
//var audioUrl = baseUrl + '/audio/alarm.mp3';

//// Create an Audio object with the constructed URL
//var audio = new Audio(audioUrl);

//// Relative path to the audio file

//// Function to start the alarm
//function startAlarm() {
//    // Get the base URL of the current page

//    var alarmButton = document.getElementById('alarmButton');
//    //var audio = new Audio('~/audio/alarm.mp3');

//    audio.addEventListener('play', function () {
//        console.log('Audio playback started');
//    });
//    // Start audio playback
//    audio.loop = true; // Loop the audio
//    audio.play();
//    alarmButton.classList.add('blinking');
//    //alert("Alarm activated!");
//}

//// Function to stop the alarm
//function stopAlarm() {
//    //var audio = new Audio('audio/alarm.mp3');
//    // Stop audio playback
//    var alarmButton = document.getElementById('alarmButton');
//    audio.pause();
//    audio.currentTime = 0; // Reset audio to beginning
//    showBSAlert(__WARNING, "Alarm Stopped", __WARNING);
//    alarmButton.classList.remove('blinking');
//}



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

//function TurnOnOffLed(id) {

//    if (id == true) {
//        startAlarm();
//    }

//    var buttonName = $("#ledTurnOnOff")
//    var id = 0;
//    var button = document.getElementById("ledTurnOnOff");
//    if (button.textContent === "Turn Off Led") {
//        button.textContent = "Turn On Led";
//        id = 1;
//    } else {
//        button.textContent = "Turn Off Led";
//        id = 0;
//    }

//    $.ajax({
//        url: '/Home/TurnOnOffLed',
//        data: {"id":id},
//        type: "POST",
//        cache: false,
//        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
//        success: function (result) {

//            //  $("#btnUnAssign").attr("class", "btn btn-primary disabled");
//            // $("#nxtUnassigned").attr("class", "btn btn-primary disabled");
//        },
//        error: function (xhr, ajaxOptions, thrownError) {
//            removeLoader("#divPri1");
//        }
//    });
//}





document.addEventListener('DOMContentLoaded', (event) => {
    var audio = new Audio('/audio/alarm.mp3');
    var alarmButton = document.getElementById('alarmButton');
    var manuallyStopped = false;
    var stopDuration = 60000; // 5 minutes in milliseconds
    var isautomaticStopped = false;

    function startAlarm() {
        if (audio.paused) {
            audio.loop = true;
            audio.play().catch(function (error) {
                console.log("Audio playback failed: " + error);
            });
        }
        alarmButton.classList.add('blinking');
    }

    function stopAlarm() {
        if (!audio.paused) {
            audio.pause();
            audio.currentTime = 0;
        }
        alarmButton.classList.remove('blinking');
        manuallyStopped = true;
        setTimeout(() => {
            manuallyStopped = false;
        }, stopDuration);
        if (isautomaticStopped == false) {
            showBSAlert(__WARNING, "Alarm Stopped manually", __WARNING);
        }
    }

    function fetchModbusValue() {
        fetch('/Home/GetModbusValue')
            .then(response => response.json())
            .then(data => {
                var modbusValue = data.value;

                document.getElementById('modbusValueDisplay').textContent = modbusValue;
                document.getElementById('alarmThresholdDisplay').textContent = 5000;


                if (!manuallyStopped && modbusValue >= 5000) {
                    startAlarm();
                } else if (modbusValue < 5000) {
                    stopAlarm();
                    isautomaticStopped = true;
                }
            })
            .catch(error => console.error('Error fetching Modbus value:', error));
    }

    setInterval(fetchModbusValue, 1000);

    alarmButton.addEventListener('click', function () {
        stopAlarm();
    });


    toggleBitButton.addEventListener('click', function () {
        fetch('/Home/ToggleBit', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ address: 40001, bitIndex: 0 })
        })
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    alert('Bit toggled successfully');
                } else {
                    alert('Failed to toggle bit');
                }
            })
            .catch(error => console.error('Error toggling bit:', error));
    });

});




        