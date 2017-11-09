
String.Format = function () {
    // The string containing the format items (e.g. "{0}")
    // will and always has to be the first argument.
    var theString = arguments[0];

    // start with the second argument (i = 1)
    for (var i = 1; i < arguments.length; i++) {
        // "gm" = RegEx options for Global search (more than one instance)
        // and for Multiline search
        var regEx = new RegExp("\\{" + (i - 1) + "\\}", "gm");
        theString = theString.replace(regEx, arguments[i]);
    }
    return theString;
}

var _function_is_not_defined = '\'{0}\' is not defined.';

var dHydraApp = new function () {

    /* Проверява дали е Windows функция */
    this.IsWindowsFunction = function () {
        if (window.external) {
            var winObj = window.external
            for (i = 0; i < arguments.length-1; i++) {
                if (arguments[i] in winObj) {
                    winObj = winObj[arguments[i]];
                }
                else {
                    return false;
                }
            }
            if (arguments[arguments.length - 1] in winObj) {
                return true;
            }
            else {
                return false;
            }
        }
        else {
            return false;
        }
    }

    /* Отваря ново приложение */
    this.OpenApplication = function (gId, name, appUrl, author) {

        if (dHydraApp.IsWindowsFunction('OpenApplication')) {
            window.external.OpenApplication(gId, name, appUrl, author);
        }
        else {
            throw new ReferenceError(String.Format(_function_is_not_defined, 'OpenApplication'));
        }
    }
}