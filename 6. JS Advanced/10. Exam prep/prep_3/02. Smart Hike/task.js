class SmartHike {

    constructor(username) {

        this.username = username;
        this.goals = {};
        this.listOfHikes = [];
        this.resources = 100;
    }

    addGoal = (peak, altitude) => {

        if (this.goals[peak] == undefined) {

            this.goals[peak] = Number(altitude);
            return `You have successfully added a new goal - ${peak}`;
        }

        return `${peak} has already been added to your goals`;
    }

    hike = (peak, time, difficultyLevel) => {

        if (this.goals[peak] == undefined) {

            throw new Error(`${peak} is not in your current goals`);
        }

        if (this.resources === 0) {

            throw new Error("You don't have enough resources to start the hike");
        }

        let diff = this.resources - (time * 10);

        if (diff < 0) {

            return "You don't have enough resources to complete the hike";
        }

        this.resources -= (time * 10);

        this.listOfHikes.push({
            peak,
            time,
            difficultyLevel
        });

        return `You hiked ${peak} peak for ${time} hours and you have ${this.resources}% resources left`;
    }

    rest = (time) => {

        this.resources += (time * 10);
        this.resources = this.resources > 100 ? 100 : this.resources;

        return  this.resources < 100 ? `You have rested for ${time} hours and gained ${time * 10}% resources` : 'Your resources are fully recharged. Time for hiking!';
    }

    showRecord = (criteria) => {

        if(this.listOfHikes.length === 0){

            return `${this.username} has not done any hiking yet`;
        }
        
        if(criteria === 'all') {

            let result = 'All hiking records:\n'

            for(let hike of this.listOfHikes){

                result += `${this.username} hiked ${hike.peak} for ${hike.time} hours\n`;
            }

            return result.trim();
        }

        if(this.listOfHikes.filter(x => x.difficultyLevel === criteria).length === 0){

            return `${this.username} has not done any ${criteria} hiking yet`
        }
        
        let bestHike = this.listOfHikes.filter(x => x.difficultyLevel === criteria).sort((a, b) => a.time - b.time)[0];

        return `${this.username}'s best ${criteria} hike is ${bestHike.peak} peak, for ${bestHike.time} hours`;
    }
}