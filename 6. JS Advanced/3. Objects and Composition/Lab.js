//task 1

function cityRecord(name, population, treasury) {

    return {
        name,
        population,
        treasury
    };
}

//task 2

function townPopulation(input) {

    let registry = input
        .map(x => x.split(' <-> '))
        .reduce((result, current) => {
            if (result[current[0]] !== undefined) {

                result[current[0]] += Number(current[1]);
            } else {

                result[current[0]] = Number(current[1]);
            }

            return result;
        }
            , {});


    for (let town in registry) {

        console.log(`${town} : ${registry[town]}`);
    }
}

// task 3

function cityTaxes(name, population, treasury) {

    return {
        name,
        population,
        treasury,
        taxRate: 10,
        collectTaxes() { this.treasury += this.population * this.taxRate },
        applyGrowth(percentage) { this.population += Math.floor(this.population * percentage / 100) },
        applyRecession(percentage) { this.treasury -= Math.floor(this.treasury * percentage / 100) }
    }
}

//task 4

function objectFactory(funcs, items) {

    let result = [];

    for (let object of items) {

        let current = Object.assign(object['template']);

        for (let task of object['parts']) {

            current[task] = funcs[task];
        }

        result.push(current);
    }

    return result;
}

//task 5

function createAssemblyLine() {

    return {

        hasClima(car) {

            car.temp = 21;
            car.tempSettings = 21;
            car.adjustTemp = () => {

                if (car.temp < car.tempSettings){
                    
                    car.temp++;
                }else if(car.temp > car.tempSettings){
                    
                    car.temp--;
                }
            }
        },

        hasAudio(car) {

            car.currentTrack = {

                name: null,
                artist: null,
            }

            car.nowPlaying = function() {

                if (car.currentTrack !== undefined && car.currentTrack !== null) {

                    console.log(`Now playing '${car.currentTrack.name}' by ${car.currentTrack.artist}`);
                }
            }
        },

        hasParktronic(car) {

            car.checkDistance = (distance) => {

                if (distance < 0.1) console.log('Beep! Beep! Beep!');
                else if (distance < 0.25) console.log('Beep! Beep!');
                else if (distance < 0.5) console.log('Beep!');
                else console.log('');
            }
        }
    }
}

// task 6

function solve(input){

    var symbols = {
        '&': '&amp;',
        '<': '&lt;',
        '>': '&gt;',
        '"': '&quot;',
        "'": '&#39;',
        '/': '&#x2F;',
        '`': '&#x60;',
        '=': '&#x3D;'
      };
      
      function escapeHtml (string) {
        return String(string).replace(/[&<>"'`=\/]/g, function (s) {
          return symbols[s];
        });
      }
    
    let inputArray = JSON.parse(input);
    let result = '<table>\n';
    result += `   <tr>`;
    let keys = Object.keys(inputArray[0]);

    for(let key of keys){

        result += `<th>${escapeHtml(key.toString())}</th>`;
    }
    result += `</tr>\n`;
      
    for(let student of inputArray){

        result += `   <tr>`;

        for(let info of Object.values(student)){

            result += `<td>${escapeHtml(info.toString())}</td>`;
        }
        result += `</tr>\n`;
    }

    result += '</table>';
    console.log(result);
}