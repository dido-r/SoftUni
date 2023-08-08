function getInfo() {

    const arr = ['1287', '1308', '1327', '2334'];
    const stopId = document.getElementById('stopId').value;
    const buses = document.getElementById('buses');
    buses.innerHTML = '';

    if (arr.find(x => x === stopId) === undefined) {

        document.getElementById('stopName').textContent = 'Error';
        return;
    }

    fetch(`http://localhost:3030/jsonstore/bus/businfo/${stopId}`)
        .then(res => res.json())
        .then(data => {

            let busData = data.buses;
            let name = data.name;
            document.getElementById('stopName').textContent = name;

            for (let [key, value] of Object.entries(busData)) {

                let li = document.createElement('li');
                li.textContent = `Bus ${key} arrives in ${value} minutes`;
                buses.appendChild(li);
            }
        })
}