// TODO: Move to another place and fix the name.
window.DocumentFunctions = {
    getBoundingClientRect: function(x, y) {
        var elementFromPoint = document.elementFromPoint(x, y);
        if (elementFromPoint === undefined || elementFromPoint == null) {
            return null;
        }

        return elementFromPoint.getBoundingClientRect();
    },
    getBoundingClientRectById: function (id) {
        var elementFromPoint = document.getElementById(id);
        if (elementFromPoint === undefined || elementFromPoint == null) {
            return null;
        }

        return elementFromPoint.getBoundingClientRect();
    },
    getOffsetBoundingClientRect: function(x, y) {
        var elementFromPoint = document.elementFromPoint(x, y);
        if (elementFromPoint === undefined || elementFromPoint == null) {
            return null;
        }

        var boundingClientRect = elementFromPoint.getBoundingClientRect();
        boundingClientRect.x += window.pageXOffset;
        boundingClientRect.y += window.pageYOffset;
        return boundingClientRect;
    }
}
