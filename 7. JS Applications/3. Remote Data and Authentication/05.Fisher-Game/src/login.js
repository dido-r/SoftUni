const view = document.getElementById('login-view');
const loginForm = view.querySelector('#login');
loginForm.addEventListener('submit', loginUser);
const notification = loginForm.querySelector('p');
const nav = document.querySelector('body header nav');
nav.querySelector('#home').classList.remove('active');
nav.querySelector('#login').classList.add('active');
nav.querySelector('#register').classList.remove('active');
document.getElementById('user').style.display = 'none';

async function loginUser(ev) {

    ev.preventDefault();
    let info = new FormData(loginForm);
    let email = info.get('email');
    let password = info.get('password');

    if (email === "" || password === "") {

        notification.textContent = 'Error';
        setTimeout(() => {

            notification.textContent = '';
        }, 3000);
        return;
    }

    let res = await fetch('http://localhost:3030/users/login', {

        method: 'post',
        headers: { 'Content-type': 'application/json' },
        body: JSON.stringify({email, password})
    });

    let data = await res.json();
    sessionStorage.setItem('token', data.accessToken);
    sessionStorage.setItem('email', email);
    window.location = './index.html';
}