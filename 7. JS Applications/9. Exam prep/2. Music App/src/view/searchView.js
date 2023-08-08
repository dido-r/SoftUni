import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import { repeat } from '../../node_modules/lit-html/directives/repeat.js';
import { get } from '../api/api.js';
import { navView } from './navView.js';

const userId = sessionStorage.getItem('userId');

const teplateView = (search, albums) => html`<section id="searchPage">
    <h1>Search by Name</h1>

    <div class="search">
        <input id="search-input" type="text" name="search" placeholder="Enter desired albums's name">
        <button class="button-list" @click=${search}>Search</button>
    </div>

    <h2>Results:</h2>  
    ${ albums ? html`<div class="search-result">
        ${albums.length === 0 ? html`<p class="no-result">No result.</p>` : html`${repeat(albums, x => x._id, teplateAlbumView)}`}
    </div>` : nothing}
</section>`;

const teplateAlbumView = (obj) => html`<div class="card-box">
    <img src="${obj.imgUrl}">
    <div>
        <div class="text-center">
            <p class="name">Name: ${obj.name}</p>
            <p class="artist">Artist: ${obj.artist}</p>
            <p class="genre">Genre: ${obj.genre}</p>
            <p class="price">Price: $${obj.price}</p>
            <p class="date">Release Date: ${obj.releaseDate}</p>
        </div>

        ${userId !== null ? html`<div class="btn-group">
            <a href="/details/${obj._id}" id="details">Details</a>
        </div>` : nothing}
    </div>
</div>`;

export function searchView(ctx) {

    navView(ctx);
    ctx.render(teplateView(search));

    async function search(event) {

        event.preventDefault();
        ctx.render(html`<div class="loader"></div>`);
        let searchField = event.target.parentElement.querySelector('#search-input');

        if (searchField.value === '') {

            alert('All fields required!');
            return;
        }

        let albums = await get(`/data/albums?where=name%20LIKE%20%22${searchField.value}%22`);
        ctx.render(teplateView(search, albums));
    }
}