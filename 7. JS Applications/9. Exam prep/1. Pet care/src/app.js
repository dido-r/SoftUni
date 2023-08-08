import page from '../node_modules/page/page.mjs';
import { render } from '../node_modules/lit-html/lit-html.js';
import { homeView } from './views/homeView.js';
import { registerView } from './views/registerView.js';
import { loginView } from './views/loginView.js';
import { dashboardView } from './views/dashboardView.js';
import { detailsView } from './views/detailsView.js';
import { editView } from './views/editView.js';
import { createView } from './views/createView.js';

page(decorateContext)
page('/', '/home');
page('/home', homeView);
page('/dashboard', dashboardView);
page('/login', loginView);
page('/register', registerView);
page('/create', createView);
page('/edit/:id', editView);
page('/details/:id', detailsView);
page.start();

function decorateContext(ctx, next) {

    ctx.render = (content) => {

        render(content, document.getElementById('content'))
    }

    ctx.navRender = (content) => {

        render(content, document.querySelector('header'))
    }

    next();
}