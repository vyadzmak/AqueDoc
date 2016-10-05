(function(angular) {
    'use strict';
    angular.module('FileManagerApp').provider('fileManagerConfig', function () {

        var values = {
            appName: 'angular-filemanager v1.5',
            defaultLang: 'ru',

            listUrl: '/AqueDocApi/Home/FilemanagerAction',
            //listUrl: 'bridges/php/handler.php',
            uploadUrl: '/AqueDocApi/Home/FilemanagerAction',
            renameUrl: '/AqueDocApi/Home/FilemanagerAction',
            copyUrl: '/AqueDocApi/Home/FilemanagerAction',
            moveUrl: '/AqueDocApi/Home/FilemanagerAction',
            removeUrl: '/AqueDocApi/Home/FilemanagerAction',
            editUrl: '/AqueDocApi/Home/FilemanagerAction',
            //getContentUrl: 'bridges/php/handler.php',
            getContentUrl: '/AqueDocApi/Home/FilemanagerAction',
            createFolderUrl: '/AqueDocApi/Home/FilemanagerAction',
            downloadFileUrl: '/AqueDocApi/api/DocContent/',
            downloadMultipleUrl: '/AqueDocApi/AqueDocApi/Home/FilemanagerAction',
            compressUrl: '/AqueDocApi/Home/FilemanagerAction',
            extractUrl: '/AqueDocApi/Home/FilemanagerAction',
            permissionsUrl: '/AqueDocApi/Home/FilemanagerAction',

            searchForm: true,
            sidebar: true,
            breadcrumb: false,
            allowedActions: {
                upload: true,
                rename: true,
                move: true,
                copy: true,
                edit: true,
                changePermissions: true,
                compress: false,
                compressChooseName: true,
                extract: true,
                download: true,
                downloadMultiple: true,
                preview: true,
                remove: true,
                createFolder: true,
                pickFiles: false,
                pickFolders: false
            },

            multipleDownloadFileName: 'angular-filemanager.zip',
            showExtensionIcons: true,
            showSizeForDirectories: false,
            useBinarySizePrefixes: false,
            downloadFilesByAjax: true,
            previewImagesInModal: true,
            enablePermissionsRecursive: true,
            compressAsync: false,
            extractAsync: false,
            pickCallback: null,

            isEditableFilePattern: /\.(txt|diff?|patch|svg|asc|cnf|cfg|conf|html?|.html|cfm|cgi|aspx?|ini|pl|py|md|css|cs|js|jsp|log|htaccess|htpasswd|gitignore|gitattributes|env|json|atom|eml|rss|markdown|sql|xml|xslt?|sh|rb|as|bat|cmd|cob|for|ftn|frm|frx|inc|lisp|scm|coffee|php[3-6]?|java|c|cbl|go|h|scala|vb|tmpl|lock|go|yml|yaml|tsv|lst)$/i,
            isImageFilePattern: /\.(jpe?g|gif|bmp|png|svg|tiff?)$/i,
            isExtractableFilePattern: /\.(gz|tar|rar|g?zip)$/i,
            tplPath: 'src/templates'
        };

        return {
            $get: function() {
                return values;
            },
            set: function (constants) {
                angular.extend(values, constants);
            }
        };

    });
})(angular);
