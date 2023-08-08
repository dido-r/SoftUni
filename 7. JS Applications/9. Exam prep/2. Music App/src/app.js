import page from '../node_modules/page/page.mjs';
import { render } from '../node_modules/lit-html/lit-html.js';
import { homeView } from './view/homeView.js';
import { registerView } from './view/registerView.js';
import { loginView } from './view/loginView.js';
import { catalogView } from './view/catalogView.js';
import { detailsView } from './view/detailsView.js';
import { editView } from './view/editView.js';
import { createView } from './view/createView.js';
import { searchView } from './view/searchView.js';

page(decorateContext)
page('/', '/home');
page('/home', homeView);
page('/catalog', catalogView);
page('/login', loginView);
page('/register', registerView);
page('/create', createView);
page('/edit/:id', editView);
page('/details/:id', detailsView);
page('/search', searchView);
page.start();

function decorateContext(ctx, next) {

    ctx.render = (content) => {

        render(content, document.getElementById('main-content'))
    }

    ctx.navRender = (content) => {

        render(content, document.querySelector('#box header'))
    }

    ctx.searchRender = (content) => {

        render(content, document.getElementById('search-result'))
    }
    
    next();
}