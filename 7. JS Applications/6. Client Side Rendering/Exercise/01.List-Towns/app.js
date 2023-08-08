import {render, html} from './node_modules/lit-html/lit-html.js';

document.getElementsByTagName('form')[0].addEventListener('submit', showList);

function showList(event){

    event.preventDefault();
    let form = new FormData(event.target);
    let {towns} = Object.fromEntries(form);
    let result = towns.split(', ');
    let list = (result) => html`
    '<ul>
        ${result.map(x => html`<li>${x}</li>`)}
    </ul>`;

    render(list(result), document.getElementById('root'));
}