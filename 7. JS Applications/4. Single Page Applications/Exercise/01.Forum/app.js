import {showPosts, clearInput, createPost} from './posts.js';

document.querySelector('header nav ul li a').addEventListener('click', getStarted);
document.querySelector('button.cancel').addEventListener('click', clearInput)
document.querySelector('button.public').addEventListener('click', createPost)
getStarted();

function getStarted() {

    document.querySelector('div.new-topic-border').style.display = 'block';
    showPosts();
}