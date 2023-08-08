import { post, put } from "./api.js";

export async function create(event){

    event.preventDefault();
    let form = new FormData(event.target);
    let {name, imgUrl, price, releaseDate, artist, genre, description} = Object.fromEntries(form);
    
    if (name === '' || imgUrl === '' || price === ''|| releaseDate === '' || artist === '' || genre === '' || description === '') {

        alert('All fields required!')
        return;
    }

    let obj = {

        name,
        imgUrl,
        price,
        releaseDate,
        artist,
        genre,
        description
    }

    try {

        await post('/data/albums', obj, true);
        event.target.reset();
        window.location.href = "/catalog";
        
    } catch (err) {

        alert(err);
        return;
    }
}