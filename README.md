# Moody

## **Overview**

Moody is a web application created for people who would like to track daily their mood, make notes about the things that has happened during day and keep statistics of their mental health and how their mood and overall feeling changes during a period of time. 

## **Architecture**

The architecture of this ASP.NET Core web application follows a modular and layered approach, promoting scalability, maintainability, and flexibility. This document provides an overview of the key components and their responsibilities.

![m5](https://github.com/polinizal/Moody/assets/71072498/3d94e813-9502-4cb4-89d7-8e2777360f7a)

### **Components**

1. **Web Project (Moody)**
    - Entry point for the web application - It’s the Startup Project.
    - Handles HTTP requests, routing, and generating dynamic content.
    - Contains controllers, views, Razor pages, and static files.
2. **Mood.Data**
    - Manages the data access layer.
    - Includes entities, migrations, and the **`ApplicationDbContext`**.
    - Responsible for interacting with the database using Entity Framework Core.
3. **Mood.Services**
    - Implements the business logic layer.
    - Defines DTOs for data transfer between layers.
    - Provides service classes encapsulating specific business logic operations.
    - Offers abstractions/interfaces for services to promote loose coupling and facilitate testing.

  ![m6](https://github.com/polinizal/Moody/assets/71072498/66ca9e04-862f-4931-8da9-26b7f9ddeb6f)

### **Key Characteristics**

- **Separation of Concerns:** Each component has a distinct responsibility, separating concerns like data access, business logic, and presentation.
- **Modularity:** The use of class libraries promotes modularity and code reuse.
- **Dependency Injection:** ASP.NET Core's built-in dependency injection container is used to inject dependencies into components, promoting decoupling and testability.
- **Layered Architecture:** The application is organized into layers (presentation, business logic, data access) to promote maintainability and scalability.

### **Advantages**

- **Scalability:** Components can be scaled independently to handle increased load.
- **Maintainability:** Clear separation of concerns makes it easier to locate and update specific parts of the application.
- **Testability:** Components can be easily unit tested in isolation, enhancing reliability.
- **Flexibility:** Changes to one layer can be made without impacting other layers, promoting agility in development.

### **Conclusion**

The architecture outlined above provides a solid foundation for building and maintaining modern web applications with ASP.NET Core. It promotes best practices in software development, enabling us to deliver robust, scalable, and maintainable solutions.

## **Functionality**

**This web app includes the following features:**

- Create an Individual account with an email and password
- Create a Daily
- Adds Daily to a list of Dailies
- Edit a Daily
- Delete a Daily
- Seeding 10 Static Moods into the database - Happy, Excited, Cheerful, Optimistic, Relaxed, Sad, Angry, Tired, Stressed, Anxious
- Makes a chart based on your moods and displays it in the Index of Dailies.
- Helps you track your moods.

## How to Run the Project

### Follow these steps:

1. Clone the project to your local computer
2. Open the project folder using Visual Studio 2022
3. Build the project
4. Set-up the database with your own Connection String
5. Run the project by pressing F5 or clicking on the green "Run" button in Visual Studio

***Congratulations!! You can install Moody by cloning the project to your local computer*** 👏🏻
## **Usage**

**Create an account:**
![s1](https://github.com/polinizal/Moody/assets/71072498/5296cdfd-c436-4b94-9746-9e2d14e55e37)

**This is your Main page or the Home page:**
![s3](https://github.com/polinizal/Moody/assets/71072498/d340b257-75be-4d71-ac0e-a7f1dfd92aef)


**Daily Journal:**
![s5](https://github.com/polinizal/Moody/assets/71072498/94bd6385-571c-4cab-bd68-f515825bbac8)

This is the Daily Index Page ⇒ your Daily List 

The **“Track Your Mood”** Button Creates a new Daily and adds to the Daily List

With ***Edit***  you can **edit** the daily

With ***Details*** you can **see the details** of the daily

With ***Delete*** you can **delete** the daily

**When you click Details of the page you can see all the details about the Daily.**
![d1](https://github.com/polinizal/Moody/assets/71072498/74a6e1e5-1102-4492-900e-088b42c9520c)

**When you click Edit you can edit the Daily.**
![d2](https://github.com/polinizal/Moody/assets/71072498/c28653c0-a7c1-4e3d-a6cd-f79eacb237df)

**When you click Delete you can delete the Daily.**
![d3](https://github.com/polinizal/Moody/assets/71072498/d22bffb5-9083-4a90-933f-11198e16278d)

**Chart showing your moods by the time passing**
![d4](https://github.com/polinizal/Moody/assets/71072498/c752c0f6-47a3-43ad-8c9d-a9e29230c324)

## **Contact Information:**

**Polina Staneva** ⇒ email: polina.staneva@yahoo.com

**Github** ⇒  [polinizal](https://github.com/polinizal)

