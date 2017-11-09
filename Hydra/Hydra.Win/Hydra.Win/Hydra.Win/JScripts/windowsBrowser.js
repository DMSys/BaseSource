var console = {
    error : function (message) {
        window.external.Console.Error(message);
    },
    log: function (message) {
        window.external.Console.Log(message);
    },
    info: function (message) {
        window.external.Console.Info(message);
    },
    warn: function (message) {
        window.external.Console.Warn(message);
    },
    debug: function (message) {
        window.external.Console.Debug(message);
    }
};