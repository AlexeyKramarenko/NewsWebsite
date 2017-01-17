

(function () {

    angular.module('admin.app')
           .config(config);

    function config($stateProvider, $urlRouterProvider, $locationProvider) {
     
        $stateProvider.state('admin', {
            url: "/",
            templateUrl: '/app/admin.app/admin.nav.html',
            css: ['/app/admin.app/admin.nav.css']
        });

        //#region  NAVIGATION pages
        $stateProvider.state('articles_nav', {
            url: "articles",
            parent:'admin',
            templateUrl: '/app/admin.app/articles/article.nav.html',
            css: ['/app/admin.app/articles/article.nav.css','/app/admin.app/admin.nav.css']
        });
        $stateProvider.state('main_nav', {
            url: "main",
            parent: 'admin',
            templateUrl: '/app/admin.app/main/main.nav.html',
            css: ['/app/admin.app/main/main.nav.css', '/app/admin.app/admin.nav.css']
        });
        $stateProvider.state('news_nav', {
            url: "news",
            parent: 'admin',
            templateUrl: '/app/admin.app/news/news.nav.html',
            css: ['/app/admin.app/news/news.nav.css', '/app/admin.app/admin.nav.css']
        });
        //#endregion


        //#region article
        $stateProvider.state('create_article', {
            url: "/create_article",
            parent: 'articles_nav',
            templateUrl: '/app/admin.app/articles/create.article/create.article.html',
            controller: 'CreateArticleController',
            controllerAs: 'vm',
            css: ['/app/admin.app/articles/create.article/create.article.css', '/app/admin.app/admin.nav.css']
        }); 
        $stateProvider.state('create_gallery', {
            url: "/create_gallery",
            parent: 'articles_nav',
            templateUrl: '/app/admin.app/articles/create.gallery/create.gallery.html',
            controller: 'CreateGalleryController',
            controllerAs: 'vm',
            css: ['/app/admin.app/articles/create.gallery/create.gallery.css', '/app/admin.app/admin.nav.css']
        }); 
        $stateProvider.state('edit_articles', {
            url: "/edit_articles",
            parent: 'articles_nav',
            templateUrl: '/app/admin.app/articles/edit.articles/edit.articles.html',
            controller: 'EditArticlesController',
            controllerAs: 'vm',
            css: ['/app/admin.app/articles/edit.articles/edit.articles.css', '/app/admin.app/admin.nav.css']
        });  
        $stateProvider.state('edit_galleries', {
            url: "/edit_galleries",
            parent: 'articles_nav',
            templateUrl: '/app/admin.app/articles/edit.galleries/edit.galleries.html',
            controller: 'EditGalleriesController',
            controllerAs: 'vm',
            css: ['/app/admin.app/articles/edit.galleries/edit.galleries.css', '/app/admin.app/admin.nav.css']
        });
        //#endregion

        
        //#region contacts
        $stateProvider.state('contacts', {
            url: "contacts",
            parent:'admin',
            templateUrl: '/app/admin.app/contacts/contacts.html',
            controller: 'ContactsController',
            controllerAs: 'vm',
            css: ['/app/admin.app/contacts/contacts.css', '/app/admin.app/admin.nav.css']
        });
        //#endregion 


        //#region main
        $stateProvider.state('add_image', {
            url: "/add_image",
            parent: 'main_nav',
            templateUrl: '/app/admin.app/main/add.image/add.image.html',
            controller: 'AddImageController',
            controllerAs: 'vm',
            css: ['/app/admin.app/main/add.image/add.image.css', '/app/admin.app/admin.nav.css']
        });  
        $stateProvider.state('delete_images', {
            url: "/delete_images",
            parent: 'main_nav',
            templateUrl: '/app/admin.app/main/delete.images/delete.images.html',
            controller: 'DeleteImagesController',
            controllerAs: 'vm',
            css: ['/app/admin.app/main/delete.images/delete.images.css', '/app/admin.app/admin.nav.css']
        });
        //#endregion 


        //#region news
        $stateProvider.state('create_news', {
            url: "/create_news",
            parent: 'news_nav',
            templateUrl: '/app/admin.app/news/create.news/create.news.html',
            controller: 'CreateNewsController',
            controllerAs: 'vm',
            css: ['/app/admin.app/news/create.news/create.news.css', '/app/admin.app/admin.nav.css']
        }); 
        $stateProvider.state('edit_news', {
            url: "/edit_news",
            parent: 'news_nav',
            templateUrl: '/app/admin.app/news/edit.news/edit.news.html',
            controller: 'EditNewsController',
            controllerAs: 'vm',
            css: ['/app/admin.app/news/edit.news/edit.news.css', '/app/admin.app/admin.nav.css']
        });
        //#endregion

        $urlRouterProvider.otherwise('/');

        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });

    }
})()