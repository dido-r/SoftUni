function attachEvents() {

    document.getElementById('submit').addEventListener('click', getWeather);
    const current = document.getElementById('current');
    const upcoming = document.getElementById('upcoming');
    let symbol;

    async function getWeather() {

        let oldCurrent = current.getElementsByTagName('div')[1];
        if (oldCurrent !== undefined) { oldCurrent.remove() }
        let oldUpcoming = upcoming.getElementsByTagName('div')[1];
        if (oldUpcoming !== undefined) { oldUpcoming.remove() }

        let location = document.getElementById('location').value;

        if(location !== 'New York' && location !== 'Barcelona' && location !== 'London'){

            let div = document.createElement('div');
            div.textContent = 'Error';
            let div2 = div.cloneNode(true);
            current.appendChild(div);
            upcoming.appendChild(div2);
            return;
        }

        let code = await fetch('http://localhost:3030/jsonstore/forecaster/locations')
            .then(res => res.json())
            .then(data => data.find(x => x.name === location).code);

        await fetch(`http://localhost:3030/jsonstore/forecaster/today/${code}`)
            .then(res => res.json())
            .then(data => {

                switch (data.forecast.condition) {
                    case 'Sunny': symbol = '&#x2600'; break;
                    case 'Partly sunny': symbol = '&#x26C5'; break;
                    case 'Overcast': symbol = '&#x2601'; break;
                    case 'Rain': symbol = '&#x2614'; break;
                }

                document.getElementById('forecast').style.display = 'block';
                let div = document.createElement('div');
                div.className = 'forecasts';
                div.innerHTML = `
                <span class="condition symbol">${symbol}</span>
                <span class="condition">
                    <span class="forecast-data">${data.name}</span>
                    <span class="forecast-data">${data.forecast.low}°/${data.forecast.high}°</span>
                    <span class="forecast-data">${data.forecast.condition}</span>
                </span>`;
                current.appendChild(div);
            });

        await fetch(`http://localhost:3030/jsonstore/forecaster/upcoming/${code}`)
            .then(res => res.json())
            .then(data => {

                let div = document.createElement('div');
                div.className = 'forecast-info';

                data.forecast.map(x => {

                    switch (x.condition) {
                        case 'Sunny': symbol = '&#x2600'; break;
                        case 'Partly sunny': symbol = '&#x26C5'; break;
                        case 'Overcast': symbol = '&#x2601'; break;
                        case 'Rain': symbol = '&#x2614'; break;
                    }

                    let span = document.createElement('span');
                    span.className = 'upcoming';
                    span.innerHTML = `
                    <span class="symbol">${symbol}</span>
                    <span class="forecast-data">${x.low}°/${x.high}°</span>
                    <span class="forecast-data">${x.condition}</span>
                    </span>`;
                    div.appendChild(span);
                });

                upcoming.appendChild(div);
            });            
    }
}

attachEvents();