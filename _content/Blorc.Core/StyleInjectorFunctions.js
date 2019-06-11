window.StyleInjectorFunctions = {
    injectHead: function (value) {

        var head = document.getElementsByTagName('head')[0];

        var div = document.createElement('div');
        div.innerHTML = value;

        while (div.children.length > 0) {
            head.appendChild(div.children[0]);
        }
    }
};