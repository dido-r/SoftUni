function solve() {
   
   let div = document.getElementsByClassName('shopping-cart')[0];
   div.addEventListener('click', buyProducts);
   let result = document.getElementsByTagName('textarea')[0];
   let products = [];

   function buyProducts(event){

      if(event.target.nodeName === 'BUTTON'){

         if(event.target.textContent.trim() === 'Add'){

            let name = event.target.parentElement.parentElement.getElementsByClassName('product-title')[0].textContent;
            let price = event.target.parentElement.parentElement.getElementsByClassName('product-line-price')[0].textContent;
            result.textContent += `Added ${name} for ${price} to the cart.\n`;
            
            if(!products.some(x => x.type === name)){

               products.push({
                  type: name,
                  money: Number(price)
               });

            }else{

               let current = products.find(x => x.type === name);
               current.money += Number(price);
            }

         }else if(event.target.textContent.trim() === 'Checkout'){

            let totalPrice = 0;

            for(let product of products){

               totalPrice += Number(product.money);
            }
            result.textContent += `You bought ${products.map(x => x.type).join(', ')} for ${totalPrice.toFixed(2)}.`;
            div.removeEventListener('click', buyProducts);
         }
      }
   }
}