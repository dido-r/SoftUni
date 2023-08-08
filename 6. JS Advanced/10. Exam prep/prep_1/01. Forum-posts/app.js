window.addEventListener("load", solve);

//code for Judge
function solve() {

    const title = document.getElementById('post-title');
    const category = document.getElementById('post-category');
    const content = document.getElementById('post-content');
    const reviewList = document.getElementById('review-list');
    const publishedList = document.getElementById('published-list');
    document.getElementById('publish-btn').addEventListener('click', publish);
    document.getElementById('clear-btn').addEventListener('click', clear);

    function publish(event) {

        event.preventDefault();

        if (title.value == '' || category.value == '' || content.value == '') {

            return;
        }

        let li = document.createElement('li');
        li.className = 'rpost';
        li.innerHTML = `<article>
            <h4>${title.value}</h4>
            <p>Category: ${category.value}</p>
            <p>Content: ${content.value}</p>
        </article>
        <button class="action-btn edit">Edit</button>
        <button class="action-btn approve">Approve</button>`;
        li.getElementsByTagName('button')[0].addEventListener('click', edit);
        li.getElementsByTagName('button')[1].addEventListener('click', approve);
        reviewList.appendChild(li);
        title.value = '';
        category.value = '';
        content.value = '';

        function edit(event) {

            let article = event.target.parentElement.getElementsByTagName('article')[0];
            let h = article.getElementsByTagName('h4')[0];
            title.value = h.textContent;
            let p1 = article.getElementsByTagName('p')[0];
            category.value = p1.textContent.replace('Category: ', '');
            let p2 = article.getElementsByTagName('p')[1];
            content.value = p2.textContent.replace('Content: ', '');
            article.parentElement.remove();
        }

        function approve(event) {

            let list = event.target.parentElement;
            list.getElementsByTagName('button')[0].remove();
            list.getElementsByTagName('button')[0].remove();
            publishedList.appendChild(list);
        }
    }

    function clear() {

        publishedList.innerHTML = '';
    }
}

//my code

function solve() {

    const title = document.getElementById('post-title');
    const category = document.getElementById('post-category');
    const content = document.getElementById('post-content');
    const reviewList = document.getElementById('review-list');
    const publishedList = document.getElementById('published-list');
    document.getElementById('publish-btn').addEventListener('click', publish);
    document.getElementById('clear-btn').addEventListener('click', clear);

    function publish(event) {

        event.preventDefault();

        if (title.value == '' || category.value == '' || content.value == '') {

            return;

        }
        
        let h = document.createElement('h4');
        h.textContent = title.value;
        let p1 = document.createElement('p');
        p1.textContent = 'Category: ' + category.value;
        let p2 = document.createElement('p');
        p2.textContent = 'Content: ' + content.value;
        let article = document.createElement('article');
        article.appendChild(h);
        article.appendChild(p1);
        article.appendChild(p2);
        let list = document.createElement('li');
        list.appendChild(article);
        list.classList.add('rpost');
        let editButton = document.createElement('button');
        editButton.className = 'action-btn edit';
        editButton.textContent = 'Edit';
        editButton.addEventListener('click', edit);
        let approveButton = document.createElement('button');
        approveButton.className = 'action-btn approve';
        approveButton.textContent = 'Approve';
        approveButton.addEventListener('click', approve);
        list.append(editButton);
        list.append(approveButton);
        reviewList.appendChild(list);
        title.value = '';
        category.value = '';
        content.value = '';

        function edit(event) {

            let article = event.target.parentElement.getElementsByTagName('article')[0];
            let h = article.getElementsByTagName('h4')[0];
            title.value = h.textContent;
            let p1 = article.getElementsByTagName('p')[0];
            category.value = p1.textContent.replace('Category: ', '');
            let p2 = article.getElementsByTagName('p')[1];
            content.value = p2.textContent.replace('Content: ', '');
            article.parentElement.remove();
        }

        function approve(event) {

            let list = event.target.parentElement;
            list.getElementsByTagName('button')[0].remove();
            list.getElementsByTagName('button')[0].remove();
            publishedList.appendChild(list);
        }
    }

    function clear() {

        publishedList.innerHTML = '';
    }
}