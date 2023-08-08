import { html } from '../../node_modules/lit-html/lit-html.js';
import { registerUser } from '../api/user.js';

const teplateView = () => html`<section id="registerPage">
<form class="registerForm" @submit=${registerUser}>
    <img src="./images/logo.png" alt="logo" />
    <h2>Register</h2>
    <div class="on-dark">
        <label for="email">Email:</label>
        <input id="email" name="email" type="text" placeholder="Type an email" value="">
    </div>

    <div class="on-dark">
        <label for="password">Password:</label>
        <input id="password" name="password" type="password" placeholder="Type a password" value="">
    </div>

    <div class="on-dark">
        <label for="repeatPassword">Repeat Password:</label>
        <input id="repeatPassword" name="repeatPassword" type="password" placeholder="Repeat your password" value="">
    </div>

    <button class="btn" type="submit">Register</button>

    <p class="field">
        <span>If you have profile click <a href="/login">here</a></span>
    </p>
</form>
</section>`;

export function registerView(ctx){

    ctx.render(teplateView());
}