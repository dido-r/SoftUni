function solve() {

   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {

      let userInput = document.getElementsByTagName('textarea')[0].value;
      let restaurants = userInput.split('","');
      let result = [];

      for (let restaurant of restaurants) {

         let data = restaurant.replace('[', '').replace(']', '').replace('"', '').replace('"', '');
         let moreData = data.split(' - ');
         let restName = moreData[0];
         let workersData = moreData[1].split(', ');

         let currentRestaurant = {
            name: restName,
            workers: [],
            averageSalary: 0
         };

         result.push(currentRestaurant);

         if (result.includes(x => x.name !== currentRestaurant.name)) {

            currentRestaurant = {

               name: restName,
               workers: [],
               averageSalary: 0
            }
         } else {

            currentRestaurant = result.find(x => x.name === restName);
         }

         for (let item of workersData) {

            currentRestaurant.workers.push({

               workerName: item.split(' ')[0],
               salary: Number(item.split(' ')[1]),
            });
         }

         let sum = 0;

         for (let item of currentRestaurant.workers) {

            sum += item.salary;
         }

         currentRestaurant.averageSalary = sum / currentRestaurant.workers.length;
      }

      let bestRest = result.sort((a, b) => b.averageSalary - a.averageSalary)[0];
      let bestSalary = bestRest.workers.sort((a, b) => b.salary - a.salary)[0].salary;
      let bestOutput = document.getElementById('bestRestaurant');
      bestOutput.getElementsByTagName('p')[0].textContent = `Name: ${bestRest.name} Average Salary: ${bestRest.averageSalary.toFixed(2)} Best Salary: ${bestSalary.toFixed(2)}`;
      
      let bestWorkerOutput = [];

      for(let item of bestRest.workers.sort((a, b) => b.salary - a.salary)){

         bestWorkerOutput.push(`Name: ${item.workerName} With Salary: ${item.salary}`);
      }
      
      let bestWorkers = document.getElementById('workers');
      bestWorkers.getElementsByTagName('p')[0].textContent = bestWorkerOutput.join(' ');
   }
}












