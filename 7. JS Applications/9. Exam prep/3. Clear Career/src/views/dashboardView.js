import { html } from '../../node_modules/lit-html/lit-html.js';
import { repeat } from '../../node_modules/lit-html/directives/repeat.js';
import { get } from '../api/api.js';
import { navView } from './navView.js';

const teplateView = (offers) => html`<section id="dashboard">
<h2>Job Offers</h2>
  ${offers.length === 0 ? html`<h2>No offers yet.</h2>` : repeat(offers, x => x._id, teplateSingleOfferView)}
</section>`;

const teplateSingleOfferView = (obj) => html`<div class="offer">
<img src="${obj.imageUrl}" alt="example1" />
<p>
  <strong>Title: </strong><span class="title">${obj.title}</span>
</p>
<p><strong>Salary:</strong><span class="salary">${obj.salary}</span></p>
<a class="details-btn" href="/details/${obj._id}">Details</a>
</div>`;

export async function dashboardView(ctx){

  navView(ctx);
  ctx.render(html`<div class="loader"></div>`);
  let offers = await get('/data/offers?sortBy=_createdOn%20desc');
  ctx.render(teplateView(offers));
}