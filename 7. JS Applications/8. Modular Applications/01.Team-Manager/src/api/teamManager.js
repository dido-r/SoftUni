import { del, get, post, put } from '../api/api.js';

const overlay = document.querySelector('.overlay');
const userId = sessionStorage.getItem('userId');

export async function teamMembers(ctx){

    return await get(`/data/members?where=teamId%3D%22${ctx.params.id}%22&load=user%3D_ownerId%3Ausers`);
}

export async function memberStatus(id){

    let res = await get(`/data/members?where=${encodeURIComponent(`_ownerId = "${userId}" AND teamId = "${id}" AND status = "member"`)}`);
    return res.length === 0 ? false : true;
}

async function getMembershipId(id){

    let res = await get(`/data/members?where=${encodeURIComponent(`_ownerId = "${userId}" AND teamId = "${id}"`)}`);
    return res[0]._id;
}

async function getUserMembershipId(team, user){

    let res = await get(`/data/members?where=${encodeURIComponent(`_ownerId = "${user}" AND teamId = "${team}"`)}`);
    return res[0]._id;
}

export async function membersCount(id){

    let res = await get(`/data/members?where=${encodeURIComponent(`teamId IN ("${id}") AND status="member"`)}`);
    let count = res.length;
    return count;
}

export async function checkForPendingRequest(id){

    let res = await get(`/data/members?where=${encodeURIComponent(`_ownerId = "${userId}" AND teamId = "${id}" AND status = "pending"`)}`);
    return res.length === 0 ? false : true;
}

export async function leaveTeam(event){

    let teamId = event.target.getAttribute('teamId');
    let id = await getMembershipId(teamId);
    let res = await del(`/data/members/${id}`, undefined, true);
    overlay.querySelector('p').textContent = 'Your left the team';
    overlay.querySelector('a').onclick = () => {

        overlay.style.display = 'none';
        location.reload();
    }
    overlay.style.display = 'block';
    return res;
}

export async function removeFromTeam(event){

    let teamId = event.target.getAttribute('teamId');
    let user = event.target.getAttribute('user');
    let id = await getUserMembershipId(teamId, user);
    let res = await del(`/data/members/${id}`, undefined, true);
    overlay.querySelector('p').textContent = 'Member was removed';
    overlay.querySelector('a').onclick = () => {

        overlay.style.display = 'none';
        location.reload();
    }
    overlay.style.display = 'block';
    return res;
}

export async function joinTeam(event){

    let id = event.target.getAttribute('teamId');
    let res = await post(`/data/members`, { teamId: id}, true);
    overlay.querySelector('p').textContent = 'Your join request has been sent';
    overlay.querySelector('a').onclick = () => {

        overlay.style.display = 'none';
        location.reload();
    }
    overlay.style.display = 'block';
    return res;
}

export async function approveRequest(event){

    let teamId = event.target.getAttribute('teamId');
    let user = event.target.getAttribute('user');
    let id = await getUserMembershipId(teamId, user);
    let obj = {

        _ownerId: user,
        teamId,
        status: 'member'
    }
    let res = await put(`/data/members/${id}`, obj, true);
    overlay.querySelector('p').textContent = 'New member was added';
    overlay.querySelector('a').onclick = () => {

        overlay.style.display = 'none';
        location.reload();
    }
    overlay.style.display = 'block';
    return res;
}

export async function declineRequest(event){

    let teamId = event.target.getAttribute('teamId');
    let user = event.target.getAttribute('user');
    let id = await getUserMembershipId(teamId, user);
    let res = await del(`/data/members/${id}`, undefined, true);
    overlay.querySelector('p').textContent = 'Member request was declined';
    overlay.querySelector('a').onclick = () => {

        overlay.style.display = 'none';
        location.reload();
    }
    overlay.style.display = 'block';
    return res;
}