
var $App = new function () {
    //OpenTabsss: "John",
    //lastName: "Doe",
    /*
    OpenTab: function () {
        return this;
    }
    */
    //console.log('testInit oooo');

    this.testInit = function () {
        //console.log('testInit');
    }
};

var $Camera = {
    /* Take a photo using the camera.
    */
    TakePicture: function () {
        return 'ImageSource';
    }
};

var $Data = {
};

function dHydraIO() {
    var extIO = new SystemIO();

    this.Path = {
        FileExists: function (path) {
            return extIO.Path.FileExists(path);
        },
        FileCopy: function (sourceFileName, destFileName, overwrite) {
            return extIO.Path.FileCopy(sourceFileName, destFileName, overwrite);
        },
        FileDelete: function (path) {
            extIO.Path.FileDelete(path);
        },
        FileMove: function (sourceFileName, destFileName) {
            extIO.Path.FileMove(sourceFileName, destFileName);
        },
        GetExtension: function (path) {
            return extIO.Path.GetExtension(path);
        },
        GetFileName: function (path) {
            return extIO.Path.GetFileName(path);
        },
        GetFileNameWithoutExtension: function (path) {
            return extIO.Path.GetFileNameWithoutExtension(path);
        }
    }
    this.FileReader = {
        Open: function (filePath) {
            return extIO.FileReader.Open(filePath);
        },
        ReadLine: function (connectionId) {
            return extIO.FileReader.ReadLine(connectionId);
        },
        Close: function (connectionId) {
            return extIO.FileReader.Close(connectionId);
        }
    }
    this.FileWriter = {
        Open: function (filePath) {
            return extIO.FileWriter.Open(filePath);
        },
        Write: function (connectionId, value) {
            return extIO.FileWriter.Write(connectionId, value);
        },
        WriteLine: function (connectionId, value) {
            return extIO.FileWriter.WriteLine(connectionId, value);
        },
        Flush: function (connectionId) {
            extIO.FileWriter.Flush(connectionId);
        },
        Close: function (connectionId) {
            extIO.FileWriter.Close(connectionId);
        }
    }
}

var $Platform = {

    Name: dHydraPlatformName(),
    Device: {
        /* Gets the model of the device. For example: "Nexus 5" or "iPhone".
        */
        Model: "iPhone",
        /* Gets the model of the device. For example: "Android" or "iOS".
        */
        OS: "Android",

        /* Gets the OS version. For example: 4.4.4(android), 8.1(ios)
        */
        OSVersion: "8.1",

        /* Gets the OS version. For example: 19(android), 8.1(ios).
        */
        sdkVersion: "8.1",

        /* Gets the type current device. Available values: "phone", "tablet".
        */
        deviceType: "tablet"
    },
    Screen: {
        mainScreen: "ScreenMetrics"
    }
};

function dHydraPlatformName()
{
    return 'android,ios';
}