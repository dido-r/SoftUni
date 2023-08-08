import { html } from '../../node_modules/lit-html/lit-html.js';
import { navBarView} from './nav.js';
import { editTeam } from '../api/edit.js';
import { get } from '../api/api.js';

let template = (data) => html`<section id="edit">
<article class="narrow">
    <header class="pad-med">
        <h1>Edit Team</h1>
    </header>
    <form id="edit-form" class="main-form pad-large" currentId="${data._id}" @submit=${editTeam}>
        <div class="error" style="display: none;">Ivalid data.</div>
        <label>Team name: <input type="text" name="name" .value="${data.name}"></label>
        <label>Logo URL: <input type="text" name="logoUrl" .value="${data.logoUrl}"></label>
        <label>Description: <textarea name="description" .value="${data.description}"></textarea></label>
        <input class="action cta" type="submit" value="Save Changes">
    </form>
</article>
</section>`;

export async function editView(ctx){

    navBarView(ctx);
    let data = await get(`/data/teams/${ctx.params.id}`);
    ctx.render(template(data));
}