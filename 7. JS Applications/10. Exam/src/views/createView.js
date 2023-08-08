import { html } from '../../node_modules/lit-html/lit-html.js';
import { post } from '../api/api.js';

const teplateView = (createAlbum) => html`<section id="create">
  <div class="form">
    <h2>Add Album</h2>
    <form class="create-form" @submit=${createAlbum}>
      <input type="text" name="singer" id="album-singer" placeholder="Singer/Band" />
      <input type="text" name="album" id="album-album" placeholder="Album" />
      <input type="text" name="imageUrl" id="album-img" placeholder="Image url" />
      <input type="text" name="release" id="album-release" placeholder="Release date" />
      <input type="text" name="label" id="album-label" placeholder="Label" />
      <input type="text" name="sales" id="album-sales" placeholder="Sales" />

      <button type="submit">post</button>
    </form>
  </div>
</section>`;

export function createView(ctx) {

  ctx.render(teplateView(createAlbum));

  async function createAlbum(event) {

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

      await post('/data/albums', obj, true);
      event.target.reset();
      ctx.page.redirect('/dashboard');
      
    } catch (err) {

      alert(err);
      return;
    }   
  }
}