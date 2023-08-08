function attachEvents() {

    const name = document.getElementsByName('author')[0];
    const content = document.getElementsByName('content')[0];
    const messages = document.getElementById('messages');
    document.getElementById('submit').addEventListener('click', send);
    document.getElementById('refresh').addEventListener('click', getMessages);

    async function send() {

        await fetch('http://localhost:3030/jsonstore/messenger', {
            method: 'post',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify({

                author: name.value,
                content: content.value,
            })
        });

        name.value = '';
        content.value = '';
    }

    async function getMessages() {
        
        messages.textContent = '';
        let result = [];
        let res = await fetch('http://localhost:3030/jsonstore/messenger');
        let data = await res.json();

        Object.values(data).map(x => {

            result.push(`${x.author}: ${x.content}`);
        });

        messages.textContent += result.join('\n');
    }
}

attachEvents();