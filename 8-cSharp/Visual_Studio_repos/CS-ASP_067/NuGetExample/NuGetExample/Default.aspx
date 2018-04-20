<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NuGetExample.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Understanding NuGet</h1>
    <p>NuGet is a package manager.  A package manager:</p>
    <ol>
        <li>Installs all the files necessary to include a third party library or other resource into your project.</li>
        <li>Adds references to the class library files in your project.</li>
        <li>Adds any DEPENDECIES that the target class library needs to do its job.</li>
        <li>Updates the package and its dependencies to the latest version (or to a specific version)</li>
    </ol>

    <p>NuGet specifically:</p>
    <ol>
        <li>Can be run from a special command line to accommodate those coming from a command line world.</li>
        <li>Can be run from a special dialog in visual studio.</li>
    </ol>

    <p>You can find packages along with their commands on <a href="http://www.nuget.org">nuget.org</a></p>
    <p>You could package your class library for inclusion in nuget.org OR for your company (i.e., <a href="https://docs.nuget.org/create/hosting-your-own-nuget-feeds)</p>">host your own nuget feeds</a>).
        
    <p>Commands: <a href="http://docs.nuget.org/consume/command-line-reference">http://docs.nuget.org/consume/command-line-reference</a></p>
        
    <p>No-Commit Workflow: <a href="https://docs.nuget.org/consume/package-restore/msbuild-integrated">https://docs.nuget.org/consume/package-restore/msbuild-integrated</a></p>
    </div>
    </form>
</body>
</html>
