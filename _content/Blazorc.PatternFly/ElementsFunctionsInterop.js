// TODO: Move to another place and fix the name.
window.ElementsFunctions = {
    getBoundingClientRect: function(x, y) {
        var elementFromPoint = document.elementFromPoint(x, y);
        if (elementFromPoint === undefined || elementFromPoint == null) {
            return null;
        }

        return elementFromPoint.getBoundingClientRect();;
    }
}
