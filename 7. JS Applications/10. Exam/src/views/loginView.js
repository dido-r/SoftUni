import { html } from '../../node_modules/lit-html/lit-html.js';
import { post } from '../api/api.js';

const teplateView = (loginUser) => html`<section id="login">
<div class="form">
  <h2>Login</h2>
  <form class="login-form" @submit=${loginUser}>
    <input type="text" name="email" id="email" placeholder="email" />
    <input type="password" name="password" id="password" placeholder="password" />
    <button type="submit">login</button>
    <p class="message">
      Not registered? <a href="/register">Create an account</a>
    </p>
  </form>
</div>
</section>`;

export function loginView(ctx) {

    ctx.render(teplateView(loginUser));

    async function loginUser(event) {

      event.preventDefault();
      let form = new FormData(event.target);
      let { email, password } = Object.fromEntries(form);
  
      if (email === '' || password === '') {
  
          alert('All fields required!')
          return;
      }
  
      let obj = {
  
          email,
          password
      }
  
      try {
  
          let data = await post('/users/login', obj);
          sessionStorage.setItem('token', data.accessToken);
          sessionStorage.setItem('userId', data._id);
          event.target.reset();
          ctx.page.redirect('/dashboard');
  
      } catch (err) {
  
          alert(err);
          return;
      }
  }
}