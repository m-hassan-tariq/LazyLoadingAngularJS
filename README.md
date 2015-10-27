# LazyLoadingAngularJS
Lazy Registration of modules of AngularJS for large scale application

When building large sites or apps with many routes/views in AngularJS, it would be good to not have to load all artefacts
such as controllers, directives etc., on the first load. Ideally, on first load, only the artefacts that are needed for 
the route in question, will be loaded. This may be either in one download or multiple depending on the app, however, it 
will only be what is needed to render the particular route. Then as the user navigates the app by changing the route, 
other artefacts that have not already been loaded, will then be loaded as and when there are needed. Not only should this
potential speed up the initial page load, but it should also result in bandwidth not being wasted.

![pastedimage 12](https://cloud.githubusercontent.com/assets/10474169/10761535/d54e9788-7c8f-11e5-99d1-a88f86e6dd65.png)

#### After clicking on Users menu item at top of webpage

![pastedimage 22](https://cloud.githubusercontent.com/assets/10474169/10761543/df695050-7c8f-11e5-8b58-15c4316c53e2.png)

#### Code Demonstration (AppConfig.js) :


![pastedimage 2](https://cloud.githubusercontent.com/assets/10474169/10761615/2e516cde-7c90-11e5-9869-126b67b1f862.png)


    angular
        .module('onBoardingApp')
        .config(configure)
        .run(runBlock);

    runBlock.$inject = ['$state'];
    configure.$inject = ['$stateProvider'];

    function runBlock($state) {
        $state.go('adminHome');
    };

    function configure($stateProvider) {
        $stateProvider
            .state('adminHome', {
                url: '/',
                controller: 'HomeController',
                controllerAs: 'vm',
                templateUrl: '/Scripts/app/modules/home/views/onBoardingApp.home.html',
                resolve: {
                    getSecondaryCandidateService: getSecondaryCandidateService
                }
            })
            .state('allCandidates', {
                url: '/candidates',
                controller: 'CandidateController',
                controllerAs: 'vm',
                templateUrl: '/Scripts/app/modules/candidate/views/onBoardingApp.candidate.html',
                resolve: {
                    allCandidates: function ($ocLazyLoad) {
                        return $ocLazyLoad.load([{
                            name: 'onBoardingApp.candidate',
                            files: ['/Scripts/app/modules/candidate/onBoardingApp.candidate.js'],
                            // {cache: false, timeout: 5000}
                            cache: false
                        }, {
                            name: 'onBoardingApp.candidate.controllers',
                            files: ['/Scripts/app/modules/candidate/js/onBoardingApp.candidate.controller.js'],
                            cache: false
                        },
                        {
                            name: 'onBoardingApp.candidate.services',
                            files: ['/Scripts/app/modules/candidate/js/onBoardingApp.candidate.services.js'],
                            cache: false
                        }]);
                    }
                }
            });

        function getSecondaryCandidateService(homeService) {
            return homeService.getAllSecondaryCandidates();
        }
    };

