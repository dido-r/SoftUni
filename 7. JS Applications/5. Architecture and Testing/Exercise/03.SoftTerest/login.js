export { loginUser }
import { homeView } from './view.js';

async function loginUser(event) {

    event.preventDefault();
    let form = new FormData(event.target);
    let { email, password } = Object.fromEntries(form);
    let user = { email, password };

    try {
        let res = await fetch('http://localhost:3030/users/login', {

            method: 'post',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(user)
        });

        let data = await res.json();

        if (res.ok == false) {

            throw new Error('Invalid user');
        }

        localStorage.setItem('token', data.accessToken);
        localStorage.setItem('email', email);
        event.target.reset();
        homeView();
        
    } catch(err) {

        alert(err.message);
        return;
    }
}