import { html, render } from './node_modules/lit-html/lit-html.js';

function solve() {
   
   generateTable();
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   async function generateTable(){

      let res = await fetch('http://localhost:3030/jsonstore/advanced/table');
      let data = await res.json();
      let result = (items) => Object.values(items).map(x => generateRow(x));
      render(result(data), document.getElementsByTagName('tbody')[0])
   }

   function generateRow(obj){

      return html`<tr>
         <td>${obj.firsName} ${obj.lastName}</td>
         <td>${obj.email}</td>
         <td>${obj.course}</td>
      </tr>`;
   }

   function onClick() {
      
      [...document.getElementsByTagName('tr')].forEach(x => x.className = '');
      let input = document.getElementById('searchField');
      [...document.getElementsByTagName('td')].forEach(x => {

         if(x.textContent.toLowerCase().includes(input.value.toLowerCase())){

            x.parentElement.className = 'select';
         }
      })

      input.value = '';
   }
}

solve();