import page from '../node_modules/page/page.mjs';
import{render } from '../node_modules/lit-html/lit-html.js';
import {loginView } from './views/login.js';
import { registerView} from './views/register.js';
import { homeView} from './views/home.js';
import { createView} from './views/create.js';
import { myFurnitureView } from './views/furniture.js';
import { detailsView } from './views/details.js';
import { editView } from './views/edit.js';
import { logout } from '../api/user.js';
import { deleteItem } from '../api/crud/delete.js';

const body = document.querySelector('.container');

page(decorateContext);
page('/', homeView);
page('/index', homeView);
page('/create', createView);
page('/login', loginView);
page('/register', registerView);
page('/my-furniture', myFurnitureView);
page('/details/:id', detailsView);
page('/edit/:id', editView);
page('/logout', logout);
page('/delete/:id', deleteItem);
page.start();

function decorateContext(ctx, next){

    ctx.render = (content) => render(content, body);
    next();
}