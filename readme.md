# JimmaNeo
JimmaNeo is a project between LMU and HM to design an e-learning platform that enables the best possible exchange between the pediatricians in Munich and the clinical staff in Jimma.
The focus is on motivating the users by allowing them to have their own avatar and customize it. As the learning progresses, the avatar can be further customized.

## Table of Contents
  - [Press-Release](#press-release)
  - [Application Description](#application-description)
    - [Landing Page, Courses and Lessons](#landing-page-courses-and-lessons)
    - [Quizzes](#quizzes)
    - [Avatar](#avatar)
    - [Responsive Layout](#responsive-layout)
  - [Software Architecture](#software-architecture)
    - [Backend](#backend)
    - [Frontend](#frontend)
  - [Team and Contact Person](#team-and-contact-person)
    - [Mode of operation](#mode-of-operation)
  - [Appendix](#appendix)



## Press-Release
### Helping medical professionals in Ethiopia treat newborn babies

##### E-Learning platform enables neonatologists at the LMU Klinikum in Munich to help medical professionals in Ethiopia treating newborn babies and ultimately save lives

MUNICH – 25.06.2021

A new E-Learning platform developed by students at the Hochschule München University of Applied Sciences was announced today by the LMU Klinikum Munich which is initially going to help neonatologists in Munich with teaching medical professionals at the Jimma University Specialized Hospital in Ethiopia how to treat newborn babies and ultimately save their lives as part of the “JimmaNeo” project. Later on, it will enable the medical professionals In Jimma to create their own teaching materials and upload it to the platform. Currently, Ethiopia has zero trained neonatologists and an infant mortality rate of almost 6%, compared to just 0.3% in Germany.

A doctor at the LMU Klinikum who is involved in the project describes it like this: “Since the Covid pandemic keeps us from visiting our Ethiopian friends in person for our trainings in neonatology, this platform helps us to give our friends access to first-class teaching possibilities nonetheless. I especially like how the platform motivates them with those 'quiz battles’ and those funny little unlockable profile pictures.” 

Apart from sharing the aforementioned educational videos, the platform also allows teachers to share additional educational documents as PDF files and to share appointments for live Zoom-Workshops. The users on the other hand will also be able to utilize the platform to take interactive online quizzes to verify their learning progress, which can then be compared to other learners in a “quiz battle”. To further boost their learning motivation, the platform utilizes various gamification elements like unlockable levels and unlockables for avatars.

“I love studying with the platform”, one of the doctors in Jimma said after having tried the latest beta version, “apart from the fact that we’re learning how to save lives which is obviously fantastic it’s also fun and easy to work with. I like how cool my avatar looks after equipping it with the items I got for completing the courses.”

The platform is completely web-based, meaning that it is not required to install any applications to use it, instead it works on every device that has an internet browser, which is important due to the very limited IT infrastructure at the hospital in Jimma. Users can download videos, documents and appointments so that they are able to view them offline. Ultimately, the aim of the project is to be able to conduct a well-prepared local training workshop in Ethiopia sometime in 2022, when international travel restrictions will hopefully have been lifted again.
Further information about the JimmaNeo project can be found at https://gitlab.lrz.de/seii_sose_2021/project_b.

## Application Description
Our JimmaNeo application is designed to provide an enjoyable way of learning with the aspect of gamification at its center to motivate and encourage students to hang on and continue their learning efforts while also trying to focus on methods to provide an optimized learning effect with instant feedback and correction. 

To provide an idea of how our platform is looking to achieve these goals, the user interaction will be explained and backed up with corresponding screenshots along its logical procedural order.

### Landing Page, Courses and Lessons
The learning experience starts out at the **landing page** where an overview of all accessible courses as well as a general progress display regarding completed courses are shown to the student. A finished course will be displayed with a green background. If a student decides to work on a specific course, he can do so by clicking the associated button. 

By doing so, the student enters the **course page**. A course consists of one or multiple lessons which, as can be seen on the course page progress bar, all have to be completed before a course is marked as successfully finished. By using the navigation options in the header, the student is always able to go back one step or reach his profile with a single click.

When clicking the button of a specific lesson, the student enters the **lesson page** where an overview  of all the materials and components of a lesson is provided. A lesson usually consists of **documents, videos and quizzes**. The teachers have free choice over which, how many and if any of the specific components are part of a lesson. 

The materials in the documents section are usually PDFs or links to literature that require the student to actively familiarize themselves with the topic. By clicking on a document button, it will appear in a new browser tab. Videos from teachers or external tutors provide a passive learning method. Each video is capsuled in a collapsible element which can be opened and closed to keep a clean overview. The video itself can be directly played in the lesson page. Quizzes give students the opportunity to test their acquired knowledge. Each quiz can be accessed over its own button which will be highlighted in green when completed. 

<br/>

*Pictures from left to right:*
<br/>
*Row 1: Landing Page, Course Page*
<br/>
*Row 2: Lesson Page, Video in Lesson*

<kbd><img src="/documentation/images/screenshots/01_LandingPage.png" alt="landing" width="270"/></kbd>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
<kbd><img src="/documentation/images/screenshots/02_CoursePage.png" alt="course" width="270"/></kbd>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 

<br/>

<kbd><img src="/documentation/images/screenshots/03_LessonPage.png" alt="lesson" width="270"/></kbd>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
<kbd><img src="/documentation/images/screenshots/04_VideoInLesson.png" alt="video" width="270"/></kbd>

<br/>

### Quizzes

Quizzes represent an essential part of the learning experience. They are the foundation of the progress control of our platform. A lesson is marked as completed when all of its quizzes have been done successfully.

<br/>

**Quiz Procedure**

A Quiz begins on its starting page where the number of upcoming questions and a status if the student has already completed the quiz are shown. The starting of the quiz is initiated by clicking the "Start Quiz" button.

While in the quiz, the progress bar on top shows which question the student is on. Each question has its own answer set. The "Check" button at the bottom of the question evaluates the chosen answer and can only be clicked when the student hast selected an answer, indicating it is ready when glowing green. The selected answer will be highlighted in blue.

When the student decides to check his answer, the quiz will give instant feedback on whether the question was answered correctly or not to provide an optimal learning and memory effect. In case of a correct answer the corresponding answer button as well as the Check Button  will be highlighted in green.  If the answer was wrong, its button and the Check button will be highlighted in red with the correct answer blinking in green to show the student what would have been correct. By Clicking on the Continue button the next answer will be shown or when already on the last question the quiz will be finished.

When the student answers any answer correctly for the first time he will gain 10 Experience Points (EXP). If enough EXP have been earned, the student will level up. With increasing level the student can unlock new accessibles for his character (more on that in the next section). This is the main functionality and motivation of our gamification aspect.


<br/>

*Pictures from left to right:*
<br/>
*Row 1: Quiz Starting Page, Quiz Question*
<br/>
*Row 2: Selected Answer, Correct Answer with earned EXP*
<br/>
*Row 3: Wrong Answer with correction, Level Up*

<kbd><img src="/documentation/images/screenshots/05_QuizStartingPage.png" alt="quizStart" width="270"/></kbd>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
<kbd><img src="/documentation/images/screenshots/06_QuestionInQuiz.png" alt="question" width="270"/></kbd>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;

<br/>

<kbd><img src="/documentation/images/screenshots/07_SelectedAnswerInQuiz.png" alt="selected" width="270"/></kbd>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
<kbd><img src="/documentation/images/screenshots/08_CorrectAnswerInQuiz.png" alt="correct" width="270"/></kbd>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;

<br/>

<kbd><img src="/documentation/images/screenshots/09_WrongAnswerInQuiz.png" alt="course" width="270"/></kbd>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
<kbd><img src="/documentation/images/screenshots/10_LevelUp.png" alt="levelUp" width="270"/></kbd>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;

<br/> <br/>

**Quiz Correction**

When the quiz has been finished, the student will be provided an overview of his performance. A message at the top tells whether the quiz was successfully completed or not. Below that a collapsible for each question will apper indicating if it was answered correctly. If clicked the collapsible will open and show the question title and correct answer as well as the students wrong answer if answered incorrectly. This overlooking correction method enables the student to reflect on his answers and make out potential difficulties and successes in his learning progress. He can return to the lesson with the given button at the bottom.

<br/>

*Pictures from left to right:*
<br/>
*Row 1: Correction Page, Correction Answers*
<br/>
*Row 2: Correction Completed Quiz*

<kbd><img src="/documentation/images/screenshots/11_CorrectionPage1.png" alt="correction1" width="270"/></kbd>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
<kbd><img src="/documentation/images/screenshots/12_CorrectionPage2.png" alt="correction2" width="270"/></kbd>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;

<br/>

<kbd><img src="/documentation/images/screenshots/13_CorrectionPage3.png" alt="correction3" width="270"/></kbd>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;

<br/> <br/>

**Progress Update**

After successfully finishing the (only) quiz in the shown lesson, its button is highlighted in green and the lesson is now completed which can be seen at the progress bar in the lesson and the green highlighting of the lesson in the corresponding course page.

<br/>

*Pictures from left to right:*
<br/>
*Row 1: Completed Quiz in Lesson, Progress Bar of completed Lesson*
<br/>
*Row 2: Completed Lesson on Course Page*

<kbd><img src="/documentation/images/screenshots/14_CompletedQuiz.png" alt="completedQuiz" width="270"/></kbd>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
<kbd><img src="/documentation/images/screenshots/15_ProgressInLesson.png" alt="lessonProgress" width="270"/></kbd>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;

<br/>

<kbd><img src="/documentation/images/screenshots/16_CompletedLesson.png" alt="completedLesson" width="270"/></kbd>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;

<br/> <br/>


### Avatar

The avatar represents the students unique character. The Profile page shows details about the students profile such as username, description, collected EXP and current level. The avatar with its equipped and accessible accessories is shown below. As previously stated, the student can level up his avatar by correctly answering questions and earning EXP. By doing so, new accessories can be unlocked to equip which motivates the student to keep learning. By clicking on any accessory button, the specific item will be equipped or unequipped. With the level up in the shown quiz, the character can now eqip his new item (face mask). 


<br/>

*Pictures from left to right: Profile Page, Avatar with new equipped item*

<kbd><img src="/documentation/images/screenshots/17_AvatarPage.png" alt="avatar1" width="270"/></kbd>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
<kbd><img src="/documentation/images/screenshots/18_AvatarWithNewAccessory.png" alt="avatar2" width="270"/></kbd>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;

<br/> <br/>


### Responsive Layout

Due to the fact that the majority of students in Jimma will be using the platform via a mobile device, our application has been designed to fit perfectly to mobile screen sizes (as seen in the previous screenshots). With the goal to provide an accessible and user friendly solution, the app has been designed to be hardware independent though and can responsively adapt to desktop browsers as well.


<br/>

*Picture: JimmaNeo application on desktop browser*

<kbd><img src="/documentation/images/screenshots/19_BrowserView.png" alt="browser" width="750"/></kbd>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;

<br/> <br/>


## Software Architecture
JimmaNeo is implemented as an ASP.NET Core web application and follows the REST design principles. Therefore, the persistence and logic is separated from the frontend and implemented in the backend, known as client-server-model. The communication between frontend and backend uses HTTP requests and resources are delivered in JavaScript Object Notation (JSON).

![Server Client Model](/documentation/images/client_server.png)

### Backend
The backend is designed with three abstraction layers: the data access, the services and the controllers. These three layers are not accessing each other directly, please see below.

**Data Access**

Data is stored as domain objects via Microsoft [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/). This allows to store .NET objects into relational databases and [supports many database engines](https://docs.microsoft.com/en-us/ef/core/providers/?tabs=dotnet-core-cli).

**Services**

The services are providing all backend features and logic and get passed the database context. They are registered in the built-in Inversion of Control (IoC)-Container and on account of this, all classes, which need the functions of these service, can get the service injected. This helps creating a loosley coupled system, while creating the dependencies at a central component, the `Startup.cs`. A further advantage is the segration of interfaces, that no client has to depend on methods it does not use. Simplified representation of dependency injection:

![Simplified representation of dependency injection](/documentation/images/dependency_injection.png)

All self-implemented services are `AddScoped`, which means an instance of the service is created once per scope. A scope is created on every request to the application.
Registered self-implemented services:
* CourseService
* LessonService
* QuizService
* StudentService
* AvatarService
* AvatarItemService
* CorrectQuestionService
* FinishedQuizService

**Controllers**

The controllers are responsible to handle the incoming HTTP request from the client and so providing the API of the Backend.
Implemented backend server API:
* Avatar
    * **GET /api/Avatars/{id}**
    Get the avatar with the given UserId of a student as AvatarDto.
    * **PUT /api/Avatars/{id}**
    Update a avatar of the specific student - Response is the updated AvatarDto.
* AvatarItem
    * **GET /api/AvatarItems**
    Get all avatar items as AvatarItemDto[].
* CorrectQuestion
    * **GET /api/CorrectQuestions/{id}**
    Get all correctly answered questions of a specific student as CorrectQuestionDto[].
    * **PUT /api/CorrectQuestions/{id}**
    Add a correctly answered question to a specific student. The student gains experience, if a correctly answered question is added. Response is the added CorrectQuestionDto.
* Course
    * **GET /api/Courses/**
    Get all courses as CourseDto[].
    * **GET /api/Courses/{id}**
    Get course  with the given id as CourseDto.
* Lesson
    * **GET /api/Lessons/**
    Get all lessons as LessonDto[].
    * **GET /api/Lessons/{id}**
    Get lesson with the given id as LessonDto.
* Quiz
    * **GET /api/Quizzes/**
    Get all quizzes as QuizDto[].
    * **GET /api/Quizzes/{id}**
    Get quiz with the given id as QuizDto.
    * **GET /api/lesson/{lessonId}/quizzes**
    Get all quizzes of the lesson with given id as QuizDto[].
* Student
    * **GET /api/Students/**
    Get all students as StudentDto[].
    * **GET /api/Students/{id}**
    Get the student with the given id as StudentDto[].
    * **PUT /api/Students/{userId}/finishQuiz/{courseId}/{lessonId}/{quizId}**
    Add a finished quiz to an student. If now the lesson is finished, then this lesson is also added to the student. And again, if now the course is finished, then this course is also added to the student.


### Frontend
The frontend consists of Razor components containing Blazorise items with no abstraction layer between the pages and the called backend services. Style items are pulled out to common style file.

**Shared**

Contains the data transfer objects, which are shared resources between front- and backend.

![Data Transfer Object Model](/documentation/images/data_transfer_object_model.png)


## Team and Contact Person

### Contact Person: Ronja Meier (rmeier@hm.edu)

**Lars Kriese:** Backend

**Tim Hoehenleitner:** Backend

**Robert Wiechmann:** Frontend

**Simon Imhof:** Frontend

**Ronja Meier:** Frontend

**Maximilian Schmitz:** Frontend

![Group photo](/documentation/images/group_photo_team_b.jpeg)

### Mode of operation

We worked as an agile team and orientated ourselves towards scrum with short sprints of roughly a week.
Once a week we hold a review/planning meeting to talk about what problems occured and to discuss how we
would like to proceed and what is next to be implemented. That way of working together was the reason
why we managed to get a lot done during a short period of time and it kept the motivation of the team
always on a high level.

## Appendix

* [**Press Release**](../pdfs/press_release.pdf)
* [**Storyboard**](../pdfs/storyboard.pdf)
* [**FAQs Costumer**](../pdfs/faq_customers.pdf)
* [**FAQs Stakeholder**](../pdfs/faq_stakeholders.pdf)
* [**Group photo**](/documentation/images/group_photo_team_b.jpeg)
* [**Avatar**](/documentation/images/avatar.png)
* [**Avatar with Items**](/documentation/images/avatar_with_items.png)
* [**Wireframe Landing-Page**](/documentation/images/wireframe_landing_page.png)
* [**Wireframe Lesson**](/documentation/images/wireframe_lesson.png)
* [**Wireframe Quiz**](/documentation/images/wireframe_quiz_1.png)
* [**Wireframe Quiz after correct answer**](/documentation/images/wireframe_quiz_2.png)
* [**Wireframe Profile**](/documentation/images/wireframe_profile.jpeg)

