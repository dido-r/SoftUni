function solve() {
  
  let type = document.getElementById('naming-convention').value;
  let array = document.getElementById('text').value.split(' ');
  result = '';

  if(type === 'Camel Case'){

    result = array[0].toLowerCase();

    for(let i = 1; i < array.length; i++){

      array[i] = array[i][0].toUpperCase() + array[i].toLowerCase().slice(1);
      result += array[i]
    }

  }else if(type === 'Pascal Case'){

    for(let i = 0; i < array.length; i++){

      array[i] = array[i][0].toUpperCase() + array[i].toLowerCase().slice(1);
      result += array[i]
    }

  }else{

    result = 'Error!'
  }

  document.getElementById('result').textContent = result;
}