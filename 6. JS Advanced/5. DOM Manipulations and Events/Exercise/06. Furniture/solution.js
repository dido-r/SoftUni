function solve() {

  let buttons = document.getElementById('exercise').getElementsByTagName('button');
  let textAreas = document.getElementById('exercise').getElementsByTagName('textarea');
  buttons[0].addEventListener('click', generate);
  buttons[1].addEventListener('click', buy)
  
  function generate() {

    let items = JSON.parse(textAreas[0].value);
    let tableBody = document.getElementsByClassName('table')[0].getElementsByTagName('tbody')[0];
    
    for (let item of items) {

      let row = document.createElement('tr');
      let cell1 = document.createElement('td');
      let cell2 = document.createElement('td');
      let cell3 = document.createElement('td');
      let cell4 = document.createElement('td');
      let cell5 = document.createElement('td');
      let image = document.createElement('img');
      image.src = item.img;
      let pName = document.createElement('p');
      pName.textContent = item.name;
      let pPrice = document.createElement('p');
      pPrice.textContent = item.price;
      let pFactor = document.createElement('p');
      pFactor.textContent = item.decFactor;
      let input = document.createElement('input');
      input.type = 'checkbox';
      cell1.appendChild(image);
      cell2.appendChild(pName);
      cell3.appendChild(pPrice);
      cell4.appendChild(pFactor);
      cell5.appendChild(input);
      row.appendChild(cell1);
      row.appendChild(cell2);
      row.appendChild(cell3);
      row.appendChild(cell4);
      row.appendChild(cell5);
      tableBody.appendChild(row);
    }
  }

  function buy() {

    let products = [];
    let tableBody = document.getElementsByClassName('table')[0].getElementsByTagName('tbody')[0];
    let rows = tableBody.getElementsByTagName('tr');
    
    for(let row of rows){

      let cells = row.getElementsByTagName('td');
            
      if(cells[4].childNodes[0].checked){
        
        products.push({
          
          furnitureName: cells[1].textContent,
          furniturePrice: Number(cells[2].textContent),
          furnitureFactor: Number(cells[3].textContent)
        });
      }
    }

    textAreas[1].textContent += `Bought furniture: ${products.map(x => x.furnitureName).join(', ')}\n`;
    textAreas[1].textContent += `Total price: ${(products.reduce((result, current) => result + current.furniturePrice, 0).toFixed(2))}\n`;
    textAreas[1].textContent += `Average decoration factor: ${(products.reduce((result, current) => result + current.furnitureFactor, 0) / products.length)}`;
  }
}