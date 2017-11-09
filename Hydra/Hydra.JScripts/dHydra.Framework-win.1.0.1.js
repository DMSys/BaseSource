var dHydraSystemFileReader = new function () {

    this.Open = function (filePath) {
        return window.external.System.FileReader.Open(filePath);
    }
    
    this.ReadLine = function (connectionId) {
        return window.external.System.FileReader.ReadLine(connectionId);
    }

    this.Close = function (connectionId) {
        window.external.System.FileReader.Close(connectionId);
    }
}

var dHydraSystemFileWriter = new function () {

    this.Open = function (filePath) {
        return window.external.System.FileWriter.Open(filePath);
    }

    this.Write = function (connectionId, value) {
        return window.external.System.FileWriter.Write(connectionId, value);
    }

    this.WriteLine = function (connectionId, value) {
        return window.external.System.FileWriter.WriteLine(connectionId, value);
    }

    this.Flush = function (connectionId) {
        window.external.System.FileWriter.Flush(connectionId);
    }

    this.Close = function (connectionId) {
        window.external.System.FileWriter.Close(connectionId);
    }
}

var dHydraData = new function () {
    /* Opens a connection to the database
    */
    this.OpenConnection = function (jsonConnection) {
        return window.external.Data.OpenConnection(jsonConnection);
    }
    /* Closes the connection to the database
    */
    this.CloseConnection = function (connectionId) {
        return window.external.Data.CloseConnection(connectionId);
    }
    /* Execute JSON command to the database
    */
    this.ExecuteQuery = function (jsonCommand, connectionId) {
        return window.external.Data.ExecuteQuery(jsonCommand, connectionId);
    }
}

var dHydraWebApp = new function () {

    /* Задава път до оформлението на страницата / Master page
    */
    this.Layout = function (path) {
        return window.external.WebApp.Layout(path);
    }
}

var dHydraSession = new function () {

    this.Get = function (name, defaultValue) {
        return window.external.Session.Get(name, defaultValue);
    }

    this.Set = function (name, value) {
        window.external.Session.Set(name, value);
    }

    this.Clear = function () {
        window.external.Session.Clear();
    }
}