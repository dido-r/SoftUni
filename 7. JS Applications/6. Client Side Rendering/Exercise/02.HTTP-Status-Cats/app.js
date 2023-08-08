import { cats } from "./catSeeder.js";
import {html, render} from './node_modules/lit-html/lit-html.js';

let createLi = (obj) => html`
        <li>
            <img src="./images/${obj.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
            <div class="info">
                <button @click="${onClick}" class="showBtn">Show status code</button>
                <div class="status" style="display: none" id="${obj.id}">
                    <h4>Status Code: ${obj.statusCode}</h4>
                    <p>${obj.statusMessage}</p>
                </div>
            </div>
        </li>`;

let createUl = (list) => html`<ul>${list.map(createLi)}</ul>`;

function onClick(event){

    let button = event.target;
    let current = event.target.parentElement.querySelector('.status');
    current.style.display = current.style.display === 'none' ? 'block' : 'none';
    button.textContent = button.textContent === 'Show status code' ? 'Hide status code' : 'Show status code';
}

render(createUl(cats), document.getElementById('allCats'));