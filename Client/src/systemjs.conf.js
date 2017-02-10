/*
 * This config is only used during development and build phase only
 * It will not be available on production
 *
 */

(function(global) {
    // ENV
    global.ENV = global.ENV || 'development';

    // map tells the System loader where to look for things
    var map = {
        'app': 'src/tmp/app',
        'test': 'src/tmp/test'
    };

    // packages tells the System loader how to load when no filename and/or no extension
    var packages = {
        'app': {
            defaultExtension: 'js'
        },
        'test': {
            defaultExtension: 'js'
        },
        'rxjs': {
            defaultExtension: 'js'
        },
        'angular2-jwt': {
            main: 'angular2-jwt.js',
            defaultExtension: 'js'
        },
        'angular2-letter-avatar': {
            defaultExtension: 'js'
        },
        'chart.js': {
            main: 'dist/Chart.js',
            defaultExtension: 'js'
        },
        'ng2-charts': {
            main: 'ng2-charts.js',
            defaultExtension: 'js'
        }
    };

    // List npm packages here
    var npmPackages = [
        '@angular',
        'rxjs',
        'lodash',
        'angular2-jwt',
        'angular2-letter-avatar',
        'chart.js',
        'ng2-charts'
    ];

    // Add package entries for packages that expose barrels using index.js
    var packageNames = [
        // App barrels
        'app/shared',
        // 3rd party barrels
        'lodash'
    ];

    // Add package entries for angular packages
    var ngPackageNames = [
        'common',
        'compiler',
        'core',
        'forms',
        'http',
        'platform-browser',
        'platform-browser-dynamic',
        'router'
    ];

    npmPackages.forEach(function (pkgName) {
        map[pkgName] = 'node_modules/' + pkgName;
    });

    packageNames.forEach(function(pkgName) {
        packages[pkgName] = { main: 'index.js', defaultExtension: 'js' };
    });

    ngPackageNames.forEach(function(pkgName) {
        map['@angular/' + pkgName] = 'node_modules/@angular/' + pkgName +
            '/bundles/' + pkgName + '.umd.js';
        map['@angular/' + pkgName+'/testing'] = 'node_modules/@angular/' + pkgName +
        '/bundles/' + pkgName + '-testing.umd.js';
    });

    var config = {
        map: map,
        packages: packages
    };

    // filterSystemConfig - index.html's chance to modify config before we register it.
    if (global.filterSystemConfig) { global.filterSystemConfig(config); }

    System.config(config);

})(this);
