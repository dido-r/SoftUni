function attachEventsListeners() {

    document.getElementById('daysBtn').addEventListener('click', days);
    document.getElementById('hoursBtn').addEventListener('click', hours);
    document.getElementById('minutesBtn').addEventListener('click', minutes);
    document.getElementById('secondsBtn').addEventListener('click', seconds);

    let day = document.getElementById('days');
    let hour = document.getElementById('hours');
    let minute = document.getElementById('minutes');
    let second = document.getElementById('seconds');

    function days(){

        hour.value = day.value * 24;
        minute.value = hour.value * 60;
        second.value = minute.value * 60;
    }

    function hours(){

        day.value = hour.value / 24;
        minute.value = hour.value * 60;
        second.value = minute.value * 60;
    }

    function minutes(){

        hour.value = minute.value / 60;
        day.value = hour.value / 24;
        second.value = minute.value * 60;
    }

    function seconds(){

        minute.value = second.value / 60;
        hour.value = minute.value / 60;
        day.value = hour.value / 24;
    }
}