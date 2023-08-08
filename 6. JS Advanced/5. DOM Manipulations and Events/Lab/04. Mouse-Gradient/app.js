function attachGradientEvents() {
    
    let gradient = document.getElementById('gradient');
    gradient.addEventListener('mousemove', solve);
    gradient.addEventListener('mouseout', out);

    function solve(event){

        let current = event.offsetX;
        let width = event.target.clientWidth;
        document.getElementById('result').textContent = `${Math.floor(Number(current) / Number(width) * 100)}%`;
    }

    function out(){

        document.getElementById('result').textContent = '';
    }
}