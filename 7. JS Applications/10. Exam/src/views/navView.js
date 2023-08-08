import { html } from '../../node_modules/lit-html/lit-html.js';
import { logoutUser } from '../api/user.js';

export const teplateNavView = (token) => html`<a id="logo" href="/"><img id="logo-img" src="/images/logo.png" alt="" /></a>

<nav>
  <div>
    <a href="/dashboard">Dashboard</a>
  </div>

  ${ token !== null ? html`<div class="user">
    <a href="/create">Add Album</a>
    <a href="#" @click=${logoutUser}>Logout</a>
  </div>` : html`<div class="guest">
    <a href="/login">Login</a>
    <a href="/register">Register</a>
  </div>`}
    
</nav>`;