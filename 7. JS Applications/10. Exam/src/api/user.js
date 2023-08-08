import { post, get } from './api.js';

export async function registerUser(event) {

    event.preventDefault();
    let form = new FormData(event.target);
    let keys = Object.fromEntries(form);
    let email = keys['email'];
    let password = keys['password'];
    let repeatPassword = keys['re-password'];
    
    if (email === '' || password === '' || repeatPassword === '') {

        alert('All fields required!')
        return;
    }

    if (password !== repeatPassword) {

        alert("Passwords don't match")
        return;
    }

    let obj = {

        email,
        password
    }

    try {

        let data = await post('/users/register', obj);
        sessionStorage.setItem('token', data.accessToken);
        sessionStorage.setItem('userId', data._id);
        event.target.reset();
        window.location.href = "/dashboard";
        
    } catch (err) {

        alert(err);
        return;
    }
}

export async function logoutUser() {

    await get('/users/logout', undefined, true);
    sessionStorage.removeItem('token');
    sessionStorage.removeItem('userId');
    window.location.href = "/dashboard";
}