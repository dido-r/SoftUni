function solution(arguments) {
    let result = [];

    switch (arguments) {

        case 'upvote': this.upvotes++; break;
        case 'downvote': this.downvotes++; break;
        case 'score':

            let reportUpvotes = this.upvotes;
            let reportDownvotes = this.downvotes;

            if (this.upvotes + this.downvotes > 50) {

                let addedValue = this.upvotes >= this.downvotes ? Math.ceil(this.upvotes * 0.25) : Math.ceil(this.downvotes * 0.25);
                reportUpvotes += addedValue;
                reportDownvotes += addedValue;
            }

            result.push(reportUpvotes);
            result.push(reportDownvotes);
            result.push(reportUpvotes - reportDownvotes);
            let rating = '';

            if (this.upvotes + this.downvotes < 10) {

                rating = 'new';

            } else if (this.upvotes / (this.upvotes + this.downvotes) > 0.66) {

                rating = 'hot';

            } else if (this.upvotes - this.downvotes >= 0 && this.upvotes + this.downvotes > 100) {

                rating = 'controversial';

            } else if (this.upvotes - this.downvotes < 0) {

                rating = 'unpopular';
            }else{

                rating = 'new';
            }

            result.push(rating);
            return result;
    }
}