# ToDo-List-Rest-API
GreenRoad Assignment

<img width="1440" alt="Screenshot 2023-12-11 at 17 26 01" src="https://github.com/CUCUMBERanOrSNCompany/ToDo-List-Rest-API/assets/70776104/c6629216-f434-4da5-a707-8d7a19d96941">

In this assignment I implemented a Tasks list that enables the customers creating tasks they need to do, modify them, change their status 
(Pending, In-Progress, Completed), deleting them and reading all of them or a specific task (CRUD operations). 
Additionally, the system reviews all tasks every 24 hours (1440 minutes),
and updates the status of each task that is in a Pending State and its deadline passed to a forth state- Overdue.

The customer can interact with the system via Swagger. Below are the system's APIs: 

# Get (GetTasks()):
Arguments: None

Returns: All tasks

<img width="1136" alt="Screenshot 2023-12-11 at 17 36 06" src="https://github.com/CUCUMBERanOrSNCompany/ToDo-List-Rest-API/assets/70776104/afef8629-73dc-44ea-a82f-e0e8e786d56e">

This API returns all the tasks.

# Get (GetTask(Id)):
Arguments: Task Id

Returns: The task with the corresponding Id.

<img width="1155" alt="Screenshot 2023-12-11 at 17 50 55" src="https://github.com/CUCUMBERanOrSNCompany/ToDo-List-Rest-API/assets/70776104/2ca59639-1e0b-4876-9b60-0363ae7c6fa3">

This API returns a single Task with the corresponding Id (If exists). It returns an empty response if the Id is invalid.

# Post (CreateTask(Task)):
Arguments: Task details

Returns: Result of request.

<img width="1135" alt="Screenshot 2023-12-11 at 17 58 42" src="https://github.com/CUCUMBERanOrSNCompany/ToDo-List-Rest-API/assets/70776104/96fabdf8-05bc-461c-91f3-3ecc0e5d659e">

This API gets task details (Title, Description, Due Date and State) and create a task which is added to the tasks.

# Put (UpdateTask(Id, Task)):
Arguments: Id, Task Details

Returns: Result of request.

<img width="1139" alt="Screenshot 2023-12-11 at 18 04 41" src="https://github.com/CUCUMBERanOrSNCompany/ToDo-List-Rest-API/assets/70776104/3978728b-a034-4f3d-932e-250ddb18206b">

This API gets a task Id and task details, and update the task with the corresponding task Id with the provided details.

# Delete (DeleteTask(Id)):
Arguments: Id

Returns: Result of request.

<img width="1147" alt="Screenshot 2023-12-11 at 18 11 35" src="https://github.com/CUCUMBERanOrSNCompany/ToDo-List-Rest-API/assets/70776104/e5771374-a82b-4532-bb5e-9cdab000d8db">

This API gets a task Id, and delete the task with the corresponding Id, if valid.



