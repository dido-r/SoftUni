import {dashboardView} from './view.js';
export {createIdea}

async function createIdea(event){

    event.preventDefault();
    let form = new FormData(event.target);
    let { title, description, imageURL } = Object.fromEntries(form);

    try {

        if (title.length < 6 || description.length < 10 || imageURL.length < 5) {

            throw new Error('Invalid Data');
        }

        let idea = { title, description, img: imageURL };

        let res = await fetch('http://localhost:3030/data/ideas', {

            method: 'post',
            headers: { 'X-Authorization': `${localStorage.getItem('token')}`},
            body: JSON.stringify(idea)
        });

        if (res.ok == false) {

            throw new Error('Unsuccessful request');
        }

        event.target.reset();
        dashboardView();

    } catch (err) {

        alert(err.message);
        return;
    }
}