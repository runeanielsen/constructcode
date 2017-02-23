"use strict";

var destinationFolder = 'wwwroot/';

var gulp = require("gulp"),
    concat = require("gulp-concat"),
    sass = require('gulp-sass'),
    cssmin = require("gulp-clean-css"),
    htmlmin = require("gulp-htmlmin"),
    uglify = require("gulp-uglify"),
    merge = require("merge-stream"),
    del = require("del"),
    babel = require('gulp-babel'),
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

gulp.task("min", ["min:js", "min:css", "min:html", "move:files"]);

gulp.task("watch", function () {
    getBundles(regex.css).forEach(function (bundle) {
        gulp.watch(bundle.inputFiles, ["min:css"]);
    });

    getBundles(regex.js).forEach(function (bundle) {
        gulp.watch(bundle.inputFiles, ["min:js"]);
    });

    gulp.watch("App/js/**/*.html", ["min:html"]);

    filesToMove.filter(function (fileToMove) {
        gulp.watch(fileToMove.source, ["move:files"]);
    });
});

gulp.task("clean", function (cb) {
    return rimraf('./wwwroot', cb);
});

gulp.task("min:js", function () {
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

gulp.task("min:css", function () {
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

gulp.task("min:html", function () {
    gulp.src("App/js/**/*.html")
        .pipe(flatten())
        .pipe(gulp.dest(destinationFolder + "templates/"));
});

gulp.task("move:files", function () {
    filesToMove.filter(function (fileToMove) {
        gulp.src(fileToMove.source)
            .pipe(gulp.dest(fileToMove.destination));
    });
});

function getBundles(regexPattern) {
    return bundleconfig.filter(function (bundle) {
        return regexPattern.test(bundle.outputFileName);
    });
}