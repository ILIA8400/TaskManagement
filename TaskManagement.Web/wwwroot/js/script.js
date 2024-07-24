document.addEventListener('DOMContentLoaded', () => {
    const taskForm = document.getElementById('taskForm');
    const taskTableBody = document.getElementById('taskTableBody');

    taskForm.addEventListener('submit', (event) => {
        event.preventDefault();

        const title = document.getElementById('taskTitle').value;
        const description = document.getElementById('taskDescription').value;
        const startDate = document.getElementById('startDate').value;
        const endDate = document.getElementById('endDate').value;

        if (title && description && startDate && endDate) {
            addTaskToTable(title, description, startDate, endDate);
            taskForm.reset();
        }
    });

    function addTaskToTable(title, description, startDate, endDate) {
        const row = document.createElement('tr');
        row.innerHTML = `
            <td>${title}</td>
            <td>${description}</td>
            <td>${startDate}</td>
            <td>${endDate}</td>
            <td>Pending</td>
            <td>
                <button class="edit-btn">Edit</button>
                <button class="delete-btn">Delete</button>
            </td>
        `;

        taskTableBody.appendChild(row);

        row.querySelector('.delete-btn').addEventListener('click', () => {
            taskTableBody.removeChild(row);
        });

        row.querySelector('.edit-btn').addEventListener('click', () => {
            const newTitle = prompt("Edit Task Title:", title);
            const newDescription = prompt("Edit Task Description:", description);
            const newStartDate = prompt("Edit Start Date:", startDate);
            const newEndDate = prompt("Edit End Date:", endDate);
            if (newTitle && newDescription && newStartDate && newEndDate) {
                row.cells[0].textContent = newTitle;
                row.cells[1].textContent = newDescription;
                row.cells[2].textContent = newStartDate;
                row.cells[3].textContent = newEndDate;
            }
        });
    }
});
