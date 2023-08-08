import page from '../node_modules/page/page.mjs';
import { render } from '../node_modules/lit-html/lit-html.js';
import { homeView } from './views/homeView.js';
import { registerView } from './views/registerView.js';
import { loginView } from './views/loginView.js';
import { dashboardView } from './views/dashboardView.js';
import { detailsView } from './views/detailsView.js';
import { editView } from './views/editView.js';
import { createView } from './views/createView.js';
import { teplateNavView } from './views/navView.js';

page(decorateContext);
page('/index.html', '/');
page('/', homeView);
page('/dashboard', dashboardView);
page('/login', loginView);
page('/register', registerView);
page('/create', createView);
page('/edit/:id', editView);
page('/details/:id', detailsView);
page.start();

function decorateContext(ctx, next) {

    const token = sessionStorage.getItem('token');
    render(teplateNavView(token), document.querySelector('header'))

    ctx.render = (content) => {

        render(content, document.querySelector('main'))
    }

    next();
}