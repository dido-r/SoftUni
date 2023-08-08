import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import { get, del, post } from '../api/api.js';

const teplateView = (album, userId, deleteAlbum, likeAlbum, likes, isLiked) => html`<section id="details">
<div id="details-wrapper">
  <p id="details-title">Album Details</p>
  <div id="img-wrapper">
    <img src="${album.imageUrl}" alt="example1" />
  </div>
  <div id="info-wrapper">
    <p><strong>Band:</strong><span id="details-singer">${album.singer}</span></p>
    <p>
      <strong>Album name:</strong><span id="details-album">${album.album}</span>
    </p>
    <p><strong>Release date:</strong><span id="details-release">${album.release}</span></p>
    <p><strong>Label:</strong><span id="details-label">${album.label}</span></p>
    <p><strong>Sales:</strong><span id="details-sales">${album.sales}</span></p>
  </div>
  <div id="likes">Likes: <span id="likes-count">${likes}</span></div>

  ${ userId === album._ownerId ? html`<div id="action-buttons">
    <a href="/edit/${album._id}" id="edit-btn">Edit</a>
    <a href="" @click=${deleteAlbum} id="delete-btn">Delete</a>
  </div>` : nothing}

  ${ (userId !== album._ownerId && userId !== null && isLiked === 0) ? html`<div id="action-buttons">
    <a href="" @click=${likeAlbum} id="like-btn">Like</a>
  </div>` : nothing}
</div>
</section>`;

export async function detailsView(ctx) {

  ctx.render(html`<div class="loader"></div>`);
  const id = ctx.params.id;
  const userId = sessionStorage.getItem('userId');
  let album = await get(`/data/albums/${id}`);
  let likes = await get(`/data/likes?where=albumId%3D%22${id}%22&distinct=_ownerId&count`);
  let isLiked = await get(`/data/likes?where=albumId%3D%22${id}%22%20and%20_ownerId%3D%22${userId}%22&count`);
  ctx.render(teplateView(album, userId, deleteAlbum, likeAlbum, likes, isLiked));

  async function likeAlbum(){

    await post('/data/likes', {albumId: id}, true);
  }

  async function deleteAlbum(){

    if (confirm("Are you sure you want to delete this album!") == true) {
   
      try {

          await del(`/data/albums/${id}`, undefined, true);
          ctx.page.redirect('/dashboard');

      } catch (err) {

          alert(err);
          return;
      }
    } 
  }
}