import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import { get, del, post } from '../api/api.js';

const teplateView = (offer, userId, deleteOffer, applyforOffer, applications, isApplied) => html`<section id="details">
<div id="details-wrapper">
  <img id="details-img" src="${offer.imageUrl}" alt="example1" />
  <p id="details-title">${offer.title}</p>
  <p id="details-category">
    Category: <span id="categories">${offer.category}</span>
  </p>
  <p id="details-salary">
    Salary: <span id="salary-number">${offer.salary}</span>
  </p>
  <div id="info-wrapper">
    <div id="details-description">
      <h4>Description</h4>
      <span
        >${offer.description}</span
      >
    </div>
    <div id="details-requirements">
      <h4>Requirements</h4>
      <span
        >${offer.requirements}</span
      >
    </div>
  </div>
  <p>Applications: <strong id="applications">${applications}</strong></p>
    
    ${userId === offer._ownerId ? html`<div id="action-buttons">
    <a href="/edit/${offer._id}" id="edit-btn">Edit</a>
    <a href="" @click=${deleteOffer} id="delete-btn">Delete</a></div>` : nothing}
  
    ${(userId !== offer._ownerId && userId !== null && isApplied === 0) ? html`<div id="action-buttons">
    <a href="" @click=${applyforOffer} id="apply-btn">Apply</a></div>` : nothing}
    </div>
</div>
</section>`;

export async  function detailsView(ctx){

  let id = ctx.params.id;
  ctx.render(html`<div class="loader"></div>`);
  const offer = await get(`/data/offers/${id}`);
  const userId = sessionStorage.getItem('userId');
  let applications = await get(`/data/applications?where=offerId%3D%22${id}%22&distinct=_ownerId&count`);
  let isApplied = await get(`/data/applications?where=offerId%3D%22${id}%22%20and%20_ownerId%3D%22${userId}%22&count`);
  ctx.render(teplateView(offer, userId, deleteOffer, applyforOffer, applications, isApplied));

  async function deleteOffer(){

    if (confirm("Are you sure you want to delete this offer!") == true) {
   
      try {

          await del(`/data/offers/${id}`, undefined, true);
          ctx.page.redirect('/dashboard');

      } catch (err) {

          alert(err);
          return;
      }
    } 
  }

  async function applyforOffer(){

    await post('/data/applications', {offerId: id}, true);
  }
}