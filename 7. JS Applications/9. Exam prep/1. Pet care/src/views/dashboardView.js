import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import { get } from '../api/api.js';

const teplateView = (data, ctx) => html`<section id="dashboard">
<h2 class="dashboard-title">Services for every animal</h2>
<div class="animals-dashboard">

   ${data.length === 0 ? html`<div>
        <p class="no-pets">No pets in dashboard</p>
    </div>` : data.map(singleView)}
    
</div>
</section>`;

const singleView = (obj) => html`<div class="animals-board">
<article class="service-img">
    <img class="animal-image-cover" src="${obj.image}">
</article>
<h2 class="name">${obj.name}</h2>
<h3 class="breed">${obj.breed}</h3>
    <div class="action">
        <a class="btn" href="/details/${obj._id}">Details</a>
    </div>
</div>`;

export async function dashboardView(ctx){

    let data = await get('/data/pets?sortBy=_createdOn%20desc&distinct=name');
    ctx.render(teplateView(data, ctx));
}