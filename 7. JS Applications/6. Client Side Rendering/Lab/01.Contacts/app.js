import {html, render} from './node_modules/lit-html/lit-html.js';
import {styleMap} from './node_modules/lit-html/directives/style-map.js';
import {contacts} from './contacts.js';

let body = document.getElementById('contacts');
let createDiv = (x) => {

    return html`<div class="contact card">
        <div>
            <i class="far fa-user-circle gravatar"></i>
        </div>
        <div class="info">
            <h2>Name: ${x.name}</h2>
            <button @click=${onClick} class="detailsBtn">Details</button>
            <div class="details" id="${x.id}" style="${styleMap(x.style)}">
                <p>Phone number: ${x.phoneNumber}</p>
                <p>Email: ${x.email}</p>
             </div>
        </div>
        </div>`;
};

let result = (data) => data.map(x => createDiv(x));

render(result(contacts), body);

function onClick(event){

    let current = event.target.parentElement;
    let details = current.querySelector('.details');
    details.style.display = details.style.display === 'none' ? 'block' : 'none';
}