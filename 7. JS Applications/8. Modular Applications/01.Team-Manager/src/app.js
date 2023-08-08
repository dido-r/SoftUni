import page from '../node_modules/page/page.mjs';
import { render } from '../node_modules/lit-html/lit-html.js';
import { browseView } from './views/browse.js';
import { createView } from './views/create.js';
import { detailView } from './views/details.js';
import { editView } from './views/edit.js';
import { homeView } from './views/home.js';
import { loginView } from './views/login.js';
import { myTeamsView } from './views/myTeams.js';
import { registerView } from './views/register.js';

page(decorateContext)
page('/', '/home');
page('/home', homeView);
page('/browse', browseView);
page('/login', loginView);
page('/register', registerView);
page('/myTeams', myTeamsView);
page('/details/:id', detailView);
page('/edit/:id', editView);
page('/create', createView);
page.start();

function decorateContext(ctx, next) {

    ctx.render = (content) => {

        render(content, document.querySelector('main'))
    }

    ctx.navRender = (content) => {

        render(content, document.getElementById('titlebar'))
    }

    next();
}