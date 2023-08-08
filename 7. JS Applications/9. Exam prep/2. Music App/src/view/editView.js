import { html } from '../../node_modules/lit-html/lit-html.js';
import { get, put } from '../api/api.js';

const teplateView = (album, editAlbum) => html`<section class="editPage">
<form @submit=${editAlbum}>
    <fieldset>
        <legend>Edit Album</legend>

        <div class="container">
            <label for="name" class="vhide">Album name</label>
            <input id="name" name="name" class="name" type="text" .value="${album.name}">

            <label for="imgUrl" class="vhide">Image Url</label>
            <input id="imgUrl" name="imgUrl" class="imgUrl" type="text" .value="${album.imgUrl}">

            <label for="price" class="vhide">Price</label>
            <input id="price" name="price" class="price" type="text" .value="${album.price}">

            <label for="releaseDate" class="vhide">Release date</label>
            <input id="releaseDate" name="releaseDate" class="releaseDate" type="text" .value="${album.releaseDate}">

            <label for="artist" class="vhide">Artist</label>
            <input id="artist" name="artist" class="artist" type="text" .value="${album.artist}">

            <label for="genre" class="vhide">Genre</label>
            <input id="genre" name="genre" class="genre" type="text" .value="${album.genre}">

            <label for="description" class="vhide">Description</label>
            <textarea name="description" class="description" rows="10"
                cols="10">${album.description}</textarea>

            <button class="edit-album" type="submit">Edit Album</button>
        </div>
    </fieldset>
</form>
</section>`;

export async function editView(ctx){

    ctx.render(html`<div class="loader"></div>`);
    let album = await get(`/data/albums/${ctx.params.id}`);
    ctx.render(teplateView(album, editAlbum));

    async function editAlbum(event){

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
    
            await put(`/data/albums/${ctx.params.id}`, obj, true);
            event.target.reset();
            window.location.href = `/details/${ctx.params.id}`;
            
        } catch (err) {
    
            alert(err);
            return;
        }
    }
}