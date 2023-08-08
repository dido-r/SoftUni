const loadButton = document.getElementById('loadBooks');
loadButton.addEventListener('click', loadBooks);
const tbody = document.querySelector('body table tbody');
const form = document.getElementsByTagName('form')[0];
const submitButton = form.querySelector('button');
const inputs = form.getElementsByTagName('input');
form.addEventListener('submit', createBook);
const save = document.createElement('button');
save.textContent = 'Save';
save.style.display = 'none';
form.appendChild(save);
let isEdit = false;
let currentId = '';

async function loadBooks() {

    tbody.innerHTML = '';
    let res = await fetch('http://localhost:3030/jsonstore/collections/books');
    let data = await res.json();
    Object.values(data).map(x => {

        let tr = document.createElement('tr');
        tr.id = x._id;
        let td = document.createElement('td');
        let editButton = document.createElement('button');
        editButton.textContent = 'Edit';
        editButton.addEventListener('click', editBook)
        let deleteButton = document.createElement('button');
        deleteButton.textContent = 'Delete';
        deleteButton.addEventListener('click', deleteBook)
        td.appendChild(editButton);
        td.appendChild(deleteButton);

        tr.innerHTML = `
            <td>${x.title}</td>
            <td>${x.author}</td>`;
        tr.appendChild(td);
        tbody.appendChild(tr);
    });
}

async function createBook(event) {

    event.preventDefault();
    let data = new FormData(form);
    let writer = data.get('author');
    let bookName = data.get('title');

    if (writer === '' || bookName === '') {

        alert('Please fill all the fields!');
        return;
    }

    if (currentId === '') {

        await fetch('http://localhost:3030/jsonstore/collections/books', {

            method: 'post',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify({
                author: writer,
                title: bookName
            })
        });
    } else {

        await fetch(`http://localhost:3030/jsonstore/collections/books/${currentId}`, {

            method: 'put',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify({
                author: writer,
                title: bookName,
                _id: currentId
            })
        });

        form.querySelector('h3').textContent = 'Form';
        submitButton.style.display = 'block';
        save.style.display = 'none';
        event.target.id = '';
        currentId = '';
    }

    inputs[0].value = '';
    inputs[1].value = '';
    loadBooks();
}

async function deleteBook(event) {

    let tebleRowID = event.target.parentElement.parentElement.id;

    await fetch(`http://localhost:3030/jsonstore/collections/books/${tebleRowID}`, {

        method: 'delete'
    });
    loadBooks();
}

function editBook(event) {
    
    event.preventDefault();
    form.querySelector('h3').textContent = 'Edit Form';
    submitButton.style.display = 'none';
    save.style.display = 'block';
    let row = event.target.parentElement.parentElement;
    inputs[0].value = row.getElementsByTagName('td')[0].textContent;
    inputs[1].value = row.getElementsByTagName('td')[1].textContent;
    currentId = row.id;
}