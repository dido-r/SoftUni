function add(num) {
  
  let sum = 0;
  

  return function(){

    return sum += num;
  }
}

console.log(add(1)(2)(3));