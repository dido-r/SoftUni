window.addEventListener("load", solve);

function solve() {

  const make = document.getElementById('make');
  const model = document.getElementById('model');
  const year = document.getElementById('year');
  const fuel = document.getElementById('fuel');
  const originalPrice = document.getElementById('original-cost');
  const sellingPrice = document.getElementById('selling-price');
  let profit = 0;
  document.getElementById('publish').addEventListener('click', publish);

  function publish(event) {

    event.preventDefault();

    if (make.value == '' || model.value == '' || year.value == '' || fuel.value == '' || originalPrice.value == '' || sellingPrice.value == '' || originalPrice.value > sellingPrice.value) {

      return;
    }

    let car = document.createElement('tr');
    let tdMake = document.createElement('td');
    let tdModel = document.createElement('td');
    let tdYear = document.createElement('td');
    let tdFuel = document.createElement('td');
    let tdOriginalPrice = document.createElement('td');
    let tdSellingPrice = document.createElement('td');
    let buttons = document.createElement('td');
    let editButton = document.createElement('button');
    let sellButton = document.createElement('button');

    car.className = 'row';
    tdMake.textContent = make.value;
    tdModel.textContent = model.value;
    tdYear.textContent = year.value;
    tdFuel.textContent = fuel.value;
    tdOriginalPrice.textContent = originalPrice.value;
    tdSellingPrice.textContent = sellingPrice.value;
    editButton.textContent = 'Edit';
    editButton.className = 'action-btn edit';
    editButton.addEventListener('click', edit);
    sellButton.textContent = 'Sell';
    sellButton.className = 'action-btn sell';
    sellButton.addEventListener('click', sell);

    buttons.appendChild(editButton);
    buttons.appendChild(sellButton);
    car.appendChild(tdMake);
    car.appendChild(tdModel);
    car.appendChild(tdYear);
    car.appendChild(tdFuel);
    car.appendChild(tdOriginalPrice);
    car.appendChild(tdSellingPrice);
    car.appendChild(buttons);
    document.getElementById('table-body').appendChild(car);

    make.value = '';
    model.value = '';
    year.value = '';
    fuel.value = '';
    originalPrice.value = '';
    sellingPrice.value = '';

    function edit(event) {

      let currentRow = event.target.parentElement.parentElement;
      let currentRowElements = currentRow.getElementsByTagName('td');
      make.value = currentRowElements[0].textContent;
      model.value = currentRowElements[1].textContent;
      year.value = currentRowElements[2].textContent;
      fuel.value = currentRowElements[3].textContent;
      originalPrice.value = currentRowElements[4].textContent;
      sellingPrice.value = currentRowElements[5].textContent;
      currentRow.remove();
    }

    function sell(event) {

      let currentRow = event.target.parentElement.parentElement;
      let currentRowElements = currentRow.getElementsByTagName('td');
      let li = document.createElement('li');
      let makeAndModelSpan = document.createElement('span');
      let yearSpan = document.createElement('span');
      let revenue = document.createElement('span');
      makeAndModelSpan.textContent = currentRowElements[0].textContent + ' ' + currentRowElements[1].textContent;
      yearSpan.textContent = currentRowElements[2].textContent;
      revenue.textContent = Number(currentRowElements[5].textContent) - Number(currentRowElements[4].textContent);
      li.appendChild(makeAndModelSpan);
      li.appendChild(yearSpan);
      li.appendChild(revenue);
      li.className = 'each-list';
      document.getElementById('cars-list').appendChild(li);
      currentRow.remove();
      profit += Number(revenue.textContent);
      document.getElementById('profit').textContent = `${profit.toFixed(2)}`;
    }
  }
}