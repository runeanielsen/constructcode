const destinationFolder = 'wwwroot/';
const htmlFilePath = 'App/js/**/*.html';
const htmlFileDestination = 'templates/';

const gulp = require('gulp'),
    concat = require('gulp-concat'),
    sass = require('gulp-sass'),
    cssmin = require('gulp-clean-css'),
    uglify = require('gulp-uglify'),
    merge = require('merge-stream'),
    babel = require("gulp-babel"),
    plumber = require('gulp-plumber'),
    autoprefixer = require('gulp-autoprefixer'),
    flatten = require('gulp-flatten'),
    rimraf = require('rimraf');

const bundleconfig = require('./Gulp/bundle-files.json'),
    filesToMove = require('./Gulp/move-files.json');

const regex = {
    scss: /\.scss$/,
    css: /\.css$/,
    html: /\.html$/,
    js: /\.js$/
};


const watch = () => {
    getBundles(regex.css).forEach(function (bundle) {
        gulp.watch(bundle.inputFiles, gulp.series(serveCss));
    });

    getBundles(regex.js).forEach(function (bundle) {
        gulp.watch(bundle.inputFiles, gulp.series(serveJs));
    });

    gulp.watch(htmlFilePath, gulp.series(serveHtml));

    filesToMove.filter(function (fileToMove) {
        gulp.watch(fileToMove.source, gulp.series(moveFiles));
    });
}

// Common
const clean = (cb) => {
    return rimraf(destinationFolder + '**/*', cb);
}

const moveFiles = async () => {
    filesToMove.filter(function (fileToMove) {
        gulp.src(fileToMove.source)
            .pipe(gulp.dest(fileToMove.destination));
    });
}

// Production tasks
const deployJs = () => {
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
}

const deployCss = () => {
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
}

const deployHtml = () => {
    return gulp.src(htmlFilePath)
        .pipe(flatten())
        .pipe(gulp.dest(destinationFolder + htmlFileDestination));
}

// Development tasks
const serveJs = () => {
    var tasks = getBundles(regex.js).map(function (bundle) {
        return gulp.src(bundle.inputFiles, {
            base: "."
        })
            .pipe(plumber())
            .pipe(concat(bundle.outputFileName))
            .pipe(gulp.dest('.'));
    });

    return merge(tasks);
}

const serveCss = () => {
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
}

const serveHtml = () => {
    return gulp.src(htmlFilePath)
        .pipe(flatten())
        .pipe(gulp.dest(destinationFolder + htmlFileDestination));
    
} 

// Helpers
function getBundles(regexPattern) {
    return bundleconfig.filter(function (bundle) {
        return regexPattern.test(bundle.outputFileName);
    });
}

// Exports
exports.deploy = gulp.series(deployJs, deployCss, deployHtml, moveFiles);
exports.serve = gulp.series(serveJs, serveCss, serveHtml, moveFiles);
exports.watch = watch;
exports.clean = clean;