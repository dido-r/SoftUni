export {showComment, createComment}

async function showComment(event) {

    let id = event.target.parentElement.id;
    document.querySelector('div.new-topic-border').style.display = 'none';
    let divs = document.querySelector('div.topic-container').getElementsByTagName('div');
    [...divs].forEach(x => x.style.display = 'none');
    let current = document.querySelector(`[current-id="${id}"]`);
    current.style.display = 'block';
    [...current.getElementsByTagName('div')].forEach(x => x.style.display = 'block');
    showComments(id);
}

async function createComment(event) {

    event.preventDefault();
    let date = new Date().toLocaleString('en-US')
    let commentForm = new FormData(event.target);
    let { postText, username } = Object.fromEntries(commentForm);
    let postId = event.target.parentElement.parentElement.parentElement.getAttribute('current-id');

    if (postText === '' || username === '') {

        alert('Empty field');
        return;
    }

    await fetch('http://localhost:3030/jsonstore/collections/myboard/comments', {

        method: 'post',
        headers: { 'Content-type': 'application/json' },
        body: JSON.stringify({

            username,
            postText,
            date,
            postId
        })
    });

    let comments = event.target.parentElement.parentElement.parentElement.querySelector('div.comment').querySelectorAll('div.user-comment');
    [...comments].forEach(x => x.remove());
    event.target.getElementsByTagName('textarea')[0].value = '';
    event.target.querySelector('div input').value = '';
    showComments(postId);
}

async function showComments(id) {

    let current = document.querySelector(`[current-id="${id}"]`).querySelector('div.comment');

    let res = await fetch('http://localhost:3030/jsonstore/collections/myboard/comments');
    let data = await res.json();
    Object.values(data).map(x => {

        if (x.postId === id) {

            let div = createCommentHTML(x.username, x.date, x.postText);
            current.appendChild(div);
        }
    });
}

function createCommentHTML(username, date, postText) {

    let div = document.createElement('div');
    div.className = 'user-comment';
    div.innerHTML = `
    <div class="topic-name-wrapper">
        <div class="topic-name">
            <p><strong>${username}</strong> commented on <time>${date}</time></p>
            <div class="post-content">
                <p>${postText}</p>
            </div>
        </div>
    </div>`;

    return div;
}