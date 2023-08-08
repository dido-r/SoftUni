import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import { get } from '../api/api.js';
import { deletePet } from '../api/crud.js';
import { donate } from '../api/donate.js';

const userId = sessionStorage.getItem('userId');

const teplateView = (data, donation, isDonated) => html`<section id="detailsPage">
<div class="details">
    <div class="animalPic">
        <img src="${data.image}">
    </div>
    <div>
        <div class="animalInfo">
            <h1>Name: ${data.name}</h1>
            <h3>Breed: ${data.breed}</h3>
            <h4>Age: ${data.age}</h4>
            <h4>Weight: ${data.weight}</h4>
            <h4 class="donation">Donation: ${donation}$</h4>
        </div>
        
        ${data._ownerId === userId ? html`<div class="actionBtn">
            <a href="/edit/${data._id}" class="edit">Edit</a>
            <a href="#" id="${data._id}" @click=${deletePet} class="remove">Delete</a>
        </div>` : nothing}

        ${(data._ownerId !== userId && userId !== null && isDonated === 0) ? html`<div class="actionBtn">
            <a href="#" petId=${data._id} @click=${donate} class="donate">Donate</a>
        </div>` : nothing}
        
    </div>
</div>
</section>`;

export async function detailsView(ctx){

    let data = await get(`/data/pets/${ctx.params.id}`);
    let donationRes = await get(`/data/donation?where=petId%3D%22${ctx.params.id}%22&distinct=_ownerId&count`);
    let donation = Number(donationRes) * 100;
    let isDonated = await get(`/data/donation?where=petId%3D%22${ctx.params.id}%22%20and%20_ownerId%3D%22${userId}%22&count`);
    ctx.render(teplateView(data, donation, isDonated));
}