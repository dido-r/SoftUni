function solve() {

    let container = document.getElementById('container').getElementsByTagName('input');
    let name = container[0];
    let hall = container[1];
    let ticketPrice = container[2];
    let button = document.querySelector('body form div button');
    button.addEventListener('click', onScreen);

    function onScreen(event) {

        event.preventDefault();

        if (name.value !== '' && hall.value !== '' && ticketPrice.value !== '' && !isNaN(parseInt(ticketPrice.value))) {

            let span = document.createElement('span');
            span.textContent = name.value;
            let strong = document.createElement('strong');
            strong.textContent = `Hall: ${hall.value}`;
            let ticket = document.createElement('strong');
            ticket.textContent = `${Number(ticketPrice.value).toFixed(2)}`;
            let input = document.createElement('input');
            input.placeholder = 'Tickets Sold';
            let archive = document.createElement('button');
            archive.textContent = 'Archive';
            archive.addEventListener('click', archiveMovie)
            let div = document.createElement('div');
            div.appendChild(ticket);
            div.appendChild(input);
            div.appendChild(archive);
            let li = document.createElement('li');
            li.appendChild(span);
            li.appendChild(strong);
            li.appendChild(div);
            document.getElementById('movies').querySelector('ul').appendChild(li);
            name.value = '';
            hall.value = '';
            ticketPrice.value = '';
        }
    }

    function archiveMovie(event) {

        let movie = event.target.parentElement.parentElement;
        let ticketSold = movie.querySelector('div input');

        if (ticketSold.value !== '' && !isNaN(parseInt(ticketSold.value))) {

            let price = movie.querySelector('div strong').textContent;
            let totalPrice = Number(ticketSold.value) * Number(price);
            movie.getElementsByTagName('div')[0].remove();
            movie.getElementsByTagName('strong')[0].textContent = `Total amount: ${totalPrice.toFixed(2)}`;
            let deleteButton = document.createElement('button');
            deleteButton.textContent = 'Delete';
            deleteButton.addEventListener('click', deleteMovie);
            movie.appendChild(deleteButton);
            document.getElementById('archive').getElementsByTagName('ul')[0].appendChild(movie);
        }
    }

    function deleteMovie(event) {

        event.target.parentElement.remove();
    }

    let archiveList = document.getElementById('archive');
    clearButton = archiveList.getElementsByTagName('button')[0];
    clearButton.addEventListener('click', clearList);

    function clearList() {

        let ul = archiveList.getElementsByTagName('ul')[0];
        ul.innerHTML = '';
    }
}