aqueDocApp.config(function($stateProvider, $urlRouterProvider, $locationProvider) {

    $urlRouterProvider.otherwise("/login");

   //main page (abstract view)
    $stateProvider
        .state("main", {
            url: "",
            abstract: true,
            template: "<div ui-view></div>",
            data: { pageTitle: "Aquedoc" },
            onEnter: function($window) { $window.document.title = "AqueDoc"; }

        })

        //login page
        .state("main.login", {
            url: "/login",
            templateUrl: "Scripts/app/Views/Login.html",
            data: { pageTitle: "Авторизация" },
            onEnter: function($window) { $window.document.title = "Авторизация"; }


        });

    //dashboard container
    $stateProvider
        .state("main.dashboard", {
            url: "/dashboard",
            templateUrl: "Scripts/app/Views/Dashboard.html",
            onEnter: function($window) { $window.document.title = "Рабочая область"; }
        });

    //inbox partial
    $stateProvider
        .state("main.dashboard.inbox", {
            url: "/inbox",
            templateUrl: "Scripts/app/Views/Inbox.html",
            onEnter: function($window) { $window.document.title = "Входящие"; }
        });


    $stateProvider
      .state("main.dashboard.inbox.details", {
          views: {
              "modal": {
                  templateUrl: "Scripts/app/Views/InboxDetails.html"
              }
          }
      });

    $stateProvider
      .state("main.dashboard.tasks", {
          url: "/tasks",
          templateUrl: "Scripts/app/Views/Tasks.html",
          onEnter: function ($window) { $window.document.title = "Задачи"; }
      });

    $stateProvider
      .state("main.dashboard.tasks.details", {
          url: "/:taskId",
          templateUrl: "Scripts/app/Views/TaskDetail.html",
          onEnter: function ($window) { $window.document.title = "Задачи"; }
      });
    //$locationProvider.html5Mode(true);
});