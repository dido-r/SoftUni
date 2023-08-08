function attachEventsListeners() {
    
    document.getElementById('convert').addEventListener('click', convert);

    function convert(){

        let distance = Number(document.getElementById('inputDistance').value);
        let unitIndex = document.getElementById('inputUnits').selectedIndex;
        
        if(unitIndex === 0) distance *= 1000;
        else if (unitIndex === 2) distance /= 100;
        else if (unitIndex === 3) distance /= 1000;
        else if (unitIndex === 4) distance *= 1609.34;
        else if (unitIndex === 5) distance *= 0.9144;
        else if (unitIndex === 6) distance *= 0.3048;
        else if (unitIndex === 7) distance *= 0.0254;

        let result = 0;
        let resultUnit = document.getElementById('outputUnits').selectedIndex;

        if(resultUnit === 0) result = distance / 1000;
        else if (resultUnit === 1) result = distance;
        else if (resultUnit === 2) result = distance * 100;
        else if (resultUnit === 3) result = distance * 1000;
        else if (resultUnit === 4) result = distance / 1609.34;
        else if (resultUnit === 5) result = distance / 0.9144;
        else if (resultUnit === 6) result = distance / 0.3048;
        else if (resultUnit === 7) result = distance / 0.0254;

        document.getElementById('outputDistance').value = result;
    }
}