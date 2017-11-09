
var console = new function () {
    this.log = function (message) {
        window.external.Console.Log(message);
    }
    this.info = function (message) {
        window.external.Console.Info(message);
    }
    this.warn = function (message) {
        window.external.Console.Warn(message);
    }
    this.debug = function (message) {
        window.external.Console.Debug(message);
    }
    this.error = function (message) {
        window.external.Console.Error(message);
    }
}
/*
Object.addEventListener = function (event, functionValue, useCapture) {
    console.log(event + functionValue + useCapture);
}
*/