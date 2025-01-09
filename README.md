# SuperBox - Delivery Service Web App

SuperBox is a web application designed for a delivery service that facilitates order placement, tracking, and management. It provides users with an intuitive platform to make delivery orders, track deliveries, and access an admin dashboard to oversee delivery activities.

## Features

- **User Authentication**: Secure login system for registered users.
- **Order Placement**: Users can place orders, selecting the sender and receiver details, including SuperBox locations.
- **Order Tracking**: Allows users to track their deliveries.
- **Order Canceling**: Allows users to cancel their deliveries with InLocker status.
- **Admin Dashboard**: Admins can view all orders, inspect SuperBOXes, manage deliveries, ensure the smooth functioning of the service and promote other users to admin role.
- **Package Receiving**: Users can also check for deliveries coming their way and see all orders placed.
- **Forms**: Two distinct forms for placing and receiving delivery orders.

## Technologies Used

- **ASP.NET Core MVC**: Used for building the web application and implementing the Model-View-Controller pattern.
- **SQLite**: Database for persisting user, order, and delivery information.
- **.NET GenericHost**: Used for running backgound services.
- **ILogger**: Used for logging debug information and displaying errors in the console.
- **Object-Oriented Programming (OOP) Principles**: Applied to ensure modular, maintainable, and scalable code.

## Installation

After you clone the repository, navigate into project directory:

```console
cd WebApplication1
```
Install the required .NET dependencies:
```console
dotnet restore
```
Update the database:
```console
dotnet ef database update
```
Run the application:
```console
dotnet run
```
## How to use
- **Login**: Start by logging into the application. New users can register if they don’t have an account.
- **Place a Delivery Order**: Navigate to the “Place Order” section, fill out the required details including the sender’s and receiver’s SuperBox locations,receiver's username and submit the form.
- **Track Deliveries**: After placing an order, users can track the status of their delivery through the “Track Delivery” page.
- **Admin Panel**: Admins can log in and access the dashboard to view all orders, track their statuses, and manage SuperBox availability.
- **View Orders**: Admins can see all placed orders and check the delivery status.
- **Promote user to admin**: An admin can promote any user account based on ther username / email to admin status.
  
# Contributing
Feel free to contribute to this project by opening issues or submitting pull requests. Contributions for improving features, code refactoring, or bug fixes are welcome.
