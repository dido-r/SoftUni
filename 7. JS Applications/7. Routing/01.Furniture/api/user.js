import { post } from './api.js';
import { get } from './api.js';

export async function register(event) {

    event.preventDefault();

    let form = new FormData(event.target);
    let { email, password, rePass } = Object.fromEntries(form);

    if (email === '' || password === "" || rePass === '' || password !== rePass) {

        alert('Ivalid data');
        return;
    }

    let user = { email, password }

    try {

        let result = await post('users/register', user);
        sessionStorage.setItem('token', result.accessToken);
        event.target.reset();
        window.location.href = "/";

    } catch (err) {

        alert(err.message);
        return;
    }
}

export async function login(event) {

    event.preventDefault();

    let form = new FormData(event.target);
    let { email, password } = Object.fromEntries(form);

    if (email === '' || password === "") {

        alert('All fields required');
        return;
    }

    let user = { email, password }

    try {

        let result = await post('users/login', user);
        sessionStorage.setItem('token', result.accessToken);
        event.target.reset();
        window.location.href = "/";

    } catch (err) {

        alert(err.message);
        return;
    }
}

export function logout(ctx) {

    sessionStorage.removeItem('token');
    ctx.page.redirect('/');
}

export async function myId(){

    return await get('users/me', undefined, true);
}