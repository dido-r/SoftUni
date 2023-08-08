function attachEvents() {

    const phonebook = document.getElementById('phonebook');
    const loadButton = document.getElementById('btnLoad');
    loadButton.addEventListener('click', loadPhonebook);
    document.getElementById('btnCreate').addEventListener('click', createContact);

    async function loadPhonebook() {

        phonebook.innerHTML = '';
        let res = await fetch('http://localhost:3030/jsonstore/phonebook');
        let data = await res.json();
        Object.values(data).map(x => {

            let li = document.createElement('li');
            li.id = x._id;
            li.textContent = `${x.person}: ${x.phone}`;
            let button = document.createElement('button');
            button.textContent = 'Delete';
            button.addEventListener('click', deleteContact);
            li.appendChild(button);
            phonebook.appendChild(li);
        });
    }

    async function deleteContact(event) {

        let ContactId = event.target.parentElement.id;
        await fetch(`http://localhost:3030/jsonstore/phonebook/${ContactId}`, {
            method: 'delete'
        });
        loadButton.click();
    }

    async function createContact() {

        const name = document.getElementById('person');
        const number = document.getElementById('phone');

        let obj = {

            person: name.value,
            phone: number.value
        }

        await fetch('http://localhost:3030/jsonstore/phonebook', {

            method: 'post',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(obj)
        });

        name.value = '';
        number.value = '';
        loadButton.click();
    }
}

attachEvents();