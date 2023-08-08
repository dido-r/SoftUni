window.addEventListener("load", solve);

function solve() {

    const productType = document.getElementById('type-product');
    const description = document.getElementById('description');
    const client = document.getElementById('client-name');
    const phone = document.getElementById('client-phone');
    const receiverOrders = document.getElementById('received-orders');
    const comleteOrders = document.getElementById('completed-orders');
    document.querySelector('section div form button').addEventListener('click', sendForm);
    document.querySelector('#completed-orders button').addEventListener('click', clear);

    function sendForm(event) {

        event.preventDefault();

        if (productType.value == '' || description.value == '' || client.value == '' || phone.value == '') {

            return;
        }

        let div = document.createElement('div');
        let h2 = document.createElement('h2');
        let h3 = document.createElement('h3');
        let h4 = document.createElement('h4');
        let startButton = document.createElement('button');
        let endButton = document.createElement('button');

        div.className = 'container';
        h2.textContent = `Product type for repair: ${productType.value}`;
        h3.textContent = `Client information: ${client.value}, ${phone.value}`;
        h4.textContent = `Description of the problem: ${description.value}`;
        startButton.className = 'start-btn';
        startButton.textContent = 'Start repair';
        endButton.className = 'finish-btn';
        endButton.textContent = 'Finish repair';
        endButton.disabled = true;
        startButton.addEventListener('click', startRepair);
        endButton.addEventListener('click', endRepair);

        div.appendChild(h2);
        div.appendChild(h3);
        div.appendChild(h4);
        div.appendChild(startButton);
        div.appendChild(endButton);
        receiverOrders.appendChild(div);    

        description.value = '';
        client.value = '';
        phone.value = '';
        
        function startRepair(event) {

            event.target.disabled = true;
            event.target.parentElement.getElementsByTagName('button')[1].disabled = false;
        }

        function endRepair(event) {

            let order = event.target.parentElement;
            order.getElementsByTagName('button')[0].remove();
            order.getElementsByTagName('button')[0].remove();
            comleteOrders.appendChild(order);
        }
    }

    function clear() {

        let divs = comleteOrders.getElementsByTagName('div');

        for (let div of Array.from(divs)) {

            div.remove();
        }
    }
}