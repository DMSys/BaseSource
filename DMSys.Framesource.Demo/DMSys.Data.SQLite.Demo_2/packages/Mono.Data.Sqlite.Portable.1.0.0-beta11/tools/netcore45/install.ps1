param($installPath, $toolsPath, $package, $project)

    # Add the SQLite SDK reference
	$sqliteReference = $project.Object.References.AddSDK("SQLite for Windows Runtime", "SQLite.WinRT, version=3.8.4.3")
    Write-Host "Successfully added a reference to the extension SDK SQLite for Windows Runtime."
    Write-Host "Please, verify that the extension SDK SQLite for Windows Runtime v3.8.4.3, from the SQLite.org site (http://www.sqlite.org/2014/sqlite-winrt-3080403.vsix), has been properly installed."

    # This is the global install file
    $rootInstall = [System.IO.Path]::Combine($toolsPath, '../install.ps1')
    $rootToolsPath = [System.IO.Path]::Combine($toolsPath, '../')
    Write-Host $rootInstall
    . $rootInstall -installPath $installPath -toolsPath $rootToolsPath -package $package -project $project
 