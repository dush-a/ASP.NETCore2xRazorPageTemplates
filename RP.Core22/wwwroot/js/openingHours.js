$(document).ready(function () {

    var now = new Date();
    var weekday = new Array(7);
    weekday[0] = "Sunday";
    weekday[1] = "Monday";
    weekday[2] = "Tuesday";
    weekday[3] = "Wednesday";
    weekday[4] = "Thursday";
    weekday[5] = "Friday";
    weekday[6] = "Saturday";

    var checkTime = function () {

    };

    var currentDay = weekday[now.getDay()];
    var currentDayID = "#" + currentDay; //gets todays weekday and turns it into id
    $(currentDayID).toggleClass("today"); //hightlights today in the view hours modal popup

   // setInterval(checkTime, 1000);
    // checkTime();

    $(function () {
        var today = weekday[now.getDay()];
        var timeDiv = document.getElementById('timeDiv');
        var dayOfWeek = now.getDay();
        var hour = now.getHours();
        var minutes = now.getMinutes();

        //add AM or PM
        var suffix = hour >= 12 ? "PM" : "AM";

        // add 0 to one digit minutes
        if (minutes < 10) {
            minutes = "0" + minutes
        };
        // debugger
        if (hour >= 13 && hour <= 23) {
            hour = ((hour + 11) % 12 + 1); //i.e. show 1:15 instead of 13:15
        }


        $('#timeDiv').openingTimes({
            openingTimes: {
                'Monday': ['08:00', '19:00'],
                'Tuesday': ['09:00', '19:00'],
                'Wednesday': ['08:00', '19:00'],
                'Thursday': ['08:00', '19:00'],
                'Friday': ['09:00', '19:00'],
                'Saturday': false
                //'Sunday': false
            },
            openString: 'it\'s ' + today + ' ' + hour + ':' + minutes + suffix + ' - we\'re open!',
            closedString: 'It\'s ' + today + ' ' + hour + ':' + minutes + suffix + ' - we\'re closed!',
            openClass: "open",
            closedClass: "closed-"
        });

    });

});
