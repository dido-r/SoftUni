import { put } from '../api/api.js';
import page from '../../node_modules/page/page.mjs';

export async function editTeam(event){

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
        description
    }

    let id = event.target.getAttribute('currentId');
    let res = await put(`/data/teams/${id}`, team, true);
    event.target.reset();
    page.redirect(`/details/${res._id}`);
}