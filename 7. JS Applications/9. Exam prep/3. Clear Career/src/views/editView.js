import { html } from '../../node_modules/lit-html/lit-html.js';
import { get, put } from '../api/api.js';

const teplateView = (offer, editOffer) => html`<section id="edit">
<div class="form">
  <h2>Edit Offer</h2>
  <form class="edit-form" @submit=${editOffer}>
    <input
      type="text"
      name="title"
      id="job-title"
      placeholder="Title"
      .value=${offer.title}
    />
    <input
      type="text"
      name="imageUrl"
      id="job-logo"
      placeholder="Company logo url"
      .value=${offer.imageUrl}
    />
    <input
      type="text"
      name="category"
      id="job-category"
      placeholder="Category"
      .value=${offer.category}
    />
    <textarea
      id="job-description"
      name="description"
      placeholder="Description"
      .value=${offer.description}
      rows="4"
      cols="50"
    ></textarea>
    <textarea
      id="job-requirements"
      name="requirements"
      placeholder="Requirements"
      .value=${offer.requirements}
      rows="4"
      cols="50"
    ></textarea>
    <input
      type="text"
      name="salary"
      id="job-salary"
      placeholder="Salary"
      .value=${offer.salary}
    />

    <button type="submit">post</button>
  </form>
</div>
</section>`;

export async function editView(ctx){

  let id = ctx.params.id;
  ctx.render(html`<div class="loader"></div>`);
  const offer = await get(`/data/offers/${id}`);
  ctx.render(teplateView(offer, editOffer));

  async function editOffer(event){

    event.preventDefault();

      let form = new FormData(event.target);
      let {title, imageUrl, category, description, requirements, salary} = Object.fromEntries(form);
    
      if (title === '' || imageUrl === '' || category === ''|| requirements === '' || salary === '' || description === '') {

          alert('All fields required!')
          return;
      }

      let offer = {

        title,
        imageUrl,
        category,
        requirements,
        salary,
        description
      }

      try {

        await put(`/data/offers/${id}`, offer, true);
        event.target.reset();
        ctx.page.redirect(`/details/${id}`);
        
    } catch (err) {

        alert(err);
        return;
    }      
  }
}