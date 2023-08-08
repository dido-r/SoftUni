import { homeView } from './view.js';
export { registerUser };

async function registerUser(event) {

    event.preventDefault();

    try {
        let form = new FormData(event.target);
        let { email, password, repeatPassword } = Object.fromEntries(form);

        if (email === '' || password === '' || repeatPassword === '' || password.length < 6 || password !== repeatPassword) {

            throw new Error('Invalid password/username');
        }

        let user = {

            email,
            password
        }

        let response = await fetch('http://localhost:3030/users/register', {

            method: 'post',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(user)
        });

        let data = await response.json();

        if (response.ok === false || response.status !== 200) {

            throw new Error('User Already registered')
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