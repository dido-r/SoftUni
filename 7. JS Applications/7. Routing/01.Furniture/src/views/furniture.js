import{ html } from '../../node_modules/lit-html/lit-html.js';
import { get } from '../../api/api.js';
import { myId } from '../../api/user.js';

const template = (res) => html`<div class="row space-top">
<div class="col-md-12">
    <h1>My Furniture</h1>
    <p>This is a list of your publications.</p>
</div>
</div>
<div class="row space-top">
    ${Object.values(res).map(x => singleObjectTemplate(x))}
</div>`;

const singleObjectTemplate = (obj) => html `<div class="col-md-4">
<div class="card text-white bg-primary">
    <div class="card-body">
        <img src=${obj.img}/>
        <p>${obj.description}</p>
        <footer>
            <p>Price: <span>${obj.price} $</span></p>
        </footer>
        <div>
            <a href="/details/${obj._id}" class="btn btn-info">Details</a>
        </div>
    </div>
</div>
</div>`;

export async function myFurnitureView(ctx){

    let res = await myId();
    let userId = res._id;
    let data = await get(`data/catalog?where=_ownerId%3D%22${userId}%22`);
    ctx.render(template(data));
}