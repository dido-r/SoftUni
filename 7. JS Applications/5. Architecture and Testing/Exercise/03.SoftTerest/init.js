export { initialize }
import { registerUser } from './regist.js';
import { loginUser } from './login.js';
import { createIdea } from './create.js';
import { homeView, onNavigate } from './view.js';

function initialize() {

    document.getElementById('navbarResponsive').style.display = 'inline';
    [...document.getElementsByClassName('navbar-nav ml-auto')[0].getElementsByTagName('li')].forEach(x => x.addEventListener('click', onNavigate));
    document.getElementsByClassName('form-user col-md-7')[0].addEventListener('submit', registerUser);
    document.getElementsByClassName('form-user col-md-8')[0].addEventListener('submit', loginUser);
    document.querySelector('[class="navbar-brand"] img').addEventListener('click', homeView);
    document.getElementsByClassName('form-idea col-md-5')[0].addEventListener('submit', createIdea);
    document.querySelector('.alreadyUser a').addEventListener('click', onNavigate);
    document.querySelector('.notAnUser a').addEventListener('click', onNavigate);
    document.querySelector('[class="btn btn-secondary btn-lg"]').addEventListener('click', onNavigate);
    homeView();
}