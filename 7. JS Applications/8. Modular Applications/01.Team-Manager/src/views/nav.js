import { html } from '../../node_modules/lit-html/lit-html.js';
import { logout } from '../api/user.js';

const token = sessionStorage.getItem('token');

let navUserTemplate = () => html`<a href="/home" class="site-logo">Team Manager</a>
<nav>
    <a href="/browse" class="action">Browse Teams</a>
    <a href="/myTeams" class="action">My Teams</a>
    <a @click=${logout} class="action">Logout</a>
</nav>`;

let navGuestTemplate = () => html`<a href="/home" class="site-logo">Team Manager</a>
<nav>
    <a href="/browse" class="action">Browse Teams</a>
    <a href="/login" class="action">Login</a>
    <a href="/register" class="action">Register</a>
</nav>`;

export function navBarView(ctx) {

    token == null ? ctx.navRender(navGuestTemplate()) : ctx.navRender(navUserTemplate());
}