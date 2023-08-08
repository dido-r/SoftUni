import { post, get } from "./api.js";

export async function register(event) {

    event.preventDefault();
    let form = new FormData(event.target);
    let { email, username, password, repass } = Object.fromEntries(form);

    if (!verifyEmail(email) || username.length < 3 || password.length < 3 || password !== repass) {

        event.target.querySelector('.error').style.display = 'inline';
        return;
    } else {

        event.target.querySelector('.error').style.display = 'none';
    }

    let obj = {

        email,
        username,
        password
    }

    let data = await post('/users/register', obj);
    sessionStorage.setItem('token', data.accessToken);
    sessionStorage.setItem('userId', data._id);
    event.target.reset();
    window.location.href = "/myTeams";
}

export async function login(event) {

    event.preventDefault();
    let form = new FormData(event.target);
    let { email, password } = Object.fromEntries(form);

    if (!verifyEmail(email) || password.length < 3) {

        event.target.querySelector('.error').style.display = 'inline';
        return;
    }
    else {

        event.target.querySelector('.error').style.display = 'none';
    }

    let obj = {

        email,
        password
    }

    let data = await post('/users/login', obj);
    sessionStorage.setItem('token', data.accessToken);
    sessionStorage.setItem('userId', data._id);
    event.target.reset();
    window.location.href = "/myTeams";
}

export async function logout() {

    await get('/users/register', undefined, true);
    sessionStorage.removeItem('token');
    sessionStorage.removeItem('userId');
    window.location.href = "/home";
}

function verifyEmail(email) {

    let regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/g;
    return regex.test(email)
}