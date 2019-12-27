window.BlorcInjector = {
    injectHead: function (value) {
        var head = document.getElementsByTagName('head')[0];

        var div = document.createElement('div');
        div.innerHTML = value;

        while (div.children.length > 0) {
            head.appendChild(div.children[0]);
        }
    },

    injectScript: function (source, type) {
        return new Promise((resolve, reject) => {

            var head = document.getElementsByTagName('head')[0];
            var script = document.createElement('script');
            script.onload = function () {
                resolve();
            };

            script.src = source;
            script.type = type;
            head.appendChild(script);
        });
    }
};