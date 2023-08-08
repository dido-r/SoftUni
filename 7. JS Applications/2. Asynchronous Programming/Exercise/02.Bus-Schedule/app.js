function solve() {

    let current = 'depot';
    const info = document.getElementById('info');
    const departButton = document.getElementById('depart');
    const arriveButton = document.getElementById('arrive');

    async function depart() {

        let res = await fetch(`http://localhost:3030/jsonstore/bus/schedule/${current}`)
        
        if(res.ok == false){

            info.textContent = 'Error';
            departButton.disabled = true;
            arriveButton.disabled = true;
        }
        
        res.json().then(data => {

            info.textContent = `Next stop ${data.name}`;
            departButton.disabled = true;
            arriveButton.disabled = false;
        });
    }

    async function arrive() {
        
        let res = await fetch(`http://localhost:3030/jsonstore/bus/schedule/${current}`);

        if(res.ok == false){

            info.textContent = 'Error';
            departButton.disabled = true;
            arriveButton.disabled = true;
        }

        res.json().then(data => {

            info.textContent = `Arriving at ${data.name}`;
            current = data.next;
            departButton.disabled = false;
            arriveButton.disabled = true;
        });
    }

    return {
        depart,
        arrive
    };
}

let result = solve();