import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import { until } from '../../node_modules/lit-html/directives/until.js';
import { navBarView} from './nav.js';
import { get } from '../api/api.js';

const token = sessionStorage.getItem('token');

let template = (data) => html`<section id="browse">
<article class="pad-med">
    <h1>Team Browser</h1>
</article>
${token !== null ? html`<article class="layout narrow">
    <div class="pad-small"><a href="/create" class="action cta">Create Team</a></div>
</article>` : nothing }

<ul>
    '${Object.values(data).map(sectionTemplate)}'
</ul>
</section>`;

let sectionTemplate = (obj) => html`<article class="layout">
<img src="${obj.logoUrl}" class="team-logo left-col">
<div class="tm-preview">
    <h2>${obj.name}</h2>
    <p>${obj.description}</p>
    <span class="details">${until(teamMembers(obj._id), 'Galculating')} Members</span>
    <div><a href="/details/${obj._id}" class="action">See details</a></div>
</div>
</article>`;

export async function browseView(ctx){

    navBarView(ctx);
    let data = await get('/data/teams');
    ctx.render(template(data));
}

async function teamMembers(id){

    let res = await get(`/data/members?where=${encodeURIComponent(`teamId IN ("${id}") AND status="member"`)}`);
    let count = res.length;
    return count;
}
