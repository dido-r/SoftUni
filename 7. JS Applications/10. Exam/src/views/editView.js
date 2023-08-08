import { html } from '../../node_modules/lit-html/lit-html.js';
import { get, put } from '../api/api.js';

const teplateView = (album, editAlbum) => html`<section id="edit">
<div class="form">
  <h2>Edit Album</h2>
  <form class="edit-form" @submit=${editAlbum} id=${album._id}>
    <input type="text" name="singer" id="album-singer" placeholder="Singer/Band" .value="${album.singer}"/>
    <input type="text" name="album" id="album-album" placeholder="Album" .value="${album.album}"/>
    <input type="text" name="imageUrl" id="album-img" placeholder="Image url" .value="${album.imageUrl}"/>
    <input type="text" name="release" id="album-release" placeholder="Release date" .value="${album.release}"/>
    <input type="text" name="label" id="album-label" placeholder="Label" .value="${album.label}"/>
    <input type="text" name="sales" id="album-sales" placeholder="Sales" .value="${album.sales}"/>

    <button type="submit">post</button>
  </form>
</div>
</section>`;

export async function editView(ctx) {

  ctx.render(html`<div class="loader"></div>`);
  const id = ctx.params.id;
  let album = await get(`/data/albums/${id}`);
  ctx.render(teplateView(album, editAlbum));

  async function editAlbum(event){

    event.preventDefault();
    let form = new FormData(event.target);
    let { singer, album, imageUrl, release, label, sales } = Object.fromEntries(form);

    if (singer === '' || album === '' || imageUrl === '' || release === '' || label === '' || sales === '') {

      alert('All fields required!')
      return;
    }

    let obj = {

      singer,
      album, 
      imageUrl, 
      release, 
      label, 
      sales
    }

    try {

      await put(`/data/albums/${id}`, obj, true);
      event.target.reset();
      ctx.page.redirect(`/details/${id}`);
      
    } catch (err) {

      alert(err);
      return;
    }   
}
}