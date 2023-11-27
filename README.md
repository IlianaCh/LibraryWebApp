 # ![🦆 icon _book_book-logo](https://github.com/IlianaCh/LibraryWebApp/assets/102560336/651e4f8f-547e-49ad-8a18-9f4dac4720c0) LibraryEDU
## Project Description
App Link: [Library Web App](https://librarywebappcosc3380.azurewebsites.net)

The library lends books, audio, and movies. These items can be loaned to students, faculty, and library staff. These items all have similar attributes but also have distinguishable attributes.The database will store students and faculty’s userID, email, first and last name and total fees due. It will also store information about the different items (such as Title, Author, Publisher, Equipment description, etc.). The database will keep track of the checkout record for every user for limit tracking purposes, amount of times items have been borrowed, and whether the user has reached the limit of amount owed. All relationships will run through this checkout record as it is an efficient way to store who purchased what and the fees they've accumulated or paid off.

## File Description
For our project, we used Azure SQL Server for our database, ASP.NET MVC for our Web Application Framework and Azure App Service to deploy our application.

![image](https://github.com/IlianaCh/LibraryWebApp/assets/102560336/26d73900-68fa-4e10-ad11-b09fd6b04354)



Database in Azure SQL:

- Our database backup file can be accessed via `sql dump file/libappdev-2023-11-25-14-57.bacpac`
  
ASP.NET MVC:
* Our application has an MVC architectural pattern which means seperates the app into three main components, Model, View, and Controller:
  - **Model**: It is responsible for managing the application's state and interacting with the database. It can be accessed via `Models`.
  - **View**: Represents the user interface (UI) and is responsible for displaying data to the user. It receives input from the user and forwards it to the controller for processing. Can be accessed via `Views`.
    * The shared layouts such as the navbar and login format are located in `./Views/Shared`
    * The Browse Catalog cshtml and CRUD functionalities are located within  `./Views/objects`
    * The Checkouts cshtml,  CRUD, and Return functionalities can be accessed via `./Views/Checkout`
    * The Fees cshtml and CRUD functionalitites are located in `./Views/fees`
    * The cshtml files for the Reports are can be accessed at `./Views/Reports`
  - **Controller**: Acts as an intermediary between the Model and the View. It receives user input from the View, processes it using the Model, and updates the View with the results. The Controller is responsible for handling user requests, managing the flow of data, and updating the Model and View accordingly. Can be accessed via `Controllers`.

* All of our css and images are located in `Contents`

## Project Documentation

### Data Modification
Data Entry Form:
The admin and staff have the ability to modify the database, they can edit the Browse Catalog, Checkout, and Fees Pages. On the Browse Catalog page, the users can change objects, object_type, object_title, object_author, object_medium, object_genre, and object_length. On the fee pages user_id, transaction_id, create_date, total_fee, remaining_fee, is_paid. On the Checkout Record, they can modify the username, the checkout date and the item being checked out.

#### Create
When the user submits the form, the controller receives the data. A new instance of the SqlCommand class is created with an SQL INSERT query, and the user-provided data is used to populate the query.

#### Modify
The Edit action retrieves the existing object from the database, modifies its properties, and then uses db.Entry(objects).State = EntityState.Modified to mark it as modified. The changes are then saved to the Azure SQL Database using db.SaveChanges().

#### Delete
When a user initiates a delete action, the controller receives a request to delete a particular record.



### User Roles

Student, Faculty, Staff, and Admin

[Login Information](login_credentials.txt)

- Student Functionalities: student can login and browse through the library catalog to see the items available for books, movies, and audios
- Faculty Functionalities: fuculty can login and browse through the library catalog to see the items available for books, movies, and audios. They also have a different amount of days of which an item is due.
- Library Staff Functionalities: Staff is able to login, Checkout & Return items for student and faculty, view fees and create new ones. They are also able to generate reports.
- Admin Functionalities: Admin is able to login, Checkout & Return items for student and faculty, they are also able to create and view fees. They are also able to generate reports.

### Triggers

- Calculate Due Date by Role: 
Trigger will add the allotted days to the checkout day by the following roles Library Staff - 180 Days, Faculty - 28 Days, Student - 14 Days. Logic is applied to the Checkout Records table. Use DateAdd() function to add days from role plus create date only AFTER an INSERT action.

- Find If Returned Late:
Trigger will flag when an item is returned late. Logic is applied to the Checkout Records table. Using DateDiff() function to calculate if the result of Return Date and Due Date is greater than zero. If so, then it will update the is_late field equal to 1 indicating the item is late. Trigger happens after INSERT or UPDATE to the Return Date. 

- Calculate Fee:
Trigger is monitoring when item is late then calculate fee by using the difference in Due Date and Return Date. This builds off of the last late flag trigger. When is_late has UPDATE action, calculate the difference in dates then multiply the difference in days by the "Fee per Day" which we established as $0.25.

### Reports

<ins>* Reports are accessed via admin login</ins>

- View Total Books Purchased: A cumulative view of data pulled from the checkout records table, and the books table. This will display all necessary information on the checkout of the book and the data of the book itself. Along with that you can view the exact total of the books purchased at the bottom within the date range that you set manually.

- View Total Fees Accumulated: A cumulative view of data pulled from the checkout records, fees, and users tables respectively. This will display all necessary information on the fees, the date it was created and the user it is attached to. Along with that you can view the summation of the fees that have been accumulated within the date range you set manually.

- View Total Movies Purchased: A cumulative view of data pulled from the checkout records table, and the movies table. This will display all necessary information on the checkout of the movies and the data of the book itself. Along with that you can view the exact total of the movies purchased at the bottom within the date range that you set manually.

## Running the App
1. **Install .NET SDK:**
   * Ensure that you have the .NET SDK installed on your machine.
2. **Install Visual Studio 2022**
3. **Clone the repository using either Visual Studio 2022**
4. **In Visual Studio 2022, click "File -> Open -> Project Solution"**
5. **Navigate to the cloned project folder and open file "LibraryWebApp.sln"**
6. **Start Project**

## Authors
- Iliana Chevez - [ilianaCh](https://github.com/IlianaCh)
- Sergio Rivera - [TheSergeon](https://github.com/TheSergeon)
- Ivy Doan - [Huynh07](https://github.com/Huynh07)
- Zachary Pierce - [Zacharypierce25](https://github.com/Zacharypierce25)
- Kamui Morita-Albright - [kamui-moritaalbright](https://github.com/kamui-moritaalbright)
- Jennifer Figueroa - [JenniferFigueroa628](https://github.com/JenniferFigueroa628)
