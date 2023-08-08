export { addMovie, deleteMovie, editMovie, likeMovie, showLikes}
import { homeView } from "./view.js";

const editMovieSection = document.getElementById('edit-movie');
const movieDetailsSection = document.getElementById('movie-example');
const likeButton = movieDetailsSection.querySelector('a[class="btn btn-primary"]');

async function addMovie(event) {

    event.preventDefault();

    try {

        let form = new FormData(event.target);
        let { title, description, img } = Object.fromEntries(form);

        if (title === '' || description === '' || img === '') {

            throw new Error('All fields required');
        }

        let movie = {

            title,
            description,
            img
        }

        let response = await fetch('http://localhost:3030/data/movies', {

            method: 'post',
            headers: { 'X-Authorization': `${sessionStorage.getItem('token')}` },
            body: JSON.stringify(movie)
        });

        if (response.ok === false || response.status !== 200) {

            throw new Error('Something wet wrong')
        }

        [...event.target.getElementsByTagName('input')].map(x => x.value = '');
        event.target.getElementsByTagName('textarea')[0].value = '';
        homeView();

    } catch (error) {

        alert(error.message);
        return;
    }
}

async function deleteMovie(event) {

    let id = event.target.parentElement.parentElement.getAttribute('movie-id');

    let response = await fetch(`http://localhost:3030/data/movies/${id}`, {

        method: 'delete',
        headers: { 'X-Authorization': `${sessionStorage.getItem('token')}` }
    });

    if (response.ok === false || response.status !== 200) {

        alert('Something went wront. Please Try again.')
        return;
    }

    homeView();
}

async function editMovie(event) {

    event.preventDefault();
    let id = editMovieSection.getAttribute('movie-id');

    let form = new FormData(event.target);
    let { title, description, img } = Object.fromEntries(form);

    let movie = {

        title,
        description,
        img
    }

    let response = await fetch(`http://localhost:3030/data/movies/${id}`, {

        method: 'put',
        headers: { 'X-Authorization': `${sessionStorage.getItem('token')}` },
        body: JSON.stringify(movie)
    });

    if (response.ok === false || response.status !== 200) {

        alert('Something went wront. Please Try again.')
        return;
    }

    editMovieSection.querySelector('input[id="title"]').value = '';
    editMovieSection.querySelector('textarea[class="form-control"]').value = '';
    editMovieSection.querySelector('input[id="imageUrl"]').value = '';
    homeView();
}

async function likeMovie(event) {

    event.preventDefault();
    let id = event.target.parentElement.parentElement.getAttribute('movie-id');

    let response = await fetch('http://localhost:3030/data/likes', {

        method: 'post',
        headers: { 'X-Authorization': `${sessionStorage.getItem('token')}` },
        body: JSON.stringify({ movieId: id })
    });

    if (response.ok === false || response.status !== 200) {

        alert('Something went wront. Please Try again.')
        return;
    }

    event.target.style.display = 'none';
    showLikes(id);
}

async function showLikes(id, myId) {

    let likes = 0;
    let res = await fetch('http://localhost:3030/data/likes')
    let data = await res.json();
    let isLiked = false;

    [...Object.values(data)].filter(x => x.movieId === id).forEach(x => {

        likes++;

        if (x._ownerId === myId) {

            isLiked = true;
        }
    });

    if (isLiked) {

        likeButton.style.display = 'none';
    }

    movieDetailsSection.querySelector('span[class="enrolled-span"]').textContent = `Liked ${likes}`;
}