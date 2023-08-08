import { towns } from './towns.js';
import { html, render } from './node_modules/lit-html/lit-html.js';

document.getElementsByTagName('button')[0].addEventListener('click', search);

let toList = (items) => html`<ul>${items.map(x => html`<li>${x}</li>`)}</ul>`;
render(toList(towns), document.getElementById('towns'));

function search() {
   
   [...document.getElementsByTagName('li')].forEach(x => x.className = '');
   let matches = 0;
   let input = document.getElementById('searchText').value;
   [...document.getElementsByTagName('li')].forEach(x => {

      if(x.textContent.includes(input)){
         
         x.className = 'active';
         matches++;
      }
   });

   document.getElementById('result').textContent = `${matches} matches found`;
}
