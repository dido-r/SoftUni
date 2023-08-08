import { useEffect, useState } from "react";
import { Todo } from "./Todo";
import { Loader } from "./Loader";

export function TodoList({todo}) {

    const [todos, setTodos] = useState([]);
    const [triggerred, setTriggered] = useState(0);

    useEffect(() => {
        fetch('http://localhost:3030/jsonstore/todos')
        .then(x => x.json())
        .then(x => setTodos(Object.values(x)))
    }, [todo, triggerred]);

    const toggleStatus = (id) => {

        let current = todos.find(x => x._id === id);

        fetch(`http://localhost:3030/jsonstore/todos/${current._id}`, {
            method: "PUT",
            headers: {"Content-Type": "application/json"},
            body: JSON.stringify({isCompleted: !current.isCompleted})
        });

        setTriggered(Math.random());
    };

    return (
        <table className="table">
            <thead>
                <tr>
                    <th className="table-header-task">Task</th>
                    <th className="table-header-status">Status</th>
                    <th className="table-header-action">Action</th>
                </tr>
            </thead>
            <tbody>
                <Todo todos={todos} toggleStatus={toggleStatus}/>
            </tbody>
        </table>
    );
}