import { post, put } from '../api/api.js';
import page from '../../node_modules/page/page.mjs';

export async function createTeam(event){

    event.preventDefault();
    let form = new FormData(event.target);
    let { name, logoUrl, description } = Object.fromEntries(form);

    if (name.length < 4 || logoUrl === '' || description.length < 10) {

        event.target.querySelector('.error').style.display = 'inline';
        return;
    }
    else {

        event.target.querySelector('.error').style.display = 'none';
    }

    let team ={

        name,
        logoUrl,
        description,
        _ownerId: sessionStorage.getItem('userId')
    }

    let res = await post('/data/teams', team, true);
    addAsMember(res);
    event.target.reset();
    page.redirect(`/details/${res._id}`);
}

async function addAsMember(data){

    let res = await post('/data/members', { teamId: data._id }, true);

    let teamId = data._id;
    let _ownerId = sessionStorage.getItem('userId');
    let status = 'member';

    let obj = {

        teamId,
        _ownerId,
        status
    }

    await put(`/data/members/${res._id}`, obj, true);
}