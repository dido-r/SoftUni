import './App.css';
import { Header } from './components/Header';
import { Footer } from './components/Footer';
import { TodoList } from './components/TodoList';
import { useState } from "react";

function App() {

    const [todo, setAdd] = useState({});

    const handleClick = () => {

        let addTodo = {
            text: "New Todo 2",
            isCompleted: false
        }

        setAdd(addTodo);

        fetch('http://localhost:3030/jsonstore/todos', {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(addTodo)
        });
    };

    return (
        <div>
            <Header />

            <main className="main">

                <section className="todo-list-container">
                    <h1>Todo List</h1>

                    <div className="add-btn-container">
                        <button onClick={() => handleClick()} className="btn">+ Add new Todo</button>
                    </div>

                    <div className="table-wrapper">

                        <TodoList todo={todo}/>
                    </div>
                </section>
            </main>
            <Footer />
        </div>
    );
}

export default App;