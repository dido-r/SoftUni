import { html } from '../../node_modules/lit-html/lit-html.js';
import { until } from '../../node_modules/lit-html/directives/until.js';
import { navBarView} from './nav.js';
import { get } from '../api/api.js';

const userId = sessionStorage.getItem('userId');

let template = (data) => html`<section id="my-teams">

<article class="pad-med">
    <h1>My Teams</h1>
</article>

${ data.length === 0 ? html`<article class="layout narrow">
    <div class="pad-med">
        <p>You are not a member of any team yet.</p>
        <p><a href="/browse">Browse all teams</a> to join one, or use the button bellow to cerate your own
            team.</p>
    </div>
    <div class=""><a href="/create" class="action cta">Create Team</a></div>
</article>` : html`<article class="layout narrow">
<div class="pad-med">
<div class=""><a href="/create" class="action cta">Create Team</a></div>
</div>
</article>
<ul>
    '${Object.values(data).map(sectionTemplate)}'
</ul>`}
</section>`;

let sectionTemplate = (obj) => html`<article class="layout">
<img src="${obj.logoUrl}" class="team-logo left-col">
<div class="tm-preview">
    <h2>${obj.name}</h2>
    <p>${obj.description}</p>
    <span class="details">${until(teamMembers(obj.teamId), 'Galculating')} Members</span>
    <div><a href="/details/${obj.teamId}" class="action">See details</a></div>
</div>
</article>`;

export async function myTeamsView(ctx){

    navBarView(ctx);
    let data = await get(`/data/members?where=_ownerId%3D%22${userId}%22%20AND%20status%3D%22member%22&load=team%3DteamId%3Ateams`)
    ctx.render(template(data));
}

async function teamMembers(id){

    let res = await get(`/data/members?where=${encodeURIComponent(`teamId IN ("${id}") AND status="member"`)}`);
    let count = res.length;
    return count;
}