/// <binding ProjectOpened='watch' />

/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

// <binding Clean='clean' />
//"use strict";

var gulp = require("gulp"),
    sass = require("gulp-sass"),
    less = require("gulp-less"),
    util = require("gulp-util"),
    ts = require("gulp-typescript");

var paths = {
    webroot: "./"
};

paths.js = paths.webroot + "Scripts/js/*.js";
paths.minJs = paths.webroot + "Scripts/js/*.min.js";
paths.css = paths.webroot + "Content/*.css";
paths.minCss = paths.webroot + "Content/*.min.css";
paths.concatJsDest = paths.webroot + "Scripts/js/site.min.js";
paths.concatCssDest = paths.webroot + "Content/site.min.css";
paths.concatJsMapDest = paths.webroot + "Scripts/js/site.min.js.map";
paths.sass = paths.webroot + "Content/*.scss";
paths.less = paths.webroot + "Content/*.less";
paths.typescript = paths.webroot + "Scripts/js/*.ts";

gulp.task('stylesless', function () {
    gulp.src(paths.less)
        .pipe(less().on('error', util.log))
        .pipe(gulp.dest('./Content/'));
});

gulp.task('stylessass', function () {
    gulp.src(paths.sass)
        .pipe(sass().on('error', util.log))
        .pipe(gulp.dest('./Content/'));
});

gulp.task('typescript', function () {
    return gulp.src(paths.typescript)
		.pipe(ts({
		    noImplicitAny: true,
		    out: 'site.js'
		}))
		.pipe(gulp.dest(paths.js));
});

//Watch task
gulp.task('watch', function () {
    gulp.watch(paths.less, ['stylesless']);
    gulp.watch(paths.sass, ['stylessass']);
    //gulp.watch(paths.typescript, ['typescript']);
});
