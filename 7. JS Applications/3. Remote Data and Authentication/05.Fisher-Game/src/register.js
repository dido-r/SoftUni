const view = document.getElementById('register-view');
const registerForm = view.querySelector('#register');
registerForm.addEventListener('submit', registerUser);
const notification = registerForm.querySelector('p');
document.getElementById('user').style.display = 'none';
const nav = document.querySelector('body header nav');
nav.querySelector('#home').classList.remove('active');
nav.querySelector('#login').classList.remove('active');
nav.querySelector('#register').classList.add('active');

async function registerUser(ev) {

    ev.preventDefault();
    notification.textContent = '';
    let data = new FormData(registerForm);
    let email = data.get('email');
    let password = data.get('password');
    let repass = data.get('rePass');

    if (password !== repass || email === '' || password === '' || repass === '') {

        notification.textContent = 'Error';
        setTimeout(() => {

            notification.textContent = '';
        }, 3000);
        return;
    }

    let user = {
        email,
        password
    }

    let res = await fetch('http://localhost:3030/users/register', {

        method: 'post',
        headers: { 'Content-type': 'application/json' },
        body: JSON.stringify(user)
    });

    let d = await res.json();

    if (d.ok = false) {

        notification.textContent = 'Error';
        setTimeout(() => {

            notification.textContent = '';
        }, 3000);
    }

    sessionStorage.setItem('token', d.accessToken);
    sessionStorage.setItem('email', email);
    window.location = './index.html';
}