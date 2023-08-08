export { registerUser }
import { homeView } from './view.js';

async function registerUser(event) {

    event.preventDefault();
    let form = new FormData(event.target);
    let { email, password, repeatPassword } = Object.fromEntries(form);

    try {

        if (email.length < 3 || password.length < 3 || repeatPassword !== password) {

            throw new Error('Invalid Data');
        }

        let user = { email, password };

        let res = await fetch('http://localhost:3030/users/register', {

            method: 'post',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(user)
        });

        let data = await res.json();

        if (res.ok == false) {

            throw new Error('Unsuccessful request');
        }

        localStorage.setItem('token', data.accessToken);
        localStorage.setItem('email', email);
        event.target.reset();
        homeView();

    } catch (err) {

        alert(err.message);
        return;
    }
}