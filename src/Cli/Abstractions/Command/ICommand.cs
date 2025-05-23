﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// Copied from: https://github.com/dotnet/sdk/blob/4a81a96a9f1bd661592975c8269e078f6e3f18c9/src/Cli/Microsoft.DotNet.Cli.Utils/ICommand.cs
namespace Azure.Functions.Cli.Abstractions.Command
{
    public interface ICommand
    {
        string CommandName { get; }

        string CommandArgs { get; }

        CommandResult Execute();

        ICommand WorkingDirectory(string projectDirectory);

        ICommand EnvironmentVariable(string name, string? value);

        ICommand CaptureStdOut();

        ICommand CaptureStdErr();

        ICommand ForwardStdOut(TextWriter? to = null, bool onlyIfVerbose = false, bool ansiPassThrough = true);

        ICommand ForwardStdErr(TextWriter? to = null, bool onlyIfVerbose = false, bool ansiPassThrough = true);

        ICommand OnOutputLine(Action<string> handler);

        ICommand OnErrorLine(Action<string> handler);

        ICommand SetCommandArgs(string commandArgs);
    }
}
