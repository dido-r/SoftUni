import { post, put, del } from "./api.js";

export async function createPet(event) {

    event.preventDefault();
    let form = new FormData(event.target);
    let { name, breed, age, weight, image } = Object.fromEntries(form);

    if (name === '' || breed === '' || age === '' || weight === '' || image === '') {

        alert('All fields required!');
        return;
    }

    let pet = {

        name,
        breed,
        age,
        weight,
        image
    }

    try {

        await post('/data/pets', pet, true);
        event.target.reset();
        window.location.href = "/home";

    } catch (err) {

        alert(err);
        return;
    }
}

export async function editPet(event) {

    event.preventDefault();
    let form = new FormData(event.target);
    let { name, breed, age, weight, image } = Object.fromEntries(form);

    if (name === '' || breed === '' || age === '' || weight === '' || image === '') {

        alert('All fields required!');
        return;
    }

    let pet = {

        name,
        breed,
        age,
        weight,
        image
    }

    try {

        let id = event.target.id;
        await put(`/data/pets/${id}`, pet, true);
        event.target.reset();
        window.location.href = `/details/${id}`;

    } catch (err) {

        alert(err);
        return;
    }
}

export async function deletePet(event) {

    if (confirm("Are you sure you want to delete this pet!") == true) {

        let id = event.target.id;

        try {

            await del(`/data/pets/${id}`, undefined, true);
            window.location.href = '/home';

        } catch (err) {

            alert(err);
            return;
        }
    } 
}