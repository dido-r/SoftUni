import { html, render } from './node_modules/lit-html/lit-html.js';

document.getElementById('loadBooks').addEventListener('click', generateBooks);
const addForm = document.getElementById('add-form');
const editFomr = document.getElementById('edit-form');
addForm.addEventListener('submit', addBook);
editFomr.addEventListener('submit', editBook);
let bookForEdit;

async function generateBooks() {

    let res = await fetch('http://localhost:3030/jsonstore/collections/books');
    let data = await res.json();
    let items = Object.entries(data);
    let result = (list) => html`${Object.values(list).map(x => generateRow(x))}`;
    render(result(items), document.getElementsByTagName('tbody')[0])
}

function generateRow(obj) {

    return html`<tr>
    <td>${obj['1'].title}</td>
    <td>${obj['1'].author}</td>
    <td id="${obj['0']}">
        <button @click=${showEditForm}>Edit</button>
        <button @click=${deleteBook}>Delete</button>
    </td>
</tr>`;
}

async function addBook(event) {

    event.preventDefault();
    let form = new FormData(event.target);
    let { title, author } = Object.fromEntries(form);
    let book = { title, author };

    if(title === '' || author === ''){

        alert('All fielad required');
        return;
    }

    await fetch('http://localhost:3030/jsonstore/collections/books', {

        method: 'post',
        headers: {'Content-type': 'application/json'},
        body: JSON.stringify(book)
    });

    event.target.reset();
    generateBooks();
}

async function deleteBook(event) {

    let bookId = event.target.parentElement.id;
    await fetch(`http://localhost:3030/jsonstore/collections/books/${bookId}`, {

        method: 'delete'
    });

    generateBooks();
}

function showEditForm(event){

    bookForEdit = event.target.parentElement.id;
    let book = event.target.parentElement.parentElement.getElementsByTagName('td');
    let title = book[0].textContent;
    let author = book[1].textContent;
    addForm.style.display = 'none';
    editFomr.style.display = 'block';
    editFomr.querySelector('[name="title"]').value = title;
    editFomr.querySelector('[name="author"]').value = author;
}

async function editBook(event) {

    event.preventDefault();
    let form = new FormData(event.target);
    let { title, author } = Object.fromEntries(form);
    let book = { title, author};

    await fetch(`http://localhost:3030/jsonstore/collections/books/${bookForEdit}`, {

        method: 'put',
        headers: {'Content-type': 'application/json'},
        body: JSON.stringify(book)
    });

    addForm.style.display = 'block';
    editFomr.style.display = 'none';
    bookForEdit = '';
    generateBooks();
}