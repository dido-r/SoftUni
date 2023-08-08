function solve() {

    let task = document.getElementById('task');
    let description = document.getElementById('description');
    let date = document.getElementById('date');
    let button = document.getElementById('add');

    button.addEventListener('click', addTask);

    function addTask(event) {

        event.preventDefault();

        if (task.value !== '' && description.value !== '' && date.value !== '') {

            let h = document.createElement('h3');
            h.textContent = task.value;
            let p1 = document.createElement('p');
            p1.textContent = `Description: ${description.value}`;
            let p2 = document.createElement('p');
            p2.textContent = `Due Date: ${date.value}`;
            let article = document.createElement('article');
            let div = document.createElement('div');
            div.className = 'flex';
            let startButton = document.createElement('button');
            startButton.textContent = 'Start';
            startButton.className = 'green';
            startButton.addEventListener('click', startTask)
            let deleteButton = document.createElement('button');
            deleteButton.textContent = 'Delete';
            deleteButton.className = 'red';
            deleteButton.addEventListener('click', deleteTask)
            div.appendChild(startButton);
            div.appendChild(deleteButton);
            article.appendChild(h);
            article.appendChild(p1);
            article.appendChild(p2);
            article.appendChild(div);
            let orange = document.getElementsByTagName('section')[1].getElementsByTagName('div')[1];
            orange.appendChild(article);
            task.value = '';
            description.value = '';
            date.value = '';
        }
    }

    function deleteTask(event) {

        event.target.parentElement.parentElement.remove();
    }

    function startTask(event) {

        let article = event.target.parentElement.parentElement;
        let firstButton = article.getElementsByTagName('button')[0];
        firstButton.className = 'red';
        firstButton.textContent = 'Delete';
        firstButton.addEventListener('click', deleteTask)
        let secondButton = article.getElementsByTagName('button')[1];
        secondButton.className = 'orange';
        secondButton.textContent = 'Finish';
        secondButton.addEventListener('click', finishTask)
        let yellow = document.getElementsByTagName('section')[2].getElementsByTagName('div')[1];
        yellow.appendChild(article);
    }

    function finishTask(event) {

        let article = event.target.parentElement.parentElement;
        article.getElementsByTagName('div')[0].remove();
        let green = document.getElementsByTagName('section')[3].getElementsByTagName('div')[1];
        green.appendChild(article);
    }
}