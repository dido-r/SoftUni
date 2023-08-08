const years = document.getElementById('years');
loadYears();

function loadYears() {

    hideSection();
    years.style.display = 'block';
    [...years.getElementsByTagName('td')].forEach(x => x.addEventListener('click', showYear));
}

function showYear(event) {

    let currentYear = event.target.tagName === 'DIV' ? event.target.textContent : event.target.querySelector('div').textContent;
    years.style.display = 'none';
    [...document.getElementsByClassName('monthCalendar')].forEach(x => x.style.display = 'none');
    let year = document.getElementById(`year-${currentYear}`);
    year.style.display = 'block';
    [...year.getElementsByTagName('td')].forEach(x => x.addEventListener('click', showMonth));
}

function showMonth(event) {

    let currentMonth;
    let currentYear;

    console.log(event.target.parentElement.parentElement.parentElement);
    if (event.target.tagName === 'DIV') {

        currentMonth = event.target.textContent;
        currentYear = event.target.parentElement.parentElement.parentElement.parentElement.querySelector('caption').textContent;
    }else{

        currentMonth = event.target.querySelector('div').textContent;
        currentYear = event.target.parentElement.parentElement.parentElement.getElementsByTagName('caption')[0].textContent;
    }

    let monthNumber;

    switch (currentMonth) {
        case 'Jan': monthNumber = 1; break;
        case 'Feb': monthNumber = 2; break;
        case 'Mar': monthNumber = 3; break;
        case 'Apr': monthNumber = 4; break;
        case 'May': monthNumber = 5; break;
        case 'Jun': monthNumber = 6; break;
        case 'Jul': monthNumber = 7; break;
        case 'Aug': monthNumber = 8; break;
        case 'Sep': monthNumber = 9; break;
        case 'Oct': monthNumber = 10; break;
        case 'Nov': monthNumber = 11; break;
        case 'Dec': monthNumber = 10; break;

    }
    let month = document.getElementById(`month-${currentYear}-${monthNumber}`);
    hideSection();
    month.style.display = 'block';
}

function hideSection() {

    [...document.getElementsByTagName('section')].forEach(x => x.style.display = 'none');
}