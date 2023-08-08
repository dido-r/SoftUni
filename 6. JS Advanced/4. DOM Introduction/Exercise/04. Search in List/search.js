function search() {

   let towns = document.getElementsByTagName('li');
   let search = document.getElementById('searchText').value;
   let matches = 0;

   for (let town of towns) {

      town.style.fontWeight = 'normal';
      town.style.textDecoration = 'none';
   }

   for (let town of towns) {

      if (town.textContent.includes(search)) {

         matches++;
         town.style.fontWeight = 'bold';
         town.style.textDecoration = 'underline';
      }
   }

   document.getElementById('result').textContent = `${matches} matches found`;
}
