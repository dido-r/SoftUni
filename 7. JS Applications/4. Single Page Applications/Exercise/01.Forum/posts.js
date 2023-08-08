export {createPost, showPosts, clearInput};
import {showComment, createComment} from './comments.js';

const title = document.getElementById('topicName');
const user = document.getElementById('username');
const post = document.getElementById('postText');

async function createPost(event) {

    event.preventDefault();
    if (title.value === '' || user.value === '' || post.value === '') {

        alert('Empty field');
        clearInput();
        return;
    }

    let article = {

        title: title.value,
        date: new Date().toISOString(),
        username: user.value,
        content: post.value
    }

    await fetch('http://localhost:3030/jsonstore/collections/myboard/posts', {

        method: 'post',
        headers: { 'Content-type': 'application/json' },
        body: JSON.stringify(article)
    });

    clearInput()
    showPosts();
}

async function showPosts() {

    let fragment = document.createDocumentFragment();

    let res = await fetch('http://localhost:3030/jsonstore/collections/myboard/posts');
    let data = await res.json();
    Object.values(data).map(x => {

        let current = document.createElement('div');
        current.className = 'topic-name-wrapper';
        current.id = x._id;
        current.innerHTML = `
           <div class="topic-name">
               <a href="javascript:void(0)" class="normal">
                   <h2>${x.title}</h2>
               </a>
               <div class="columns">
                   <div>
                       <p>Date: <time>${x.date}</time></p>
                       <div class="nick-name">
                           <p>Username: <span>${x.username}</span></p>
                       </div>
                   </div>
               </div>
           </div>`;
        let a = current.querySelector('div a');
        a.id = x._id;
        a.addEventListener('click', showComment)

        fragment.append(current);

        let currentComment = document.createElement('div');
        currentComment.className = 'theme-content';
        currentComment.setAttribute('current-id', x._id)
        currentComment.innerHTML = `
            <div class="theme-title">
                <div class="theme-name-wrapper">
                    <div class="theme-name">
                        <h2>${x.title}</h2>
                    </div>
                </div>
            </div>

            <div class="comment">
            <div class="header">
                <img src="./static/profile.png" alt="avatar">
                    <p><span>${x.username}</span> posted on <time>${x.date}</time></p>

                    <p class="post-content">${x.content}</p>
            </div>
            </div>

            <div class="answer-comment">
                <p><span>currentUser</span> comment:</p>
                <div class="answer">
                    <form>
                        <textarea name="postText" id="comment" cols="30" rows="10"></textarea>
                        <div>
                            <label for="username">Username <span class="red">*</span></label>
                            <input type="text" name="username" id="username">
                        </div>
                        <button>Post</button>
                    </form>
                </div>
            </div>`;
        currentComment.getElementsByTagName('form')[0].addEventListener('submit', createComment);
        currentComment.style.display = 'none';
        fragment.append(currentComment);
    });

    document.querySelector('div.topic-container').replaceChildren(fragment);
}

function clearInput(event){

    event.preventDefault();
    title.value = '';
    user.value = '';
    post.value = '';
}