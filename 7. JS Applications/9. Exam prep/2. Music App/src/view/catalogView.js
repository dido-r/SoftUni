import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import { get } from '../api/api.js';
import { repeat } from '../../node_modules/lit-html/directives/repeat.js';
import { navView } from './navView.js';

const token = sessionStorage.getItem('token');

const teplateView = (catalog) => html`<section id="catalogPage">
<h1>All Albums</h1>
    ${repeat(catalog, x => x._id, teplateCurrnetView)}
</section>`;

const teplateCurrnetView = (obj) => html`<div class="card-box">
<img src="${obj.imgUrl}">
<div>
    <div class="text-center">
        <p class="name">Name: ${obj.name}</p>
        <p class="artist">Artist: ${obj.artist}</p>
        <p class="genre">Genre: ${obj.genre}</p>
        <p class="price">Price: $${obj.price}</p>
        <p class="date">Release Date: ${obj.releaseDate}</p>
    </div>
    ${token !== null ? html`<div class="btn-group">
        <a href="/details/${obj._id}" id="details">Details</a>
    </div>` : nothing}
</div>
</div>`;

export async function catalogView(ctx){

    navView(ctx);
    ctx.render(html`<div class="loader"></div>`);
    let catalog = await get('/data/albums?sortBy=_createdOn%20desc&distinct=name');
    catalog.length !== 0 ? ctx.render(teplateView(catalog)) : ctx.render(html`<section id="catalogPage">
    <p>No Albums in Catalog!</p></section>`) ;
}