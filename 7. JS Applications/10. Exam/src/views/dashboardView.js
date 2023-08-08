import { html } from '../../node_modules/lit-html/lit-html.js';
import { repeat } from '../../node_modules/lit-html/directives/repeat.js';
import { get } from '../api/api.js';

const teplateView = (albums) => html`<section id="dashboard">
<h2>Albums</h2>
  <ul class="card-wrapper">
    ${ albums.length !== 0 ? repeat(albums, x => x._id, teplateSingleAlbumView) : html`<h2>There are no albums added yet.</h2>`}
  </ul>
</section>`;

const teplateSingleAlbumView = (obj) => html`<li class="card">
<img src="${obj.imageUrl}" alt="travis" />
<p>
  <strong>Singer/Band: </strong><span class="singer">${obj.singer}</span>
</p>
<p>
  <strong>Album name: </strong><span class="album">${obj.album}</span>
</p>
<p><strong>Sales:</strong><span class="sales">${obj.sales}</span></p>
<a class="details-btn" href="/details/${obj._id}">Details</a>
</li>`;

export async function dashboardView(ctx) {

    ctx.render(html`<div class="loader"></div>`);
    let albums = await get('/data/albums?sortBy=_createdOn%20desc');
    ctx.render(teplateView(albums));
}