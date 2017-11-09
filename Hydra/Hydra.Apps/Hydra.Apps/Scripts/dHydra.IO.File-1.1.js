function FileReader(filePath) {

    this.connectionId = dHydraSystemFileReader.Open(filePath);

    this.ReadLine = function () {
        return dHydraSystemFileReader.ReadLine(this.connectionId);
    }

    this.Close = function () {
        return dHydraSystemFileReader.Close(this.connectionId);
    }
}

function FileWriter(filePath) {

    this.connectionId = dHydraSystemFileWriter.Open(filePath);

    this.Write = function (value) {
        return dHydraSystemFileWriter.Write(this.connectionId, value);
    }

    this.WriteLine = function (value) {
        return dHydraSystemFileWriter.WriteLine(this.connectionId, value);
    }

    this.Flush = function () {
        return dHydraSystemFileWriter.Flush(this.connectionId);
    }

    this.Close = function () {
        return dHydraSystemFileWriter.Close(this.connectionId);
    }
}