
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

var dHydra = new function () {

    this.System;

    this.Data;

    this.TypeIsDefined = function (value) {
        return (typeof value === 'undefined')
    }
    this.TypeIsFunction = function (value) {
        return (typeof value === 'function')
    }
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
}

dHydra.System = new function () {
    /* Затваря приложението */
    this.Close = function () {
        if (dHydra.IsWindowsFunction('System', 'Close')) {
            window.external.System.Close();
        }
        else {
            throw new ReferenceError(String.Format(_function_is_not_defined, 'Close'));
        }
    }
    /* Отваря форма за съобщения */
    this.ShowMessageBox = function (text, caption) {
        if (dHydra.IsWindowsFunction('System', 'ShowMessageBox')) {
            window.external.System.ShowMessageBox(text, caption);
        }
        else {
            throw new ReferenceError(String.Format(_function_is_not_defined, 'ShowMessageBox'));
        }
    }
    /* Отваря форма за съобщения */
    this.TestArray = function (value) {
        if (dHydra.IsWindowsFunction('System', 'TestArray')) {
            var res = window.external.System.TestArray(value);
            return res.split(',');
        }
        else {
            throw new ReferenceError(String.Format(_function_is_not_defined, 'TestArray'));
        }
    }
}

dHydra.Data = new function () {
    /* Execute JSON command to the database
    */
    this.OpenConnection = function (jsonConnection) {
        if (dHydra.IsWindowsFunction('Data', 'OpenConnection')) {
            return window.external.Data.OpenConnection(jsonConnection);
        }
        else {
            throw new ReferenceError(String.Format(_function_is_not_defined, 'OpenConnection'));
        }
    }
    /* Closes the connection to the database
    */
    this.CloseConnection = function (connectionId) {
        if (dHydra.IsWindowsFunction('Data', 'CloseConnection')) {
            return window.external.Data.CloseConnection(connectionId);
        }
        else {
            throw new ReferenceError(String.Format(_function_is_not_defined, 'CloseConnection'));
        }
    }
    /* Execute JSON command to the database
    */
    this.ExecuteQuery = function (jsonCommand, connectionId) {
        if (dHydra.IsWindowsFunction('Data', 'ExecuteQuery')) {
            return window.external.Data.ExecuteQuery(jsonCommand, connectionId);
        }
        else {
            throw new ReferenceError(String.Format(_function_is_not_defined, 'ExecuteQuery'));
        }
    }
}