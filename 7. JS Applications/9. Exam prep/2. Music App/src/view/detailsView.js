import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import { get, del } from '../api/api.js';
import { navView } from './navView.js';

const userId = sessionStorage.getItem('userId');

const teplateView = (album, deleteAlbum) => html`<section id="detailsPage">
<div class="wrapper">
    <div class="albumCover">
        <img src="${album.imgUrl}">
    </div>
    <div class="albumInfo">
        <div class="albumText">

            <h1>Name: ${album.name}</h1>
            <h3>Artist: ${album.artist}</h3>
            <h4>Genre: ${album.genre}</h4>
            <h4>Price: $${album.price}</h4>
            <h4>Date: ${album.releaseDate}</h4>
            <p>Description: ${album.description	}</p>
        </div>

        ${ userId === album._ownerId ? html`<div class="actionBtn">
            <a href="/edit/${album._id}" class="edit">Edit</a>
            <a href="#" @click=${deleteAlbum} class="remove">Delete</a>
        </div>` : nothing} 
    </div>
</div>
</section>`;

export async function detailsView(ctx){

    navView(ctx);
    ctx.render(html`<div class="loader"></div>`);
    let album = await get(`/data/albums/${ctx.params.id}`);
    ctx.render(teplateView(album, deleteAlbum));

    async function deleteAlbum(){

        if (confirm("Are you sure you want to delete this album!") == true) {
   
            try {
    
                await del(`/data/albums/${ctx.params.id}`, undefined, true);
                window.location.href = '/catalog';
    
            } catch (err) {
    
                alert(err);
                return;
            }
        } 
    }
}