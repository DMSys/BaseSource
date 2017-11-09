/* Достъп до Api на Hydra
*/
dHydraStatic = function () { };
/* IO: Begin
*/
dHydraStatic.prototype.IO = function () { };

dHydraStatic.prototype.IO.Path = function () { };
/* Determines whether the specified file exists.
*/
dHydraStatic.prototype.IO.Path.FileExists = function (path) {
    return window.external.IO.Path.FileExists(path);
};
/* Returns the names of files (including their paths) in the specified directory.
*/
dHydraStatic.prototype.IO.Path.GetFiles = function (path) {
    return window.external.IO.Path.GetFiles(path).split(",");
};
/* Copies an existing file to a new file. Overwriting a file of the same name is allowed.
*/
dHydraStatic.prototype.IO.Path.FileCopy = function (sourceFileName, destFileName, overwrite) {
    if (typeof overwrite === "undefined") {
        window.external.IO.Path.FileCopy(sourceFileName, destFileName, true);
    }
    else {
        return window.external.IO.Path.FileCopy(sourceFileName, destFileName, overwrite);
    }    
}
/* Deletes the specified file.
*/
dHydraStatic.prototype.IO.Path.FileDelete = function (path) {
    return window.external.IO.Path.FileDelete(path);
}
/* Moves a specified file to a new location, providing the option to specify a new file name.
*/
dHydraStatic.prototype.IO.Path.FileMove = function (sourceFileName, destFileName) {
    return window.external.IO.Path.FileMove(sourceFileName, destFileName);
}
/* Returns the extension of the specified path string.
*/
dHydraStatic.prototype.IO.Path.GetExtension = function (path) {
    return window.external.IO.Path.GetExtension(path);
}
/* Returns the file name and extension of the specified path string.
*/
dHydraStatic.prototype.IO.Path.GetFileName = function (path) {
    return window.external.IO.Path.GetFileName(path);
}
/* Returns the file name of the specified path string without the extension.
*/
dHydraStatic.prototype.IO.Path.GetFileNameWithoutExtension = function (path) {
    return window.external.IO.Path.GetFileNameWithoutExtension(path);
}

dHydraStatic.prototype.IO.FileReader = function (filePath) {
    var _FilePath = filePath;
    var _ConnectionId = window.external.IO.FileReader.Open(_FilePath);

    this.ReadLine = function () {
        return window.external.IO.FileReader.ReadLine(_ConnectionId);
    }

    this.EndOfFile = function () {
        return window.external.IO.FileReader.EndOfFile(_ConnectionId);
    }

    this.Close = function () {
        window.external.IO.FileReader.Close(_ConnectionId);
    }

    this.GetId = function () {
        return _ConnectionId;
    }

    return this;
};
/* IO: End
*/

/* Създава инстанция на Hydra
*/
var dHydra = new dHydraStatic();


function SystemIO() {
    this.FileWriter = new function () {
        this.Open = function (filePath) {
            return window.external.IO.FileWriter.Open(filePath);
        }
        this.Write = function (connectionId, value) {
            return window.external.IO.FileWriter.Write(connectionId, value);
        }
        this.WriteLine = function (connectionId, value) {
            return window.external.IO.FileWriter.WriteLine(connectionId, value);
        }
        this.Flush = function (connectionId) {
            window.external.IO.FileWriter.Flush(connectionId);
        }
        this.Close = function (connectionId) {
            window.external.IO.FileWriter.Close(connectionId);
        }
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