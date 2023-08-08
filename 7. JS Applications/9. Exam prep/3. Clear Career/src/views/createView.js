import { html } from '../../node_modules/lit-html/lit-html.js';
import { post } from '../api/api.js';

const teplateView = (createOffer) => html`<section id="create">
<div class="form">
  <h2>Create Offer</h2>
  <form class="create-form" @submit=${createOffer}>
    <input
      type="text"
      name="title"
      id="job-title"
      placeholder="Title"
    />
    <input
      type="text"
      name="imageUrl"
      id="job-logo"
      placeholder="Company logo url"
    />
    <input
      type="text"
      name="category"
      id="job-category"
      placeholder="Category"
    />
    <textarea
      id="job-description"
      name="description"
      placeholder="Description"
      rows="4"
      cols="50"
    ></textarea>
    <textarea
      id="job-requirements"
      name="requirements"
      placeholder="Requirements"
      rows="4"
      cols="50"
    ></textarea>
    <input
      type="text"
      name="salary"
      id="job-salary"
      placeholder="Salary"
    />

    <button type="submit">post</button>
  </form>
</div>
</section>`;

export function createView(ctx){

    ctx.render(teplateView(createOffer));

    async function createOffer(event){

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
        description, 
        requirements, 
        salary

      }

      try {

        await post('/data/offers', offer, true);
        event.target.reset();
        ctx.page.redirect('/dashboard');
        
    } catch (err) {

        alert(err);
        return;
    }   
  }
}