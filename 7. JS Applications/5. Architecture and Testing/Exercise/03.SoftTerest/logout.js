export { logoutUser }
import { homeView } from './view.js';

async function logoutUser(){

    try {

        let res = await fetch('http://localhost:3030/users/logout', {

        method: 'post',
        headers: { 'Content-type': 'application/json' }
        });

        if (res.ok == false) {

            throw new Error('Unsuccessful request');
        }

        localStorage.removeItem('token');
        localStorage.removeItem('email');
        homeView();

    } catch (err) {

        alert(err.message);
        return;
    }
}