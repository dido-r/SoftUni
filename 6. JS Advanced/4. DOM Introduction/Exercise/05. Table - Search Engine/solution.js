function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {

      let elements = document.querySelectorAll('tbody tr');
      let input = document.getElementById('searchField').value;
      document.getElementById('searchField').value = '';

      for (let item of elements) {

         item.classList.remove('select')
      }

      if (input !== '') {

         for (let item of elements) {

            if (item.textContent.includes(input)) {

               item.classList.add("select");
            }
         }
      }
   }
}