import { html } from '../../node_modules/lit-html/lit-html.js';
import { logoutUser } from '../api/user.js';

const teplateView = (token) => html`<a id="logo" href="/"
><img id="logo-img" src="./images/logo.jpg" alt=""
/></a>

<nav>
<div>
  <a href="/dashboard">Dashboard</a>
</div>
    ${token === null ? html`<div class="guest">
    <a href="/login">Login</a>
    <a href="/register">Register</a>
    </div>` : html`<div class="user">
    <a href="/create">Create Offer</a>
    <a href="#" @click=${logoutUser}>Logout</a>
    </div>`}
</nav>`;

export function navView(ctx){

    const token = sessionStorage.getItem('token');
    ctx.navRender(teplateView(token));
}