import { html } from '../../node_modules/lit-html/lit-html.js';
import { editPet } from '../api/crud.js';
import { get } from '../api/api.js';

const teplateView = (data) => html`<section id="editPage">
<form class="editForm" id=${data._id} @submit=${editPet}>
    <img src="./images/editpage-dog.jpg">
    <div>
        <h2>Edit PetPal</h2>
        <div class="name">
            <label for="name">Name:</label>
            <input name="name" id="name" type="text" .value="${data.name}">
        </div>
        <div class="breed">
            <label for="breed">Breed:</label>
            <input name="breed" id="breed" type="text" .value="${data.breed}">
        </div>
        <div class="Age">
            <label for="age">Age:</label>
            <input name="age" id="age" type="text" .value="${data.age}">
        </div>
        <div class="weight">
            <label for="weight">Weight:</label>
            <input name="weight" id="weight" type="text" .value="${data.weight}">
        </div>
        <div class="image">
            <label for="image">Image:</label>
            <input name="image" id="image" type="text" .value="${data.image}">
        </div>
        <button class="btn" type="submit">Edit Pet</button>
    </div>
</form>
</section>`;

export async function editView(ctx){

    let data = await get(`/data/pets/${ctx.params.id}`);
    ctx.render(teplateView(data));
}