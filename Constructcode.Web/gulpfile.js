﻿"use strict";

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
    rimraf = require('rimraf'),
    bundleconfig = require("./bundleconfig.json");

var regex = {
    scss: /\.scss$/,
    css: /\.css$/,
    html: /\.(html|htm)$/,
    js: /\.js$/
};

var filesToMove = [{
        source: "App/resources/**/*",
        destination: "wwwroot/"
    },
    {
        source: "node_modules/font-awesome/fonts/**/*",
        destination: "wwwroot/fonts/"
    },
    {
        source: "node_modules/tinymce/themes/modern/theme.min.js",
        destination: "wwwroot/themes/modern/"
    },
    {
        source: "node_modules/tinymce/skins/lightgray/skin.min.css",
        destination: "wwwroot/skins/lightgray/"
    },
    {
        source: "node_modules/tinymce/skins/lightgray/content.min.css",
        destination: "wwwroot/skins/lightgray/"
    },
    {
        source: "node_modules/tinymce/plugins/codesample/css/prism.css",
        destination: "wwwroot/plugins/codesample/css/"
    },
    {
        source: "node_modules/tinymce/skins/lightgray/fonts/**/*",
        destination: "wwwroot/skins/lightgray/fonts/"
    }
]

gulp.task("clean", function (cb) {
    return rimraf('./wwwroot', cb);
});

gulp.task("min", ["min:js", "min:css", "min:html", "move:files"]);

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
        return gulp.src(bundle.inputFiles, {
                base: "."
            })
            .pipe(plumber())
            .pipe(concat(bundle.outputFileName))
    });

    var scssTask = getBundles(regex.css).map(function (bundle) {
        return gulp.src(bundle.inputFiles, {
                base: "."
            })
            .pipe(plumber())
            .pipe(sass())
            .pipe(concat(bundle.outputFileName))
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
    var tasks = getBundles(regex.html).map(function (bundle) {
        return gulp.src(bundle.inputFiles, {
                base: "."
            })
            .pipe(plumber())
            .pipe(concat(bundle.outputFileName))
            .pipe(htmlmin({
                collapseWhitespace: true,
                minifyCSS: true,
                minifyJS: true
            }))
            .pipe(gulp.dest(destinationFolder));
    });

    return merge(tasks);
});

gulp.task("move:files", function () {
    filesToMove.filter(function (fileToMove) {
        gulp.src(fileToMove.source)
            .pipe(gulp.dest(fileToMove.destination));
    });
});

gulp.task("watch", function () {
    getBundles(regex.css).forEach(function (bundle) {
        gulp.watch(bundle.inputFiles, ["min:css"]);
    });

    getBundles(regex.js).forEach(function (bundle) {
        gulp.watch(bundle.inputFiles, ["min:js"]);
    });
});

function getBundles(regexPattern) {
    return bundleconfig.filter(function (bundle) {
        return regexPattern.test(bundle.outputFileName);
    });
}