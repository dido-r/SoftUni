import { navigate, addMovieView, editMovieView, homeView } from './view.js';
import { registerUser } from './register.js';
import { loginUser } from './login.js';
import { addMovie, deleteMovie, editMovie, likeMovie } from './manageMovies.js';
export { init }

function init() {

    const movieDetailsSection = document.getElementById('movie-example');
    const editMovieSection = document.getElementById('edit-movie');
    const addMoviebutton = document.getElementById('add-movie-button');

    let nav = document.querySelector('nav[class="navbar navbar-expand-lg navbar-dark bg-dark"]').getElementsByTagName('a');
    [...nav].forEach(x => x.addEventListener('click', navigate));
    document.getElementById('register-form').addEventListener('submit', registerUser);
    document.getElementById('form-login').addEventListener('submit', loginUser);
    document.getElementById('add-movie-form').addEventListener('submit', addMovie);
    movieDetailsSection.querySelector('a[class="btn btn-danger"]').addEventListener('click', deleteMovie);
    movieDetailsSection.querySelector('a[class="btn btn-warning"]').addEventListener('click', editMovieView);
    movieDetailsSection.querySelector('a[class="btn btn-primary"]').addEventListener('click', likeMovie);
    editMovieSection.querySelector('form').addEventListener('submit', editMovie);
    addMoviebutton.addEventListener('click', addMovieView);
    homeView();
}