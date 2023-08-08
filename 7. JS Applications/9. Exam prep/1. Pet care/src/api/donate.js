import { post } from "./api.js";

export async function donate(event){

    let petId = event.target.getAttribute('petId');
    await post('/data/donation', {petId},  true);
}