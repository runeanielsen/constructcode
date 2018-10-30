var destinationFolder = 'wwwroot/';
var htmlFilePath = 'App/js/**/*.html';
var htmlFileDestination = 'templates/';

var gulp = require('gulp'),
    concat = require('gulp-concat'),
    sass = require('gulp-sass'),
    cssmin = require('gulp-clean-css'),
    htmlmin = require('gulp-htmlmin'),
    uglify = require('gulp-uglify'),
    merge = require('merge-stream'),
    del = require('del'),
    babel = require("gulp-babel"),
    plumber = require('gulp-plumber'),
    autoprefixer = require('gulp-autoprefixer'),
    flatten = require('gulp-flatten'),
    rimraf = require('rimraf');

var bundleconfig = require('./Gulp/bundle-files.json'),
    filesToMove = require('./Gulp/move-files.json');

var regex = {
    scss: /\.scss$/,
    css: /\.css$/,
    html: /\.html$/,
    js: /\.js$/
};


// Tasks
gulp.task('deploy', ['deploy:js', 'deploy:css', 'deploy:html', 'move:files']);
gulp.task('serve', ['serve:js', 'serve:css', 'serve:html', 'move:files']);


// Watches
gulp.task('watch', function () {
    getBundles(regex.css).forEach(function (bundle) {
        gulp.watch(bundle.inputFiles, ['serve:css']);
    });

    getBundles(regex.js).forEach(function (bundle) {
        gulp.watch(bundle.inputFiles, ['serve:js']);
    });

    gulp.watch(htmlFilePath, ['serve:html']);

    filesToMove.filter(function (fileToMove) {
        gulp.watch(fileToMove.source, ["serve:files"]);
    });
});


// Common
gulp.task('clean', function (cb) {
    return rimraf(destinationFolder + '**/*', cb);
});

gulp.task('move:files', function () {
    filesToMove.filter(function (fileToMove) {
        gulp.src(fileToMove.source)
            .pipe(gulp.dest(fileToMove.destination));
    });
});


// Production tasks
gulp.task('deploy:js', function () {
    var tasks = getBundles(regex.js).map(function (bundle) {
        return gulp.src(bundle.inputFiles, {
            base: "."
        })
            .pipe(plumber())
            .pipe(babel({
                presets: ['es2015'],
                compact: true,
                ignore: [
                    'node_modules/**/*.js'
                ]
            }))
            .pipe(concat(bundle.outputFileName))
            .pipe(uglify())
            .pipe(gulp.dest('.'));
    });

    return merge(tasks);
});

gulp.task('deploy:css', function () {
    var cssTask = getBundles(regex.css).map(function (bundle) {
        return gulp.src(bundle.inputFiles,
            {
                base: "."
            })
            .pipe(plumber())
            .pipe(concat(bundle.outputFileName));
    });

    var scssTask = getBundles(regex.css).map(function (bundle) {
        return gulp.src(bundle.inputFiles,
            {
                base: "."
            })
            .pipe(plumber())
            .pipe(sass())
            .pipe(concat(bundle.outputFileName));
    });

    var merged = merge(cssTask, scssTask)
        .pipe(plumber())
        .pipe(autoprefixer({
            browsers: ['last 2 versions'],
            cascade: false
        }))
        .pipe(cssmin(), {
            showLog: true
        })
        .pipe(gulp.dest("."));

    return merged;
});

gulp.task('deploy:html', function () {
    gulp.src(htmlFilePath)
        .pipe(flatten())
        .pipe(gulp.dest(destinationFolder + htmlFileDestination));
});


// Development tasks
gulp.task('serve:js', function () {
    var tasks = getBundles(regex.js).map(function (bundle) {
        return gulp.src(bundle.inputFiles, {
            base: "."
        })
            .pipe(plumber())
            .pipe(concat(bundle.outputFileName))
            .pipe(gulp.dest('.'));
    });

    return merge(tasks);
});

gulp.task('serve:css', function () {
    var cssTask = getBundles(regex.css).map(function (bundle) {
        return gulp.src(bundle.inputFiles,
            {
                base: "."
            })
            .pipe(plumber())
            .pipe(concat(bundle.outputFileName));
    });

    var scssTask = getBundles(regex.css).map(function (bundle) {
        return gulp.src(bundle.inputFiles,
            {
                base: "."
            })
            .pipe(plumber())
            .pipe(sass())
            .pipe(concat(bundle.outputFileName));
    });

    var merged = merge(cssTask, scssTask)
        .pipe(plumber())
        .pipe(gulp.dest("."));

    return merged;
});

gulp.task('serve:html', function () {
    gulp.src(htmlFilePath)
        .pipe(flatten())
        .pipe(gulp.dest(destinationFolder + htmlFileDestination));
});


// Helpers
function getBundles(regexPattern) {
    return bundleconfig.filter(function (bundle) {
        return regexPattern.test(bundle.outputFileName);
    });
}