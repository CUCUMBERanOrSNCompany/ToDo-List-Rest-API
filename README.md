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
