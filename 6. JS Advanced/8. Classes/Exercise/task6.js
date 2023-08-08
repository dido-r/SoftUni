class Company {

    constructor() {

        this.departments = [];
    }

    addEmployee(name, salary, position, department) {

        if(salary < 0 || this.nullOrWhitespace(name) || this.nullOrWhitespace(salary) || this.nullOrWhitespace(position) || this.nullOrWhitespace(department)){

            throw Error('Invalid input!');
        }

        let employee = {

            name,
            salary,
            position,
            department
        }

        let currentDept = this.departments.find(x => x.deptName === employee.department);

        if(currentDept === undefined){

            this.departments.push(
                {
                    deptName: employee.department,
                    employees: []
                }
            );

            currentDept = this.departments.find(x => x.deptName === employee.department);
            currentDept.employees.push(employee);
        }else{

            currentDept.employees.push(employee)
        }

        return `New employee is hired. Name: ${employee.name}. Position: ${employee.position}`
    }

    bestDepartment(){

        let averageSalary = 0;
        let bestDept;
        let result = '';

        for(let dept of this.departments){

            let currentAvgSalary = dept.employees.reduce((result, current) => result + current.salary, 0);
            currentAvgSalary /= dept.employees.length;
            
            if(currentAvgSalary > averageSalary){

                averageSalary = currentAvgSalary;
                bestDept = dept;
            }
        }

        result += `Best Department is: ${bestDept.deptName}\nAverage salary: ${averageSalary.toFixed(2)}\n`;

        bestDept.employees.sort((a, b) => {

            let compare = b.salary - a.salary;

            if(compare > 0) return 1;
            if(compare < 0) return -1;
            if(compare === 0) return a.name.localeCompare(b.name);
        })

        for(let emp of bestDept.employees){

            result += `${emp.name} ${emp.salary} ${emp.position}\n`;
        }

        return result.trim();
    }   

    nullOrWhitespace(string) {
        
        if(string === undefined || string === null || string === ''){

            return true;
        }

        return false;
    }
}