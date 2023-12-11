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

# Structure of The Project:
The project consists of two projects:

1. The main project with the logic of the tasks system.
2. Tests project consists of five tests.

# The Main Project Structure:
The main logic consists of the following components:

**Entities**
1. _CustomerTask_:
   A class that defines the structure of the Task object. It consists of the following class members:
   I. + Title: String (Property with basic checks).

   II. - _title: String (Storing the actual title of the task if deemed valid by Title).

   III. + Description: String (Holds the description of the task).

   IV. + DueDate: DateTime (Property with basic checks).

   V. - _dueDate: DateTime (Storing the actual due date of the task if deemed valid by DueDate).

   VI. + TaskStatus: Status (Holds the status of the task).

   VII. + Id: Guid (Holds the unique Id of the task - Set up at the constructor).

   VIII. + CustomerTask() (Instantiate a task object with a unique Id).

2. _Status_:
   An enum that stores the available statuses of tasks.

**Controllers**
1. _TasksController_ extends ControllerBase:
   This class acts as the controller. It uses a Constructor Injection to get its dependencies (Which is the abstract form of TaskService (ITaskService)), so it is easier to mock the system in the Unit Tests suite, and to follow the Dependency Inversion principle. Below are the class members:
   I. - _taskService: ITaskService (The dependency of the controller is the Task Service which is instentiated as a Singleton to keep the interaction with a specific instance of the service and keep the data persistant).

   II. + TasksController(taskService: ITaskService) (Dependency Constructor).

   III. + GetTasks(): IActionResult (Explained at the APIs section).

   IV. + GetTask(id: Guid): IActionResult (Explained at the APIs section).

   V. + CreateTask(task: CustomerTask): IActionResult (Explained at the APIs section).

   VI. + UpdateTask(id: Guid, updatedTask: CustomerTask): IActionResult (Explained at the APIs section).

   VII. + DeleteTask(id: Guid): IActionResult (Explained at the APIs section).

**Services**
   1. _>>ITaskService<<_
      This interface outlines the contract of TaskServices.
      I. + GetAllTasks(): List<CustomerTask> (Supports GetTasks()).

      II. + GetTaskById(Id: Guid): CustomerTask (Supports GetTask(id)).

      III. + CreateTask(task: CustomerTask): void (Supports CreateTask(task)).

      IV. + UpdateTask(id: Guid, updatedTask: CustomerTask): void (Supports UpdateTask(id, updatedTask)).

      V. + DeleteTask(id: Guid): void (Supports DeleteTask(id)).


      
   
   



