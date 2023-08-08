import { html } from '../../node_modules/lit-html/lit-html.js';
import { get } from '../../api/api.js';
import { myId } from '../../api/user.js';

const templateOwner = (obj) => html`<div class="row space-top">
    <div class="col-md-12">
        <h1>Furniture Details</h1>
    </div>
</div>
<div class="row space-top">
    <div class="col-md-4">
        <div class="card text-white bg-primary">
            <div class="card-body">
                <img src="${obj.img}" />
            </div>
        </div>
    </div>
    <div class="col-md-4">
        <p>Make: <span>${obj.make}</span></p>
        <p>Model: <span>${obj.model}</span></p>
        <p>Year: <span>${obj.year}</span></p>
        <p>Description: <span>${obj.description}</span></p>
        <p>Price: <span>${obj.price}</span></p>
        <p>Material: <span>${obj.material}</span></p>
        <div>
            <a href="/edit/${obj._id}" class="btn btn-info">Edit</a>
            <a href="/delete/${obj._id}" class="btn btn-red">Delete</a>
        </div>
    </div>
</div>`;

const template = (obj) => html`<div class="row space-top">
    <div class="col-md-12">
        <h1>Furniture Details</h1>
    </div>
</div>
<div class="row space-top">
    <div class="col-md-4">
        <div class="card text-white bg-primary">
            <div class="card-body">
                <img src="${obj.img}" />
            </div>
        </div>
    </div>
    <div class="col-md-4">
        <p>Make: <span>${obj.make}</span></p>
        <p>Model: <span>${obj.model}</span></p>
        <p>Year: <span>${obj.year}</span></p>
        <p>Description: <span>${obj.description}</span></p>
        <p>Price: <span>${obj.price}</span></p>
        <p>Material: <span>${obj.material}</span></p>
    </div>
</div>`;

export async function detailsView(ctx) {

    let itemId = ctx.params.id;
    let data = await get(`data/catalog/${itemId}`);
    let ownerId = data._ownerId;

    if (sessionStorage.getItem('token') === null) {

        ctx.render(template(data));
    }
    else {

        const res = await getCurrentUserId();
        const userId = res._id;

        if (userId === ownerId) {

            ctx.render(templateOwner(data));
        }
        else {

            ctx.render(template(data));
        }
    }
}

async function getCurrentUserId() {

    return await myId();
}