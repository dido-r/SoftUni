import { html } from '../../node_modules/lit-html/lit-html.js';
import { register } from '../api/user.js';

let template = () => html`<section id="register">
<article class="narrow">
    <header class="pad-med">
        <h1>Register</h1>
    </header>
    <form id="register-form" class="main-form pad-large" @submit=${register}>
        <div class="error" style="display: none;">Invalid data</div>
        <label>E-mail: <input type="text" name="email"></label>
        <label>Username: <input type="text" name="username"></label>
        <label>Password: <input type="password" name="password"></label>
        <label>Repeat: <input type="password" name="repass"></label>
        <input class="action cta" type="submit" value="Create Account">
    </form>
    <footer class="pad-small">Already have an account? <a href="/login" class="invert">Sign in here</a>
    </footer>
</article>
</section>`;

export function registerView(ctx){

    ctx.render(template());
}