window.BlorcFile = {
    SaveAs: function (fileName, bytesBase64) {
        var link = document.createElement('a');
        link.download = fileName;
        link.href = "data:application/octet-stream;base64," + bytesBase64;
        document.body.appendChild(link); // Needed for Firefox
        link.click();
        document.body.removeChild(link);
    }
};