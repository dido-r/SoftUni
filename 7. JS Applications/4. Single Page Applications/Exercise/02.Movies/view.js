export { navigate, addMovieView, editMovieView, homeView }
import { showLikes } from './manageMovies.js';

const nav = document.querySelector('nav[class="navbar navbar-expand-lg navbar-dark bg-dark"]').getElementsByTagName('a');
const greeting = nav[1];
const logout = nav[2];
const login = nav[3];
const register = nav[4];
const homeSection = document.getElementById('home-page');
const movieListSection = document.getElementById('movie');
const addMovieSection = document.getElementById('add-movie');
const addMoviebutton = document.getElementById('add-movie-button');
const editMovieSection = document.getElementById('edit-movie');
const registerSection = document.getElementById('form-sign-up');
const loginSection = document.getElementById('form-login');
const movieDetailsSection = document.getElementById('movie-example');
const deleteButton = movieDetailsSection.querySelector('a[class="btn btn-danger"]');
const editButton = movieDetailsSection.querySelector('a[class="btn btn-warning"]');
const likeButton = movieDetailsSection.querySelector('a[class="btn btn-primary"]');

function navigate(event) {

    switch (event.target.textContent) {

        case 'Movies': homeView(); break;
        case 'Logout': logoutView(); break;
        case 'Login': loginView(); break;
        case 'Register': registerView(); break;
    }
}

function loginView() {

    hideSections();
    logout.style.display = 'none';
    loginSection.style.display = 'block';
}

function registerView() {

    hideSections();
    logout.style.display = 'none';
    registerSection.style.display = 'block';
}

function logoutView() {

    sessionStorage.removeItem('email');
    sessionStorage.removeItem('token');
    homeView();
}

function addMovieView() {

    hideSections();
    addMovieSection.style.display = 'block';
}

function editMovieView(event) {

    hideSections();
    let parent = event.target.parentElement.parentElement;
    let id = parent.getAttribute('movie-id');
    let name = parent.getElementsByTagName('h1')[0].textContent;
    let image = parent.querySelector('img[class="img-thumbnail"]').src;
    let description = parent.getElementsByTagName('p')[0].textContent;
    editMovieSection.querySelector('input[id="title"]').value = name.replace('Movie title: ', '');
    editMovieSection.querySelector('textarea[class="form-control"]').value = description;
    editMovieSection.querySelector('input[id="imageUrl"]').value = image;
    editMovieSection.setAttribute('movie-id', id);
    editMovieSection.style.display = 'block';
}

function homeView() {

    hideSections();
    showMovieList();
    homeSection.style.display = 'block';
    movieListSection.style.display = 'block';

    if (sessionStorage.getItem('email') != null) {

        logout.style.display = 'block';
        login.style.display = 'none';
        register.style.display = 'none';
        addMoviebutton.style.display = 'block';
        greeting.textContent = `Welcome, ${sessionStorage.getItem('email')}`;

    } else {

        logout.style.display = 'none';
        login.style.display = 'block';
        register.style.display = 'block';
        addMoviebutton.style.display = 'none';
        greeting.textContent = `Welcome, guest`;
    }
}

async function showMovieList() {

    const movieListUl = document.getElementById('movies-list');
    let frag = document.createDocumentFragment();
    let response = await fetch('http://localhost:3030/data/movies');
    let data = await response.json();

    if (response.ok === false || response.status !== 200) {

        return;
    }

    Object.values(data).map(x => {

        let div = document.createElement('div');
        div.className = 'card mb-4';
        div.setAttribute('owner-id', x._ownerId);
        div.id = x._id;
        div.innerHTML = `
        <img class="card-img-top" src="${x.img}"
            alt="Card image cap" width="400">
        <div class="card-body">
        <h4 class="card-title">${x.title}</h4>
        </div>
        <div class="card-footer">
            <a href="#/details/6lOxMFSMkML09wux6sAF">
                <button type="button" class="btn btn-info">Details</button>
            </a>
        </div>`;

        let button = div.querySelector('button[class="btn btn-info"]');
        button.disabled = sessionStorage.getItem('email') != null ? false : true;
        button.addEventListener('click', movieDetails);
        frag.append(div);
    });

    movieListUl.replaceChildren(frag);
}

async function movieDetails(event) {

    hideSections();
    let id = event.target.parentElement.parentElement.parentElement.id;
    let ownerId = event.target.parentElement.parentElement.parentElement.getAttribute('owner-id');
    let response = await fetch(`http://localhost:3030/data/movies/${id}`);
    let data = await response.json();

    if (response.ok === false || response.status !== 200) {

        alert('Something went wront. Please Try again.')
        return;
    }

    let movie = movieDetailsSection.querySelector('div[class="row bg-light text-dark"]');
    movie.setAttribute('movie-id', id);
    movie.setAttribute('creator-id', ownerId);
    movie.querySelector('img[class="img-thumbnail"]').src = data.img;
    movie.querySelector('h1').textContent = `Movie title: ${data.title}`;
    movie.getElementsByTagName('p')[0].textContent = data.description;

    let responseMe = await fetch('http://localhost:3030/users/me', {

        headers: { 'X-Authorization': `${sessionStorage.getItem('token')}` }
    });

    let dataMe = await responseMe.json();

    deleteButton.style.display = dataMe._id === ownerId ? 'inline' : 'none';
    editButton.style.display = dataMe._id === ownerId ? 'inline' : 'none';
    likeButton.style.display = dataMe._id === ownerId ? 'none' : 'inline';
    showLikes(id, dataMe._id);
    movieDetailsSection.style.display = 'block';
}

function hideSections() {

    [...document.getElementsByTagName('section')].forEach(x => x.style.display = 'none');
}