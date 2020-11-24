module.exports = {
    css: {
        loaderOptions: {
            sass: {
                prependData: `@import "@/utils/_vars.scss";`,
            },
        },
    },
};
