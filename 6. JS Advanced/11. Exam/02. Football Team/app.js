class footballTeam {

    constructor(clubName, country) {

        this.clubName = clubName;
        this.country = country;
        this.invitedPlayers = [];
    }

    newAdditions = (footballPlayers) => {
        let result = [];

        for (let player of footballPlayers) {

            let data = player.split('/');
            let current = this.invitedPlayers.find(x => x.name === data[0]);  

            if (current == undefined) {

                this.invitedPlayers.push({

                    name: data[0],
                    age: Number(data[1]),
                    playerValue: Number(data[2])
                });
                result.push(data[0]);

            } else {

                if (current.playerValue < Number(data[2])) {

                    current.playerValue = Number(data[2]);
                }
            }
        }

        return `You successfully invite ${result.join(', ')}.`
    }

    signContract = (selectedPlayer) => {

        let data = selectedPlayer.split('/');
        let current = this.invitedPlayers.find(x => x.name === data[0]);

        if (current == undefined) {

            throw new Error(`${data[0]} is not invited to the selection list!`);
        }

        if (Number(data[1]) < current.playerValue) {

            throw new Error(`The manager's offer is not enough to sign a contract with ${data[0]}, ${current.playerValue - Number(data[1])} million more are needed to sign the contract!`);
        }

        current.playerValue = 'Bought';

        return `Congratulations! You sign a contract with ${current.name} for ${data[1]} million dollars.`;
    }

    ageLimit = (name, age) => {

        let current = this.invitedPlayers.find(x => x.name === name);

        if (current == undefined) {

            throw new Error(`${name} is not invited to the selection list!`);
        }

        if (current.age < age) {

            let ageDifference = age - current.age;

            return ageDifference < 5 ? `${current.name} will sign a contract for ${ageDifference} years with ${this.clubName} in ${this.country}!` : `${current.name} will sign a full 5 years contract for ${this.clubName} in ${this.country}!`;
        }

        if (current.age >= age) {

            return `${current.name} is above age limit!`;
        }
    }

    transferWindowResult = () => {

        let result = 'Players list:\n';

        for (let player of this.invitedPlayers.sort((a, b) => a.name.localeCompare(b.name))) {

            result += `Player ${player.name}-${player.playerValue}\n`;
        }

        return result.trimEnd();
    }
}