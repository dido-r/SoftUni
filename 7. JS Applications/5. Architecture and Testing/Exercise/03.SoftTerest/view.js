import { logoutUser } from './logout.js';
export { homeView, dashboardView, onNavigate }

const home = document.getElementsByClassName('container home wrapper  my-md-5 pl-md-5')[0];
const register = document.getElementsByClassName('container home wrapper  my-md-5 pl-md-5')[1];
const login = document.getElementsByClassName('container home wrapper  my-md-5 pl-md-5')[2];
const dashboard = document.getElementById('dashboard-holder');
const create = document.getElementsByClassName('container home wrapper  my-md-5 pl-md-5')[3];
const details = document.getElementsByClassName('container home some')[0];
const navLi = document.getElementsByClassName('navbar-nav ml-auto')[0].getElementsByTagName('li');

function onNavigate(event) {

    event.preventDefault();
    hideContent();
    let current = event.target.textContent;

    switch (current) {

        case 'Dashboard': dashboardView(); break;
        case 'Create': create.style.display = 'block'; break;
        case 'Login': login.style.display = 'block'; break;
        case 'Register': register.style.display = 'block'; break;
        case 'Logout': logoutUser(); break;
        case 'Sign-Up': register.style.display = 'block'; break;
        case 'Sign-In': login.style.display = 'block'; break;
        case 'Get Started': register.style.display = 'block'; break;

    }
}

async function dashboardView() {

    hideContent();
    dashboard.style.display = 'block';

    let res = await fetch('http://localhost:3030/data/ideas?select=_id%2Ctitle%2Cimg&sortBy=_createdOn%20desc');
    let data = await res.json();

    if (res.ok == false) {

        throw new Error('Invalid request');
    }

    if (data.lenght === 0) {

        dashboard.innerHTML = '<h1>No ideas yet! Be the first one :)</h1>';
    }

    let fragment = document.createDocumentFragment();

    [...Object.values(data)].forEach(x => {

        let div = document.createElement('div');
        div.className = 'card overflow-hidden current-card details';
        div.style = 'width: 20rem; height: 18rem;';
        div.id = `${x._id}`;
        div.innerHTML = `
            <div class="card-body">
                <p class="card-text">${x.title}</p>
            </div>
            <img class="card-image" src="${x.img}" alt="Card image cap">
            <a class="btn" href="">Details</a>`;
        div.querySelector('a').addEventListener('click', showDetails)
        fragment.appendChild(div);
    });

    dashboard.replaceChildren(fragment)
}

function homeView() {

    if (localStorage.getItem('token') !== null) {

        navLi[0].style.display = 'inline';
        navLi[1].style.display = 'inline';
        navLi[2].style.display = 'inline';
        navLi[3].style.display = 'none';
        navLi[4].style.display = 'none';

    } else {

        navLi[0].style.display = 'inline';
        navLi[1].style.display = 'none';
        navLi[2].style.display = 'none';
        navLi[3].style.display = 'inline';
        navLi[4].style.display = 'inline';
    }

    hideContent();
    home.style.display = 'block';
}

async function showDetails(event) {

    event.preventDefault();
    hideContent();
    details.style.display = 'block';
    let id = event.target.parentElement.id;
    let res = await fetch('http://localhost:3030/data/ideas/' + id);
    let data = await res.json();

    if (res.ok == false) {

        throw new Error('Unsuccessful request');
    }

    details.innerHTML = `
        <img class="det-img" src="${data.img}" />
        <div class="desc">
            <h2 class="display-5">${data.title}</h2>
            <p class="infoType">Description:</p>
            <p class="idea-description">${data.description}</p>
        </div>
        <div class="text-center">
        </div>`;
    let deleteButton = details.querySelector('a');
    deleteButton.className = 'btn detb';
    deleteButton.href = '';
    deleteButton.style.display = 'none';
    deleteButton.textContent = 'Delete';
    deleteButton.setAttribute('detailsID', id)
    deleteButton.addEventListener('click', deleteIdea);

    if (localStorage.getItem('token') !== null) {

        deleteButtonVisibility(data._ownerId, deleteButton);
    }
}

async function deleteButtonVisibility(owner, button) {

    let response = await fetch('http://localhost:3030/users/me', {

        headers: { 'X-Authorization': `${localStorage.getItem('token')}` }
    });

    let data = await response.json();

    if (data._id === owner) {

        details.querySelector('.text-center').appendChild(button);
    }
}

async function deleteIdea(event) {

    event.preventDefault();

    try {
        let id = event.target.getAttribute('detailsID');

        let response = await fetch('http://localhost:3030/data/ideas/' + id, {

            method: 'delete',
            headers: { 'X-Authorization': `${localStorage.getItem('token')}` }
        });

        if (response.ok == false) {

            throw new Error('Unsuccessful request');
        }

        dashboardView();

    } catch (err) {

        alert(err.message);
        return;
    }
}

function hideContent() {

    home.style.display = 'none';
    register.style.display = 'none';
    login.style.display = 'none';
    dashboard.style.display = 'none';
    create.style.display = 'none';
    details.style.display = 'none';
}