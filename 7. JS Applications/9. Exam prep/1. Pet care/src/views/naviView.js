import { html } from '../../node_modules/lit-html/lit-html.js';
import { loginUser, logoutUser } from '../api/user.js';

const token = sessionStorage.getItem('token');

const teplateUserView = () => html`<nav>
<section class="logo">
    <img src="./images/logo.png" alt="logo">
</section>
<ul>
    <!--Users and Guest-->
    <li><a href="/home">Home</a></li>
    <li><a href="/dashboard">Dashboard</a></li>
    <!--Only Users-->
    <li><a href="/create">Create Postcard</a></li>
    <li><a href="#" @click=${logoutUser}>Logout</a></li>
</ul>
</nav>`;

const teplateGuestView = () => html`<nav>
<section class="logo">
    <img src="./images/logo.png" alt="logo">
</section>
<ul>
    <!--Users and Guest-->
    <li><a href="/home">Home</a></li>
    <li><a href="/dashboard">Dashboard</a></li>
    <!--Only Guest-->
    <li><a href="/login">Login</a></li>
    <li><a href="/register">Register</a></li>
</ul>
</nav>`;

export function navView(ctx){

    token === null ? ctx.navRender(teplateGuestView()) : ctx.navRender(teplateUserView());
}