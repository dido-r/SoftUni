import { html, render } from './node_modules/lit-html/lit-html.js';

window.onload = loadDropMenu;
document.getElementsByTagName('form')[0].addEventListener('submit', addItem);
const menu = document.getElementById('menu');

async function loadDropMenu() {

    let res = await fetch('http://localhost:3030/jsonstore/advanced/dropdown');
    let data = await res.json();
    let result = (items) => Object.values(items).map(x => html`<option .value=${x._id}>${x.text}</option>`);
    render(result(data), menu);
}

async function addItem(event) {

    event.preventDefault();
    let input = document.getElementById('itemText').value;
    let obj = { text: input }
    fetch('http://localhost:3030/jsonstore/advanced/dropdown', {

        method: 'post',
        headers: { 'Content-type': 'application/json' },
        body: JSON.stringify(obj)
    });
    event.target.reset();
    loadDropMenu();
}