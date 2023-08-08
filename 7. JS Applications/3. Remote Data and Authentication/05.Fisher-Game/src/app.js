window.addEventListener('DOMContentLoaded', loadIndexPage);
const addButton = document.querySelector('button.add');
const addForm = document.getElementById('addForm');
addButton.addEventListener('click', addCatch);
addForm.addEventListener('submit', addCatch)
document.querySelector('button.load').addEventListener('click', loadCatches);
document.getElementById('logout').addEventListener('click', logOut)

function loadIndexPage() {

    let token = sessionStorage.getItem('token');

    if (token !== null) {

        document.getElementById('guest').style.display = 'none';
        document.querySelector('p.email span').textContent = sessionStorage.getItem('email');
        addButton.disabled = false;
    } else {
        document.getElementById('user').style.display = 'none';
        document.getElementById('guest').style.display = 'inline';
        addButton.disabled = true;
    }
}

function logOut() {

    sessionStorage.removeItem('token');
    sessionStorage.removeItem('email');
    document.querySelector('p.email span').textContent = 'guest';
    loadIndexPage();
}

async function loadCatches() {

    let catchesList = document.getElementById('catches');
    catchesList.innerHTML = '';
    let token = sessionStorage.getItem('token');

    let res = await fetch('http://localhost:3030/data/catches');
    let data = await res.json();
    Object.values(data).map(x => {

        let div = document.createElement('div');
        div.className = 'catch';
        div.innerHTML = `
        <label>Angler</label>
        <input type="text" class="angler" value="${x.angler}">
        <label>Weight</label>
        <input type="text" class="weight" value="${x.weight}">
        <label>Species</label>
        <input type="text" class="species" value="${x.species}">
        <label>Location</label>
        <input type="text" class="location" value="${x.location}">
        <label>Bait</label>
        <input type="text" class="bait" value="${x.bait}">
        <label>Capture Time</label>
        <input type="number" class="captureTime" value="${x.captureTime}">
        <button class="update" data-id="${x._id}">Update</button>
        <button class="delete" data-id="${x._id}">Delete</button>
        `;
        let update = div.querySelector('button.update');
        update.addEventListener('click', editCatch);
        let remove = div.querySelector('button.delete');
        remove.addEventListener('click', deleteCatch);

        if (token === null) {

            remove.disabled = true;
            update.disabled = true;
        } 

        catchesList.appendChild(div)
    });
}

async function addCatch(ev) {

    let token = sessionStorage.getItem('token');
    ev.preventDefault();
    let result = new FormData(addForm);
    let obj = {

        angler: result.get('angler'),
        weight: Number(result.get('weight')),
        species: result.get('species'),
        location: result.get('location'),
        bait: result.get('bait'),
        captureTime: Number(result.get('captureTime'))
    };

    await fetch('http://localhost:3030/data/catches', {

        method: 'post',
        headers: { 'X-Authorization': `${token}` },
        body: JSON.stringify(obj)
    });
    loadCatches();
}

async function editCatch(ev) {

    ev.preventDefault();
    let token = sessionStorage.getItem('token');
    let result = ev.target.parentElement;

    let obj = {

        angler: result.querySelector('input.angler').value,
        weight: Number(result.querySelector('input.weight').value),
        species: result.querySelector('input.species').value,
        location: result.querySelector('input.location').value,
        bait: result.querySelector('input.bait').value,
        captureTime: Number(result.querySelector('input.captureTime').value)
    };
    let id = ev.target.getAttribute('data-id');

    await fetch(`http://localhost:3030/data/catches/${id}`, {

        method: 'put',
        headers: { 'X-Authorization': `${token}` },
        body: JSON.stringify(obj)
    });
    loadCatches();
}

async function deleteCatch(ev) {

    ev.preventDefault();
    let token = sessionStorage.getItem('token');
    let id = ev.target.getAttribute('data-id');

    await fetch(`http://localhost:3030/data/catches/${id}`, {

        method: 'delete',
        headers: { 'X-Authorization': `${token}` }
    });
    loadCatches();
}