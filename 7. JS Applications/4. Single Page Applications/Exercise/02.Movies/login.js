import { homeView } from './view.js';
export { loginUser };

async function loginUser(event) {

    event.preventDefault();

    try {
        let form = new FormData(event.target);
        let { email, password } = Object.fromEntries(form);

        if (email === '' || password === '') {

            throw new Error('All fields required');
        }

        let user = {

            email,
            password
        }

        let response = await fetch('http://localhost:3030/users/login', {

            method: 'post',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(user)
        });

        let data = await response.json();

        if (response.ok === false || response.status !== 200) {

            throw new Error('Invalid username/password')
        }

        sessionStorage.setItem('email', user.email);
        sessionStorage.setItem('token', data.accessToken);
        [...event.target.getElementsByTagName('input')].map(x => x.value = '');
        homeView();

    } catch (error) {

        alert(error.message);
        return;
    }
}