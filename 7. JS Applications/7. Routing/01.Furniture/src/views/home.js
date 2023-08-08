import { html } from '../../node_modules/lit-html/lit-html.js';
import { get } from '../../api/api.js';

const template = (res) => html`<div class="row space-top">
    <div class="col-md-12">
        <h1>Welcome to Furniture System</h1>
        <p>Select furniture from the catalog to view details.</p>
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

export async function homeView(ctx) {

    navButtons();
    let data = await get('data/catalog');
    ctx.render(template(data));
}

function navButtons(){

    const token = sessionStorage.getItem('token');
    let userNav = document.getElementById('user');
    let guestNav = document.getElementById('guest');

    userNav.style.display = token === null? 'none' : 'inline-block';
    guestNav.style.display = token === null? 'inline-block' : 'none';
}