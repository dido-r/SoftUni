import { html } from '../../node_modules/lit-html/lit-html.js';
import { navBarView} from './nav.js';
import { createTeam } from '../api/create.js';

let template = () => html`<section id="create">
<article class="narrow">
    <header class="pad-med">
        <h1>New Team</h1>
    </header>
    <form id="create-form" class="main-form pad-large" @submit=${createTeam}>
        <div class="error" style="display: none;">Invalid data.</div>
        <label>Team name: <input type="text" name="name"></label>
        <label>Logo URL: <input type="text" name="logoUrl"></label>
        <label>Description: <textarea name="description"></textarea></label>
        <input class="action cta" type="submit" value="Create Team">
    </form>
</article>
</section>`;

export function createView(ctx){

    navBarView(ctx);
    ctx.render(template());
}