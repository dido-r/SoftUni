import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import { get } from '../api/api.js';
import { navBarView} from './nav.js';
import { joinTeam, leaveTeam, teamMembers, memberStatus, membersCount, checkForPendingRequest, approveRequest, declineRequest, removeFromTeam } from '../api/teamManager.js';

const userId = sessionStorage.getItem('userId');

let template = (data, members, isMember, countOfMembers, isPending) => html`<section id="team-home">
<article class="layout">
    <img src="${data.logoUrl}" class="team-logo left-col">
    <div class="tm-preview">
        <h2>${data.name}</h2>
        <p>${data.description}</p>
        <span class="details">${countOfMembers} Members</span>
        <div>
            ${ userId === data._ownerId ? html`<a href="/edit/${data._id}" class="action">Edit team</a>` : nothing}
            ${ (!isMember && !isPending && userId !== data._ownerId && userId !== null) ? html`<a @click =${joinTeam} teamId="${data._id}" class="action">Join team</a>` : nothing}
            ${ (isMember && userId !== data._ownerId && userId !== null) ? html`<a @click =${leaveTeam} teamId="${data._id}" class="action invert">Leave team</a>` : nothing}
            ${ (isPending && userId !== data._ownerId && userId !== null) ? html`Membership pending. <a @click =${leaveTeam} teamId="${data._id}">Cancel request</a>` : nothing}  
        </div>
    </div>
    <div class="pad-large">
        <h3>Members</h3>
        <ul class="tm-members"> 
           ${members.filter(x => x.status === 'member').map(x => templateMembers(x, data))}
        </ul>
    </div>
    ${ userId === data._ownerId ? html`<div class="pad-large">
        <h3>Membership Requests</h3>
        <ul class="tm-members">
            ${members.find(x => x.status === 'pending') ? members.filter(x => x.status === 'pending').map(x => templatePending(x, data)) : html`<p>No pending requests.</p>`}
        </ul>
    </div>` : nothing}
</article>
</section>`;

let templateMembers = (member, data) => html`<li>${member.user.username} ${ (userId === data._ownerId && member._ownerId !== userId) ? html`<a @click=${removeFromTeam} teamId="${data._id}" user="${member.user._id}" class="tm-control action">Remove from team</a>` : nothing}</li>`;
let templatePending = (member, data) => html`<li>${member.user.username} <a @click=${approveRequest} teamId="${data._id}" user="${member.user._id}" class="tm-control action">Approve</a><a @click=${declineRequest} teamId="${data._id}" user="${member.user._id}" class="tm-control action">Decline</a></li>`;

export async function detailView(ctx){

    navBarView(ctx);
    let data = await get(`/data/teams/${ctx.params.id}`);
    let members = await teamMembers(ctx);
    let countOfMembers = await  membersCount(ctx.params.id);
    let isMember = await memberStatus(ctx.params.id);
    let isPending = await checkForPendingRequest(ctx.params.id);
    ctx.render(template(data, members, isMember, countOfMembers, isPending));
}