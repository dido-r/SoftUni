import { html } from '../../node_modules/lit-html/lit-html.js';
import { createPet } from '../api/crud.js';

const teplateView = () => html`<section id="createPage">
<form class="createForm" @submit=${createPet}>
    <img src="./images/cat-create.jpg">
    <div>
        <h2>Create PetPal</h2>
        <div class="name">
            <label for="name">Name:</label>
            <input name="name" id="name" type="text" placeholder="Pet name...">
        </div>
        <div class="breed">
            <label for="breed">Breed:</label>
            <input name="breed" id="breed" type="text" placeholder="Pet breed...">
        </div>
        <div class="Age">
            <label for="age">Age:</label>
            <input name="age" id="age" type="text" placeholder="Pet years...">
        </div>
        <div class="weight">
            <label for="weight">Weight:</label>
            <input name="weight" id="weight" type="text" placeholder="Pet weight...">
        </div>
        <div class="image">
            <label for="image">Image:</label>
            <input name="image" id="image" type="text" placeholder="Pet image...">
        </div>
        <button class="btn" type="submit">Create Pet</button>
    </div>
</form>
</section>
`;

export function createView(ctx){

    ctx.render(teplateView());
}