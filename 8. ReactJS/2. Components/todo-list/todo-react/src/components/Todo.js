export function Todo({ 
    todos,
    toggleStatus
 }) {
    return (

        todos.map(x => (
        <tr key={x._id} className={x.isCompleted ? 'todo is-completed' : 'todo'}>
            <td>{x.text}</td>
            <td>{x.isCompleted ? 'Completed' : 'Not Completed'}</td>
            <td className="todo-action">
                <button onClick={() => toggleStatus(x._id)} className="btn todo-btn">Change status</button>
            </td>
        </tr>
        ))
    );
}