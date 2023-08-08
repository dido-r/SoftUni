import { html } from '../../node_modules/lit-html/lit-html.js';
import { logoutUser } from '../api/user.js';

const token = sessionStorage.getItem('token');

const teplateUserView = () => html`<nav>
<img src="/images/headphones.png">
<a href="/home">Home</a>
<ul>
    <!--All user-->
    <li><a href="/catalog">Catalog</a></li>
    <li><a href="/search">Search</a></li>
    <!--Only user-->
    <li><a href="/create">Create Album</a></li>
    <li><a href="#" @click=${logoutUser}>Logout</a></li>
</ul>
</nav>`;

const teplateGuestView = () => html`<nav>
<img src="./images/headphones.png">
<a href="/home">Home</a>
<ul>
    <!--All user-->
    <li><a href="/catalog">Catalog</a></li>
    <li><a href="/search">Search</a></li>
    <!--Only guest-->
    <li><a href="/login">Login</a></li>
    <li><a href="/register">Register</a></li>
</ul>
</nav>`;

export function navView(ctx){

    token === null ? ctx.navRender(teplateGuestView()) : ctx.navRender(teplateUserView());
}